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
    public class clsListadoDepartamentosDAL
    {
        public List<clsDepartamento> getListadoDepartamentosDAL()
        {
            clsMyConnection miConexion;

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsDepartamento departamento;

            SqlConnection conexion;


            miConexion = new clsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM departamentos";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new clsDepartamento();
                        departamento.idDepartamento = (int)miLector["ID"];
                        departamento.nombre = (string)miLector["Nombre"];
                        listadoDepartamentos.Add(departamento);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (listadoDepartamentos);
        }
    }
}