using _05_PersonaModificada_ASP.Models.Interfaces;
using Examen_Alejandro_Gomez_Ejercicio_2_UWP.Models.Entities;
using Examen_Alejandro_Gomez_Ejercicio_2_UWP.Models.Listados;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Alejandro_Gomez_Ejercicio_2_UWP.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region Atributos
        ObservableCollection<clsPersona> _listado;
        ObservableCollection<string> _cursos;
        String _cursoSeleccionado;
        #endregion

        #region Constructores
        public MainPageVM()
        {
            //clsListadoPersonas listadoPersonas = new clsListadoPersonas();
            //_listado = listadoPersonas.listadoPersonas; Esto era una prueba para ver si el bindeo estaba correcto.
            _listado = new ObservableCollection<clsPersona>();
            _cursos = rellenarCursos();
            _cursoSeleccionado = "";
        }
        #endregion

        #region Propiedades
        public ObservableCollection<clsPersona> listado
        {
            get
            {
                return _listado;
            }

            set
            {
                _listado = rellenarAlumnosPorCurso ();
                NotifyPropertyChanged("listado");
            }
        }

        public ObservableCollection<string> cursos
        {
            get
            {
                return _cursos;
            }
        }

        public String cursoSeleccionado
        {
            get
            {
                return _cursoSeleccionado;
            }

            set
            {
                _cursoSeleccionado = value;
                _listado = rellenarAlumnosPorCurso();
                NotifyPropertyChanged("listado");
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo dedicado a rellenar una colección de string con los cursos necesarios
        /// </summary>
        /// <returns> Colección con los cursos insertados </returns>
        public ObservableCollection<string> rellenarCursos()
        {
            ObservableCollection<string> listaCursos = new ObservableCollection<string>();

            listaCursos.Add("1º CFGS");
            listaCursos.Add("2º CFGS");

            return listaCursos;
        }

        /// <summary>
        /// Metodo dedicado a rellenar los alumnos en una colección, dependiendo del cursoSeleccionado
        /// </summary>
        /// <returns> Lista de alumnos filtrada </returns>
        public ObservableCollection<clsPersona> rellenarAlumnosPorCurso()
        {
            ObservableCollection<clsPersona> lista = new ObservableCollection<clsPersona> ();
            clsListadoPersonas listadoPersonas = new clsListadoPersonas();

            for (int i = 0; i < listadoPersonas.listadoPersonas.Count; i++)
            {
                if (listadoPersonas.listadoPersonas[i].curso.Equals (_cursoSeleccionado/*"1º CFGS"*/))
                {
                    lista.Add(listadoPersonas.listadoPersonas[i]);
                }
            }

            return lista;
        }
        #endregion
    }
}
