using Examen_Alejandro_Gomez_Ejercicio_1_UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Examen_Alejandro_Gomez_Ejercicio_1_UWP.Views
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public MainPageVM ViewModel { get; }
        public int numeroAciertos { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
           // this.ViewModel = (MainPageVM)this.DataContext;
        }


        /// <summary>
        /// Metodo utilizado para comprobar si las diferencias son correctas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comprobarDiferencias(object sender, PointerRoutedEventArgs e)
        {
            Ellipse ellipse = (Ellipse) sender;

            if (ellipse.Opacity == 0)
            {
                ellipse.Opacity = 100;
                numeroAciertos++;
            }

            if (numeroAciertos == 7)
            {
                textoGanador.Visibility = Visibility.Visible;
                volverJugar();
            }
        }

        /// <summary>
        /// Metodo que pregunta si se quiere volver a jugar una partida
        /// </summary>
        public async void volverJugar()
        {

            ContentDialog volverAJugar = new ContentDialog();
            volverAJugar.Title = "Volver a jugar";
            volverAJugar.Content = "¿Desea volver a jugar?";
            volverAJugar.PrimaryButtonText = "Si";
            volverAJugar.SecondaryButtonText = "No";

            ContentDialogResult resultado = await volverAJugar.ShowAsync();

            if (resultado == ContentDialogResult.Primary)
            {

                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
