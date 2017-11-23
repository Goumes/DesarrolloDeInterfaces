using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.ComponentModel;


using _18_WPFPersonas_Ent;
using System.Windows;
using _18_WPFPersonas_BL;

namespace _18_WPFPersonas_ViewModels
{
    public class clsMainPageVM:clsVMBase
    {
        private clsPersona _personaSeleccionada;
        private List<clsPersona> _lista;
        private String _listvisible;
        private String _btnnewvisible;

        private DelegateCommand _gotoMasterDetail;
        private DelegateCommand _gotoAnadir;

        private DelegateCommand _eliminarCommand;
        private DelegateCommand _buscarCommand;
        private DelegateCommand _anadirCommand;
        private DelegateCommand _actualizarCommand;
        
        

        private String textoaBuscar;

        public clsMainPageVM()
        {
            //lista = new clsListado().list;
            lista = new clsListadosPersonasBL().getListadoPersonaBL();

            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
            _gotoAnadir = new DelegateCommand(GotoAnadir_Executed);
            _anadirCommand = new DelegateCommand(AnadirCommand_Executed, AnadirCommand_CanExecuted);
            _gotoMasterDetail = new DelegateCommand(GotoMasterDetail_Executed);
            _actualizarCommand = new DelegateCommand(ActualizarCommand_Executed, ActualizarCommand_CanExecuted);

            _btnnewvisible = "Collapsed";
            _listvisible = "Visible";
            
        }





        #region getters&setters
        public String listvisible
        {
            get
            {
                return _listvisible;
            }
            set
            {
                this._listvisible = value;
                NotifyPropertyChanged("listvisible");
            }
        }

        public String btnnewvisible
        {
            get
            {
                return _btnnewvisible;
            }
            set
            {
                this._btnnewvisible = value;
                NotifyPropertyChanged("btnnewvisible");
            }
        }

        public clsPersona  personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }

            set
            {
                _personaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                _actualizarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");

            }
        }

        public DelegateCommand EliminarCommand
        {
            get
            {
                
                return _eliminarCommand;
            }

        
        }

        public DelegateCommand AnadirCommand
        {
            get
            {
                return _anadirCommand;
            }
        }

        public DelegateCommand gotoAnadir
        {
            get
            {
                return this._gotoAnadir;
            }
        }

        public DelegateCommand actualizarCommand
        {
            get
            {
                return this._actualizarCommand;
            }
        }

        public DelegateCommand gotoMasterDetail
        {
            get
            {
                return this._gotoMasterDetail;
            }
        }

        public DelegateCommand buscarCommand
        {
            get
            {
                _buscarCommand = new DelegateCommand(buscarCommand_Executed);
                return _buscarCommand;
            }
        }

        public List<clsPersona> lista
        {
            get
            {
                return this._lista;
            }
            set
            {
                this._lista = value;
                NotifyPropertyChanged("_lista");
                
            }
        }
        #endregion

        #region funciones

        private bool EliminarCommand_CanExecuted()
        {
            bool sePuedeBorrar = false;

            if (_personaSeleccionada != null){ sePuedeBorrar = true; }
            return sePuedeBorrar;
        }

        private void EliminarCommand_Executed()
        {
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();

            try
            {
                if (MessageBox.Show("Confirma borrar la persona?", "Confirmar borrado", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    cmpb.deletePersona(_personaSeleccionada.id);
                    lista = new clsListadosPersonasBL().getListadoPersonaBL();
                    personaSeleccionada = null;
                    NotifyPropertyChanged("lista");
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        private void GotoAnadir_Executed()
        {

            listvisible = "Collapsed";
            btnnewvisible = "Visible";
            

            NotifyPropertyChanged("btnnewvisible");
            NotifyPropertyChanged("listvisible");
            

            personaSeleccionada = new clsPersona();
        }

        private void GotoMasterDetail_Executed()
        {
            listvisible = "Visible"; 
             btnnewvisible = "Collapsed";


            NotifyPropertyChanged("btnnewvisible");
            NotifyPropertyChanged("listvisible");


            personaSeleccionada = null;
        }

        public void buscarCommand_Executed()
        {
            if (!String.IsNullOrEmpty(textoaBuscar))
            {
                var listarFiltrada = from p in _lista where p.nombre.StartsWith(textoaBuscar) select p;
                lista = new List<clsPersona>(listarFiltrada);
            }
            else
            {
                lista = new List<clsPersona>(lista);
            }
            
           NotifyPropertyChanged("lista");
        }

        private bool AnadirCommand_CanExecuted()
        {
            return true;
        }

        private void AnadirCommand_Executed()
        {
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();
            try{
                    cmpb.insertPerson(personaSeleccionada);
               
                
                    listvisible = "Visible";
                    btnnewvisible = "Collapsed";

                    NotifyPropertyChanged("btnnewvisible");
                    NotifyPropertyChanged("listvisible");
                
                    lista = new clsListadosPersonasBL().getListadoPersonaBL();
                    NotifyPropertyChanged("lista");
                }
                catch (Exception )
                {
                    MessageBox.Show("Error con la bbdd");
                }
        }

        private bool ActualizarCommand_CanExecuted()
        {
            bool posible = false;
            if(personaSeleccionada!= null){
                posible = true;
            }
            return posible;
        }

        private void ActualizarCommand_Executed()
        {
            clsManejadoraPersonaBL cmpb = new clsManejadoraPersonaBL();
            try
            {
                cmpb.updatePerson(personaSeleccionada);
                lista = new clsListadosPersonasBL().getListadoPersonaBL();
                NotifyPropertyChanged("lista");

            }
            catch (Exception)
            {
                MessageBox.Show("Error con la BBDD");
            }

        }

        #endregion
    }
}
