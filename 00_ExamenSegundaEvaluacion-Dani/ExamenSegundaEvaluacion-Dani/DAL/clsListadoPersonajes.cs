using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace ExamenSegundaEvaluacion_Dani.DAL
{
    public class clsListadoPersonajes
    {
        private Uri uri = new Uri("http://localhost:2461/api/personajes");

        public clsListadoPersonajes()
        {

        }


        /// <summary>
        ///  Metodo que recoge todas las personas, con o sin parametros de busqueda
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<clsPersonaje>> getPersonajes(String textoaBuscar = null)
        {
            ObservableCollection<clsPersonaje> lista = new ObservableCollection<clsPersonaje>();
            HttpBaseProtocolFilter filtro = new HttpBaseProtocolFilter();
            filtro.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            filtro.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            HttpClient mihttpClient = new HttpClient(filtro);

            try
            {
                string respuesta = await mihttpClient.GetStringAsync(uri);
                mihttpClient.Dispose();
                lista = JsonConvert.DeserializeObject<ObservableCollection<clsPersonaje>>(respuesta);

             
            }
            catch (Exception)
            {

            }

            return lista;
        }


    }
}
