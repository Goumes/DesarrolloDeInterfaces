using Newtonsoft.Json;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.dal
{
    public class ProductoController
    {
        

        #region Builder
        public ProductoController()
        {

        }
        #endregion


        #region Functions


        /// <summary>
        ///  Metodo que recoge todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Producto>> getProductos()
        {
            String url = "http://dleal.ciclo.iesnervion.es/Producto";
            Uri uri = new Uri(url);
            ObservableCollection<Producto> lista = new ObservableCollection<Producto>();


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
                lista = JsonConvert.DeserializeObject<ObservableCollection<Producto>>(respuesta);

                
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
        public async Task<bool> editProduct(Producto p)
        {
            bool correcto = false;
            String url = "http://dleal.ciclo.iesnervion.es/Producto/"+p.idproducto;
            Uri uri = new Uri(url);
            string postBody = JsonConvert.SerializeObject(p);
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic",
                                               Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                    string.Format("{0}:{1}", "admin", "admin"))));

            
            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage res = await httpClient.PutAsync(uri,new StringContent(postBody));
            String resultado = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
                correcto = true;
            
            return correcto;

        }

        /// <summary>
        ///  Metodo que añade un producto 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> addProducto(Producto p)
        {
            bool correcto = false;
            HttpResponseMessage res;
               String url = "http://dleal.ciclo.iesnervion.es/Producto";
            Uri uri = new Uri(url);
            string postBody = JsonConvert.SerializeObject(p);
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
        public async Task<bool> deleteProduct(int id)
        {
            bool borradocorrecto = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Producto/"+id;
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
