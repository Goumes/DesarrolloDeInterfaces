using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUD_Personas_ET
{
    public class clsPersona
    {
        [Display(Name = "ID Persona")]
        public int idPersona { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Apellidos")]
        [MaxLength(40)]
        public string apellidos { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime fechaNac { get; set; }
        [MaxLength(200)]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }
        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[9|6|7][0-9]{8}$", ErrorMessage = "Not a valid Phone number")]
        public string telefono { get; set; }
        [Display(Name = "ID Departamento")]
        public int idDepartamento { get; set; }

        public clsPersona()
        {
            this.idPersona = 0;
            this.nombre = "Alejandro";
            this.apellidos = "Gómez";
            this.direccion = "Mi casa";
            this.telefono = "954224444";
            this.idDepartamento = 3;
            this.fechaNac = DateTime.Now;
        }

        public clsPersona(String nombre, String apellidos, String direccion, String telefono, DateTime fechaNac)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.telefono = telefono;
            this.fechaNac = fechaNac;
        }

    }
}
