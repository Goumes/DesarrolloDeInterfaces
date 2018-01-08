using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_API_Ejemplo_DAL.Listado;
using Web_API_Ejemplo_Entidades;

namespace Web_API_Ejemplo_BL
{
	public class clsListadoPersonasBL
	{
		public ObservableCollection<clsPersona> obtenerListadoPersonasBL()
		{
			clsListadoPersonasDAL listadoDAL = new clsListadoPersonasDAL();
			ObservableCollection<clsPersona> listadoBL = listadoDAL.obtenerListadoPersonasDAL();
			return (listadoBL);
		}

		public clsPersona obtenerPersonaAEditar(int id)
		{
		 	clsListadoPersonasDAL personaEditada = new clsListadoPersonasDAL();
			clsPersona persona = personaEditada.editarPersona(id);
			return (persona);
		}

		public int obtenerPersonaEditada(clsPersona personaEditada)
		{
			clsListadoPersonasDAL personaGuardarEditada = new clsListadoPersonasDAL();
			int resultado = personaGuardarEditada.guardarPersonaEditada(personaEditada);
			return (resultado);
		}

		public int eliminarPersona(int id)
		{
			clsListadoPersonasDAL personaEliminar = new clsListadoPersonasDAL();
			int resultado = personaEliminar.eliminarPersona(id);
			return (resultado);
		}

		public int crearPersona(clsPersona nuevaPersona)
		{
			clsListadoPersonasDAL personaCreada = new clsListadoPersonasDAL();
			int resultado = personaCreada.crearPersona(nuevaPersona);
			return (resultado);
		}
	}
}
