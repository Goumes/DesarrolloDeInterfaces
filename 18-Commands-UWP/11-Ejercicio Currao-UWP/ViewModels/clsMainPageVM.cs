using _05_PersonaModificada_ASP.Models.Entities;
using _05_PersonaModificada_ASP.Models.Interfaces;
using _11_Ejercicio_Currao_UWP.Models.Lists;
using _13_DataContext.ViewModels;
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
        private DelegateCommand _borrarCommand;

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
                _borrarCommand.RaiseCanExecuteChanged();
               NotifyPropertyChanged("personaSeleccionada");
            }
        }

        public DelegateCommand borrarCommand
        {
            get
            {
                _borrarCommand = new DelegateCommand(borrar, puedeBorrar); // (execute (), canExecute ())
                return _borrarCommand;
            }

            set
            {
                _borrarCommand = value;
            }
        }
        #endregion

        #region Metodos
        public bool puedeBorrar()
        {
            bool puede = false;

            if (_personaSeleccionada != null)
            {
                puede = true;
            }

            return puede;
        }

        public void borrar()
        {
            listado.Remove(_personaSeleccionada);
        }
        #endregion
    }
}
