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


// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _20_RoutedEvents
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Rectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if(e.GetType() == typeof(Rectangle))
            {
                Rectangle rect = (Rectangle)e.OriginalSource;

                txt1.Text = "Llamado desde el rectangulo : "+rect.Name+" . El sender es: "+sender.ToString();
            }
          
        }

        private void StackPanel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (e.GetType() == typeof(Rectangle))
            {
                Rectangle rect = (Rectangle)e.OriginalSource;

                txt1.Text = "Llamado desde el rectangulo : " + rect.Name + " . El sender es: " + sender.ToString();
            }
        }
    }
}
