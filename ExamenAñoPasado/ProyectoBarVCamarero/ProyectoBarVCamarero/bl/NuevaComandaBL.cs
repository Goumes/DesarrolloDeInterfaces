using ProyectoBarVCamarero.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.bl
{
    public class NuevaComandaBL
    {

        public async Task<bool> eliminarNuevaComanda(int idCuenta,int idProducto)
        {
            bool eliminadocorrecto = false;
            NuevaComandaController cc = new NuevaComandaController();
            eliminadocorrecto = await cc.deleteNuevasComanda(idCuenta,idProducto);
            return eliminadocorrecto;
        }

        
    }
}
