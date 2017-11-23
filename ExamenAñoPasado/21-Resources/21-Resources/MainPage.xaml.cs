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

namespace _21_Resources
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

        

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)e.OriginalSource;

            Random r = new Random();
            int i = r.Next(2);
            //for (int i = 0; i < Resources.Count; i++)
            //{
            b.Background = (Brush)Resources.ElementAt(i).Value;
            //}


            if (b.Content.Equals("Pulsa vera que guapo"))
            {
                b.Content = "Ta queao flipao a que ji";
            }
            else if (b.Content.Equals("Ta queao flipao a que ji"))
            {
                b.Content = "Deja de toca el botonsitooo";
            }
            else
            {
                b.Content = "CARA ANCHOA";
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.OriginalSource;
            Random rdm = new Random();

            byte a = (byte)rdm.Next(255);
            byte r = (byte)rdm.Next(255);
            byte g = (byte)rdm.Next(255);
            byte b = (byte)rdm.Next(255);

            LinearGradientBrush lgb = new LinearGradientBrush();
            GradientStop gs = new GradientStop();
            gs.Offset = 0;
            gs.Color = Windows.UI.Color.FromArgb(a,r,g,b);


            a = (byte)rdm.Next(255);
            r = (byte)rdm.Next(255);
            g = (byte)rdm.Next(255);
            b = (byte)rdm.Next(255);
            GradientStop gs2 = new GradientStop();
            gs.Offset = 1;
            gs.Color = Windows.UI.Color.FromArgb(a, r, g, b);

            GradientStopCollection gsc = new GradientStopCollection();
            gsc.Add(gs);
            gsc.Add(gs2);


            lgb.GradientStops = gsc;

            string nombre = rdm.Next().ToString();
            Resources.Add(nombre, lgb);

            for(int i=0; i < Resources.Count; i++)
            {
                if (Resources.ElementAt(i).Key.Equals(nombre))
                {
                    btn.Background = (Brush)Resources.ElementAt(i).Value;
                    
                }
            }
            
            
        }
    }
}
