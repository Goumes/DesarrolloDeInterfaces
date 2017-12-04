using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20_CRUD_Personas_ET;
using _20_CRUD_Personas_DAL.Listados;

namespace _20_CRUD_Personas_BL.Listados
{
    public class clsListadoPersonasBL
    {
        public List<clsPersona> getListadoPersonasBL()
        {
            List<clsPersona> lista;

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            lista = listadoPersonasDAL.getListadoPersonasDAL();

            return lista;

        }
    }
}
