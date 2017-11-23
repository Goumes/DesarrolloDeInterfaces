using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using ProyectoBarVCamarero.dal;
using ProyectoBarVCamarero.models;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace ProyectoBarVCamareroTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task getProductos()
        {
            ProductoController pc = new ProductoController();
            ObservableCollection<Producto> lista = await pc.getProductos();
            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public async Task editProduct()
        {
            ProductoController pc = new ProductoController();
            Producto p = new Producto(2, "Aguaaaaa Mineral",0.8, 2,1);

            
            Assert.IsTrue(await pc.editProduct(p));
        }

        [TestMethod]
        public async Task postProduct()
        {
            ProductoController pc = new ProductoController();
            Producto p = new Producto(0, "PruebaUnitaria", 0.1, 4,1);

            
            Assert.IsTrue(await pc.addProducto(p));
        }

        [TestMethod]
        public async Task DeleteProduct()
        {
            ProductoController pc = new ProductoController();
            bool res = await pc.deleteProduct(29);
            Assert.IsTrue(res);
        }
    }
}
