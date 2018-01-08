using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_API_Ejemplo_DAL.Conexion;
using Web_API_Ejemplo_Entidades;

namespace Web_API_Ejemplo_DAL.Listado
{
	public class clsListadoPersonasDAL
	{
		public ObservableCollection<clsPersona> obtenerListadoPersonasDAL()
		{
			ObservableCollection<clsPersona> listadoPersonas = new ObservableCollection<clsPersona>();

			//CREO UN OBJETO DE clsMyConnnection PARA CONECTARME CON LA BBDD
			clsMyConnection miConexion = new clsMyConnection();

			//DECLARO LA VARIABLE DE SQLCONNNECTION
			SqlConnection conexion;
			SqlCommand miComando = new SqlCommand();
			SqlDataReader miLector;
			clsPersona oPersona;

			try
			{
				conexion = miConexion.getConnection();
				miComando.CommandText = "SELECT * FROM personas";
				miComando.Connection = conexion;
				miLector = miComando.ExecuteReader();

				if (miLector.HasRows)
				{
					while (miLector.Read())
					{
						oPersona = new clsPersona();
						oPersona.idPersona = (int)miLector["id"];
						oPersona.nombre = (string)miLector["nombre"];
						oPersona.apellidos = (string)miLector["apellidos"];
						oPersona.direccion = (string)miLector["direccion"];
						oPersona.telefono = (string)miLector["telefono"];
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


		public clsPersona editarPersona(int id)
		{
			clsPersona personaEditar = new clsPersona(id, "", "", "", "");

			//CREO UN OBJETO DE clsMyConnnection PARA CONECTARME CON LA BBDD
			clsMyConnection miConexion = new clsMyConnection();

			//DECLARO LA VARIABLE DE SQLCONNNECTION
			SqlConnection conexion;
			SqlCommand miComando = new SqlCommand();
			SqlDataReader miLector;

			try
			{
				conexion = miConexion.getConnection();

				miComando.CommandText = "SELECT * FROM personas WHERE id = @id";

				SqlParameter param;
				param = new SqlParameter();
				param.ParameterName = "@id";
				param.SqlDbType = System.Data.SqlDbType.Int;
				param.Value = id;

				miComando.Parameters.Add(param);
				miComando.Connection = conexion;
				miLector = miComando.ExecuteReader();

				if (miLector.HasRows)
				{
					while (miLector.Read())
					{
						personaEditar.idPersona = (int)miLector["id"];
						personaEditar.nombre = (string)miLector["nombre"];
						personaEditar.apellidos = (string)miLector["apellidos"];
						personaEditar.direccion = (string)miLector["direccion"];
						personaEditar.telefono = (string)miLector["telefono"];
					}
				}

				miLector.Close();
				miConexion.closeConnection(ref conexion);
			}
			catch (SqlException exSql)
			{
				throw exSql;
			}

			return (personaEditar);
		}

		public int guardarPersonaEditada(clsPersona persona)
		{

			//CREO UN OBJETO DE clsMyConnnection PARA CONECTARME CON LA BBDD
			clsMyConnection miConexion = new clsMyConnection();

			//DECLARO LA VARIABLE DE SQLCONNNECTION
			SqlConnection conexion;
			SqlCommand miComando = new SqlCommand();
			int resultado;
			try
			{
				conexion = miConexion.getConnection();

				miComando.CommandText = "UPDATE personas SET nombre=@nombre, apellidos=@apellidos, direccion=@direccion, telefono=@telefono WHERE id=@id";

				miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
				miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
				miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
				miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
				miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

				miComando.Connection = conexion;
				resultado = miComando.ExecuteNonQuery();

				miConexion.closeConnection(ref conexion);
			}
			catch (SqlException exSql)
			{
				throw exSql;
			}

			return (resultado);
		}

		public int eliminarPersona(int id)
		{

			//CREO UN OBJETO DE clsMyConnnection PARA CONECTARME CON LA BBDD
			clsMyConnection miConexion = new clsMyConnection();

			//DECLARO LA VARIABLE DE SQLCONNNECTION
			SqlConnection conexion;
			SqlCommand miComando = new SqlCommand();
			int resultado;
			try
			{
				conexion = miConexion.getConnection();

				miComando.CommandText = "DELETE FROM personas WHERE id=@id";

				miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

				miComando.Connection = conexion;
				resultado = miComando.ExecuteNonQuery();

				miConexion.closeConnection(ref conexion);
			}
			catch (SqlException exSql)
			{
				throw exSql;
			}

			return (resultado);
		}

		public int crearPersona(clsPersona persona)
		{

			//CREO UN OBJETO DE clsMyConnnection PARA CONECTARME CON LA BBDD
			clsMyConnection miConexion = new clsMyConnection();

			//DECLARO LA VARIABLE DE SQLCONNNECTION
			SqlConnection conexion;
			SqlCommand miComando = new SqlCommand();
			int resultado;
			try
			{
				conexion = miConexion.getConnection();

				miComando.CommandText = "INSERT INTO personas (nombre, apellidos, direccion, telefono) VALUES (@nombre, @apellidos, @direccion, @telefono)";

				miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
				miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
				miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
				miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

				miComando.Connection = conexion;
				resultado = miComando.ExecuteNonQuery();
				miConexion.closeConnection(ref conexion);
			}
			catch (SqlException exSql)
			{
				throw exSql;
			}

			return (resultado);
		}
	}
}
