using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _Binding2.Models
{

  public class clsPersona:INotifyPropertyChanged
    {
        //propiedades y Getters/Setters
        private String _nombre { get; set; }
        private String _apellido { get; set; }
        private DateTime? _fechaNac;
        private String _telefono { get; set; }
        private String _direccion;
        public int id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //constructores
        public clsPersona(String nombre, String apellido, DateTime fechaNac, String telefono, String direccion)
        {
 
            this._nombre = nombre;
            this._apellido = apellido;
            this._fechaNac = fechaNac;
            this._telefono = telefono;
            this._direccion = direccion; 
           
        }

        public clsPersona()
        {
            this.id = -1;
            this._nombre = null;
            this._apellido = null;
            this._fechaNac = new DateTime();
            this._telefono = null;
            this._direccion = null; 
        }



        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                this._nombre = value;
                OnPropertyChanged("nombre");
            }
        }

        public String apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                this._apellido = value;
                OnPropertyChanged("apellido");
            }
        }



        public object fechaNac
        {
            get
            {
                return this._fechaNac;
            }
            set
            {
                //Aqui teniamos un prblema porque nuestra propiedad es un DATETIME, pero el set que recibe es una cadena asi que hay que convertirla, pero se le suma otro problema
                //que las fechas que recibimos de la bbdd son typo DATETIME, entonces tenemos que buscar una solucion como esta:
                if (value.GetType() == typeof(string))
                {

                    this._fechaNac = Convert.ToDateTime((String)value);
                }

                else
                {
                    this._fechaNac = (DateTime)value;
                }
                


                OnPropertyChanged("fechaNac");
            }
        }

        public String telefono
        {
            get
            {
                return this._telefono;
            }
            set
            {
                this._telefono = value;
                OnPropertyChanged("telefono");
            }
        }

        public String direccion
        {
            get
            {
                return this._direccion;
            }
            set
            {
                this._direccion = value;
                OnPropertyChanged("direccion");
            }
        }


        override
        public String ToString()
        {
            return ("Nombre: "+this.nombre+" , Apellidos: "+this.apellido);
        }


        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
