using _18_WPFPersonas_Ent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _18_WPFPersonas_DAL
{
    public class clsManejadoraPersonaDAL
    {
        clsMyConnection miConexion;

        public clsManejadoraPersonaDAL()
        {
            miConexion = new clsMyConnection();
        }

        /// <summary>
        /// El metodo obtiene una persona por parametros, e intenta introducirlo en la bbdd,
        ///     si todo va correcto retornará un entero (0 o 1) con el numero de filas afectadas en la bbdd,
        ///     si algo falla en la conexion saltará una excepcion sql.
        ///     Retornara 1 en el caso de que hubiera insertado una fila en la bbdd
        ///     "       " 0 en el caso de que no insertara nada.
        /// </summary>
        /// <param name="persona">Objeto persona que hace refencia a la persona para insertar</param>
        /// <returns>Retornara un entero con el numero de filas afectadas en la bbdd :
        ///         1 en el caso de que hubiera insertado una fila en la bbdd
        ///         0 en el caso de que no insertara nada.
        /// </returns>
        public int insertPersona(clsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion= new SqlConnection() ;
            SqlCommand comando;
           

            try
            {
                conexion = miConexion.getConnection();
                comando = new SqlCommand();

                //Añadimos los parametros
                comando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
                comando.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellido;
                comando.Parameters.Add("@FechaNac", System.Data.SqlDbType.VarChar).Value = persona.fechaNac;
                comando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
                comando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

                //Comando Sql
                comando.CommandText = "Insert Into personas (" + ColumnasConstantes.@colNombre + ", " + ColumnasConstantes.@colApellidos + "," +
                    ColumnasConstantes.@colFechaNac + "," + ColumnasConstantes.@colDireccion + "," + ColumnasConstantes.@colTelefono + ")"+
                        "Values (@Nombre, @Apellidos,@FechaNac,@Direccion,@Telefono)";
                comando.Connection = conexion;
                resultado = comando.ExecuteNonQuery();


            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                conexion.Close();
            }

            

            return resultado;
        }


        /// <summary>
        ///     Este metodo obtiene una persona por parametros, intentara actualizar una persona de la bbdd segun su id
        ///         si todo va correcto, y hay alguna persona con esa id en la bbdd lo actualizará (y retornara 1)
        ///         ,si no hay ninguna persona con esa id en la bbdd no actualizará nada (y retornara 0),
        ///         si hay algun fallo con la bbdd saltará una excepcion.
        /// </summary>
        /// <param name="id">entero que hace referencia a la id de una persona </param>
        /// <returns> retornará un entero con el numero de filas afectadas en la bbdd
        ///           " 1 en el caso de que hubiera actualizado una persona en la bbdd
        ///           " 0 en el caso de que no hubiera actualizado nada.
        /// </returns>
        public int updatePersona(clsPersona persona)
        {
            int resultado=0;
            

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando;


            try
            {
                conexion = miConexion.getConnection();
                comando = new SqlCommand();

                //Añadimos los parametros
                comando.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = persona.id;
                comando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
                comando.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellido;
                comando.Parameters.Add("@FechaNac", System.Data.SqlDbType.VarChar).Value = persona.fechaNac;
                comando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
                comando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

                //Comando Sql
                comando.CommandText = "Update Personas set " + ColumnasConstantes.colNombre +
                                            "=@Nombre, " + ColumnasConstantes.colApellidos +
                                            "=@Apellidos, " + ColumnasConstantes.colFechaNac +
                                            "=@FechaNac, " + ColumnasConstantes.colDireccion +
                                            "=@Direccion, " + ColumnasConstantes.colTelefono +
                                            "=@Telefono where IDPersona="+persona.id;
                comando.Connection = conexion;
                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

                return resultado;
        }
        /// <summary>
        ///     Obtiene una id por parametros, buscará una persona en la bbdd con ese id, si lo encuentra devolvera esa persona
        ///         si no devolvera una persona vacía, saltará excepcion de sql en caso de algun fallo con la conexion.
        /// </summary>
        /// <param name="id">entero que hace referencia a la id de la persona </param>
        /// <returns>retornara una persona, si todo es correcto una persona de la bbdd segun su id,
        ///         si no hay ninguna persona con esa id retornará una persona vacia.</returns>
        public clsPersona getPersona(int id)
        {
            clsPersona persona = new clsPersona();


            clsMyConnection myconexion = new clsMyConnection();


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            
            SqlDataReader lector = null;
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value=id;
            try
            {
                conexion = myconexion.getConnection();

                comando.CommandText = "select * from personas where IDPersona = @id";
                comando.Connection = conexion;
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        
                        persona.id = (int)lector[ColumnasConstantes.colId];
                        persona.nombre = (String)lector[ColumnasConstantes.colNombre];
                        persona.apellido = (String)lector[ColumnasConstantes.colApellidos];
                        persona.fechaNac = (DateTime)lector[ColumnasConstantes.colFechaNac];
                        persona.direccion = (String)lector[ColumnasConstantes.colDireccion];
                        persona.telefono = (String)lector[ColumnasConstantes.colTelefono];
                        
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (lector != null)
                {
                    lector.Close();
                }
                myconexion.closeConnection(ref conexion);
            }
            return persona;
        }

        
        /// <summary>
        ///  Intetara borrar a una persona de la bbdd segun la id que nos envien, devolverá un entero con el num. de filas
        ///     afectadas (1 o 0), si algo falla en la conexion Saltará una excepcion sql.
        /// </summary>
        /// <param name="id">entero id que hace referencia a la id de la persona a borrar</param>
        /// <returns>retorna un entero con el numero de filas afectadas en la bbdd,
        ///             si todo va bien retornará 1 (que ha borrado a una persona),
        ///             si no ha encontrado a la persona retornara 0,
        ///</returns>
        public int deletePerson(int id)
        {
            int resultado = 0;

            clsMyConnection myconexion = new clsMyConnection();


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = miConexion.getConnection();
                comando = new SqlCommand();


                //Comando Sql
                comando.CommandText = "Delete from personas Where IDPersona = "+id;
                comando.Connection = conexion;

                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return resultado;


            
        }

         
    }

}