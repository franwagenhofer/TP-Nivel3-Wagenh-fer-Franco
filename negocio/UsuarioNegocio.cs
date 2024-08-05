using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class UsuarioNegocio
    {

        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void actualizar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set urlImagenPerfil = @imagen, nombre = @nombre, apellido = @apellido Where Id = @id");
                datos.setearParametro("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Login(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS Where email = @email And pass = @pass");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["id"];
                    user.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool EmailYaRegistrado(string email)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select count(*) from Users where email = @email");
                datos.setearParametro("@email", email);

                int count = (int)datos.ejecutarEscalar(); 
                return count > 0; 
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void GuardarFavorito(int IdUser, int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Favoritos (IdUser, IdArticulo) VALUES (@IdUser, @IdArticulo)");
                datos.setearParametro("@IdUser", IdUser);
                datos.setearParametro("@IdArticulo", IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> ObtenerFavoritos(int IdUser)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT a.Id, a.Nombre, a.Descripcion, a.Codigo, a.ImagenUrl, a.Precio, a.IdMarca, m.Descripcion as MarcaDescripcion, a.IdCategoria, c.Descripcion as CategoriaDescripcion FROM ARTICULOS a INNER JOIN FAVORITOS f ON a.Id = f.IdArticulo LEFT JOIN Marcas m ON a.IdMarca = m.Id LEFT JOIN Categorias c ON a.IdCategoria = c.Id WHERE f.IdUser = @IdUser");
                datos.setearParametro("@IdUser", IdUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        articulo.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    articulo.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                    {
                        articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                        articulo.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];
                    }

                    articulo.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                    {
                        articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        articulo.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];
                    }

                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarFavorito(int IdUser, int IdArticulo)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete from FAVORITOS where IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametro("@IdUser", IdUser);
                datos.setearParametro("@IdArticulo", IdArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
