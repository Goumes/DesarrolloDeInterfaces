using _20_CRUD_Personas_DAL.Manejadoras;
using _20_CRUD_Personas_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_CRUD_Personas_BL.Manejadoras
{
    public class clsGestoraDepartamentoBL
    {
        public clsDepartamento getDepartamentoPorId(int id)
        {
            clsDepartamento departamento;
            clsGestoraDepartamentoDAL gestoraDepartamentoDAL = new clsGestoraDepartamentoDAL();
            departamento = gestoraDepartamentoDAL.buscarDepartamentoPorID(id);

            return departamento;
        }
        public clsDepartamento getDepartamentoPorNombre(String nombre)
        {
            clsDepartamento departamento;
            clsGestoraDepartamentoDAL gestoraDepartamentoDAL = new clsGestoraDepartamentoDAL();
            departamento = gestoraDepartamentoDAL.buscarDepartamentoPorNombre(nombre);

            return departamento;
        }
    }
}
