using Examen_Final_Alejandro_Gomez_BL.Listados;
using Examen_Final_Alejandro_Gomez_BL.Manejadoras;
using Examen_Final_Alejandro_Gomez_ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Examen_Final_Alejandro_Gomez_UI.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        //El botón de momento aparece cuando seleccionas el segundo combatiente, pero deberia de ser cuando seleccionas todas las opciones
        //Además debería de hacer la lista de las segundas puntuaciones con la inversa de la primera, pero tampoco me da tiempo.
        //También tendría que arreglar el metodo del insert, porque no esta hecho de manera correcta. También deberia de consultar en la badat las ids en vez de meterlas a mano
        #region Atributos
        private ObservableCollection<clsLuchador> _luchadores1;
        private ObservableCollection<clsLuchador> _luchadores2;
        private ObservableCollection<clsCombate> _combates;
        private ObservableCollection<int> _puntuaciones;
        private clsLuchador _luchadorSeleccionado1;
        private clsLuchador _luchadorSeleccionado2;
        private clsCombate _combateSeleccionado;
        private clsCasa _casa1;
        private clsCasa _casa2;
        private int _puntuacionS1;
        private int _puntuacionE1;
        private int _puntuacionV1;
        private int _puntuacionS2;
        private int _puntuacionE2;
        private int _puntuacionV2;
        private Visibility _visibilidadLuchador2;
        private Visibility _visibilidadImagen1;
        private Visibility _visibilidadImagen2;
        private Visibility _visibilidadLuchador1;
        private Visibility _visibilidadBoton;
        private Visibility _visibilidadPuntuaciones1;
        private Visibility _visibilidadPuntuaciones2;
        public clsGestoraEntidadesBL gestoraEntidadesBL { get; set; }
        public clsGestoraListadosBL gestoraListadosBL { get; set; }

        public clsMainPageVM()
        {
            gestoraListadosBL = new clsGestoraListadosBL();
            gestoraEntidadesBL = new clsGestoraEntidadesBL();
            //gestoraListadosBL.getListadoLuchadores();
            _luchadores1 = new ObservableCollection<clsLuchador>(gestoraListadosBL.getListadoLuchadores());
            _luchadores2 = new ObservableCollection<clsLuchador>();
            _combates = new ObservableCollection<clsCombate>(gestoraListadosBL.getListadoCombates ());
            _puntuaciones = new ObservableCollection<int> {5, 10};
            _visibilidadLuchador2 = Visibility.Collapsed;
            _visibilidadImagen1 = Visibility.Collapsed;
            _visibilidadImagen2 = Visibility.Collapsed;
            _visibilidadLuchador1 = Visibility.Collapsed;
            _visibilidadBoton = Visibility.Collapsed;
            _visibilidadPuntuaciones1 = Visibility.Collapsed;
            _visibilidadPuntuaciones2 = Visibility.Collapsed;
        }
        #endregion

        #region Propiedades
        public ObservableCollection<clsLuchador> luchadores1
        {
            get
            {
                return _luchadores1;
            }

            set
            {
                _luchadores1 = value;
                NotifyPropertyChanged("luchadores1");
            }
        }

        public ObservableCollection<clsLuchador> luchadores2
        {
            get
            {
                return _luchadores2;
            }

            set
            {
                _luchadores2 = value;
                NotifyPropertyChanged("luchadores2");
            }
        }

        public ObservableCollection<clsCombate> combates
        {
            get
            {
                return _combates;
            }

            set
            {
                _combates = value;
                NotifyPropertyChanged("combates");
            }
        }

        public ObservableCollection<int> puntuaciones
        {
            get
            {
                return _puntuaciones;
            }

            set
            {
                _puntuaciones = value;
                NotifyPropertyChanged("puntuaciones");
            }
        }

        public clsLuchador luchadorSeleccionado1
        {
            get
            {
                return _luchadorSeleccionado1;
            }

            set
            {
                _luchadorSeleccionado1 = value;
                NotifyPropertyChanged("luchadorSeleccionado1");
                visibilidadLuchador2 = Visibility.Visible;
                visibilidadImagen1 = Visibility.Visible;
                casa1 = gestoraEntidadesBL.getCasaPorId(luchadorSeleccionado1.idCasa);
                luchadores2 = new ObservableCollection<clsLuchador>( gestoraListadosBL.getListadoLuchadoresMenosUno(luchadorSeleccionado1.idLuchador));
            }
        }

        public clsLuchador luchadorSeleccionado2
        {
            get
            {
                return _luchadorSeleccionado2;
            }

            set
            {
                _luchadorSeleccionado2 = value;
                NotifyPropertyChanged("luchadorSeleccionado2");
                visibilidadImagen2 = Visibility.Visible;
                visibilidadBoton = Visibility.Visible;
                visibilidadPuntuaciones1 = Visibility.Visible;
                visibilidadPuntuaciones2 = Visibility.Visible;
                //Visibilidad botones de puntuacion
                casa2 = gestoraEntidadesBL.getCasaPorId(luchadorSeleccionado2.idCasa);
            }
        }

        public clsCombate combateSeleccionado
        {
            get
            {
                return _combateSeleccionado;
            }

            set
            {
                _combateSeleccionado = value;
                NotifyPropertyChanged("combateSeleccionado");
                visibilidadLuchador1 = Visibility.Visible;
            }
        }

        public Visibility visibilidadLuchador2
        {
            get
            {
                return _visibilidadLuchador2;
            }

            set
            {
                _visibilidadLuchador2 = value;
                NotifyPropertyChanged("visibilidadLuchador2");
            }
        }

        public Visibility visibilidadLuchador1
        {
            get
            {
                return _visibilidadLuchador1;
            }

            set
            {
                _visibilidadLuchador1 = value;
                NotifyPropertyChanged("visibilidadLuchador1");
            }
        }

        public Visibility visibilidadImagen1
        {
            get
            {
                return _visibilidadImagen1;
            }

            set
            {
                _visibilidadImagen1 = value;
                NotifyPropertyChanged("visibilidadImagen1");
            }
        }

        public Visibility visibilidadImagen2
        {
            get
            {
                return _visibilidadImagen2;
            }

            set
            {
                _visibilidadImagen2 = value;
                NotifyPropertyChanged("visibilidadImagen2");
            }
        }

        public Visibility visibilidadBoton
        {
            get
            {
                return _visibilidadBoton;
            }

            set
            {
                _visibilidadBoton = value;
                NotifyPropertyChanged("visibilidadBoton");
            }
        }

        public Visibility visibilidadPuntuaciones1
        {
            get
            {
                return _visibilidadPuntuaciones1;
            }

            set
            {
                _visibilidadPuntuaciones1 = value;
                NotifyPropertyChanged("visibilidadPuntuaciones1");
            }
        }

        public Visibility visibilidadPuntuaciones2
        {
            get
            {
                return _visibilidadPuntuaciones2;
            }

            set
            {
                _visibilidadPuntuaciones2 = value;
                NotifyPropertyChanged("visibilidadPuntuaciones2");
            }
        }

        public clsCasa casa1
        {
            get
            {
                return _casa1;
            }

            set
            {
                _casa1 = value;
                NotifyPropertyChanged("casa1");
            }
        }

        public clsCasa casa2
        {
            get
            {
                return _casa2;
            }

            set
            {
                _casa2 = value;
                NotifyPropertyChanged("casa2");
            }
        }

        public int puntuacionS1
        {
            get
            {
                return _puntuacionS1;
            }

            set
            {
                _puntuacionS1 = value;
                NotifyPropertyChanged("puntuacionS1");
            }
        }

        public int puntuacionS2
        {
            get
            {
                return _puntuacionS2;
            }

            set
            {
                _puntuacionS2 = value;
                NotifyPropertyChanged("puntuacionS2");
            }
        }

        public int puntuacionE1
        {
            get
            {
                return _puntuacionE1;
            }

            set
            {
                _puntuacionE1 = value;
                NotifyPropertyChanged("puntuacionE1");
            }
        }

        public int puntuacionE2
        {
            get
            {
                return _puntuacionE2;
            }

            set
            {
                _puntuacionE2 = value;
                NotifyPropertyChanged("puntuacionE2");
            }
        }

        public int puntuacionV1
        {
            get
            {
                return _puntuacionV1;
            }

            set
            {
                _puntuacionV1 = value;
                NotifyPropertyChanged("puntuacionV1");
            }
        }

        public int puntuacionV2
        {
            get
            {
                return _puntuacionV2;
            }

            set
            {
                _puntuacionV2 = value;
                NotifyPropertyChanged("puntuacionV2");
            }
        }
        #endregion

        #region Metodos
        public void insertarPuntuaciones()
        {
           
            clsClasificacionCombate clasificacionCombate = new clsClasificacionCombate(combateSeleccionado.idCombate, _puntuacionS1, 1, luchadorSeleccionado1.idLuchador);
            gestoraEntidadesBL.insertClasificacionCombate(clasificacionCombate);
            clasificacionCombate = new clsClasificacionCombate(combateSeleccionado.idCombate, _puntuacionE1, 2, luchadorSeleccionado1.idLuchador);
            gestoraEntidadesBL.insertClasificacionCombate(clasificacionCombate);
            clasificacionCombate = new clsClasificacionCombate(combateSeleccionado.idCombate, _puntuacionV1, 3, luchadorSeleccionado1.idLuchador);
            gestoraEntidadesBL.insertClasificacionCombate(clasificacionCombate);

            clasificacionCombate = new clsClasificacionCombate(combateSeleccionado.idCombate, _puntuacionS2, 1, luchadorSeleccionado2.idLuchador);
            gestoraEntidadesBL.insertClasificacionCombate(clasificacionCombate);
            clasificacionCombate = new clsClasificacionCombate(combateSeleccionado.idCombate, _puntuacionE2, 2, luchadorSeleccionado2.idLuchador);
            gestoraEntidadesBL.insertClasificacionCombate(clasificacionCombate);
            clasificacionCombate = new clsClasificacionCombate(combateSeleccionado.idCombate, _puntuacionV2, 3, luchadorSeleccionado2.idLuchador);
            gestoraEntidadesBL.insertClasificacionCombate(clasificacionCombate);
        }
        #endregion
    }
}
