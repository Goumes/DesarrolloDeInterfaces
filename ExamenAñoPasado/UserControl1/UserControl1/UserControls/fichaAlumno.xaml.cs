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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UserControl1.UserControls
{
    public sealed partial class fichaAlumno : UserControl
    {
        public fichaAlumno()
        {
            this.InitializeComponent();
        }


        public string StudentName
        {
            get { return (string)GetValue(StudentNameProperty); }
            set { SetValue(StudentNameProperty, value); }
        }
        public string StudentFirstName
        {
            get { return (string)GetValue(StudentFirstNameProperty); }
            set { SetValue(StudentFirstNameProperty, value); }
        }

        public ImageSource Foto
        {
            get { return (ImageSource)GetValue(FotoProperty); }
            set { SetValue(FotoProperty, value); }
        }


        // Using a DependencyProperty as the backing store for StudentName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StudentNameProperty =
            DependencyProperty.Register("StudentName", typeof(string), typeof(fichaAlumno), new PropertyMetadata("Nombre"));

        public static readonly DependencyProperty StudentFirstNameProperty =
          DependencyProperty.Register("StudentFirstName", typeof(string), typeof(fichaAlumno),   new PropertyMetadata("Apellidos"));

        public static readonly DependencyProperty FotoProperty =
          DependencyProperty.Register("Foto",  typeof(ImageSource), typeof(fichaAlumno),
              new PropertyMetadata(new BitmapImage(new Uri("ms-appx://_UserContol/fotos/logo.png"))));
    


    }
}
