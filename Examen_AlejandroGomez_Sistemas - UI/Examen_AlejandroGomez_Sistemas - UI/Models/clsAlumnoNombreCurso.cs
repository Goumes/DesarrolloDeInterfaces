using Examen_AlejandroGomez_Sistemas___ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_AlejandroGomez_Sistemas___UI.Models
{
    public class clsAlumnoNombreCurso
    {
        #region Propiedades
        public clsAlumno alumno { get; set; }
        public string nombreCurso { get; set; }
        #endregion

        #region Constructores
        public clsAlumnoNombreCurso ()
        {
            this.alumno = new clsAlumno();
            this.nombreCurso = "";
        }

        public clsAlumnoNombreCurso (clsAlumno alumno, string nombreCurso)
        {
            this.alumno = alumno;
            this.nombreCurso = nombreCurso;
        }
        #endregion
    }
}