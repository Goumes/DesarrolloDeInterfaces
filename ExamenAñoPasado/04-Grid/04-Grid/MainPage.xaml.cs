using _04_Grid.Models;
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
using _04_Grid.Models;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _04_Grid
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private clsPersona persona;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string[] errores;
            clsUtilidades u = new clsUtilidades();

            errores = u.personaValida(txtNombre.Text, txtApellidos.Text, Fecha.Date);

            for (int i = 0; i < errores.Length; i++)
            {
                if (errores[i] != "")
                    switch (i)
                    {
                        case 0:
                            lblErrorNombre.Text = errores[i];
                            break;
                        case 1:
                            lblErrorApellidos.Text = errores[i];
                            break;
                        case 2:
                            lblErrorFecha.Text = errores[i];
                            break;
                    }

                else
                {
                    switch (i)
                    {
                        case 0:
                            lblErrorNombre.Text = "";
                            break;
                        case 1:
                            lblErrorApellidos.Text = "";
                            break;
                        case 2:
                            lblErrorFecha.Text = "";
                            break;
                    }
                }
            }
        }







    }
}
