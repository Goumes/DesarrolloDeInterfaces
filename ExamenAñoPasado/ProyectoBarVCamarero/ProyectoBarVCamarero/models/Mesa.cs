using ProyectoBarVCamarero.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
    public class Mesa : clsVMBase
    {

        #region Properties

        private int _nummesa;

        private string _codigo;

        private int _disponibilidad;

        private int _operativa;


        public Uri _imagenmesa = new Uri("ms-appx://ProyectoBarVCamarero/Assets/mesaimg.png", UriKind.RelativeOrAbsolute);
        #endregion

        #region Builders
        public Mesa(int _nummesa, string _codigo, int _disponibilidad)
        {
            this._nummesa = _nummesa;
            this._codigo = _codigo;
            this._disponibilidad = _disponibilidad;
        }
        public Mesa()
        {
          
        }
        #endregion

        #region Getters&Setters
        public int Nummesa
        {
            get
            {
                return _nummesa;
            }

            set
            {
                _nummesa = value;
                NotifyPropertyChanged("Nummesa");
            }
        }

        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
                NotifyPropertyChanged("Codigo");
            }
        }

        public int Disponibilidad
        {
            get
            {
                return _disponibilidad;
            }

            set
            {
                _disponibilidad = value;
                NotifyPropertyChanged("Disponibilidad");
            }
        }

        public int Operativa
        {
            get
            {
                return _operativa;
            }

            set
            {
                _operativa = value;
                NotifyPropertyChanged("Operativa");

            }
        }

        public Uri Imagenmesa
        {
            get
            {
                return _imagenmesa;
            }
        }
        #endregion
    }
}
