using _20_CRUD_Personas_DAL.Conexion;
using _20_CRUD_Personas_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUD_Personas_DAL.Listados
{
    public class clsListadoPersonasDAL
    {
        #region Metodos
        /// <summary>
        /// Funcion que nos devuelve un listado  de personas.
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> getListadoPersonasDAL()
        {
            clsMyConnection miConexion;

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona oPersona;

            SqlConnection conexion;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.idPersona = (int)miLector["IDPersona"];
                        oPersona.nombre = (string)miLector["nombre"];
                        oPersona.apellidos = (string)miLector["apellidos"];
                        oPersona.fechaNac = (DateTime)miLector["fechaNac"];
                        oPersona.direccion = (string)miLector["direccion"];
                        oPersona.telefono = (string)miLector["telefono"];
                        oPersona.idDepartamento = (int)miLector["idDepartamento"];
                        listadoPersonas.Add(oPersona);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (listadoPersonas);
        }

       
        #endregion
    }
}
