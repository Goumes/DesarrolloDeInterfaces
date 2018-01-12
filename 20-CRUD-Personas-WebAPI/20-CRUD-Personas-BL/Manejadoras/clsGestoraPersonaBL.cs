using _20_CRUD_Personas_DAL.Manejadoras;
using _20_CRUD_Personas_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace _20_CRUD_Personas_BL.Manejadoras
{
    public class clsGestoraPersonaBL
    {
        clsGestoraPersonaDAL gestoraPersonaDAL;
        public clsPersona getPersonaEditar(int id)
        {
            clsPersona persona;
            gestoraPersonaDAL = new clsGestoraPersonaDAL();
            persona = gestoraPersonaDAL.buscarPersonaPorId(id);

            return persona;
        }

        public async Task<bool> getGuardarPersona(clsPersona persona)
        {
            bool resultado = false;
            clsGestoraPersonaDAL gestoraPersonaDAL = new clsGestoraPersonaDAL();
            resultado = await gestoraPersonaDAL.updatePersonaDAL(persona);
                        
            return resultado;
        }

        public async Task <bool> getBorrarPersona(int id)
        {
            bool resultado = false;
            clsGestoraPersonaDAL gestoraPersonaDAL = new clsGestoraPersonaDAL();
            resultado = await gestoraPersonaDAL.deletePersona(id);

            return resultado;
        }

        public async Task<bool> getAddPersona (clsPersona persona)
        {
            bool resultado = false;

            clsGestoraPersonaDAL gestoraPersonaDAL = new clsGestoraPersonaDAL();
            resultado = await gestoraPersonaDAL.addPersonaDAL(persona);

            return resultado;
        }
    }
}
