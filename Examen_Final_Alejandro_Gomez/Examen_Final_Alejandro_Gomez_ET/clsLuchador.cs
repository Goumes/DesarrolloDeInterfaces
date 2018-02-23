using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_ET
{
    public class clsLuchador
    {
        private int _idLuchador;
        public String nombreLuchador { get; set; }
        public int idCasa { get; set; }

        public Uri foto { get; set; }

        public clsLuchador()
        {
            this.idLuchador = 0;
            this.idCasa = 0;
            this.nombreLuchador = "Tyrion";
        }

        public clsLuchador(int idLuchador, String nombreLuchador, int idCasa)
        {
            this.idLuchador = idLuchador;
            this.idCasa = idCasa;
            this.nombreLuchador = nombreLuchador;
        }

        public int idLuchador
        {
            get
            {
                return _idLuchador;
            }

            set
            {
                _idLuchador = value;
                seleccionarImagen();
            }
        }

        public void seleccionarImagen()
        {

            this.foto = new Uri("ms-appx:///Assets/Imagenes/Luchadores/"+_idLuchador+".jpg");
        }
    }
}
