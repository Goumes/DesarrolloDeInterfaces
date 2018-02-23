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
    public class clsGestoraListadoLuchadoresDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo que nos devuelve el listado de todos los luchadores
        /// </summary>
        /// <returns></returns>
        public List<clsLuchador> getListadoLuchadoresDAL()
        {
            clsMyConnection miConexion;

            List<clsLuchador> listado = new List<clsLuchador>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsLuchador oLuchador;

            SqlConnection conexion;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM luchadores";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oLuchador = new clsLuchador();
                        oLuchador.idLuchador = (int)miLector["idLuchador"];
                        oLuchador.nombreLuchador = (string)miLector["nombreLuchador"];
                        oLuchador.idCasa = (int)miLector["idCasa"];
                        listado.Add(oLuchador);
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

        /// <summary>
        /// Metodo que nos devuelve el listado de todos los luchadores menos uno
        /// </summary>
        /// <returns></returns>
        public List<clsLuchador> getListadoLuchadoresMenosUnoDAL(int id)
        {
            clsMyConnection miConexion;

            List<clsLuchador> listado = new List<clsLuchador>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsLuchador oLuchador;

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM luchadores WHERE idLuchador NOT LIKE @idLuchador";
                parameter = new SqlParameter();
                parameter.ParameterName = "@idLuchador";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = id;
                miComando.Parameters.Add(parameter);

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oLuchador = new clsLuchador();
                        oLuchador.idLuchador = (int)miLector["idLuchador"];
                        oLuchador.nombreLuchador = (string)miLector["nombreLuchador"];
                        oLuchador.idCasa = (int)miLector["idCasa"];
                        listado.Add(oLuchador);
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
