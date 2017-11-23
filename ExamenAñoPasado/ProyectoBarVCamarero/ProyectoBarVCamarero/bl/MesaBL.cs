using ProyectoBarVCamarero.dal;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.bl
{
    public class MesaBL
    {
        public MesaBL()
        {

        }


        public async Task<Cuenta> getCuentaxMesa(int numeromesa)
        {
            Cuenta c = null;
            CuentaController cc = new CuentaController();
            ObservableCollection<Cuenta> cuentas = await cc.getCuentas(nummesa: numeromesa);
            if(cuentas.Count>0 )
                if(cuentas.ElementAt(0).finalizada==0)
                    c = cuentas.ElementAt(0);
            return c;
        }

        public async Task<bool> addmesa()
        {
            bool añadida = false;
            Mesa m = new Mesa();
            MesaController mc = new MesaController();
            if (await mc.postMesa(m))
            {
                añadida = true;
            }

            return añadida;
        }

        public async Task<bool> deletemesa(int nummesa)
        {
            bool eliminado = false;
            Mesa m = new Mesa();
            MesaController mc = new MesaController();
            if (await mc.deleteMesa(nummesa))
            {
                eliminado = true;
            }

            return eliminado;
        }
    }
}
