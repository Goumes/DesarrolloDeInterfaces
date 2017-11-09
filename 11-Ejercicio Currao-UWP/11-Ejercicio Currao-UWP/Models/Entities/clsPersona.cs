using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_PersonaModificada_ASP.Models.Entities
{
    public class clsPersona
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string direccion { get; set; }
        public DateTime fechaNac { get; set; }
        public string telefono { get; set; }

        public clsPersona()
        {
            this.idPersona = 0;
            this.nombre = "Alejandro";
            this.apellido1 = "Gómez";
            this.apellido2 = "Olivera";
            this.fechaNac = new DateTime();
            this.direccion = "Mi casa";
            this.telefono = "954224444";
        }

        public clsPersona(int idPersona, String nombre, String apellido1, String apellido2, DateTime fechaNac, String direccion, String telefono)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }

    }
}

  