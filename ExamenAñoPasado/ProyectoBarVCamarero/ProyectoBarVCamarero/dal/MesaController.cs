using Newtonsoft.Json;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.dal
{
    public class MesaController
    {

        #region Builder
        public MesaController()
        {

        }
        #endregion


        #region Functions
        /// <summary>
        /// Metodo que recoge todas las mesas
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Mesa>> getMesas()
        {
            String url = "http://dleal.ciclo.iesnervion.es/Mesa";
            Uri uri = new Uri(url);
            ObservableCollection<Mesa> lista = new ObservableCollection<Mesa>();


            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
      new AuthenticationHeaderValue("Basic",
                                    Convert.ToBase64String(
                                     System.Text.ASCIIEncoding.ASCII.GetBytes(
                                         string.Format("{0}:{1}", "admin", "admin"))));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



           
                string respuesta = await httpClient.GetStringAsync(uri);
                httpClient.Dispose();
                lista = JsonConvert.DeserializeObject<ObservableCollection<Mesa>>(respuesta);


            

            return lista;
        }

        /// <summary>
        ///  Metodo que edita una mesa 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> editMesa(Mesa m)
        {
            String url = "http://dleal.ciclo.iesnervion.es/Mesa/" + m.Nummesa;
            Uri uri = new Uri(url);
            string postBody = JsonConvert.SerializeObject(m);
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic",
                                               Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                    string.Format("{0}:{1}", "admin", "admin"))));



            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await httpClient.PutAsync(uri, new StringContent(postBody));
            String resultado = await res.Content.ReadAsStringAsync();
            return res;

        }


        /// <summary>
        ///  Metodo que añade una mesa 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> postMesa(Mesa m)
        {
            bool añadido = false;
            String url = "http://dleal.ciclo.iesnervion.es/Mesa";
            Uri uri = new Uri(url);
            string postBody = JsonConvert.SerializeObject(m);
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic",
                                               Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                    string.Format("{0}:{1}", "admin", "admin"))));



            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await httpClient.PostAsync(uri, new StringContent(postBody));
            String resultado = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode) añadido = true;
            return añadido;

        }



        /// <summary>
        /// Metodo que elimina una mesa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> deleteMesa(int id)
        {
            bool eliminado = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Mesa/" + id;
            Uri uri = new Uri(url);

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic",
                                               Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                    string.Format("{0}:{1}", "admin", "admin"))));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            res = await httpClient.DeleteAsync(uri);
            String resultado = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode) eliminado = true;
            return eliminado;
        }
        #endregion
    }
}
