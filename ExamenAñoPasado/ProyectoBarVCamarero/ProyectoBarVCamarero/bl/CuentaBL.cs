using ProyectoBarVCamarero.dal;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.bl
{
    public class CuentaBL
    {
        /// <summary>
        /// Metodo para finalizar una cuenta pagada
        /// </summary>
        /// <param name="idcuenta"></param>
        public async Task<bool> finalizarCuentaPagada(int idcuenta)
        {
            bool correcto = false;
            CuentaController cc = new CuentaController();
            correcto = await cc.finalizarCuenta(idcuenta,1);
            return correcto;
        }
        /// <summary>
        /// Metodo para finalizar una cuenta sin pagar
        /// </summary>
        /// <param name="idcuenta"></param>
        public async Task<bool> finalizarCuentaSinPagar(int idcuenta)
        {
            bool correcto = false;
            CuentaController cc = new CuentaController();
            correcto = await cc.finalizarCuenta(idcuenta, 2);
            return correcto;
        }
        /// <summary>
        /// Metodo para añadir un pedido a una cuenta
        /// </summary>
        /// <param name="idcuenta"></param>
        public async Task<bool> añadirPedidoaCuenta(Cuenta cuenta)
        {
            bool correcto = false;
            DetallesCuentaController cc = new DetallesCuentaController();
            correcto = await cc.addPedido(cuenta);
            return correcto;
        }



        /// <summary>
        /// Metodo para editar un pedido de una cuenta
        /// </summary>
        /// <param name="idcuenta"></param>
        public async Task<bool> editarPedidodeCuenta(int idcuenta, List<Listdetallecuenta> pedido)
        {
            bool correcto = false;
            DetallesCuentaController cc = new DetallesCuentaController();
            correcto = await cc.editPedido(idcuenta, pedido);
            return correcto;
        }


        /// <summary>
        /// Metodo para eliminar un pedido de una cuenta
        /// </summary>
        /// <param name="idcuenta"></param>
        public async Task<bool> eliminarPedidodeCuenta(int idcuenta, int idProducto)
        {
            bool correcto = false;
            DetallesCuentaController cc = new DetallesCuentaController();
            correcto = await cc.deletePedidoCuenta(idcuenta, idProducto);
            return correcto;
        }

        public async Task<bool> añadirCuenta(int nummesa)
        {
            bool correcto = false;
            CuentaController cc = new CuentaController();
            correcto = await cc.addCuenta(new Cuenta(-1, nummesa, new List<Listdetallecuenta>(), DateTime.Now.ToString(), 0.0, 0));
            return correcto;
        }
    }
}
