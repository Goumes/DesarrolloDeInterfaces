using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Binding2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using _13_DataContext.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Binding2.DAL;

using System.Globalization;
using Windows.UI.ViewManagement;

namespace Binding2.ViewModels
{
    public class clsMainPageVM : clsVMBase 
    {
        private bool _progressring;
        private clsPersona _personaSeleccionada;
        private ObservableCollection<clsPersona> _lista;
        private DelegateCommand _guardarCommand;
        private DelegateCommand _addCommand;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _buscarCommand;

        public String textoaBuscar { get; set; }

        public clsMainPageVM()
        {
            progessring = true;
            //Llamamos a un metodo asíncrono
            rellenaLista();
            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
            _guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecuted);
            _addCommand = new DelegateCommand(addCommand_Executed);
            
        }

        #region getters&setters
        public bool progessring
        {
            get
            {
                return this._progressring;
            }
            set
            {
                this._progressring = value;
                NotifyPropertyChanged("progessring");
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
                _guardarCommand.RaiseCanExecuteChanged();
                _addCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");


         

            }
        }
        public DelegateCommand guardarCommand
        {
            get
            {

                return _guardarCommand;
            }


        }

        public DelegateCommand addCommand
        {
            get
            {

                return _addCommand;
            }
        }
        public DelegateCommand EliminarCommand
        {
            get
            {
                
                return _eliminarCommand;
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

        public ObservableCollection<clsPersona> lista
        {
            get
            {
                return this._lista;
            }
            set
            {
                this._lista = value;
                NotifyPropertyChanged("lista");
                
            }
        }
        #endregion
        #region funciones

        /// <summary>
        ///  Metodo para comprobar si puede ejecutarse el comando De eliminar
        /// </summary>
        /// <returns></returns>
        private bool EliminarCommand_CanExecuted()
        {
            bool sePuedeBorrar = false;

            if (_personaSeleccionada != null && _personaSeleccionada.id!=-1){ sePuedeBorrar = true; }
            return sePuedeBorrar;
        }

        /// <summary>
        /// Metodo para eliminar a una persona
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            
            ContentDialog dialogo = new ContentDialog();
            dialogo.Title = "Eliminar";
            dialogo.Content = "¿Está seguro de que sea borrar?";
            dialogo.PrimaryButtonText = "Cancelar";
            dialogo.SecondaryButtonText = "Aceptar";

            ContentDialogResult resultado = await dialogo.ShowAsync();

            if(resultado == ContentDialogResult.Secondary)
            {
                try
                {
                    ManejadoraPersona mp = new ManejadoraPersona();
                    mp.DeletePersona(personaSeleccionada.id);
                    
                    
                }
                catch (Exception)
                {

                }

                try
                {
                    
                    personaSeleccionada = null;
                    this.rellenaLista();
                    if (Window.Current.Bounds.Width <= 720)
                    {
                        ((Frame)Window.Current.Content).GoBack();
                    }
                }
                catch (Exception)
                {

                }
            }

        }

        private bool GuardarCommand_CanExecuted()
        {
            bool sePuedeGuardar = false;

            if (_personaSeleccionada != null) { sePuedeGuardar = true; }
            return sePuedeGuardar;
        }

        private async void GuardarCommand_Executed()
        {
            ManejadoraPersona mp = new ManejadoraPersona();
            if (personaSeleccionada.id == -1)
            {
                //Si el id es igua a -1 quiere decir que es una insercion
                mp.SavePersona(personaSeleccionada);
            }
            else
            {
                //si no una actualizacion
                mp.UpdatePerson(personaSeleccionada);
            }
           
            personaSeleccionada = null;

            lista = await new clsListado().getPersonas();
            NotifyPropertyChanged("lista");
            if (Window.Current.Bounds.Width <= 720)
            {
                ((Frame)Window.Current.Content).GoBack();
            }
        }

        private void addCommand_Executed()
        {
            personaSeleccionada = new clsPersona();
            
            NotifyPropertyChanged("personaSeleccionada");
        }

        private async void rellenaLista()
        {
            clsListado olistados = new clsListado();
            progessring = true;
            NotifyPropertyChanged("progessring");
            lista = await olistados.getPersonas();
            progessring = false;
            NotifyPropertyChanged("progessring");
            NotifyPropertyChanged("lista");
        }

        public async void buscarCommand_Executed()
        {
            try
            {
                clsListado olistados = new clsListado();
                lista = await olistados.getPersonas(textoaBuscar);
                NotifyPropertyChanged("lista");
            }
            catch(Exception)
            {

            }
            
           NotifyPropertyChanged("lista");
        }



        #endregion
    }
}
