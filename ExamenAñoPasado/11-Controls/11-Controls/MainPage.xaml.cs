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

namespace _11_Controls
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();

            CalendarView calendario = Inicio;
            CalendarView calendario2 = Fin;
            calendario.MinDate = new DateTimeOffset(DateTime.Now);
            

        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            switch (boton.Name)
            {
                case "go":
                    if (si.IsChecked==true)
                    {
                        texto.Text = "Ha pulsado si.";
                    }
                    else if(no.IsChecked == true)
                    {
                        texto.Text = "Ha pulsado no.";
                    }
                    else if(alomejor.IsChecked == true)
                    {
                        texto.Text = "Ha pulsado a lo mejor.";
                    }
                    break;
            }

        }
        
        private void SeleccionarFechaInicio(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            
            Fin.MinDate=sender.SelectedDates.ElementAt(0).AddDays(1);
            
            
        }

        private void SeleccionarFechaFin(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            
            int dias = (Fin.SelectedDates.ElementAt(0) - Inicio.SelectedDates.ElementAt(0)).Days;
            diferenciaFechas.Text = "Va a reservar "+dias.ToString()+" días";
        }
    }
}
