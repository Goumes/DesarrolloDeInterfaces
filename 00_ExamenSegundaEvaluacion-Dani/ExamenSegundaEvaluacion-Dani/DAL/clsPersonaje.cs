using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSegundaEvaluacion_Dani.DAL
{
    public class clsPersonaje
    {
        public int idPersonaje { get; set; }
        public string nombre { get; set; }
        public string alias { get; set; }
        public double vida { get; set; }
        public double regeneracion { get; set; }
        public double danno { get; set; }
        public double armadura { get; set; }
        public double velAtaque { get; set; }
        public double resistencia { get; set; }
        public double velMovimiento { get; set; }
        public Uri imagen { get; set; }
        public ObservableCollection<Uri> skins { get; set; }
        //Constructor por defecto

        //public clsPersonaje()
        //{
        //    this.nombre = "";
        //    this.alias = "";
        //    this.vida = 0;
        //    this.regeneracion = 0;
        //    this.danno = 0;
        //    this.armadura = 0;
        //    this.velAtaque = 0;
        //    this.resistencia = 0;
        //    this.velMovimiento = 0;
        //}

        //Constructor por parámetros

        public clsPersonaje(string nombre, string alias, double vida, double regeneracion, double danno, double armadura, double velAtaque, double resistencia, double velMovimiento)
        {
            this.nombre = nombre;
            this.alias = alias;
            this.vida = vida;
            this.regeneracion = regeneracion;
            this.danno = danno;
            this.armadura = armadura;
            this.velAtaque = velAtaque;
            this.resistencia = resistencia;
            this.velMovimiento = velMovimiento;
            this.imagen = asignafoto(nombre);
            this.skins = new ObservableCollection<Uri>();
            this.asignaSkin(nombre);
        }

        private Uri asignafoto(string nombre)
        {

            Uri u = new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + ".png", UriKind.RelativeOrAbsolute);
            return u;
        }

        private void asignaSkin(string nombre)
        {
            switch (nombre) {
                case "Aatrox":
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_0.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_1.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_2.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_3.jpg", UriKind.RelativeOrAbsolute));
                    break;
                case "Ahri":
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_0.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_1.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_2.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_3.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_4.jpg", UriKind.RelativeOrAbsolute));

                    break;
                case "Akali":
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_0.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_1.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_2.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_3.jpg", UriKind.RelativeOrAbsolute));
                   
                    break;
                case "Alistar":
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_0.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_1.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_2.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_3.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_4.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_5.jpg", UriKind.RelativeOrAbsolute));

                    break;

                case "Amumu":
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_0.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_1.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_2.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_3.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_4.jpg", UriKind.RelativeOrAbsolute));

                    break;
                case "Anivia":
                
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_0.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_1.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_2.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_3.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_4.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_5.jpg", UriKind.RelativeOrAbsolute));
                    skins.Add(new Uri("ms-appx://ExamenSegundaEvaluacion-Dani/Assets/Imagenes/" + nombre + "_6.jpg", UriKind.RelativeOrAbsolute));

                    break;



            }

        }
    }
}
