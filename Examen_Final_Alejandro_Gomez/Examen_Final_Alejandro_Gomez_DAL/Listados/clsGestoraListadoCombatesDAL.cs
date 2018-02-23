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
    public class clsGestoraListadoCombatesDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo que nos devuelve el listado de todos los combates
        /// </summary>
        /// <returns></returns>
        public List<clsCombate> getListadoCombatesDAL()
        {
            clsMyConnection miConexion;

            List<clsCombate> listado = new List<clsCombate>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsCombate oCombate;

            SqlConnection conexion;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM combates";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCombate = new clsCombate();
                        oCombate.idCombate = (int)miLector["idCombate"];
                        oCombate.fecha = ((DateTime)miLector["fechaCombate"]).ToString();
                        listado.Add(oCombate);
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
