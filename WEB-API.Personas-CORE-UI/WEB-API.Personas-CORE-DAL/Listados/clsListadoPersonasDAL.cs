using _20_CRUD_Personas_ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_API.Personas_CORE_DAL.Conexion;

namespace WEB_API.Personas_CORE_DAL.Listados
{
	public class clsListadoPersonasDAL
	{
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

        public int updatePersonaDAL(clsPersona persona)
        {

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection miConexion = new clsMyConnection(); ;
            int resultado = 0;
            miComando.CommandText = "UPDATE personas SET nombre=@nombre, apellidos=@apellidos, fechaNac=@fechaNac, direccion=@direccion, telefono=@telefono, idDepartamento=@idDepartamento WHERE IDPersona = @idPersona";
            miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = persona.idPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.fechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.idDepartamento;

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

        public int deletePersona(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection miConexion = new clsMyConnection(); ;
            int resultado = 0;
            miComando.CommandText = "DELETE FROM personas WHERE IDPersona = @idPersona";
            miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = id;

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

        public int addPersonaDAL(clsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection miConexion = new clsMyConnection(); ;
            miComando.CommandText = "INSERT INTO personas (nombre, apellidos, fechaNac, direccion, telefono, idDepartamento) VALUES (@nombre, @apellidos, @fechaNac, @direccion, @telefono, @idDepartamento)";
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.fechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = 2;


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
    }
}
