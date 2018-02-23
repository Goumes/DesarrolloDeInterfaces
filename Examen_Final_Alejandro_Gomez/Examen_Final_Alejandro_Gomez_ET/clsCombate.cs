using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_ET
{
    public class clsCombate
    {
        public int idCombate { get; set; }
        public String fecha { get; set; }

        public clsCombate()
        {
            this.idCombate = 0;
            this.fecha = "0/0/0";
        }

        public clsCombate(int idCombate, String fecha)
        {
            this.idCombate = idCombate;
            this.fecha = fecha;
        }
    }
}
