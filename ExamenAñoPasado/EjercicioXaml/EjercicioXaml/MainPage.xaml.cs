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

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EjercicioXaml
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Button boton;
        public MainPage()
        {
            
            
            this.InitializeComponent();
            this.cargarPagina();



        }
        /// <summary>
        /// Breve comentario: Creamos un boton , se lo asignamos al Grid y le añado los Clicks
        ///                     de los botones.
        /// Precondiciones: Los componentes deben estar inicializados
        /// Entradas:Nada
        /// Salidas:Nada
        /// PostCondiciones: Nada
        /// </summary>
        public void cargarPagina()
        {
            Grid padre = Grid;
            boton = new Button();
            boton.Name = "btn3";
            boton.Content = "Boton 3";
            boton.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Blue);
            boton.FontWeight = Windows.UI.Text.FontWeights.Bold;
            boton.HorizontalAlignment = HorizontalAlignment.Center;
            boton.VerticalAlignment = VerticalAlignment.Center;
            boton.Width = 200;
            boton.Height = 70;
            boton.FontFamily =new FontFamily("Verdana");
            boton.FontSize = 16;
            boton.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Yellow);

            padre.Children.Add(boton);

            boton.Click += new RoutedEventHandler(Click1);
            Btn1.Click += new RoutedEventHandler(Click1);
            Btn2.Click += new RoutedEventHandler(Click1);



        }

        public void Click1(Object sender,RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(  btn.Name== Btn1.Name)
            {
                Grid.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red);
            }

            else if (btn.Name == Btn2.Name)
            {
                Grid.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Beige);
            }
            else
            {
                Grid.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Violet);
            }
            
        }
    }
}
