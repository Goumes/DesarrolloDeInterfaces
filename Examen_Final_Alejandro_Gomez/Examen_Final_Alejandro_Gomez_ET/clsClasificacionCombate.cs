using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_ET
{
    public class clsClasificacionCombate
    {
        public int idCombate { get; set; }
        public int puntos { get; set; }
        public int idCategoriaPremio { get; set; }
        public int idLuchador { get; set; }

        public clsClasificacionCombate()
        {
            this.idCombate = 0;
            this.puntos = 0;
            this.idCategoriaPremio = 0;
            this.idLuchador = 0;
        }

        public clsClasificacionCombate(int idCombate, int puntos, int idCategoriaPremio, int idLuchador)
        {
            this.idCombate = idCombate;
            this.puntos = puntos;
            this.idCategoriaPremio = idCategoriaPremio;
            this.idLuchador = idLuchador;
        }
    }
}
