using ExamenLol.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace ExamenLol.ViewModels
{
    public class clsUtilidades
    {        
        private Uri uri;

        public clsUtilidades()
        {
            uri = new Uri("http://localhost:2461/api/personajes");
        }

        

        public async Task<ObservableCollection<clsPersonaje>> getPersonajes()
        {

            HttpBaseProtocolFilter filtro = new HttpBaseProtocolFilter();
            filtro.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            filtro.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;

            HttpClient mihttpClient = new HttpClient(filtro);

            ObservableCollection<clsPersonaje> listadoPersonajes = new ObservableCollection<clsPersonaje>();

            try
            {
                string respuesta = await mihttpClient.GetStringAsync(uri);
                mihttpClient.Dispose();

                listadoPersonajes = JsonConvert.DeserializeObject<ObservableCollection<clsPersonaje>>(respuesta);
                foreach (clsPersonaje pers in listadoPersonajes)
                {
                    pers.imagenPerfil = obtenerUrlFotoPerfil(pers.nombre);
                    pers.fotos = obtenerUrlsFotos(pers.nombre);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listadoPersonajes;
        }

        public string obtenerUrlFotoPerfil(string nombre)
        {
            string res = "../Assets/Imagenes/Aatrox.png";
            if (nombre == "Ahri")
                res = "../Assets/Imagenes/Ahri.png";
            else if (nombre != "Aatrox")
                res = "../Assets/Imagenes/"+nombre.ToLower()+".png";
            return res;
        }

        public string[] obtenerUrlsFotos(string nombre)
        {
            int num = 0;
            string[] res = new string[5];
            switch (nombre)
            {
                case "Aatrox":
                case "Akali":
                    num = 3;
                    break;
                case "Ahri":
                case "Amumu":
                    num = 4;
                    break;
                case "Alistar":
                    num = 5;
                    break;
                case "Anivia":
                    num = 5;
                    break;
            }            
           

            for (int i = 0; i < num; i++)
            {
                res[i] = "../Assets/Imagenes/" + nombre + "_"+i+".jpg";
            }

            //Eliminar espacios sobrantes
            res = res.Where(c => c != null).ToArray();

            return res;
        }

    }
}
