using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ControlDeslizante
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int valueinstaller;
        
        public MainPage()
        {
            this.InitializeComponent();
            //Uri pathUri = new Uri("appx:///Videos/requiem.mp4");
            //mediaSimple.Source = MediaSource.CreateFromUri(pathUri);
            




            //ElementSoundPlayer.Volume = slider.ValueChanged;

        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {


            ElementSoundPlayer.Volume = ((Slider)sender).Value / 100f;
        }

        private async void botonplay_Click(object sender, RoutedEventArgs e)
        {
   
          await SetLocalMedia();
         }

        async private System.Threading.Tasks.Task SetLocalMedia()
        {
            FileOpenPicker openPicker = new FileOpenPicker();

            openPicker.FileTypeFilter.Add(".wmv");
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".wma");
            openPicker.FileTypeFilter.Add(".mp3");

            StorageFile file = await openPicker.PickSingleFileAsync();

            
            if (file != null)
            {
                mediaSimple.Source = MediaSource.CreateFromStorageFile(file);

                mediaSimple.MediaPlayer.Play();
            }
        }

        private void install_Click(object sender, RoutedEventArgs e)
        {
            valueinstaller = 0;
            install.Visibility = Visibility.Collapsed;
            Instalando.Visibility = Visibility.Visible;
            Clickforinstall.Visibility = Visibility.Visible;
        }

        private void Clickforinstall_Click(object sender, RoutedEventArgs e)
        {
            valueinstaller += 20;
            Instalando.Value = valueinstaller;
            if (valueinstaller == 100)
            {
                Instalando.Visibility = Visibility.Collapsed;
                Clickforinstall.Visibility = Visibility.Collapsed;
                instalado.Visibility = Visibility.Visible;
            }
                
        }

        private void buscaCamara_Click(object sender, RoutedEventArgs e)
        {
            buscando.Visibility = Visibility.Visible;
            buscaCamara.Visibility = Visibility.Collapsed;
            txtbuscando.Visibility = Visibility.Visible;
            encontrado.Visibility = Visibility.Visible;
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 10);
        }

        private void encontrado_Click(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 10);
            buscando.Visibility = Visibility.Collapsed;
            encontrado.Visibility = Visibility.Collapsed;
            txtbuscando.Visibility = Visibility.Collapsed;
            txtencontrado.Visibility = Visibility.Visible;
        }

        private void ConectServer_Click(object sender, RoutedEventArgs e)
        {
            ConectServer.Visibility = Visibility.Collapsed;
            conectado.Visibility = Visibility.Visible;
            progressring.IsActive = true;
        }

        private void conectado_Click(object sender, RoutedEventArgs e)
        {
            progressring.IsActive = false;
            conectado.Visibility = Visibility.Collapsed;
            felicidades.Visibility = Visibility.Visible;
        }
    }
}
