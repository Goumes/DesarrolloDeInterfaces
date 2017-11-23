using ProyectoBarVCamarero.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
    public class Producto : clsVMBase
    {
        #region Properties
        
        private int _id;
        
        private String _nombre;
        
        private double _precio;
        
        private int _idcategoria;

        private int _operativo;
        #endregion
        #region Builders
        public Producto()
        {

        }

        public Producto(int _id, string _nombre, double _precio, int _idcategoria, int operativo)
        {
            this._id = _id;
            this._nombre = _nombre;
            this._precio = _precio;
            this._idcategoria = _idcategoria;
            this._operativo = operativo;
        }



        #endregion
        #region Getters&Setters
        public int idproducto
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                NotifyPropertyChanged("Idproducto");
            }
        }

        public string nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
                NotifyPropertyChanged("Nombre");
            }
        }

        public double precio
        {
            get
            {
                return _precio;
            }

            set
            {
                _precio = value;
                NotifyPropertyChanged("Precio");
            }
        }

        public int idcategoria
        {
            get
            {
                return _idcategoria;
            }

            set
            {
                _idcategoria = value;
                NotifyPropertyChanged("Idcategoria");
            }
        }

        public int operativo
        {
            get
            {
                return _operativo;
            }

            set
            {
                _operativo = value;
                NotifyPropertyChanged("Operativo");
            }
        }
        #endregion

    }
}
