using _05_PersonaModificada_ASP.Models.Entities;
using _11_Ejercicio_Currao_UWP.Models.Lists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _11_Ejercicio_Currao_UWP.ViewModels
{
    class clsMainPageVM : INotifyPropertyChanged
    {
        #region "Atributos"
        private ObservableCollection<clsPersona> _listadoPersonas;
        private clsPersona _personaSeleccionada;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region "Constructores"
        public clsMainPageVM ()
        {
            clsListadoPersonas personas = new clsListadoPersonas();
            _listadoPersonas = personas.personas;
        }
        #endregion

        #region "Propiedades"

        public ObservableCollection<clsPersona> listado
        {
            get
            {
                return _listadoPersonas;
            }
        }

        public clsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }

            set
            {
                _personaSeleccionada = value;
               NotifyPropertyChanged("personaSeleccionada");
            }
        }
        #endregion

        #region "Metodos"

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
