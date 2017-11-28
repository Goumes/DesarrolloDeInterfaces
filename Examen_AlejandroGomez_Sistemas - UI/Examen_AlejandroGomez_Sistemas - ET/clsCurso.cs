using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___ET
{
    public class clsCurso
    {
        #region Propiedades
        public int idCurso { get; set; }
        public string nombreCurso { get; set; }
        #endregion

        #region Constructores
        public clsCurso ()
        {
            this.idCurso = 0;
            this.nombreCurso = "";
        }

        public clsCurso (int idCurso, string nombreCurso)
        {
            this.idCurso = idCurso;
            this.nombreCurso = nombreCurso;
        }
        #endregion
    }
}
