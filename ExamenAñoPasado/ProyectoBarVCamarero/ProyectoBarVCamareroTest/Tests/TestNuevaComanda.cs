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
    public class TestNuevaComanda
    {
        [TestMethod]
        public async Task getNuevasComandas()
        {
            NuevaComandaController cc = new NuevaComandaController();
            ObservableCollection<NuevasComandas> lista = await cc.getNuevasComandas();
            Assert.IsTrue(lista.Count > 0);
        }

    }
}
