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
    public class clsGestoraCombateDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo que nos devuelve un combate por la id pasada por parametros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsCombate buscarCombatePorId(int id)
        {

            clsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsCombate oCombate = null;

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM combates WHERE idCombate = @id";
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
                    oCombate = new clsCombate();
                    oCombate.idCombate = (int)miLector["idCombate"];
                    oCombate.fecha = ((DateTime)miLector["fechaCombate"]).ToString();
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (oCombate);

        }
        #endregion
    }
}
