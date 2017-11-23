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
    public class CategoriaController
    {
        #region Builder
        public CategoriaController()
        {

        }
        #endregion


        #region Functions


        /// <summary>
        ///  Metodo que recoge todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Categoria>> getCategorias()
        {
            String url = "http://dleal.ciclo.iesnervion.es/Categoria";
            Uri uri = new Uri(url);
            ObservableCollection<Categoria> lista = new ObservableCollection<Categoria>();


            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
      new AuthenticationHeaderValue("Basic",
                                    Convert.ToBase64String(
                                     System.Text.ASCIIEncoding.ASCII.GetBytes(
                                         string.Format("{0}:{1}", "admin", "admin"))));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                string respuesta = await httpClient.GetStringAsync(uri);
                httpClient.Dispose();
                lista = JsonConvert.DeserializeObject<ObservableCollection<Categoria>>(respuesta);


            }
            catch (Exception)
            {

            }

            return lista;
        }



        /// <summary>
        ///  Metodo que edita un producto 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> editCategoria(Categoria c)
        {
            bool correcto = false;
            String url = "http://dleal.ciclo.iesnervion.es/Categoria/" + c.idCategoria;
            Uri uri = new Uri(url);
            string postBody = JsonConvert.SerializeObject(c);
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic",
                                               Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                    string.Format("{0}:{1}", "admin", "admin"))));



            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await httpClient.PutAsync(uri, new StringContent(postBody));
            String resultado = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
                correcto = true;

            return correcto;

        }

        /// <summary>
        ///  Metodo que añade un producto 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> addCategoria(Categoria c)
        {
            bool correcto = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Categoria";
            Uri uri = new Uri(url);
            string postBody = JsonConvert.SerializeObject(c);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic",
                                               Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                    string.Format("{0}:{1}", "admin", "admin"))));

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            res = await httpClient.PostAsync(uri, new StringContent(postBody));
            String resultado = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
                correcto = true;
            return correcto;

        }
        /// <summary>
        /// Metodo que elimina un producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> deleteCategoria(int id)
        {
            bool borradocorrecto = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Categoria/" + id;
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
            if (res.IsSuccessStatusCode) borradocorrecto = true;
            return borradocorrecto;
        }
        #endregion

    }
}
