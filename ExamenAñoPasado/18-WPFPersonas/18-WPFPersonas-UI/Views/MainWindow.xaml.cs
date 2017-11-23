using _18_WPFPersonas_ViewModels;
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

namespace _18_WPFPersonas_UI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public clsMainPageVM ViewModel { get; }
        public MainWindow()
        {
            InitializeComponent();
            this.ViewModel = (clsMainPageVM)this.DataContext;
        }
        public void btnGuardar_Click(Object sender, RoutedEventArgs e)
        {
            txtNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtApellidos.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtFechaNacimiento.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtTelefono.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtDescripcion.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            lista.GetBindingExpression(ListView.ItemsSourceProperty).UpdateSource();
            
        }
    }
}
