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
    public class NuevaComandaController
    {

        private HttpClient httpClient;
        private string respuesta;
        private String url;
        private Uri uri;
        ObservableCollection<NuevasComandas> lista;
        public async Task<ObservableCollection<NuevasComandas>> getNuevasComandas()
        {

             url = "http://dleal.ciclo.iesnervion.es/NuevosPedidos";

            
            uri = new Uri(url);
            lista = new ObservableCollection<NuevasComandas>();
            try
            {

                httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue("Basic",
                                        Convert.ToBase64String(
                                         System.Text.ASCIIEncoding.ASCII.GetBytes(
                                             string.Format("{0}:{1}", "admin", "admin"))));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                respuesta = await httpClient.GetStringAsync(uri);

                lista = JsonConvert.DeserializeObject<ObservableCollection<NuevasComandas>>(respuesta);
            }
            catch (Exception)
            {

            }

            if(lista == null)
            {
                lista = new ObservableCollection<NuevasComandas>();
            }



            return lista;
        }

        public async Task<bool> deleteNuevasComanda(int idCuenta,int idproducto)
        {
            bool borrado = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/NuevosPedidos/" + idCuenta + "/Producto/" + idproducto;
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

            if (res.IsSuccessStatusCode) borrado = true;
            return borrado;
        }

        

    }
}
