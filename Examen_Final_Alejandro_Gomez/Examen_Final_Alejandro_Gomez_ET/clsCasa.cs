using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_ET
{
    public class clsCasa
    {
        private int _idCasa;
        public String nombreCasa { get; set; }
        public Uri foto { get; set; }

        public clsCasa()
        {
            this.idCasa = 0;
            this.nombreCasa = "TargaryenPorEjemplo";
        }

        public clsCasa(int idCasa, String nombreCasa)
        {
            this.idCasa = idCasa;
            this.nombreCasa = nombreCasa;
        }

        public int idCasa
        {
            get
            {
                return _idCasa;
            }

            set
            {
                _idCasa = value;
                asignarImagen();
            }
        }

        public void asignarImagen()
        {
            this.foto = new Uri("ms-appx:///Assets/Imagenes/Casas/" + _idCasa + ".png");
        }

    }
}
