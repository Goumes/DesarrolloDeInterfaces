using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _20_CRUD_Personas_ET;
using _20_CRUD_Personas_DAL.Listados;
using System.Collections.ObjectModel;

namespace _20_CRUD_Personas_BL.Listados
{
    public class clsListadoPersonasBL
    {
        public async Task <ObservableCollection<clsPersona>> getListadoPersonasBL()
        {
            ObservableCollection<clsPersona> lista;

            clsListadoPersonasDAL listadoPersonasDAL = new clsListadoPersonasDAL();

            lista = await listadoPersonasDAL.getListadoPersonasDAL();

            return lista;

        }
    }
}
