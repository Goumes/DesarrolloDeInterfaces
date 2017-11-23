using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ProyectoBarVCamarero.dal;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamareroTest.Tests
{
    [TestClass]
    public class TestMesas
    {
        [TestMethod]
        public async Task getMesas()
        {
            MesaController pc = new MesaController();
            ObservableCollection<Mesa> lista = await pc.getMesas();
            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public async Task editMesa()
        {
            MesaController pc = new MesaController();
            Mesa m = new Mesa(1, "12345",1);

            HttpResponseMessage res = await pc.editMesa(m);
            Assert.IsTrue(res.IsSuccessStatusCode);
        }


        [TestMethod]
        public async Task postMesa()
        {
            MesaController pc = new MesaController();
            Mesa m = new Mesa(1, "67890", 0);

            bool res = await pc.postMesa(m);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public async Task DeleteMesa()
        {
            MesaController pc = new MesaController();
            

            bool res = await pc.deleteMesa(7);
            Assert.IsTrue(res);
        }


    }
}
