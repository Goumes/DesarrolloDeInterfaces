using Examen_AlejandroGomez_Sistemas___DAL.Listados;
using Examen_AlejandroGomez_Sistemas___ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___BL.Listados
{
    public class clsListadoCursosBL
    {
        /// <summary>
        /// Metodo dedicado a obtener el listado de cursos de la capa DAL
        /// </summary>
        /// <returns>Un listado de cursos</returns>
        public List<clsCurso> getListadoCursosBL ()
        {
            List<clsCurso> cursos;
            clsListadoCursosDAL listadoCursosDAL = new clsListadoCursosDAL();

            cursos = listadoCursosDAL.getListadoCursosDAL();


            return cursos;
        }
    }
}
