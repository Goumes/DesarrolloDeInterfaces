using Examen_AlejandroGomez_Sistemas___ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_AlejandroGomez_Sistemas___UI.Models
{
    public class clsListadoCursos
    {
        #region Propiedades
        public List<clsCurso> cursos { get; set; }
        public int idCurso { get; set; }
        #endregion
        #region Constructor
        public clsListadoCursos ()
        {
            this.cursos = new List<clsCurso>();
            idCurso = 0;
        }

        public clsListadoCursos (List<clsCurso> cursos, int idCurso)
        {
            this.cursos = cursos;
            this.idCurso = idCurso;
        }
        #endregion
    }
}