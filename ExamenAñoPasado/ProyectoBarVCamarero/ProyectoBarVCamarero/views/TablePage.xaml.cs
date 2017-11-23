
using ProyectoBarVCamarero.models;
using ProyectoBarVCamarero.viewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Printing;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Printing;




// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProyectoBarVCamarero.views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    /// 



    public sealed partial class TablePage : Page
    {
        private bool imprimirCuenta;
        private PrintManager printMan;
        private PrintDocument printDoc;
        private IPrintDocumentSource printDocSource;
        

        public TablePage()
        {
            imprimirCuenta = false;
            this.InitializeComponent();
            editarInformacion.IsEnabled = true;
            
        }
        public clsMainPageVM ViewModel { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel = (clsMainPageVM)e.Parameter;
            //add to image component
            this.DataContext = ViewModel;
            qrcodeImg.Source = this.generarqr(ViewModel.mesaSeleccionada.Codigo);
            
            txtNumMesa.Text = "Número de mesa: " + ViewModel.mesaSeleccionada.Nummesa;




            // Register for hardware and software back request from the system
            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += TablePage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

        }

        /// <summary>
        /// This function unregisters the app for printing with Windows.
        /// </summary>
        public void UnregisterForPrinting()
        {
            if (printDoc == null)
            {
                return;
            }

            printDoc.Paginate -= Paginate;
            printDoc.GetPreviewPage -= GetPreviewPage;
            printDoc.AddPages -= AddPages;

            // Remove the handler for printing initialization.
            PrintManager printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested -= PrintTaskRequested;

            
        }

        private WriteableBitmap generarqr(String codigo)
        {
            WriteableBitmap qr = null;

            ZXing.IBarcodeWriter writer = new ZXing.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 300,
                    Width = 300
                }
            };

            var result = writer.Write(codigo);
            qr = result as WriteableBitmap;

            return qr;
        }

        private void Paginate(object sender, PaginateEventArgs e)
        {
            // As I only want to print one Rectangle, so I set the count to 1
            printDoc.SetPreviewPageCount(1, PreviewPageCountType.Final);
        }

        private void GetPreviewPage(object sender, GetPreviewPageEventArgs e)
        {


            // Provide a UIElement as the print preview.
            if (!imprimirCuenta)
                printDoc.SetPreviewPage(e.PageNumber, qrcodeImg);
            else
                printDoc.SetPreviewPage(e.PageNumber, paraImprimir);
        }





        private void AddPages(object sender, AddPagesEventArgs e)
        {
            if (!imprimirCuenta)
                printDoc.AddPage(qrcodeImg);
            else
                printDoc.AddPage(paraImprimir);
            // Indicate that all of the print pages have been provided
            printDoc.AddPagesComplete();
        }

   
        async private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {


            imprimirCuenta = false;
            printMan = PrintManager.GetForCurrentView();
            try
            {
                printMan.PrintTaskRequested += PrintTaskRequested;
            }
            catch
            {
                UnregisterForPrinting();
                printMan.PrintTaskRequested += PrintTaskRequested;
            }


            // Build a PrintDocument and register for callbacks

            printDoc = new PrintDocument();
            printDocSource = printDoc.DocumentSource;
            printDoc.Paginate += Paginate;
            printDoc.GetPreviewPage += GetPreviewPage;
            printDoc.AddPages += AddPages;

            
            if (PrintManager.IsSupported())
            {
                try
                {
                    // Show print UI
                    await PrintManager.ShowPrintUIAsync();
                }
                catch
                {
                    // Printing cannot proceed at this time
                    ContentDialog noPrintingDialog = new ContentDialog()
                    {
                        Title = "Printing error",
                        Content = "\nSorry, printing can' t proceed at this time.",
                        PrimaryButtonText = "OK"
                    };
                    await noPrintingDialog.ShowAsync();
                }
            }
            else
            {
                // Printing is not supported on this device
                ContentDialog noPrintingDialog = new ContentDialog()
                {
                    Title = "Printing not supported",
                    Content = "\nSorry, printing is not supported on this device.",
                    PrimaryButtonText = "OK"
                };
                await noPrintingDialog.ShowAsync();
            }
        }
        private void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            // Create the PrintTask.
            // Defines the title and delegate for PrintTaskSourceRequested
            PrintTask printTask = null;
            printTask = args.Request.CreatePrintTask("Print", PrintTaskSourceRequrested);

            // Handle PrintTask.Completed to catch failed print jobs
            printTask.Completed += PrintTaskCompleted;
            
        }

        private void PrintTaskSourceRequrested(PrintTaskSourceRequestedArgs args)
        {
            // Set the document source.
            args.SetSource(printDocSource);
        }

        private async void PrintTaskCompleted(PrintTask sender, PrintTaskCompletedEventArgs args)
        {
            // Notify the user when the print operation fails.
            if (args.Completion == PrintTaskCompletion.Failed)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    ContentDialog noPrintingDialog = new ContentDialog()
                    {
                        Title = "Printing error",
                        Content = "\nSorry, failed to print.",
                        PrimaryButtonText = "OK"
                    };
                    await noPrintingDialog.ShowAsync();
                });
            }
        }



        private void TablePage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            // Mark event as handled so we don't get bounced out of the app.

            UnregisterForPrinting();
            OnBackRequested();
        }

        private void OnBackRequested()
        {
            Frame.GoBack(new DrillInNavigationTransitionInfo());
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested -= TablePage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            imprimirCuenta = true;

            printMan = PrintManager.GetForCurrentView();
            try
            {
                printMan.PrintTaskRequested += PrintTaskRequested;
            }
            catch
            {
                UnregisterForPrinting();
                printMan.PrintTaskRequested += PrintTaskRequested;
            }


            // Build a PrintDocument and register for callbacks

            printDoc = new PrintDocument();
            printDocSource = printDoc.DocumentSource;
            printDoc.Paginate += Paginate;
            printDoc.GetPreviewPage += GetPreviewPage;
            printDoc.AddPages += AddPages;
            if (PrintManager.IsSupported())
            {
                try
                {
                    // Show print UI
                    await PrintManager.ShowPrintUIAsync();
                }
                catch
                {
                    // Printing cannot proceed at this time
                    ContentDialog noPrintingDialog = new ContentDialog()
                    {
                        Title = "Printing error",
                        Content = "\nSorry, printing can' t proceed at this time.",
                        PrimaryButtonText = "OK"
                    };
                    await noPrintingDialog.ShowAsync();
                }
            }
            else
            {
                // Printing is not supported on this device
                ContentDialog noPrintingDialog = new ContentDialog()
                {
                    Title = "Printing not supported",
                    Content = "\nSorry, printing is not supported on this device.",
                    PrimaryButtonText = "OK"
                };
                await noPrintingDialog.ShowAsync();
            }
        }

    

        private void modifyCantCuenta_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            bool contienenum = false;
            
            for ( int i = 0; i< ((TextBox)sender).Text.Length; i++) 
            {
                    if (int.Parse(((TextBox)sender).Text.ElementAt(i).ToString()) > 0)
                    contienenum = true;
            }

            if (e.Key.ToString().Equals("Back"))
            {
                if ((((TextBox)sender).Text).Length == 0 || (!contienenum))
                {
                    if (((TextBox)sender).Name == addCantCuenta.Name)
                        aceptarañadirPedido.IsEnabled = false;
                    else
                        editarInformacion.IsEnabled = false;
                }
                e.Handled = false;
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                if (e.Key.ToString() == string.Format("Number{0}", i) || e.Key.ToString() == string.Format("NumberPad{0}", i))
                {
                    if( 
                        ((((TextBox)sender).Text.Length) == 0 && (e.Key.ToString() != string.Format("Number{0}", 0) && e.Key.ToString() != string.Format("NumberPad{0}", 0)))
                        || 
                        ((contienenum )|| (e.Key.ToString() != string.Format("Number{0}", 0) && e.Key.ToString() != string.Format("NumberPad{0}", 0))) 
                        ) //fin if
                    {

                        if(((TextBox)sender).Name == addCantCuenta.Name)
                            aceptarañadirPedido.IsEnabled = true;
                        else
                            editarInformacion.IsEnabled = true;
                        ViewModel.EditarPedidodeCuentaCommand.RaiseCanExecuteChanged();
                        
                    }

                    e.Handled = false;
                    return;
                }
            }
            e.Handled = true;
        }


        private void editarInformacion_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.detalleCuentaSeleccionada.cantidad = int.Parse(modifyCantCuenta.Text);
            modifyCantCuenta.Text = "";
        }

        private void aceptarañadirPedido_Click(object sender, RoutedEventArgs e)
        {
            Listdetallecuenta nuevoDetalle = new Listdetallecuenta((Producto)comboproductos.SelectedItem, int.Parse(addCantCuenta.Text));
            ViewModel.nuevaComandaAñadir = nuevoDetalle;
        }

        private async void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            bool fincuenta = await ViewModel.finalizarCuentaPagadaParaCodigoBehind();

            if (fincuenta)
            {
                TablePage_BackRequested(null,null);
            }
        }

        private async void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            bool fincuenta = await ViewModel.finalizarCuentaSinPagarParaCodigoBehind();

            if (fincuenta)
            {
                TablePage_BackRequested(null, null);
            }
        }
    }
}