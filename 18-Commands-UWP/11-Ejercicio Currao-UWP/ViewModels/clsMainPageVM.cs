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
        private ObservableCollection<clsPersona> _listadoAuxiliar;
        private clsPersona _personaSeleccionada;
        private String _textoBusqueda;
        private DelegateCommand _borrarCommand;
        private DelegateCommand _saveCommand;
        private DelegateCommand _addCommand;
        private DelegateCommand _buscarCommand;

        #endregion

        #region "Constructores"
        public clsMainPageVM ()
        {
            clsListadoPersonas personas = new clsListadoPersonas();
            _listadoPersonas = personas.personas;
            _listadoAuxiliar = personas.personas;
            _textoBusqueda = "";
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

        public ObservableCollection<clsPersona> listadoAuxiliar
        {
            get
            {
                return _listadoAuxiliar;
            }

            set
            {
                _listadoAuxiliar = value;
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
                _saveCommand.RaiseCanExecuteChanged();
               NotifyPropertyChanged("personaSeleccionada");
            }
        }

        public String textoBusqueda
        {
            get
            {
               return _textoBusqueda;
            }

            set
            {
                _textoBusqueda = value;
                _buscarCommand.RaiseCanExecuteChanged();
                //NotifyPropertyChanged("textoBusqueda");
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

        public DelegateCommand saveCommand
        {
            get
            {
                _saveCommand = new DelegateCommand(save, canSave);
                return _saveCommand;
    }

            set
            {
                _saveCommand = value;
            }
        }

        public DelegateCommand addCommand
        {
            get
            {
                _addCommand = new DelegateCommand(add);
                return _addCommand;
            }

            set
            {
                _addCommand = value;
            }
        }

        public DelegateCommand buscarCommand
        {
            get
            {
                _buscarCommand = new DelegateCommand(buscar, puedeBuscar);
                return _buscarCommand;
            }

            set
            {
                _buscarCommand = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo dedicado a comprobar si se puede borrar un item
        /// </summary>
        /// <returns>boolean</returns>
        public bool puedeBorrar()
        {
            bool puede = false;

            if (_personaSeleccionada != null)
            {
                puede = true;
            }

            return puede;
        }

        /// <summary>
        /// Metodo dedicado a borrar un item de la lista
        /// </summary>
        public void borrar()
        {
            listado.Remove(_personaSeleccionada);
        }

        /// <summary>
        /// Metodo que comprueba si se puede guardar
        /// </summary>
        /// <returns>boolean</returns>
        public bool canSave()
        {
            bool puede = false;

            if (_personaSeleccionada != null)
            {
                puede = true;
            }

            return puede;
        }

        /// <summary>
        /// Metodo dedicado a guardar una nueva persona creada
        /// </summary>
        public void save()
        {
            if (_personaSeleccionada.idPersona == 0)
            {
                _personaSeleccionada.idPersona = listado.ElementAt(listado.Count - 1).idPersona + 1;
                NotifyPropertyChanged("personaSeleccionada");
                listado.Add(_personaSeleccionada);
                NotifyPropertyChanged("listado");
            }
        }

        /// <summary>
        /// Metodo que crea una persona nueva
        /// </summary>
        public void add()
        {
            _personaSeleccionada = new clsPersona();
            NotifyPropertyChanged("personaSeleccionada");
        }

        public void buscar()
        {
            listadoAuxiliar = new ObservableCollection<clsPersona> ();

            for (int i = 0; i < listado.Count; i++)
            {
                if (listado[i]._nombre.ToLower().Contains (textoBusqueda.ToLower ()))
                {
                    listadoAuxiliar.Add(listado[i]);
                    NotifyPropertyChanged("listadoAuxiliar");
                }
            }
        }

        public bool puedeBuscar()
        {
            bool puede = false;

            if (textoBusqueda.Length > 0)
            {
                puede = true;
            }

            else
            {
                _listadoAuxiliar = listado;
                NotifyPropertyChanged("listadoAuxiliar");
            }

            return puede;
        }
        #endregion
    }
}
