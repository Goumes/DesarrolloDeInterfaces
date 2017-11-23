using _05_PersonaModificada_ASP.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace _11_Ejercicio_Currao_UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Metodo dedicado a actualizar el binding de las propiedades de los atributos del grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.txbNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txbApellidos.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txbFechaNacimiento.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txbTelefono.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.txbDireccion.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
