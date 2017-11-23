using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ProyectoBarVCamarero.dal;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamareroTest.Tests
{
    [TestClass]
    public class TestCuentas
    {
        [TestMethod]
        public async Task getCuentas()
        {
            CuentaController cc = new CuentaController();
            ObservableCollection<Cuenta> lista = await cc.getCuentas();
            Assert.IsTrue(lista.Count > 0);
        }
        [TestMethod]
        public async Task getCuentaxid()
        {
            CuentaController cc = new CuentaController();
            ObservableCollection<Cuenta> listaCuentas = await cc.getCuentas();
            ObservableCollection<Cuenta> lista = await cc.getCuentas( idcuenta:listaCuentas.ElementAt(1).idcuenta);
            Assert.IsTrue(lista.Count > 0);
        }
        [TestMethod]
        public async Task getCuentaxnumMesa()
        {
            CuentaController cc = new CuentaController();
            ObservableCollection<Cuenta> listaCuentas = await cc.getCuentas();
            ObservableCollection<Cuenta> lista = await cc.getCuentas(nummesa:3);
            Assert.IsTrue(lista.Count > 0);
        }
        [TestMethod]
        public async Task eliminarPedidoxCuenta()
        {
            DetallesCuentaController dcc = new DetallesCuentaController();
            Assert.IsTrue(await dcc.deletePedidoCuenta(91, 3));
        }
    }
}
