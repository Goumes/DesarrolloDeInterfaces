using _20_CRUD_Personas_ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEB_API.Personas_CORE_DAL.Listados;

namespace WEB_API.Personas_CORE_BL
{
	public class clsListadoPersonasBL
	{
		public List<clsPersona> getListadoPersonasBL()
		{
			clsListadoPersonasDAL listadoDAL = new clsListadoPersonasDAL();
			List<clsPersona> listadoBL = listadoDAL.getListadoPersonasDAL();
			return (listadoBL);
		}

		public clsPersona buscarPersonaPorId(int id)
		{
		 	clsListadoPersonasDAL personaEditada = new clsListadoPersonasDAL();
			clsPersona persona = personaEditada.buscarPersonaPorId(id);
			return (persona);
		}

		public int obtenerPersonaEditada(clsPersona personaEditada)
		{
			clsListadoPersonasDAL personaGuardarEditada = new clsListadoPersonasDAL();
			int resultado = personaGuardarEditada.updatePersonaDAL(personaEditada);
			return (resultado);
		}

		public int eliminarPersona(int id)
		{
			clsListadoPersonasDAL personaEliminar = new clsListadoPersonasDAL();
			int resultado = personaEliminar.deletePersona(id);
			return (resultado);
		}

		public int crearPersona(clsPersona nuevaPersona)
		{
			clsListadoPersonasDAL personaCreada = new clsListadoPersonasDAL();
			int resultado = personaCreada.addPersonaDAL(nuevaPersona);
			return (resultado);
		}
	}
}
