using ProyectoBarVCamarero.dal;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.bl
{
    public class ProductoBL
    {
        public ProductoBL()
        {

        }

        public async Task<bool> updateProducto(Producto p)
        {
            bool editadocorrecto = false;
            ProductoController pc = new ProductoController();
            editadocorrecto = await pc.editProduct(p);
            return editadocorrecto;
        }


        public async Task<bool> addProducto(Producto p)
        {
            bool editadocorrecto = false;
            ProductoController pc = new ProductoController();
            editadocorrecto = await pc.addProducto(p);
            return editadocorrecto;
        }

        public async Task<bool> deleteProducto(int id)
        {
            bool borradocorrecto = false;
            ProductoController pc = new ProductoController();
            borradocorrecto = await pc.deleteProduct(id);
            return borradocorrecto;
        }
    }
}
