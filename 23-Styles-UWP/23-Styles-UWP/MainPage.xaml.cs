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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _23_Styles_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            AnimateProgressRingSlice(PhotoButtonRotateTransform.Angle + 9999999999);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Button button = (Button)sender;
            /*
            RotateTransform m_transform = new RotateTransform();
            button.RenderTransform = m_transform;

            for (int j = 0; j < 100; j++)
            {
                for (int i = 0; i < 360; i++)
                {
                    m_transform.Angle = i;
                }
            }
            */
            /*
            Binding miBinding = new Binding();
            miBinding.Source = btnLocura;
            miBinding.Path = new PropertyPath("Angle");
            BindingOperations.SetBinding(btnLocura2, RotateTransform.AngleProperty, miBinding);
            */

            switch (button.Name)
            {
                case "PhotoButtonRotateTransform":
                    AnimateProgressRingSlice(PhotoButtonRotateTransform.Angle + 9999999999);
                break;

                case "PhotoButtonRotateTransform2":
                    AnimateProgressRingSlice(PhotoButtonRotateTransform.Angle + 9999999999);
                    break;

                case "PhotoButtonRotateTransform3":
                    AnimateProgressRingSlice(PhotoButtonRotateTransform.Angle + 9999999999);
                    break;
            }
            
        }

        private void AnimateProgressRingSlice(double to, double miliseconds = 9999999999)
        {
            var storyboard = new Storyboard();
            var doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromMilliseconds(miliseconds);
            doubleAnimation.EnableDependentAnimation = true;
            doubleAnimation.To = to;
            Storyboard.SetTargetProperty(doubleAnimation, "Angle");
            Storyboard.SetTarget(doubleAnimation, PhotoButtonRotateTransform);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }
    }
}
