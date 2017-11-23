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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UserControl1
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static int columna=0;
        private static int fila=0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        public void insertarFicha(String nombre,String apellidos,String uri)
        {
            UserControls.fichaAlumno newAlumno = new UserControls.fichaAlumno();
            
            newAlumno.StudentName = nombre;
            //Creamos el UserControl
            newAlumno.StudentFirstName = apellidos;
            try
            {
                BitmapImage image = image = new BitmapImage(new Uri(uri, UriKind.Absolute));
                newAlumno.Foto = image;
                
            }
            catch (Exception)
            {
                
            }
            
            
            newAlumno.HorizontalContentAlignment = HorizontalAlignment.Center;
            //Añadimos una fila
            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(1,GridUnitType.Star);


            RowDefinitionCollection coleccionfilas = gridUserControls.RowDefinitions;

            //Le asignamos a la vista el user control
            gridUserControls.Children.Add(newAlumno);


            Grid.SetColumn(newAlumno, columna);
            Grid.SetRow(newAlumno, fila);
            if (columna == 2)
            {
                fila += 1;
                columna = 0;
                coleccionfilas.Add(row);
                

            }
            else
            {
                
                columna += 1;
            }

            
            


        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text!="" && txtApellidos.Text!="" 
                && txturlfoto.Text!="" )
                this.insertarFicha(txtName.Text, txtApellidos.Text, txturlfoto.Text );
            else
            {
                if (txtName.Text=="")
                {
                    txtName.PlaceholderText = "Este campo no puede estar vacio";
                }
                if(txtApellidos.Text == "")
                {
                    txtApellidos.PlaceholderText = "Este campo no puede estar vacio";
                }
                if(txturlfoto.Text == "" )
                {
                    txturlfoto.PlaceholderText = "Este campo no puede estar vacio";
                }
                

            }
        }
    }
}
