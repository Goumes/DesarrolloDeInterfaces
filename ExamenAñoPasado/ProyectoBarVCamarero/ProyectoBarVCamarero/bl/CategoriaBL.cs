using ProyectoBarVCamarero.dal;
using ProyectoBarVCamarero.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.bl
{
    public class CategoriaBL
    {

        public async Task<bool> updateCategoria(Categoria c)
        {
            bool editadocorrecto = false;
            CategoriaController cc = new CategoriaController();
            editadocorrecto = await cc.editCategoria(c);
            return editadocorrecto;
        }


        public async Task<bool> addCategoria(Categoria c)
        {
            bool añadidocorrecto = false;
            CategoriaController cc = new CategoriaController();
            añadidocorrecto = await cc.addCategoria(c);
            return añadidocorrecto;
        }

        public async Task<bool> eliminarCategoria(int id)
        {
            bool eliminadocorrecto = false;
            CategoriaController cc = new CategoriaController();
            eliminadocorrecto = await cc.deleteCategoria(id);
            return eliminadocorrecto;
        }
    }
}
