using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___ET
{
    public class clsAlumno
    {
        #region Propiedades
        public int idAlumno { get; set; }
        public string nombreAlumno { get; set; }
        public string apellidosAlumno { get; set; }
        public int idCurso { get; set; }
        public decimal beca { get; set; }
        #endregion

        #region Constructores
        public clsAlumno ()
        {
            this.idAlumno = 0;
            this.nombreAlumno = "";
            this.apellidosAlumno = "";
            this.idCurso = 0;
            this.beca = 0;
        }

        public clsAlumno (int idAlumno, string nombreAlumno, string apellidosAlumno, int idCurso, decimal beca)
        {
            this.idAlumno = idAlumno;
            this.nombreAlumno = nombreAlumno;
            this.apellidosAlumno = apellidosAlumno;
            this.idCurso = idCurso;
            this.beca = beca;
        }
        #endregion
    }
}
