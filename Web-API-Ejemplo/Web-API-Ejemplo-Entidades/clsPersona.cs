using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_API_Ejemplo_Entidades
{
	public class clsPersona
	{

		public int idPersona { get; set; }

		public string nombre { get; set; }

		public string apellidos { get; set; }
		//public DateTime fechaNac { get; set; }

		public string direccion { get; set; }

		public string telefono { get; set; }
		//public int idDepartamento { get; set; }

		public clsPersona()
		{
			this.idPersona = 0;
			this.nombre = "";
			this.apellidos = "";
			this.direccion = "";
			this.telefono = "";
			//this.idDepartamento = 3;
		}

		public clsPersona(int id, String nombre, String apellidos, String direccion, String telefono)
		{
			this.idPersona = id;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.direccion = direccion;
			this.telefono = telefono;
		}


	}
}
