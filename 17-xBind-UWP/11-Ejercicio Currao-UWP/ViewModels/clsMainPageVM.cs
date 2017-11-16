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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _11_Ejercicio_Currao_UWP.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        #region "Atributos"
        private ObservableCollection<clsPersona> _listadoPersonas;
        private clsPersona _personaSeleccionada;
        private int _indicePersonaSeleccionada;

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

            set
            {
                _listadoPersonas = value;
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

        public int indicePersonaSeleccionada
        {
            get
            {
                return _indicePersonaSeleccionada;
            }

            set
            {
                _indicePersonaSeleccionada = value;
            }
        }
        #endregion

        public void Borrar_Click (object sender, RoutedEventArgs e)
        {
            if (indicePersonaSeleccionada > -1)
            {
                listado.RemoveAt(indicePersonaSeleccionada);
                NotifyPropertyChanged("listado");
            }
        }

        /// <summary>
        /// Metodo dedicado a actualizar el binding de las propiedades de los atributos del grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Guardar_Click(object sender, RoutedEventArgs e)
        {
            /*
            this.txbNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txbApellidos.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txbFechaNacimiento.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txbTelefono.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txbDireccion.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            */
        }
    }
}
