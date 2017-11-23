using ExamenSegundaEvaluacion_Dani.DAL;
using ExamenSegundaEvaluacion_Dani.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace ExamenSegundaEvaluacion_Dani.ViewModel
{
    public class clsMainPageVM : clsVMBase
    {

        private ObservableCollection<clsPersonaje> _lista;
        private clsPersonaje _personaje;
        private Uri imagenseleccionada;



        public clsMainPageVM()
        {
            rellenalista();

        }

        public ObservableCollection<clsPersonaje> lista
        {
            get
            {
                return _lista;
            }

            set
            {
                _lista = value;
                NotifyPropertyChanged("lista");
                
            }
        }

        public clsPersonaje personaje
        {
            get
            {
                return _personaje;
            }

            set
            {
                _personaje = value;
                NotifyPropertyChanged("personaje");
                


            }
        }

        public Uri Imagenseleccionada
        {
            get
            {
                return imagenseleccionada;
            }

            set
            {
                imagenseleccionada = value;
                NotifyPropertyChanged("Imagenseleccionada");
            }
        }

        private async void rellenalista()
        {

            clsListadoPersonajes clp = new clsListadoPersonajes();
            lista =await clp.getPersonajes();

            
            
        }

        


    }
}
