using _20_CRUD_Personas_DAL.Conexion;
using _20_CRUD_Personas_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUD_Personas_DAL.Manejadoras
{
    public class clsGestoraDepartamentoDAL
    {
        public clsDepartamento buscarDepartamentoPorID(int id)
        {

            clsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsDepartamento oDepartamento = null;

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM departamentos WHERE ID = @id";
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
                    oDepartamento = new clsDepartamento();
                    oDepartamento.idDepartamento = (int)miLector["ID"];
                    oDepartamento.nombre = (string)miLector["nombre"];
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (oDepartamento);

        }

        public clsDepartamento buscarDepartamentoPorNombre(String nombre)
        {

            clsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsDepartamento oDepartamento = null;

            SqlConnection conexion;

            SqlParameter parameter;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM departamentos WHERE nombre = @nombre";
                parameter = new SqlParameter();
                parameter.ParameterName = "@nombre";
                parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                parameter.Value = nombre;
                miComando.Parameters.Add(parameter);


                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();
                    oDepartamento = new clsDepartamento();
                    oDepartamento.idDepartamento = (int)miLector["ID"];
                    oDepartamento.nombre = (string)miLector["nombre"];
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (oDepartamento);

        }
    }
}
