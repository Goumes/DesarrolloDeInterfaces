using _09_CRUD_Personas_DAL.Conexion;
using Examen_AlejandroGomez_Sistemas___ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___DAL.Listados
{
    public class clsListadoAlumnosDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo dedicado a buscar en la base de datos todos los alumnos dependiendo del curso que recibe por parametros
        /// </summary>
        /// <returns>Una lista de alumnos rellena</returns>
        public List<clsAlumno> getListadoAlumnosPorCursoDAL (int idCurso)
        {
            List<clsAlumno> lista = new List<clsAlumno>();


            clsMyConnection miConexion;

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsAlumno oAlumno;

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Alumnos WHERE idCurso = @idCurso";
                parameter = new SqlParameter();
                parameter.ParameterName = "@idCurso";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = idCurso;
                miComando.Parameters.Add(parameter);

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oAlumno = new clsAlumno();
                        oAlumno.idAlumno = (int)miLector["idAlumno"];
                        oAlumno.apellidosAlumno = (string)miLector["apellidosAlumno"];
                        oAlumno.nombreAlumno = (string)miLector["nombreAlumno"];
                        oAlumno.idCurso = (int)miLector["idCurso"];
                        //oAlumno.beca = (int)miLector["beca"];
                        //oAlumno.beca = miLector.GetDecimal(4);
                        lista.Add(oAlumno);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (lista);
        }
        #endregion
    }
}
