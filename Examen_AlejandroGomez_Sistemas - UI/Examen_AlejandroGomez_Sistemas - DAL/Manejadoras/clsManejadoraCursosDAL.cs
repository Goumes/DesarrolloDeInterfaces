using _09_CRUD_Personas_DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___DAL.Manejadoras
{
    public class clsManejadoraCursosDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo dedicado a buscar el nombre de un curso recibiendo la id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Nombre del curso</returns>
        public string buscarNombreCursoPorIdDAL(int id)
        {
            clsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            string nombreCurso = "";

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT nombreCurso FROM Cursos WHERE idCurso = @id";
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
                    nombreCurso = (string)miLector["nombreCurso"];
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return nombreCurso;
        }
        #endregion
    }
}
