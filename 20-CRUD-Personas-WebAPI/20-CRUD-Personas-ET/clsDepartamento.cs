using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUD_Personas_ET
{
    public class clsDepartamento
    {
        public int idDepartamento { get; set; }
        public string nombre { get; set; }

        public clsDepartamento()   
        {
            this.idDepartamento = 1;
            this.nombre = "";
        }

        public clsDepartamento(int idDepartamento, string nombre)
        {
            this.idDepartamento = idDepartamento;
            this.nombre = nombre;
        }
    }
}
