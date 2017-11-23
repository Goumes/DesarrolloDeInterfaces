using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Grid.Models
{
    class clsUtilidades
    {
        /// <summary>
        ///     Funcion para comprobar los atributos de una persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fNacimiento"></param>
        /// <returns>Un array de 3 posiciones con los errores si en alguna de sus casillas esta rellena ,no es posible esa persona</returns>
        public string[] personaValida(String nombre, String apellido, DateTimeOffset fNacimiento)
        {
            
            char[] nombrechar = nombre.ToCharArray();
            char[] apellidochar = apellido.ToCharArray();
            string[] errores = new string[] { "", "", "" };

            //Comprobamos que sean letras el nombre y el apellido
            if (String.IsNullOrEmpty(nombre))
            {

                errores[0] = "El nombre no puede estar vacío";
            }
            if (String.IsNullOrEmpty(apellido))
            {

                errores[1] = "Los apellidos no pueden estar vacío";
            }

            for (int i = 0; i < nombre.Length || i < apellido.Length; i++)
            {
                if ((i < nombre.Length) && (!Char.IsLetter(nombrechar[i])) && errores[0]=="")
                {
                    
                    errores[0] = "El nombre debe contener solo letras";

                }

                if ((i < apellido.Length) && (!Char.IsLetter(apellidochar[i]) ) && errores[1]=="")
                {
                    errores[1] = "El apellido solo puede haber letras";
                }

            }


            //Comprobamos que la fecha sea anterior
            if (String.IsNullOrEmpty(fNacimiento.ToString()))
            {
                errores[2] = " La fecha Nacimiento no puede estar vacío";
            }
            else if (fNacimiento.CompareTo(DateTimeOffset.Now) > 0)
            {
                errores[2] = " La fecha de Nacimiento no puede ser superior a la actual";
            }




            return errores;
        }

    }
}
