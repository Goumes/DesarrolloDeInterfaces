using Examen_Final_Alejandro_Gomez_DAL.Conexion;
using Examen_Final_Alejandro_Gomez_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_DAL.Manejadoras
{
    public class clsGestoraLuchadorDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo que nos devuelve un luchador por la id pasada por parametros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsLuchador buscarLuchadorPorId(int id)
        {

            clsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsLuchador oLuchador = null;

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM luchadores WHERE idLuchador = @id";
                parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = id;
                miComando.Parameters.Add(parameter);


                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();
                    oLuchador = new clsLuchador();
                    oLuchador.idLuchador = (int)miLector["idLuchador"];
                    oLuchador.nombreLuchador = (string)miLector["nombreLuchador"];
                    oLuchador.idCasa = (int)miLector["idCasa"];
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (oLuchador);

        }
        #endregion
    }
}
