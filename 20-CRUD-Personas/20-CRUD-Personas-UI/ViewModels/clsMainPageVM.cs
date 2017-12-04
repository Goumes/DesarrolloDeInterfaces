using _20_CRUD_Personas_BL.Listados;
using _20_CRUD_Personas_BL.Manejadoras;
using _20_CRUD_Personas_ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUD_Personas_UI.ViewModels
{
    public class clsMainPageVM : clsVMBase
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
        public clsMainPageVM()
        {
            clsListadoPersonasBL listadoPersonasBL = new clsListadoPersonasBL();
            _listadoPersonas = new ObservableCollection <clsPersona> (listadoPersonasBL.getListadoPersonasBL());
            _listadoAuxiliar = _listadoPersonas;
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
                NotifyPropertyChanged("listadoAuxiliar");
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
            clsGestoraPersonaBL gestoraPersonaBL = new clsGestoraPersonaBL();
            clsListadoPersonasBL listadoPersonasBL = new clsListadoPersonasBL();
            gestoraPersonaBL.getBorrarPersona(personaSeleccionada.idPersona);
            _listadoAuxiliar = new ObservableCollection <clsPersona> (listadoPersonasBL.getListadoPersonasBL());
            NotifyPropertyChanged("listadoAuxiliar");
            //listado.Remove(_personaSeleccionada);
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
            listadoAuxiliar = new ObservableCollection<clsPersona>();

            for (int i = 0; i < listado.Count; i++)
            {
                if (listado[i].nombre.ToLower().Contains(textoBusqueda.ToLower()))
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
