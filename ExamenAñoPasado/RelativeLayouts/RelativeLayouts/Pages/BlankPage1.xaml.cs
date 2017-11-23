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

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace RelativeLayouts.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>


    public sealed partial class BlankPage1 : Page
    {
        private Boolean pintando;
        public BlankPage1()
        {
            
            this.InitializeComponent();
            lienzo.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse;
            lienzo.InkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Inking;


        }

        private void BotonBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (pintando)
            {
                lienzo.InkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Erasing;
                pintando = false;
            }
            else
            {
                lienzo.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse;
                pintando = true;

            }

            

        }

        private void BotonAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof( MainPage));
        }
    }
}
