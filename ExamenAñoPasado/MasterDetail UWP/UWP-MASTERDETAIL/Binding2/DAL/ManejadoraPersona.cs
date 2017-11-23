using _Binding2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Binding2.DAL
{
    public class ManejadoraPersona
    {
        string stringurl = "http://webapirestdanileal.azurewebsites.net/api/personas/";


        /// <summary>
        ///     Metodo que borra una persona de la bbdd segun el id que nos pasen.
        /// </summary>
        /// <param name="id"></param>
        public async void DeletePersona(int id)
        {
            HttpClient mihttpClient = new HttpClient();
            try
            {
                stringurl = stringurl + id;
                Uri url = new Uri(stringurl);
                await mihttpClient.DeleteAsync(url);
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// Metodo para guardar una persona
        /// </summary>
        /// <param name="persona"></param>
        public async void SavePersona(clsPersona persona)
        {
            HttpClient mihttpClient = new HttpClient();
            Uri url = new Uri(stringurl);

            try
            {
                string jsonconvertido=JsonConvert.SerializeObject(persona);
                IHttpContent contentPost = new HttpStringContent(jsonconvertido,Windows.Storage.Streams.UnicodeEncoding.Utf8,"application/json");
                await mihttpClient.PostAsync(url, contentPost);
               

       
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        ///     Metodo para actualizar una persona
        /// </summary>
        /// <param name="persona"></param>
        public async void UpdatePerson(clsPersona persona)
        {
            HttpClient mihttpClient = new HttpClient();
            stringurl = stringurl + persona.id;
            Uri url = new Uri(stringurl);
            try
            {
                string jsonconvertido = JsonConvert.SerializeObject(persona);
                IHttpContent contentput = new HttpStringContent(jsonconvertido, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                await mihttpClient.PutAsync(url, contentput);
            }
            catch (Exception)
            {

            }
        }
    }
}
