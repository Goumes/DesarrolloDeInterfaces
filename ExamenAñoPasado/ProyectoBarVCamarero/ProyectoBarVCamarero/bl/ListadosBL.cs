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
    public class ListadosBL
    {
        private NuevaComandaController ncc;
        private ObservableCollection<NuevasComandas> nuevasComandas;
        public ListadosBL()
        {
           ncc = new NuevaComandaController();
        }

        /// <summary>
        /// Metodo que recoge todas las mesas
        /// </summary>
        /// <returns>Un listado de mesas</returns>
        public async Task<ObservableCollection<Mesa>> getMesas()
        {
            MesaController mc = new MesaController();
            ObservableCollection<Mesa> mesas = new ObservableCollection<Mesa>();
            mesas = await mc.getMesas();
            for(int i = mesas.Count-1; i >= 0 ; i--)
            {
                if (mesas.ElementAt(i).Operativa == 0)
                {
                    mesas.RemoveAt(i);
                }
            }
            
            return mesas;
        }

        /// <summary>
        /// Metodo que recoge las nuevas Comandas 
        /// </summary>
        /// <returns>Un listado de Cuentas</returns>
        public async Task<ObservableCollection<NuevasComandas>> getNuevasComandas()
        {
            
            
            nuevasComandas = await ncc.getNuevasComandas();

            return nuevasComandas;
        }

        /// <summary>
        /// Metodo que recoge todos los productos
        /// </summary>
        /// <returns>Un listado de Productos</returns>
        public async Task<ObservableCollection<Producto>> getProductos()
        {
            ProductoController pc = new ProductoController();
            ObservableCollection<Producto> productos = new ObservableCollection<Producto>();
            productos = await pc.getProductos();
            for (int i = productos.Count -1; i >= 0; i--)
            {
                if (productos.ElementAt(i).operativo == 0) productos.RemoveAt(i);
            }

            return productos;
        }


        /// <summary>
        /// Metodo que recoge todos los productos
        /// </summary>
        /// <returns>Un listado de Productos</returns>
        public async Task<ObservableCollection<Cuenta>> getCuentas()
        {
            CuentaController cc = new CuentaController();
            ObservableCollection<Cuenta> cuentas = new ObservableCollection<Cuenta>();
            cuentas = await cc.getCuentas();
            
            for (int i = cuentas.Count-1 ; i>= 0 ; i--)
            {
                if(cuentas.ElementAt(i).finalizada != 2)
                {
                    cuentas.RemoveAt(i);
                }
            }

            return cuentas;
        }



        /// <summary>
        /// Metodo que recoge todos las categorias
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Categoria>> getCategorias()
        {
            CategoriaController cc = new CategoriaController();
            ObservableCollection<Categoria> categorias = new ObservableCollection<Categoria>();

            categorias = await cc.getCategorias();

            for(int i = categorias.Count-1; i >=0 ; i--)
            {
                if(categorias.ElementAt(i).operativo==0)
                    categorias.RemoveAt(i);
            }

            return categorias;
        }

        /// <summary>
        /// Metodo que recoge todos las categorias
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Categoria>> getCategoriasInactivas()
        {
            CategoriaController cc = new CategoriaController();
            ObservableCollection<Categoria> categorias = new ObservableCollection<Categoria>();

            categorias = await cc.getCategorias();

            for (int i = categorias.Count -1 ; i >= 0 ; i--)
            {
                if (categorias.ElementAt(i).operativo == 1)
                    categorias.RemoveAt(i);
            }

            return categorias;
        }


        /// <summary>
        ///     Obtiene todos los productos deshabilitados con categorias habilitadas
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Producto>> getProductosInactivos()
        {
            ProductoController pc = new ProductoController();
            ObservableCollection<Producto> productos = new ObservableCollection<Producto>();
            ObservableCollection<Categoria> categorias = new ObservableCollection<Categoria>();

            productos = await pc.getProductos();
            categorias = await getCategoriasInactivas();

            for(int i = productos.Count-1; i >= 0; i--)
            {
                bool catdes = false;
                if (productos.ElementAt(i).operativo == 0) {
                    for (int x = categorias.Count - 1; x >= 0 && !catdes; x--)
                    {
                        if (productos.ElementAt(i).idcategoria == categorias.ElementAt(x).idCategoria)
                        {
                            productos.RemoveAt(i);
                            catdes = true;
                        }
                    }
                }
                else
                {
                    productos.RemoveAt(i);
                }
            }

            return productos;
        }


    }
}
