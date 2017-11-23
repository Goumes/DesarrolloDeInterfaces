using ProyectoBarVCamarero.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
    public class Cuenta:clsVMBase
    {
        #region Properties
        private int _idcuenta;
        private int _nummesa;
        private IList<Listdetallecuenta> _listdetallecuenta;
        private string _fecha;
        private double _preciofinal;
        private int _finalizada;
        public bool cuentaAbierta { get; set; }
        public bool cuentaCerrada { get; set; }
        #endregion
        #region Builders
        public Cuenta(int idcuenta, int nummesa, IList<Listdetallecuenta> listdetallecuenta, string fecha, double preciofinal, int finalizada)
        {
            this.idcuenta = idcuenta;
            this.nummesa = nummesa;
            this.listdetallecuenta = listdetallecuenta;
            this.fecha = fecha;
            this.preciofinal = preciofinal;
            this.finalizada = finalizada;
            if (finalizada == 0)
            {
                cuentaAbierta = true;
                cuentaCerrada = false;

            }
            else
            {

                cuentaAbierta = false;
                cuentaCerrada = true;
            }

        }
        public Cuenta()
        {

        }
        #endregion
        #region Getters&Setters

        public int idcuenta
        {
            get
            {
                return _idcuenta;
            }

            set
            {
                _idcuenta = value;
                NotifyPropertyChanged("idcuenta");
            }
        }

        public int nummesa
        {
            get
            {
                return _nummesa;
            }

            set
            {
                _nummesa = value;
                NotifyPropertyChanged("nummesa");
            }
        }

        public IList<Listdetallecuenta> listdetallecuenta
        {
            get
            {
                return _listdetallecuenta;
            }

            set
            {
                _listdetallecuenta = value;
                NotifyPropertyChanged("listdetallecuenta");
            }
        }

        public string fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                _fecha = value;
                NotifyPropertyChanged("fecha");
            }
        }

        public double preciofinal
        {
            get
            {
                return _preciofinal;
            }

            set
            {
                _preciofinal = value;
                NotifyPropertyChanged("preciofinal");
            }
        }

        public int finalizada
        {
            get
            {
                return _finalizada;
            }

            set
            {
                _finalizada = value;
                NotifyPropertyChanged("finalizada");
                
                if (value == 0)
                {
                    cuentaAbierta = true;
                    cuentaCerrada = false;

                }
                else
                {

                    cuentaAbierta = false;
                    cuentaCerrada = true;
                }
            }
        }

        
        #endregion
    }
}
