using _09_CRUD_Personas_DAL.Conexion;
using Examen_AlejandroGomez_Sistemas___ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___DAL.Manejadoras
{
    public class clsManejadoraAlumnosDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo dedicado a buscar un alumno en la base de datos con el id recibido por parametros
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El alumno selecionado</returns>
        public clsAlumno buscarAlumnoPorId (int id)
        {
            clsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsAlumno alumno = null;

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Alumnos WHERE idAlumno = @id";
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
                    alumno = new clsAlumno();
                    alumno.idAlumno = (int)miLector["idAlumno"];
                    alumno.nombreAlumno = (string)miLector["nombreAlumno"];
                    alumno.apellidosAlumno = (string)miLector["apellidosAlumno"];
                    alumno.idCurso = (int)miLector["idCurso"];
                    //alumno.beca = miLector.GetDecimal(4);
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return alumno;
        }

        /// <summary>
        /// Metodo dedicado a asignarle la beca a un alumno.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beca"></param>
        /// <returns></returns>
        ///
        public int asignarBeca (int id, decimal beca)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection miConexion = new clsMyConnection(); ;
            int resultado = 0;
            miComando.CommandText = "UPDATE Alumnos SET beca = @beca WHERE idAlumno = @idAlumno";
            miComando.Parameters.Add("@beca", System.Data.SqlDbType.Int).Value = beca;
            miComando.Parameters.Add("@idAlumno", System.Data.SqlDbType.Int).Value = id;

            try
            {
                conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }


            return resultado;
        }
        #endregion
    }
}
