using Examen_AlejandroGomez_Sistemas___DAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_AlejandroGomez_Sistemas___BL.Manejadoras
{
    public class clsManejadoraCursosBL
    {
        /// <summary>
        /// Metodo dedicado a llamar a la capa dal y recibir el nombre de un curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>nombre del curso</returns>
        public string getNombreCursoPorIdBL(int id)
        {
            string nombreCurso = "";

            clsManejadoraCursosDAL manejadoraCursosDAL = new clsManejadoraCursosDAL();

            nombreCurso = manejadoraCursosDAL.buscarNombreCursoPorIdDAL(id);

            return nombreCurso;
        }
    }
}
