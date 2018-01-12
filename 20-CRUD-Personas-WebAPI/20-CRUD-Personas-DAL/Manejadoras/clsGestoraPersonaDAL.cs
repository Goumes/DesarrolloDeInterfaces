using _20_CRUD_Personas_DAL.Conexion;
using _20_CRUD_Personas_ET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUD_Personas_DAL.Manejadoras
{
    public class clsGestoraPersonaDAL
    {

        //clsListadoPersonasDAL clsListadoPersonasDAL;

        #region Metodos
        public clsPersona buscarPersonaPorId(int id)
        {

            clsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona oPersona = null;

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM personas WHERE IDPersona = @id";
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
                    oPersona = new clsPersona();
                    oPersona.idPersona = (int)miLector["IDPersona"];
                    oPersona.nombre = (string)miLector["nombre"];
                    oPersona.apellidos = (string)miLector["apellidos"];
                    oPersona.fechaNac = (DateTime)miLector["fechaNac"];
                    oPersona.direccion = (string)miLector["direccion"];
                    oPersona.telefono = (string)miLector["telefono"];
                    oPersona.idDepartamento = (int)miLector["idDepartamento"];
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (oPersona);

        }

        public async Task<bool> updatePersonaDAL(clsPersona persona)
        {
            clsMyConnection miConexion;
            HttpResponseMessage respuesta;
            StringContent queryString;
            String personaSerializada;
            personaSerializada = JsonConvert.SerializeObject(persona);
            queryString = new StringContent(personaSerializada, Encoding.UTF8, "application/json");


            HttpClient httpClient = new HttpClient();
            miConexion = new clsMyConnection();


            try
            {
                respuesta = await httpClient.PutAsync(miConexion.miUri + "/"+persona.idPersona, queryString);
            }

            catch (Exception exSql)
            {
                throw exSql;
            }

            return respuesta.IsSuccessStatusCode;
        }

        public async Task<bool> deletePersona(int id)
        {
            clsMyConnection miConexion;
            HttpResponseMessage respuesta;

            HttpClient httpClient = new HttpClient();
            miConexion = new clsMyConnection();

            try
            {
                respuesta = await httpClient.DeleteAsync(miConexion.miUri + "/"+ id);
            }

            catch (Exception exSql)
            {
                throw exSql;
            }


            return respuesta.IsSuccessStatusCode;
        }

        public async Task<bool> addPersonaDAL(clsPersona persona)
        {
            clsMyConnection miConexion;
            HttpResponseMessage respuesta;
            StringContent queryString;
            String personaSerializada;
            personaSerializada = JsonConvert.SerializeObject(persona);
            queryString = new StringContent(personaSerializada, Encoding.UTF8, "application/json");


            HttpClient httpClient = new HttpClient();
            miConexion = new clsMyConnection();


            try
            {
                respuesta = await httpClient.PostAsync (miConexion.miUri, queryString);
            }

            catch (Exception exSql)
            {
                throw exSql;
            }

            return respuesta.IsSuccessStatusCode;
        }

        #endregion
    }
}
