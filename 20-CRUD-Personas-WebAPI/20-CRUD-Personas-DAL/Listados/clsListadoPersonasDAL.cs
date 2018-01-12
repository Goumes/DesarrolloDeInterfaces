using _20_CRUD_Personas_DAL.Conexion;
using _20_CRUD_Personas_ET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace _20_CRUD_Personas_DAL.Listados
{
    public class clsListadoPersonasDAL
    {
        #region Metodos
        /// <summary>
        /// Funcion que nos devuelve un listado  de personas.
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<clsPersona>> getListadoPersonasDAL()
        {
            clsMyConnection miConexion;
            ObservableCollection<clsPersona> listadoPersonas;
            String resultado;

            HttpClient httpClient = new HttpClient();
            miConexion = new clsMyConnection();
            listadoPersonas = new ObservableCollection<clsPersona>();

            try
            {
                resultado = await httpClient.GetStringAsync(miConexion.miUri);
                listadoPersonas = JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(resultado);
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
