using ExamenLol.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ExamenLol.ViewModels
{
    public class clsMainPageVM : INotifyPropertyChanged
    {
        private clsPersonaje _personajeSeleccionado;
        public ObservableCollection<clsPersonaje> listaPersonajes { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;        

        public clsMainPageVM()
        {
            listaPersonajes = new ObservableCollection<clsPersonaje>();
            //Image m = new Image() { Source = new BitmapImage(new Uri("ms-appx:///Assets/Imagenes/Aatrox.png", UriKind.Absolute)) };
            //Image[] imgs = new Image[] { new Image() { Source = new BitmapImage(new Uri("ms-appx:///Assets/Imagenes/Aatrox_0.jpg", UriKind.Absolute)) } };

            //listaPersonajes.Add(new clsPersonaje("Aatrox", "Alias de aatrox",2,3,4,5,6,7,8,m, imgs));
            
            obtenerPersonajes();
            
        }


        public clsPersonaje personajeSelecionado
        {
            get
            {
                return _personajeSeleccionado;
            }

            set
            {
                _personajeSeleccionado = value;                
                OnPropertyChanged("personajeSelecionado");
            }
        }


        private async void obtenerPersonajes()
        {
            clsUtilidades utiles = new clsUtilidades();
            listaPersonajes = await utiles.getPersonajes();
            personajeSelecionado = listaPersonajes[0];
            OnPropertyChanged("listaPersonajes");            
        }


        protected void OnPropertyChanged(string name)
        {            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
    }
}
