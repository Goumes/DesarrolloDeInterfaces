using _05_PersonaModificada_ASP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Ejercicio_Currao_UWP.Models.Lists
{
    class clsListadoPersonas
    {
        public ObservableCollection<clsPersona> personas { get; set; }

        public clsListadoPersonas()
        {
            this.personas = new ObservableCollection<clsPersona>();
            this.cargar();
        }

        public clsListadoPersonas(ObservableCollection<clsPersona> personas)
        {
            this.personas = personas;
        }

        public void cargar()
        {
            this.personas.Add(new clsPersona(1, "pepejava1", "apellido1_1", "apellido2_1", new DateTime(2001, 1, 1), "direccion1", "111111111"));
            this.personas.Add(new clsPersona(2, "pepejava2", "apellido1_2", "apellido2_2", new DateTime(2002, 2, 2), "direccion2", "222222222"));
            this.personas.Add(new clsPersona(3, "pepejava3", "apellido1_3", "apellido2_3", new DateTime(2003, 3, 3), "direccion3", "333333333"));
            this.personas.Add(new clsPersona(4, "pepejava4", "apellido1_4", "apellido2_4", new DateTime(2004, 4, 4), "direccion4", "444444444"));
            this.personas.Add(new clsPersona(5, "pepejava5", "apellido1_5", "apellido2_5", new DateTime(2005, 5, 5), "direccion5", "555555555"));
            this.personas.Add(new clsPersona(6, "pepejava6", "apellido1_6", "apellido2_6", new DateTime(2006, 6, 6), "direccion6", "666666666"));
            this.personas.Add(new clsPersona(7, "pepejava7", "apellido1_7", "apellido2_7", new DateTime(2007, 7, 7), "direccion7", "777777777"));
            this.personas.Add(new clsPersona(8, "pepejava8", "apellido1_8", "apellido2_8", new DateTime(2008, 8, 8), "direccion8", "888888888"));
            this.personas.Add(new clsPersona(9, "pepejava9", "apellido1_9", "apellido2_9", new DateTime(2009, 9, 9), "direccion9", "999999999"));
            this.personas.Add(new clsPersona(10, "pepejava10", "apellido1_10", "apellido2_10", new DateTime(2010, 10, 10), "direccion10", "101010101"));
            this.personas.Add(new clsPersona(11, "pepejava11", "apellido1_11", "apellido2_11", new DateTime(2011, 11, 11), "direccion11", "110110110"));
            this.personas.Add(new clsPersona(12, "pepejava12", "apellido1_12", "apellido2_12", new DateTime(2012, 12, 12), "direccion12", "121212121"));
        }

        /*
        public clsPersona getPersonaPorId(int idPersona)
        {
            clsPersona resultado = new clsPersona();

            for (int i = 0; i < this.personas.Count; i++)
            {
                if (this.personas[i].idPersona == idPersona)
                {
                    resultado = this.personas[i];
                }
            }

            return resultado;
        }
        */

    }
}
