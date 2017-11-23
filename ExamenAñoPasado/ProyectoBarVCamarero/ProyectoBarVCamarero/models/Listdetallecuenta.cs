using ProyectoBarVCamarero.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
   public class Listdetallecuenta:clsVMBase
    {
        #region Properties
        private Producto _producto;
        private int _cantidad;
        private double _preciofinal;


        #endregion
        #region Builders
        public Listdetallecuenta(Producto producto, int cantidad)
        {
            this._producto = producto;
            this._cantidad = cantidad;
            this._preciofinal = cantidad * producto.precio;
        
        }

        public Listdetallecuenta()
        {

        }
        #endregion
        #region Getters&Setters

        public Producto producto
        {
            get
            {
                return _producto;
            }

            set
            {
                _producto = value;
                NotifyPropertyChanged("producto");
            }
        }

        public int cantidad
        {
            get
            {
                return _cantidad;
            }

            set
            {
                _cantidad = value;

                precioTotal = producto.precio * cantidad;
                NotifyPropertyChanged("cantidad");
            }
        }

        public double precioTotal
        {
            get
            {
                return _preciofinal;
            }
            set
            {
                _preciofinal = value;
                NotifyPropertyChanged("precioTotal");
            }
        }
        #endregion
    }
}
