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
    public class clsListadoCursosDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo dedicado a conectarse a la base de datos y recoger en una lista todos los cursos
        /// </summary>
        /// <returns>Lista de cursos rellena</returns>
        public List<clsCurso> getListadoCursosDAL ()
        {
            List<clsCurso> lista = new List<clsCurso>();

            clsMyConnection miConexion;

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsCurso oCurso;

            SqlConnection conexion;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM Cursos";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oCurso = new clsCurso();
                        oCurso.idCurso = (int)miLector["idCurso"];
                        oCurso.nombreCurso = (string)miLector["nombreCurso"];
                        lista.Add(oCurso);
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
