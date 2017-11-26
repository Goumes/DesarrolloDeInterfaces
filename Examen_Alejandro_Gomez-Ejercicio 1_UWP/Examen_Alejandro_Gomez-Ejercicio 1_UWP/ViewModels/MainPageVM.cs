using _05_PersonaModificada_ASP.Models.Interfaces;
using _13_DataContext.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Examen_Alejandro_Gomez_Ejercicio_1_UWP.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region Atributos
        private bool _diferencia1_Presionada;
        private int _diferencia1_Opacidad;
        private int _diferenciasEncontradas;
        private bool _visibilidadGanador;
        #endregion

        #region Constructores
        public MainPageVM ()
        {
            _diferenciasEncontradas = 0;
            diferencia1_Presionada = false;
            diferencia1_Opacidad = 0;
            _visibilidadGanador = false;
        }
        #endregion

        #region Propiedades

        public bool visibilidadGanador
        {
            get
            {
                return _visibilidadGanador;
            }

            set
            {
                _visibilidadGanador = value;
                NotifyPropertyChanged("visibilidadGanador");
            }
        }

        public bool diferencia1_Presionada
        {
            get
            {
                return _diferencia1_Presionada;
            }

            set
            {
                _diferencia1_Presionada = value;
                NotifyPropertyChanged("diferencia1_Presionada");
            }
        }

        public int diferenciasEncontradas
        {
            get
            {
                return _diferenciasEncontradas;
            }
            set
            {
                _diferenciasEncontradas = value;
            }
        }

        public int diferencia1_Opacidad
        {
            get
            {
                return _diferencia1_Opacidad;
            }

            set
            {
                if (_diferencia1_Presionada)
                {
                    _diferencia1_Opacidad = 100;
                    _diferenciasEncontradas++;

                    if (_diferenciasEncontradas == 7)
                    {
                        _visibilidadGanador = true;
                    }
                }

                else
                {
                    _diferencia1_Opacidad = value;
                }
            }
        }
        #endregion

        #region Metodos

        public void comprobarDiferencias (object sender, PointerRoutedEventArgs e)
        {
            diferencia1_Presionada = true;
            _diferencia1_Opacidad = 100;
            _diferenciasEncontradas++;
        }

        public async void volverJugar ()
        {

            ContentDialog volverAJugar = new ContentDialog();
            volverAJugar.Title = "Volver a jugar";
            volverAJugar.Content = "¿Desea volver a jugar?";
            volverAJugar.PrimaryButtonText = "Si";
            volverAJugar.SecondaryButtonText = "No";

            ContentDialogResult resultado = await volverAJugar.ShowAsync();

            if (resultado == ContentDialogResult.Primary)
            {

                //Views.MainPage.Frame.Navigate(typeof(Views.MainPage));
            }
        }
        #endregion
    }
}
