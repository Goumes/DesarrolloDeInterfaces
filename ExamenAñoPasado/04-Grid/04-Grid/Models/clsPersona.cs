using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_Grid.Models;


namespace _04_Grid.Models
{

    class clsPersona
    {
        //propiedades y Getters/Setters
        public String nombre { get; set; }
        public String apellido { get; set; }
        public Nullable <DateTimeOffset> fechaNacimiento { get; set; }

        //constructores
        public clsPersona(String nombre, String apellido, DateTimeOffset fechaNacimiento)
        {
            
            
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
           
        }

        public clsPersona()
        {
            this.nombre = null;
            this.apellido = null;
            this.fechaNacimiento = null;
        }
        override
        public String ToString()
        {
            return ("Nombre: "+this.nombre+" , Apellidos: "+this.apellido+", Fecha de Nacimiento: "+this.fechaNacimiento.ToString());
        }
    }
}
