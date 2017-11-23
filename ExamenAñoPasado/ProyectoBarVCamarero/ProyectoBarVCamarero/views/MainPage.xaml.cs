using ProyectoBarVCamarero.bl;
using ProyectoBarVCamarero.models;
using ProyectoBarVCamarero.viewModel;
using ProyectoBarVCamarero.views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProyectoBarVCamarero
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = (clsMainPageVM)this.DataContext;
        }
        public clsMainPageVM ViewModel { get; }


        private void VisualStateGroup_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }

        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {


            //var isNarrow = newState == pantallaPequenia;

            //clsPersona p = ViewModel.personaSeleccionada;

            //if (isNarrow && oldState == pantallaGrande && p != null)
            //{
                // Resize down to the detail item. Don't play a transition.
               // Frame.Navigate(typeof(TablePage), p, new SuppressNavigationTransitionInfo());
            //}

            //EntranceNavigationTransitionInfo.SetIsTargetElement(lista, isNarrow);

        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (VisualStateGroup.CurrentState == pantallaPequenia)
            //            if(this.Width<720)
            //{
            // Use "drill in" transition for navigating from master list to detail view
            this.GridViewMesas.IsActiveView = false;
            ViewModel.mesaSeleccionada =(Mesa) e.ClickedItem;
            Frame.Navigate(typeof(TablePage), ViewModel, new DrillInNavigationTransitionInfo());
            //}
        }

        private void añadirCategoria_Click(object sender, RoutedEventArgs e)
        {
            gridDatosCat.Visibility = Visibility.Visible;
            AñadirCategoriaAcept.Visibility = Visibility.Visible;
            EditarCategoriaAcept.Visibility = Visibility.Collapsed;

            gridDatosPro.Visibility = Visibility.Collapsed;
            AñadirProductoAccept.Visibility = Visibility.Collapsed;
            EditarProductoAccept.Visibility = Visibility.Collapsed;

            
            
            
            txtNombreCat.Text = "";
        }

        private void editarCategoria_Click(object sender, RoutedEventArgs e)
        {
            gridDatosCat.Visibility = Visibility.Visible;
            AñadirCategoriaAcept.Visibility = Visibility.Collapsed;
            EditarCategoriaAcept.Visibility = Visibility.Visible;

            gridDatosPro.Visibility = Visibility.Collapsed;
            AñadirProductoAccept.Visibility = Visibility.Collapsed;
            EditarProductoAccept.Visibility = Visibility.Collapsed;
            txtNombreCat.Text = ViewModel.categoriaSeleccionada.nombre;

            
        }


        private void verInformacion_Click(object sender, RoutedEventArgs e)
        {
            gridDatosCat.Visibility = Visibility.Collapsed;
            AñadirCategoriaAcept.Visibility = Visibility.Collapsed;
            EditarCategoriaAcept.Visibility = Visibility.Collapsed;

            gridDatosPro.Visibility = Visibility.Visible;
            AñadirProductoAccept.Visibility = Visibility.Collapsed;
            EditarProductoAccept.Visibility = Visibility.Collapsed;

            txtCategoria.Visibility = Visibility.Visible;
            comboCategoria.Visibility = Visibility.Collapsed;

            txtNombrePro.Text = ViewModel.productoSeleccionado.nombre;
            txtNombrePro.IsReadOnly = true;
            txtCategoria.Text = ViewModel.getNombreCatxId(ViewModel.productoSeleccionado.idcategoria).nombre;
            txtPrecioPro.Text = ViewModel.productoSeleccionado.precio.ToString();
            txtPrecioPro.IsReadOnly = true;

        }

        private void editarInformacion_Click(object sender, RoutedEventArgs e)
        {

            gridDatosCat.Visibility = Visibility.Collapsed;
            AñadirCategoriaAcept.Visibility = Visibility.Collapsed;
            EditarCategoriaAcept.Visibility = Visibility.Collapsed;

            gridDatosPro.Visibility = Visibility.Visible;
            AñadirProductoAccept.Visibility = Visibility.Collapsed;
            EditarProductoAccept.Visibility = Visibility.Visible;

            txtCategoria.Visibility = Visibility.Collapsed;
            comboCategoria.Visibility = Visibility.Visible;

            txtNombrePro.Text = ViewModel.productoSeleccionado.nombre;
            txtNombrePro.IsReadOnly = false;
            comboCategoria.ItemsSource = ViewModel.listCategorias;
            comboCategoria.SelectedItem = ViewModel.categoriaSeleccionada;
            txtPrecioPro.Text = ViewModel.productoSeleccionado.precio.ToString();
            txtPrecioPro.IsReadOnly = false;

        }

        private void añadirProducto_Click(object sender, RoutedEventArgs e)
        {
            gridDatosCat.Visibility = Visibility.Collapsed;
            AñadirCategoriaAcept.Visibility = Visibility.Collapsed;
            EditarCategoriaAcept.Visibility = Visibility.Collapsed;

            gridDatosPro.Visibility = Visibility.Visible;
            AñadirProductoAccept.Visibility = Visibility.Visible;
            EditarProductoAccept.Visibility = Visibility.Collapsed;

            txtCategoria.Visibility = Visibility.Collapsed;
            comboCategoria.Visibility = Visibility.Visible;

            txtPrecioPro.IsReadOnly = false;
            txtNombrePro.IsReadOnly = false;

            txtNombrePro.Text = "";
            comboCategoria.ItemsSource = ViewModel.listCategorias;
            comboCategoria.SelectedItem = ViewModel.categoriaSeleccionada;
            txtPrecioPro.Text = "";
        }

        private void AñadirCategoriaAcept_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.categoriaaAñadir = new Categoria(-1, txtNombreCat.Text, 1);
        }

        private void EditarCategoriaAcept_Click(object sender, RoutedEventArgs e)
        {

            ViewModel.categoriaSeleccionada.nombre = txtNombreCat.Text;
            txtNombreCat.GetBindingExpression(TextBox.TextProperty).UpdateSource();


        }

        private async void GridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (e.OriginalSource is Image)
            {
                await ViewModel.obtenerCuentaxmesa(((Mesa)((Image)e.OriginalSource).DataContext).Nummesa);
                
                if (ViewModel.cuentaSeleccionada == null)
                {
                    ContentDialog dialogo = new ContentDialog();
                    dialogo.Title = "Eliminar mesa";
                    dialogo.Content = "¿Está seguro de que desea eliminar la mesa?";
                    dialogo.PrimaryButtonText = "Cancelar";
                    dialogo.SecondaryButtonText = "Aceptar";

                    ContentDialogResult resultado = await dialogo.ShowAsync();
                    if (resultado == ContentDialogResult.Secondary)
                    {
                        MesaBL mb = new MesaBL();
                        if (await mb.deletemesa(((Mesa)((Image)e.OriginalSource).DataContext).Nummesa))
                            ViewModel.obtenerMesas();
                    }
                }

            }
        }


        private void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridDatosCat.Visibility = Visibility.Collapsed;
            AñadirCategoriaAcept.Visibility = Visibility.Collapsed;
            EditarCategoriaAcept.Visibility = Visibility.Collapsed;

            gridDatosPro.Visibility = Visibility.Collapsed;
            AñadirProductoAccept.Visibility = Visibility.Collapsed;
            EditarProductoAccept.Visibility = Visibility.Collapsed;

            txtCategoria.Visibility = Visibility.Collapsed;
            comboCategoria.Visibility = Visibility.Collapsed;

            
        }

        private void EditarProductoAccept_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.productoSeleccionado.nombre = txtNombrePro.Text;
            ViewModel.productoSeleccionado.precio = double.Parse(txtPrecioPro.Text);
            ViewModel.productoSeleccionado.idcategoria = ((Categoria)comboCategoria.SelectedItem).idCategoria;
        }

        private void AñadirProductoAccept_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.productoaAñadir = new Producto(-1, txtNombrePro.Text,double.Parse(txtPrecioPro.Text), ((Categoria)comboCategoria.SelectedItem).idCategoria,1);
        }

        private void txtPrecioPro_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            bool contienecoma = false;
            if (((TextBox)sender).Text.Length == 0)
            {
                if (e.Key.ToString().Equals("188"))
                {
                    txtPrecioPro.Text = "0,";
                }
                EditarProductoAccept.IsEnabled = true;
                AñadirProductoAccept.IsEnabled = true;
            }
            

            for (int i = 0; i < ((TextBox)sender).Text.Length && !contienecoma; i++)
            {
                if (((TextBox)sender).Text.ElementAt(i).ToString().Equals(","))
                    contienecoma = true;
            }

            if (e.Key.ToString().Equals("Back"))
            {
                if ((((TextBox)sender).Text).Length == 0)
                {
                    EditarProductoAccept.IsEnabled = false;
                    AñadirProductoAccept.IsEnabled = false;
                }
                
                e.Handled = false;

                return;
            }
            for (int i = 0; i < 10; i++)
            {
                if (e.Key.ToString() == string.Format("Number{0}", i) || e.Key.ToString() == string.Format("NumberPad{0}", i) || (e.Key.ToString().Equals("188") && !contienecoma) )
                {

                    e.Handled = false;
                    return;
                }
            }
            e.Handled = true;
        }

        private void txtNombrePro_KeyDown(object sender, KeyRoutedEventArgs e)
        {
           if (((TextBox)sender).Text.Length == 0)
            {
                
                EditarProductoAccept.IsEnabled = true;
                AñadirProductoAccept.IsEnabled = true;
            }

            if (e.Key.ToString().Equals("Back"))
            {
                if ((((TextBox)sender).Text).Length == 0)
                {
                    EditarProductoAccept.IsEnabled = false;
                    AñadirProductoAccept.IsEnabled = false;
                }

                e.Handled = false;

                return;
            }


       }



        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.productoSeleccionado = null;
            ViewModel.categoriaSeleccionada = null;
            ViewModel.productodesSeleccionado = null;
            ViewModel.categoriadesSeleccionada = null;
            ViewModel.obtenerCategorias();
            ViewModel.obtenerCategoriasdes();
            ViewModel.obtenerProductosdes();
        }

        private void GridView_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ViewModel.cuentaSeleccionada = (Cuenta)e.ClickedItem;
            Frame.Navigate(typeof(CuentaNoFinalizada), ViewModel, new DrillInNavigationTransitionInfo());
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            
            comboCategoria.ItemsSource = ViewModel.listCategorias;
            comboCategoria.SelectedItem = ViewModel.categoriaSeleccionada;
            
            

        }

        private void EditarCategoriaCancel_Click(object sender, RoutedEventArgs e)
        {

            gridDatosCat.Visibility = Visibility.Collapsed;
            AñadirCategoriaAcept.Visibility = Visibility.Collapsed;
            EditarCategoriaAcept.Visibility = Visibility.Collapsed;

            gridDatosPro.Visibility = Visibility.Collapsed;
            AñadirProductoAccept.Visibility = Visibility.Collapsed;
            EditarProductoAccept.Visibility = Visibility.Collapsed;

            txtCategoria.Visibility = Visibility.Collapsed;
            comboCategoria.Visibility = Visibility.Collapsed;
        }
    }
}
