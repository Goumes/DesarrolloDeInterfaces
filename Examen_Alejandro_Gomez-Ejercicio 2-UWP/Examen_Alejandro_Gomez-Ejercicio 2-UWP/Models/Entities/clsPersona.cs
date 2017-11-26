using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Alejandro_Gomez_Ejercicio_2_UWP.Models.Entities
{
    public class clsPersona
    {
        #region Atributos
        private String _nombre;
        private String _apellidos;
        private String _curso;
        #endregion

        #region Constructores
        public clsPersona()
        {
            this._nombre = "Nombre";
            this._apellidos = "Apellidos";
            this._curso = "1º CFGS";
        }

        public clsPersona(String nombre, String apellidos, String curso)
        {
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._curso = curso;
        }
        #endregion

        #region Propiedades
        public String nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public String apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                _apellidos = value;
            }
        }

        public String curso
        {
            get
            {
                return _curso;
            }

            set
            {
                _curso = value;
            }
        }
        #endregion
    }
}
