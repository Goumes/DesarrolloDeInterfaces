using Examen_AlejandroGomez_Sistemas___DAL.Listados;
using Examen_AlejandroGomez_Sistemas___ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___BL.Listados
{
    public class clsListadoAlumnosBL
    {
        #region Metodos
        /// <summary>
        /// Metodo dedicado a obtener el listado de alumnos dependiendo de su curso de la capa DAL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un listado de alumnos</returns>
        public List<clsAlumno> getListadoAlumnosPorCursoBL (int id)
        {
            List<clsAlumno> alumnos = new List<clsAlumno>();
            clsListadoAlumnosDAL listadoAlumnosDAL = new clsListadoAlumnosDAL();

            alumnos = listadoAlumnosDAL.getListadoAlumnosPorCursoDAL(id);


            return alumnos;
        }
        #endregion
    }
}
