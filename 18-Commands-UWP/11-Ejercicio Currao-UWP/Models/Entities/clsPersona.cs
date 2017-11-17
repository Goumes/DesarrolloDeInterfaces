using _05_PersonaModificada_ASP.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _05_PersonaModificada_ASP.Models.Entities
{
    public class clsPersona : clsVMBase
    {
        public int idPersona { get; set; }
        private string nombre;
        public string apellido1;
        public string apellido2 { get; set; }
        public string direccion;
        public DateTime fechaNac;
        public string telefono;


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

        public string _nombre
            {
                get
                {
                    return nombre;
                }

                set
                {
                    nombre = value;
                    NotifyPropertyChanged("_nombre");
                }
            }

        public string _apellido1
        {
            get
            {
                return apellido1;
            }

            set
            {
                apellido1 = value;
                NotifyPropertyChanged("_apellido1");
            }
        }

        public DateTime _fechaNac
        {
            get
            {
                return fechaNac;
            }

            set
            {
                fechaNac = value;
                NotifyPropertyChanged("_fechaNac");
            }
        }

        public string _telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
                NotifyPropertyChanged("_telefono");
            }
        }

        public string _direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
                NotifyPropertyChanged("_direccion");
            }
        }

    }
}

  