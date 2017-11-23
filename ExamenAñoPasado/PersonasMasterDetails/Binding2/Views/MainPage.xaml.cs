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
using _Binding2.Models;
using System.Collections.ObjectModel;
using Binding2.Views;
using Windows.UI.Xaml.Media.Animation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Binding2
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = (ViewModels.clsMainPageVM) this.DataContext;
           
        }

        public ViewModels.clsMainPageVM ViewModel { get; }

        //private void lista_RightTapped(object sender, RightTappedRoutedEventArgs e)
        //{
        //    ListView listView = (ListView)sender;
        //    //listView.SelectedIndex = e.GetPosition;
            

        //   // allContactsMenuFlyout.ShowAt(listView,e.getPostion(listView));
        //}

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtApellidos.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtFechaNacimiento.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtTelefono.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtDireccion.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            lista.GetBindingExpression(ListView.ItemsSourceProperty).UpdateSource();



            if (VisualStateGroup.CurrentState == pantallaPequenia)
            //            if(this.Width<720)
            {
                // Use "drill in" transition for navigating from master list to detail view
                Frame.Navigate(typeof(Detail), null , new DrillInNavigationTransitionInfo());
            }

        }

        private void lista_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (VisualStateGroup.CurrentState == pantallaPequenia)
            //            if(this.Width<720)
            {
                // Use "drill in" transition for navigating from master list to detail view
                Frame.Navigate(typeof(Detail), e.ClickedItem, new DrillInNavigationTransitionInfo());
            }

        }


        private void VisualStateGroup_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }

        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == pantallaPequenia;
            
            clsPersona p = ViewModel.personaSeleccionada;

            if (isNarrow && oldState == pantallaGrande &&  p!= null)
            {
                // Resize down to the detail item. Don't play a transition.
                Frame.Navigate(typeof(Detail), p, new SuppressNavigationTransitionInfo());
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(lista, isNarrow);
           
        }

     
    }
   
}
