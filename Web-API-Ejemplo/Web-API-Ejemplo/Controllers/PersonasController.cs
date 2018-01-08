using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_Ejemplo_BL;
using Web_API_Ejemplo_Entidades;

namespace Web_API_Ejemplo.Controllers
{
    public class PersonasController : ApiController
    {
		/// <summary>
		/// El verbo GET nos muestra el listado completo de personas
		/// </summary>
		/// <returns>Listado de personas</returns>
		public ObservableCollection<clsPersona> Get()
        {
			clsListadoPersonasBL listadoBL = new clsListadoPersonasBL();
			ObservableCollection<clsPersona> listado = listadoBL.obtenerListadoPersonasBL();
			return (listado);
        }

        /// <summary>
		/// El verbo GET nos muestra la persona encontrada con la id pasada
		/// </summary>
		/// <param name="id">Id persona a buscar</param>
		/// <returns>Persona</returns>
        public clsPersona Get(int id)
        {
			clsListadoPersonasBL personaID = new clsListadoPersonasBL();
			clsPersona persona = personaID.obtenerPersonaAEditar(id);
			return (persona);
		}

        /// <summary>
		/// El verbo POST crea una persona
		/// </summary>
		/// <param name="nuevaPersona">Persona a introducir</param>
        public void Post([FromBody]clsPersona nuevaPersona)
        {
			clsListadoPersonasBL personaCreada = new clsListadoPersonasBL();
			int resultado = personaCreada.crearPersona(nuevaPersona);
		}

        /// <summary>
		/// El verbo Put actualiza la persona si encuentra el ID, y si no la crea
		/// </summary>
		/// <param name="id">Id persona</param>
		/// <param name="persona"> Objeto persona introducido</param>
        public void Put(int id, [FromBody]clsPersona persona)
        {
			clsListadoPersonasBL listado = new clsListadoPersonasBL();
			persona.idPersona = id;
			listado.obtenerPersonaEditada(persona);			
        }

        /// <summary>
		/// El verbo DELETE elimina la persona con la id introducida
		/// </summary>
		/// <param name="id">Id de la persona a eliminar</param>
        public void Delete(int id)
        {
			clsListadoPersonasBL personaEliminar = new clsListadoPersonasBL();
			int resultado = personaEliminar.eliminarPersona(id);
		}
    }
}
