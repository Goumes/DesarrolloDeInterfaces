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

            switch (ellipse.Name)
            {
                case "diferencia1_1":
                    diferencia1_1.Opacity = 100;
                    diferencia1_2.Opacity = 100;
                    numeroAciertos++;
                break;

               
                case "diferencia2_1":
                    diferencia2_1.Opacity = 100;
                    diferencia2_2.Opacity = 100;
                    numeroAciertos++;
                    break;

                case "diferencia3_1":
                    diferencia3_1.Opacity = 100;
                    diferencia3_2.Opacity = 100;
                    numeroAciertos++;
                    break;

                case "diferencia4_1":
                    diferencia4_1.Opacity = 100;
                    diferencia4_2.Opacity = 100;
                    numeroAciertos++;
                    break;

                case "diferencia5_1":
                    diferencia5_1.Opacity = 100;
                    diferencia5_2.Opacity = 100;
                    numeroAciertos++;
                    break;

                case "diferencia6_1":
                    diferencia6_1.Opacity = 100;
                    diferencia6_2.Opacity = 100;
                    numeroAciertos++;
                    break;

                case "diferencia7_1":
                    diferencia7_1.Opacity = 100;
                    diferencia7_2.Opacity = 100;
                    numeroAciertos++;
                    break;
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
