using Examen_Final_Alejandro_Gomez_DAL.Conexion;
using Examen_Final_Alejandro_Gomez_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_DAL.Manejadoras
{
    public class clsGestoraClasificacionCombateDAL
    {
        #region Metodos
        public int insertClasificacionCombateDAL(clsClasificacionCombate oClasificacionCombate)
        {
            int resultado = 0;

            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            clsMyConnection miConexion = new clsMyConnection(); ;
            miComando.CommandText = "INSERT INTO clasificacionComabate(idCombate, puntos, idCategoriaPremio, idLuchador) VALUES(@idCombate, @puntos, @idCategoriaPremio, @idLuchador))";
            miComando.Parameters.Add("@idCombate", System.Data.SqlDbType.Int).Value = oClasificacionCombate.idCombate;
            miComando.Parameters.Add("@puntos", System.Data.SqlDbType.Int).Value = oClasificacionCombate.puntos;
            miComando.Parameters.Add("@idCategoriaPremio", System.Data.SqlDbType.Int).Value = oClasificacionCombate.idCategoriaPremio;
            miComando.Parameters.Add("@idLuchador", System.Data.SqlDbType.Int).Value = oClasificacionCombate.idLuchador;


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
        #endregion
    }
}
