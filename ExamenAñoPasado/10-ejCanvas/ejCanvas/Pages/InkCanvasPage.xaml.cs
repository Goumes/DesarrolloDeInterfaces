using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace ejCanvas.Pages
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
   
    public sealed partial class InkCanvasPage : Page
    {
        
        public InkCanvasPage()
        {
            this.InitializeComponent();


            miInkCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen; //lo del Pen no haria falta

            InkDrawingAttributes inkDrawingAttributes = new InkDrawingAttributes();
            inkDrawingAttributes.Color = Windows.UI.Colors.Blue;
            miInkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(inkDrawingAttributes);

            // miInkCanvas.Background = Brushes.LightGreen; NO FUNCIONA

            //esto sobra, pero es para ver como se pone en modo Inking o Erasing
            miInkCanvas.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Inking;

            

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.InkCanvasPage));
        }        
    }
}






//PARA GUARDAR IMAGEN CREADA y poner un Background (no me sale)
//This is working for me.Use the following markup to display an image as the background of an InkCanvas.
 
//<InkCanvas Name = "inkcanvas" >
//    < InkCanvas.Background >
//        < ImageBrush ImageSource="c:\..\..\someimage.jpg" />
//    </InkCanvas.Background>
//</InkCanvas>
 
//Draw some lines on it, the save the InkCanvas to disk, using the following code.Both the background image and the lines drawn are being saved.


//public static void SaveVisualToPNG(Visual visual, string filename)
//{
//    RenderTargetBitmap rtb = new RenderTargetBitmap(
//        (int)bounds.Width,
//        (int)bounds.Height,
//        96, 96, PixelFormats.Default);

//    rtb.Render(visual);

//    PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
//    pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

//    using (Stream stream = File.Create(filename))
//    {
//        pngEncoder.Save(stream);
//    }
//}
