using Examen_Alejandro_Gomez_Ejercicio_2_UWP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Alejandro_Gomez_Ejercicio_2_UWP.Models.Listados
{
    public class clsListadoPersonas
    {
        #region Atributos
        ObservableCollection<clsPersona> _listadoPersonas;
        #endregion

        #region Constructores
        public clsListadoPersonas()
        {
            this.listadoPersonas = new ObservableCollection<clsPersona>();
            listadoPersonas = rellenarPersonas();
        }
        #endregion

        #region Propiedades
        public ObservableCollection<clsPersona> listadoPersonas
        {
            get
            {
                return _listadoPersonas;
            }

            set
            {
                _listadoPersonas = value;
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que carga un listado con varias personas
        /// </summary>
        /// <returns> listado relleno </returns>
        public ObservableCollection<clsPersona> rellenarPersonas()
        {
            ObservableCollection<clsPersona> listado = new ObservableCollection<clsPersona>();

            listado.Add(new clsPersona ("David Abraham", "Aguilar Martín", "1º CFGS"));
            listado.Add(new clsPersona("Campanario Fernández", "Yeray Manuel", "1º CFGS"));
            listado.Add(new clsPersona("Alberto Vadillo", "Carlos", "1º CFGS"));
            listado.Add(new clsPersona("Carmona Romero", "Francisco Javier", "2º CFGS"));
            listado.Add(new clsPersona("Castillo Calle", "Iván", "2º CFGS"));

            return listado;
        }
        #endregion


    }
}
