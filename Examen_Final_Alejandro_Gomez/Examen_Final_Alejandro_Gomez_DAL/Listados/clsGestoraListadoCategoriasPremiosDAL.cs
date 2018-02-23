using Examen_Final_Alejandro_Gomez_DAL.Conexion;
using Examen_Final_Alejandro_Gomez_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_DAL.Listados
{
    public class clsGestoraListadoCategoriasPremiosDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo que nos devuelve el listado de todas las categoriasPremios
        /// </summary>
        /// <returns></returns>
        public List<clsCategoriaPremio> getListadoCategoriasPremiosDAL()
        {
            clsMyConnection miConexion;

            List<clsCategoriaPremio> listado = new List<clsCategoriaPremio>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsCategoriaPremio oCategoriaPremio;

            SqlConnection conexion;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM categoriasPremios";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCategoriaPremio = new clsCategoriaPremio();
                        oCategoriaPremio.idCategoriaPremio = (int)miLector["idCategoriaPremio"];
                        oCategoriaPremio.nombreCategoriaPremio = (string)miLector["nombreCategoriaPremio"];
                        listado.Add(oCategoriaPremio);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (listado);
        }


        #endregion
    }
}
