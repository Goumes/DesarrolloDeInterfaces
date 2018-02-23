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
    public class clsGestoraListadoCasasDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo que nos devuelve el listado de todas las casas
        /// </summary>
        /// <returns></returns>
        public List<clsCasa> getListadoCasasDAL()
        {
            clsMyConnection miConexion;

            List<clsCasa> listado = new List<clsCasa>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsCasa oCasa;

            SqlConnection conexion;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM casas";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCasa = new clsCasa();
                        oCasa.idCasa = (int)miLector["idCasa"];
                        oCasa.nombreCasa = (string)miLector["nombreCasa"];
                        listado.Add(oCasa);
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
