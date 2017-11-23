using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWorldsWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string oracion = this.txtOracion.Text;
            int numerovocales=0;

            for(int i = 0; i < oracion.Length; i++)
            {
                if (oracion[i].Equals('a') || oracion[i].Equals('e') 
                    || oracion[i].Equals('i') || oracion[i].Equals('o') 
                    || oracion[i].Equals('u'))
                {
                    numerovocales++;
                }
            }
            //if (nombre != null && nombre != "")
            //Equivalente
          
                MessageBox.Show("Hay un total de " + numerovocales+ " vocales", "Numero de vocales",
                MessageBoxButton.OKCancel);
           
        }

        private void buttona_Click(object sender, RoutedEventArgs e)
        {
            String oracion = txtOracion.Text;
            int repeticiones=0;

            for(int i = 0; i < oracion.Length; i++)
            {
                if (oracion[i].Equals('a'))
                {
                    repeticiones++;
                }
            }

            MessageBox.Show("La letra a aparece, " + repeticiones+ " veces", "REPETICIONES VOCALES",
                MessageBoxButton.OKCancel);
        }

        private void buttone_Click(object sender, RoutedEventArgs e)
        {
            String oracion = txtOracion.Text;
            int repeticiones = 0;

            for (int i = 0; i < oracion.Length; i++)
            {
                if (oracion[i].Equals('e'))
                {
                    repeticiones++;
                }
            }

            MessageBox.Show("La letra e aparece, " + repeticiones + " veces", "REPETICIONES VOCALES",
                MessageBoxButton.OKCancel);
        }

        private void buttoni_Click(object sender, RoutedEventArgs e)
        {
            String oracion = txtOracion.Text;
            int repeticiones = 0;

            for (int i = 0; i < oracion.Length; i++)
            {
                if (oracion[i].Equals('i'))
                {
                    repeticiones++;
                }
            }

            MessageBox.Show("La letra i aparece, " + repeticiones + " veces", "REPETICIONES VOCALES",
                MessageBoxButton.OKCancel);
        }

        private void buttono_Click(object sender, RoutedEventArgs e)
        {
            String oracion = txtOracion.Text;
            int repeticiones = 0;

            for (int i = 0; i < oracion.Length; i++)
            {
                if (oracion[i].Equals('o'))
                {
                    repeticiones++;
                }
            }

            MessageBox.Show("La letra o aparece, " + repeticiones + " veces", "REPETICIONES VOCALES",
                MessageBoxButton.OKCancel);
        }

        private void buttonu_Click(object sender, RoutedEventArgs e)
        {
            String oracion = txtOracion.Text;
            int repeticiones = 0;

            for (int i = 0; i < oracion.Length; i++)
            {
                if (oracion[i].Equals('u'))
                {
                    repeticiones++;
                }
            }

            MessageBox.Show("La letra u aparece, " + repeticiones + " veces", "REPETICIONES VOCALES",
                MessageBoxButton.OKCancel);
        }
    }
}
