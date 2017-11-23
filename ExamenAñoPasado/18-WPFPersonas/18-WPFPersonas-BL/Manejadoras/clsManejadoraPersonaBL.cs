using _18_WPFPersonas_DAL;
using _18_WPFPersonas_Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _18_WPFPersonas_BL
{
    public class clsManejadoraPersonaBL
    {
        private clsManejadoraPersonaDAL cmpd;

        public clsManejadoraPersonaBL()
        {
             cmpd = new clsManejadoraPersonaDAL();
        }

        /// <summary>
        /// Inserta una persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns>-1 en caso de que hubiera fallo
        ///         1 en caso de que todo fuera correcto</returns>
        public int insertPerson(clsPersona p)
        {
            

            int resultado = -1;
            resultado = cmpd.insertPersona(p);
            return resultado;
        }

        public int updatePerson(clsPersona p)
        {
            int resultado = -1;
            resultado = cmpd.updatePersona(p);

            return resultado;
        }

        public clsPersona getPersona (int id)
        {
            clsPersona p;
            p = cmpd.getPersona(id);
            return p;
        }

        public int deletePersona(int id)
        {
            return cmpd.deletePerson(id);
        }
    }
}
