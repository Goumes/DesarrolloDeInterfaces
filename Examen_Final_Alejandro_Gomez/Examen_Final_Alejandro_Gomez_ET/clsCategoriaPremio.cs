using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_ET
{
    public class clsCategoriaPremio
    {
        public int idCategoriaPremio { get; set; }
        public String nombreCategoriaPremio { get; set; }

        public clsCategoriaPremio()
        {
            this.idCategoriaPremio = 0;
            this.nombreCategoriaPremio = "Dominacion";
        }

        public clsCategoriaPremio(int idCategoriaPremio, String nombreCategoriaPremio)
        {
            this.idCategoriaPremio = idCategoriaPremio;
            this.nombreCategoriaPremio = nombreCategoriaPremio;
        }
    }
}
