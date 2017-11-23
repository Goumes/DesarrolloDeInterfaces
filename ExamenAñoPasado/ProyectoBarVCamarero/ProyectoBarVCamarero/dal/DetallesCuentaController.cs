using Newtonsoft.Json;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.dal
{
    public class DetallesCuentaController
    {
        /// <summary>
        ///  Añade un pedido a la cuenta
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public async Task<bool> addPedido(Cuenta c)
        {
            bool correcto = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Cuenta/"+ c.idcuenta + "/Detalles";
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
            if (res.IsSuccessStatusCode) correcto = true;

            return correcto;

        }


        /// <summary>
        ///  Añade un pedido a la cuenta
        /// </summary>
        /// <param name="idCuenta"></param>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        public async Task<bool> editPedido(int idCuenta, List<Listdetallecuenta> pedidos)
        {
            bool correcto = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Cuenta/" + idCuenta + "/Detalles";
            Uri uri = new Uri(url);
            string postBody = JsonConvert.SerializeObject(pedidos);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Basic",
                                               Convert.ToBase64String(
                                                System.Text.ASCIIEncoding.ASCII.GetBytes(
                                                    string.Format("{0}:{1}", "admin", "admin"))));

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            res = await httpClient.PutAsync(uri, new StringContent(postBody));
            String resultado = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode) correcto = true;

            return correcto;

        }


        /// <summary>
        /// Metodo que elimina un pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> deletePedidoCuenta(int idcuenta,int idproducto)
        {
            bool completado = false;
            HttpResponseMessage res;
            String url = "http://dleal.ciclo.iesnervion.es/Cuenta/" + idcuenta + "/" + idproducto;
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
            if (res.IsSuccessStatusCode) completado = true;
            return completado;
        }
    }
}
