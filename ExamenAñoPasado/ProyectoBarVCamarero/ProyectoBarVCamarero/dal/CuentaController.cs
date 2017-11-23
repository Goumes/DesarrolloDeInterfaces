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
    public class CuentaController
    {

        #region Builder
        public CuentaController()
        {

        }
        #endregion


        #region Functions


        /// <summary>
        ///  Metodo que recoge todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Cuenta>> getCuentas(int idcuenta=-1,int nummesa=-1)
        {
            
                String url = "http://dleal.ciclo.iesnervion.es/Cuenta";

                if (idcuenta != -1)
                {
                    url += "/" + idcuenta;
                }
                else
                if (nummesa != -1)
                {
                    url += "/mesa/" + nummesa;
                }
                Uri uri = new Uri(url);
                ObservableCollection<Cuenta> lista = null;


                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
          new AuthenticationHeaderValue("Basic",
                                        Convert.ToBase64String(
                                         System.Text.ASCIIEncoding.ASCII.GetBytes(
                                             string.Format("{0}:{1}", "admin", "admin"))));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            
                string respuesta = await httpClient.GetStringAsync(uri);

                lista = JsonConvert.DeserializeObject<ObservableCollection<Cuenta>>(respuesta);
            if (lista == null)
            {
                lista = new ObservableCollection<Cuenta>();
            }

            
            

            return lista;
        }



        /// <summary>
        ///  Metodo que edita un producto 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> editCuenta(Cuenta c)
        {
            String url = "http://dleal.ciclo.iesnervion.es/Cuenta/" + c.idcuenta;
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
            return res;

        }
        /// <summary>
        /// Metodo para finalizar una cuenta
        /// </summary>
        /// <param name="id">Id cuenta</param>
        /// <param name="tipo">Indica el tipo de finalizado (1 pagada , 2 sin pagar)</param>
        /// <returns></returns>
        public async Task<bool> finalizarCuenta(int id,int tipo)
        {
            bool correcto = false;
            String url = "http://dleal.ciclo.iesnervion.es/Cuenta/" + id + "/Finalizar/"+tipo;
            Uri uri = new Uri(url);
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic",
                                               Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                    string.Format("{0}:{1}", "admin", "admin"))));



            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await httpClient.PutAsync(uri,null);
            String resultado = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode) correcto = true;
            return correcto;

        }

        /// <summary>
        ///  Metodo que añade un producto 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> addCuenta(Cuenta c)
        {
            bool correcto = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Cuenta";
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
            correcto = res.IsSuccessStatusCode;
            return correcto;

        }
        /// <summary>
        /// Metodo que elimina un producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> deleteCuenta(int id)
        {
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Cuenta/" + id;
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

            return res;
        }
        #endregion
    }
}

