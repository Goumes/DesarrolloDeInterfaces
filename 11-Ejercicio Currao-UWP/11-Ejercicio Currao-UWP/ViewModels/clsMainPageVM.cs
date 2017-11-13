using _05_PersonaModificada_ASP.Models.Entities;
using _05_PersonaModificada_ASP.Models.Interfaces;
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
    class clsMainPageVM : clsVMBase
    {
        #region "Atributos"
        private ObservableCollection<clsPersona> _listadoPersonas;
        private clsPersona _personaSeleccionada;

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
    }
}
