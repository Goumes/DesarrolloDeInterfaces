using ProyectoBarVCamarero.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
    public class Categoria : clsVMBase
    {
        #region Properties

        private int _id;

        private String _nombre;
        private int _operativo;
        #endregion

        public Categoria(int id,String nombre,int operativo){
            _id = id;
            _nombre = nombre;
            _operativo = operativo;
        }

        public Categoria()
        {

        }
        #region getters&setters

        public int idCategoria
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyPropertyChanged("idCategoria");
            }
        }

        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                NotifyPropertyChanged("nombre");
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
                NotifyPropertyChanged("operativa");
            }
        }
        #endregion
    }
}
