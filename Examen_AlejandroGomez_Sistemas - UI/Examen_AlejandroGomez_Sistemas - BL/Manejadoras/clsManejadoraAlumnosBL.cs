using Examen_AlejandroGomez_Sistemas___DAL.Manejadoras;
using Examen_AlejandroGomez_Sistemas___ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___BL.Manejadoras
{
    public class clsManejadoraAlumnosBL
    {
        #region Metodos
        /// <summary>
        /// Metodo dedicado a recoger un alumno de la capa DAL por medio de una id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El alumno seleccionado</returns>
        public clsAlumno getAlumnoPorIdBL (int id)
        {
            clsAlumno alumno = new clsAlumno();

            clsManejadoraAlumnosDAL manejadoraAlumnosDAL = new clsManejadoraAlumnosDAL();

            alumno = manejadoraAlumnosDAL.buscarAlumnoPorId(id);

            return alumno;
        }

        /// <summary>
        /// Metodo dedicado a llamar a la capa dal para actualizar la beca de un alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beca"></param>
        /// <returns>un entero indicando si ha sido correcto o no</returns>
        public int asignarBecaAlumnoBL (int id, decimal beca)
        {
            int resultado = 0;
            clsManejadoraAlumnosDAL manejadoraAlumnosDAL = new clsManejadoraAlumnosDAL();
            resultado = manejadoraAlumnosDAL.asignarBeca(id, beca);

            return resultado;
        }
        #endregion
    }
}
