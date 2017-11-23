using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;


using System.Globalization;
using Windows.UI.ViewManagement;
using ProyectoBarVCamarero.models;
using ProyectoBarVCamarero.bl;
using System.Threading;

namespace ProyectoBarVCamarero.viewModel
{
    public class clsMainPageVM : clsVMBase 
    {
        #region Combobox
        private int _SelectedIndexCategoria = 0;
        private int _SelectedIndexProducto = 0;
        public int SelectedIndexCategoria
        {
            get
            {
                return _SelectedIndexCategoria;
            }
            set
            {
                _SelectedIndexCategoria = value;
                NotifyPropertyChanged("SelectedIndexCategoria");
                //RaisePropertyChanged(nameof(SelectedIndex));
            }
        }

        public int SelectedIndexProducto
        {   

            get
            {
                return _SelectedIndexProducto;
            }
            set
            {
                _SelectedIndexProducto = value;
                NotifyPropertyChanged("SelectedIndexProducto");
                //RaisePropertyChanged(nameof(SelectedIndex));
            }
        }



        #endregion

        private DispatcherTimer timer;
        private ListadosBL bl;
        private MesaBL mb;

        private string _txtCantidad;
        private bool _btnProductos;
        private bool _btnCategoria;
        private bool _mesaConCuenta;
        private bool _btndetallesCuentaxMesa;
        private bool _gridEditadodeProd;
        private ObservableCollection<Mesa> _mesas;
        private ObservableCollection<NuevasComandas> _nuevasComandas;
        private ObservableCollection<Cuenta> _cuentas;
        private ObservableCollection<Categoria> _listCategorias;
        private ObservableCollection<Categoria> _listCategoriasdes;
        private ObservableCollection<Producto> _productos;
        private ObservableCollection<Producto> _productosdes;
        private Categoria _categoriaSeleccionada;
        private Categoria _categoriadesSeleccionada;
        public Categoria categoriaaAñadir { get; set; }
        private NuevasComandas _nuevaComandaSeleccionada;
        public Listdetallecuenta nuevaComandaAñadir { get; set; }
        
        private Listdetallecuenta _detalleCuentaSeleccionada;
        private Producto _productoSeleccionado;
        private Producto _productodesSeleccionado;
        public Producto productoaAñadir { get; set; }
        private Mesa _mesaSeleccionada;
        private Cuenta _cuentaSeleccionada;


        //Delegate Comands
        private DelegateCommand _añadirMesaCommand;
        private DelegateCommand _finalizarCuentaPagadaCommand;
        private DelegateCommand _finalizarCuentaSinPagarCommand;
        private DelegateCommand _eliminarPedidodeCuentaCommand;
        private DelegateCommand _editarPedidodeCuentaCommand;
        private DelegateCommand _añadirPedidoaCuenta;
        private DelegateCommand _eliminarCategoriaCommand;
        private DelegateCommand _editarCategoriaCommand;
        private DelegateCommand _añadirCategoriaCommand;
        private DelegateCommand _habilitarCategoriaCommand;
        private DelegateCommand _eliminarProductoCommand;
        private DelegateCommand _editarProductoCommand;
        private DelegateCommand _añadirProductoCommand;
        private DelegateCommand _habilitarProductoCommand;
        private DelegateCommand _eliminarNuevaComandaCommand;
        public String textoaBuscar { get; set; }

        public clsMainPageVM()
        {
            nuevasComandas = new ObservableCollection<NuevasComandas>();
            txtCantidad = "";
            NotifyPropertyChanged("txtCantidad");
            bl = new ListadosBL();
            mb = new MesaBL();
            btnDetallesCuentaxMesa = false;
            btnProductos = false;
            btnCategoria = false;
            _gridEditadodeProd = false;

            obtenerMesas();
            obtenerNuevasComandas();
            obtenerCategorias();
            obtenerCategoriasdes();
            obtenerProductosdes();

            obtenerCuentas();
            NotifyPropertyChanged("cuentaAbierta");
            NotifyPropertyChanged("cuentaCerrada");

            _finalizarCuentaPagadaCommand = new DelegateCommand(finalizarCuentaPagada_Executed, finalizarCuenta_CanExecuted);
            _finalizarCuentaSinPagarCommand = new DelegateCommand(finalizarCuentaSinPagar_Executed, finalizarCuenta_CanExecuted);
            _eliminarPedidodeCuentaCommand = new DelegateCommand(eliminarPedidodeCuenta_Executed, eliminarPedidodeCuenta_CanExecuted);
            _editarPedidodeCuentaCommand = new DelegateCommand(editarPedidodeCuenta_Executed, editarPedidodeCuenta_CanExecuted);
            _editarCategoriaCommand = new DelegateCommand(editarCategoria_Executed, editarCategoria_CanExecuted);
            _eliminarCategoriaCommand = new DelegateCommand(eliminarCategoria_Executed,eliminarCategoria_CanExecuted);
            _añadirCategoriaCommand = new DelegateCommand(añadirCategoria_Executed);
            _añadirPedidoaCuenta = new DelegateCommand(añadirPedidoaCuenta_Executed);
            _añadirMesaCommand = new DelegateCommand(añadirMesa_Executed);
            _habilitarProductoCommand = new DelegateCommand(habilitarProducto_Executed, habilitarProducto_CanExecuted);
            _habilitarCategoriaCommand = new DelegateCommand(habilitarCategoria_Executed, habilitarCategoria_CanExecuted);
            _eliminarNuevaComandaCommand = new DelegateCommand(eliminarNuevaComanda_Executed, eliminarNuevaComanda_CanExecuted);
            _editarProductoCommand = new DelegateCommand(editarProducto_Executed, editarProducto_CanExecuted);
            _eliminarProductoCommand = new DelegateCommand(eliminarProducto_Executed, eliminarProducto_CanExecuted);
            _añadirProductoCommand = new DelegateCommand(añadirProducto_Executed);
        }

        #region getters&setters

        public string txtCantidad
        {
            get
            {
                return txtCantidad;
            }
            set
            {
                _txtCantidad = value;
                NotifyPropertyChanged("txtCantidad");
            }
        }
        public bool btnDetallesCuentaxMesa
        {
            get
            {
                return this._btndetallesCuentaxMesa;
            }
            set
            {
                this._btndetallesCuentaxMesa = value;
                NotifyPropertyChanged("btnDetallesCuentaxMesa");
            }
        }

        public bool btnProductos
        {
            get
            {
                return this._btnProductos;
            }
            set
            {
                this._btnProductos = value;
                NotifyPropertyChanged("btnProductos");
            }
        }

        public bool btnCategoria
        {
            get
            {
                return this._btnCategoria;
            }
            set
            {
                this._btnCategoria = value;
                NotifyPropertyChanged("btnCategoria");
            }
        }

        public bool mesaConCuenta
        {
            get
            {
                return this._mesaConCuenta;
            }
            set
            {
                this._mesaConCuenta = value;
                NotifyPropertyChanged("mesaConCuenta");
            }
        }
        public bool gridEditadodeProd
        {
            get
            {
                return this._gridEditadodeProd;
            }
            set
            {
                this._gridEditadodeProd = value;
                NotifyPropertyChanged("gridEditadodeProd");
            }
        }

        public ObservableCollection<Mesa> mesas
        {
            get
            {
                return _mesas;
            }

            set
            {
                _mesas = value;
                NotifyPropertyChanged("mesas");
            }
        }

        public ObservableCollection<NuevasComandas> nuevasComandas
        {
            get
            {
                return _nuevasComandas;
            }

            set
            {
                _nuevasComandas = value;
                NotifyPropertyChanged("nuevasComandas");

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += timer_Tick;
                timer.Start();
            }
        }
        void timer_Tick(object sender, object e)
        {
            obtenerNuevasComandas();
            timer.Tick -= timer_Tick;
        }
        public ObservableCollection<Cuenta> cuentas
        {
            get
            {
                return _cuentas;
            }

            set
            {
                _cuentas = value;
                NotifyPropertyChanged("cuentas");
            }
        }

        public ObservableCollection<Producto> productos
        {
            get
            {
                return _productos;
            }

            set
            {
                _productos = value;
                NotifyPropertyChanged("productos");
            }
        }
        public ObservableCollection<Producto> productosdes
        {
            get
            {
                return _productosdes;
            }

            set
            {
                _productosdes = value;
                NotifyPropertyChanged("productosdes");
            }
        }

        public ObservableCollection<Categoria> listCategorias
        {
            get
            {
                return _listCategorias;
            }
            set
            {
                _listCategorias = value;
                NotifyPropertyChanged("listCategorias");
            }
        }
        public ObservableCollection<Categoria> listCategoriasdes
        {
            get
            {
                return _listCategoriasdes;
            }
            set
            {
                _listCategoriasdes = value;
                NotifyPropertyChanged("listCategoriasdes");
            }
        }

        public NuevasComandas nuevaComandaSeleccionada
        {
            get
            {
                return _nuevaComandaSeleccionada;
            }

            set
            {
                _nuevaComandaSeleccionada = value;
                EliminarNuevaComandaCommand.RaiseCanExecuteChanged();
            }
        }

        public Listdetallecuenta detalleCuentaSeleccionada
        {
            get
            {
                return _detalleCuentaSeleccionada;
            }

            set
            {
                _detalleCuentaSeleccionada = value;
                btnDetallesCuentaxMesa = true;
                NotifyPropertyChanged("detalleCuentaSeleccionada");
                EliminarPedidodeCuentaCommand.RaiseCanExecuteChanged();
                
            }
        }

        public Categoria categoriaSeleccionada
        {
            get
            {
                return _categoriaSeleccionada;
            }

            set
            {

                _categoriaSeleccionada = value;
                NotifyPropertyChanged("categoriaSeleccionada");
                productoSeleccionado = null;
                btnProductos = false;
                
                if (value != null)
                {
                    btnCategoria = true;
                    obtenerProductosxCategoria();
                    EliminarCategoriaCommand.RaiseCanExecuteChanged();
                    EditarCategoriaCommand.RaiseCanExecuteChanged();
                    obtenerProductosxCategoria();
                    
                    SelectedIndexProducto = 0;
                }
                else
                {
                    btnCategoria = false;
                }
                
            }
        }

        public Categoria categoriadesSeleccionada
        {
            get
            {
                return _categoriadesSeleccionada;
            }

            set
            {

                _categoriadesSeleccionada = value;
                HabilitarCategoriaCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("categoriadesSeleccionada");
                
            }
        }

        public Producto productoSeleccionado
        {
            get
            {
                return _productoSeleccionado;
            }

            set
            {
                _productoSeleccionado = value;

                
                EditarProductoCommand.RaiseCanExecuteChanged();
                EliminarProductoCommand.RaiseCanExecuteChanged();
                if (value != null)
                {
                    SelectedIndexCategoria = value.idcategoria - 1;
                    btnProductos = true;
                    
                }
                NotifyPropertyChanged("productoSeleccionado");
            }
        }


        public Producto productodesSeleccionado
        {
            get
            {
                return _productodesSeleccionado;
            }

            set
            {
                _productodesSeleccionado = value;
                NotifyPropertyChanged("productodesSeleccionado");
                HabilitarProductoCommand.RaiseCanExecuteChanged();
            }
        }
        public Mesa mesaSeleccionada
        {
            get
            {
                return _mesaSeleccionada;
            }

            set
            {
                _mesaSeleccionada = value;
                //Cargar cuenta x mesa
                obtenerCuentaxmesa(value.Nummesa);
                NotifyPropertyChanged("mesaSeleccionada");
            }
        }

        public Cuenta cuentaSeleccionada
        {
            get
            {
                return _cuentaSeleccionada;
            }

            set
            {
                _cuentaSeleccionada = value;
                NotifyPropertyChanged("cuentaSeleccionada");
            }
        }




        //DelegateCommands
        
        public DelegateCommand FinalizarCuentaPagadaCommand
          {
             get
              {

                  return _finalizarCuentaPagadaCommand;
              }


          }
        public DelegateCommand FinalizarCuentaSinPagarCommand
        {
            get
            {

                return _finalizarCuentaSinPagarCommand;
            }


        }

        public DelegateCommand EliminarPedidodeCuentaCommand
        {
            get
            {

                return _eliminarPedidodeCuentaCommand;
            }
        }

        public DelegateCommand EditarPedidodeCuentaCommand
        {
            get
            {

                return _editarPedidodeCuentaCommand;
            }


        }

        public DelegateCommand EditarCategoriaCommand
        {
            get
            {

                return _editarCategoriaCommand;
            }

        }

        public DelegateCommand AñadirCategoriaCommand
        {
            get
            {

                return _añadirCategoriaCommand;
            }
        }

        public DelegateCommand EliminarCategoriaCommand
        {
            get
            {

                return _eliminarCategoriaCommand;
            }
        }

        public DelegateCommand AñadirPedidoaCuentaCommand
        {
            get
            {

                return _añadirPedidoaCuenta;
            }
        }

        public DelegateCommand AñadirMesaCommand
        {
            get
            {

                return _añadirMesaCommand;
            }
        }

        public DelegateCommand EditarProductoCommand
        {
            get
            {

                return _editarProductoCommand;
            }

        }

        public DelegateCommand AñadirProductoCommand
        {
            get
            {

                return _añadirProductoCommand;
            }
        }

        public DelegateCommand EliminarProductoCommand
        {
            get
            {

                return _eliminarProductoCommand;
            }
        }
        public DelegateCommand HabilitarProductoCommand
        {
            get
            {

                return _habilitarProductoCommand;
            }
        }
        public DelegateCommand HabilitarCategoriaCommand
        {
            get
            {

                return _habilitarCategoriaCommand;
            }
        }
        public DelegateCommand EliminarNuevaComandaCommand
        {
            get
            {

                return _eliminarNuevaComandaCommand;
            }
        }

        
        #endregion
        #region funciones

        public Categoria getNombreCatxId(int id)
        {
            Categoria categoria = null;

            foreach (Categoria cat in listCategorias)
            {
                if (cat.idCategoria == id) categoria = cat;
                
            } 

            return categoria;
        }


        public async Task obtenerCuentaxmesa(int nummesa)
        {
            cuentaSeleccionada = await mb.getCuentaxMesa(nummesa);
            if(cuentaSeleccionada != null)
            {
                mesaConCuenta = true;
                FinalizarCuentaPagadaCommand.RaiseCanExecuteChanged();
                FinalizarCuentaSinPagarCommand.RaiseCanExecuteChanged();
                SelectedIndexCategoria = 0;
                SelectedIndexProducto = 0;
            }
            else
            {
                mesaConCuenta = false;
            }
        }
        public async void obtenerMesas()
        {
            mesas = await bl.getMesas();
        }

        /// <summary>
        /// Llamada al bl para recoger las nuevas comandas
        /// </summary>
        private async void obtenerNuevasComandas()
        {
            nuevasComandas = await bl.getNuevasComandas();
        }
        private async void obtenerCuentas()
        {
            cuentas = await bl.getCuentas();
        }

        public async void obtenerCategorias()
        {

            listCategorias = await bl.getCategorias();
        }
        public async void obtenerCategoriasdes()
        {
            listCategoriasdes = await bl.getCategoriasInactivas();
        }

        public async void obtenerProductosdes()
        {
           
            productosdes = await bl.getProductosInactivos();
        }

        /// <summary>
        /// Recoge los productos segun la categoria
        /// </summary>
        private async void obtenerProductosxCategoria()
        {
            ObservableCollection<Producto> productosse = new ObservableCollection<Producto>();
           
            foreach ( Producto producto in await bl.getProductos())
            {
                if(categoriaSeleccionada.idCategoria == producto.idcategoria)
                    productosse.Add(producto);
            }
            productos = productosse;
            
        }

        #region Commands
        /// <summary>
        ///  Metodo para comprobar si puede ejecutarse el comando De eliminar
        /// </summary>
        /// <returns></returns>
        /// 
        private bool finalizarCuenta_CanExecuted()
        {
            bool sePuedeBorrar = false;

            if (cuentaSeleccionada != null) sePuedeBorrar = true;

            return sePuedeBorrar;
        }

        /// <summary>
        /// Metodo para eliminar a una persona
        /// </summary>
        private  void finalizarCuentaPagada_Executed()
        {

            //Lo hago con un metodo click desde el codigo behind porque necesito cambiar de pantalla despues de hacer la accion. 
            //Y no lo puedo hhacer desde viewModel.
            
            /*
            CuentaBL cbl = new CuentaBL();
            
            ContentDialog dialogo = new ContentDialog();
            dialogo.Title = "Finalizar cuenta";
            dialogo.Content = "¿Está seguro de que desea finalizar la cuenta?";
            dialogo.PrimaryButtonText = "Cancelar";
            dialogo.SecondaryButtonText = "Aceptar";

            ContentDialogResult resultado = await dialogo.ShowAsync();

           if(resultado == ContentDialogResult.Secondary)
            {
              if(await cbl.finalizarCuentaPagada(cuentaSeleccionada.idcuenta))
                {
                    cuentaSeleccionada = null;
                    ContentDialog dialogofin = new ContentDialog();
                    dialogo.Title = "Finalizado";
                    dialogo.Content = "Finalizado con exito.";
                    dialogo.PrimaryButtonText = "Ok";

                    ContentDialogResult resultadofin = await dialogo.ShowAsync();
                }

            }*/

        }

        public async Task<bool> finalizarCuentaPagadaParaCodigoBehind()
        {
            CuentaBL cbl = new CuentaBL();
            bool fincuenta=false;
            ContentDialog dialogo = new ContentDialog();
            dialogo.Title = "Finalizar cuenta";
            dialogo.Content = "¿Está seguro de que desea finalizar la cuenta?";
            dialogo.PrimaryButtonText = "Cancelar";
            dialogo.SecondaryButtonText = "Aceptar";

            ContentDialogResult resultado = await dialogo.ShowAsync();

            if (resultado == ContentDialogResult.Secondary)
            {
                if (await cbl.finalizarCuentaPagada(cuentaSeleccionada.idcuenta))
                {
                    cuentaSeleccionada = null;
                    ContentDialog dialogofin = new ContentDialog();
                    dialogo.Title = "Finalizado";
                    dialogo.Content = "Finalizado con exito.";
                    dialogo.PrimaryButtonText = "Ok";

                    ContentDialogResult resultadofin = await dialogo.ShowAsync();
                    fincuenta = true;
                }

            }
            return fincuenta;
        }

        /// <summary>
        /// Metodo para eliminar a una persona
        /// </summary>
        private void finalizarCuentaSinPagar_Executed()
        {
            /* CuentaBL cbl = new CuentaBL();

             ContentDialog dialogo = new ContentDialog();
             dialogo.Title = "Finalizar cuenta";
             dialogo.Content = "¿Está seguro de que dejar la cuenta sin pagar?";
             dialogo.PrimaryButtonText = "Cancelar";
             dialogo.SecondaryButtonText = "Aceptar";

             ContentDialogResult resultado = await dialogo.ShowAsync();

             if (resultado == ContentDialogResult.Secondary)
             {
                 if (await cbl.finalizarCuentaSinPagar(cuentaSeleccionada.idcuenta))
                 {
                     cuentaSeleccionada = null;
                     ContentDialog dialogofin = new ContentDialog();
                     dialogo.Title = "Finalizado";
                     dialogo.Content = "Finalizado con exito.";
                     dialogo.PrimaryButtonText = "Ok";

                     ContentDialogResult resultadofin = await dialogo.ShowAsync();
                 }

             }*/

        }

        public async Task<bool> finalizarCuentaSinPagarParaCodigoBehind()
        {
            CuentaBL cbl = new CuentaBL();
            bool fincuenta = false;
            

            ContentDialog dialogo = new ContentDialog();
            dialogo.Title = "Finalizar cuenta";
            dialogo.Content = "¿Está seguro de que dejar la cuenta sin pagar?";
            dialogo.PrimaryButtonText = "Cancelar";
            dialogo.SecondaryButtonText = "Aceptar";

            ContentDialogResult resultado = await dialogo.ShowAsync();

            if (resultado == ContentDialogResult.Secondary)
            {
                if (await cbl.finalizarCuentaSinPagar(cuentaSeleccionada.idcuenta))
                {
                    cuentaSeleccionada = null;
                    ContentDialog dialogofin = new ContentDialog();
                    dialogo.Title = "Finalizado";
                    dialogo.Content = "Finalizado con exito.";
                    dialogo.PrimaryButtonText = "Ok";

                    ContentDialogResult resultadofin = await dialogo.ShowAsync();
                    fincuenta = true;
                }

            }
            return fincuenta;
        }
        /*private bool GuardarCommand_CanExecuted()
        {
            bool sePuedeGuardar = false;

            return sePuedeGuardar;
        }*/

        /* private async void GuardarCommand_Executed()
         {

         }*/

        private async void eliminarPedidodeCuenta_Executed()
        {

            CuentaBL cbl = new CuentaBL();

            if (await cbl.eliminarPedidodeCuenta(cuentaSeleccionada.idcuenta, detalleCuentaSeleccionada.producto.idproducto)) { 
               await obtenerCuentaxmesa(mesaSeleccionada.Nummesa);
                btnDetallesCuentaxMesa = false;
                NotifyPropertyChanged("btnDetallesCuentaxMesa");

            }

        }


        private bool eliminarPedidodeCuenta_CanExecuted()
        {
            bool sepuedeeliminar = false;
            if (detalleCuentaSeleccionada != null)
            {
                sepuedeeliminar = true;
            }

            return sepuedeeliminar;
        }


        private async void editarPedidodeCuenta_Executed()
        {
          //  int cantidad = int.Parse(txtCantidad);
            CuentaBL cbl = new CuentaBL();
            List<Listdetallecuenta> detalle = new List<Listdetallecuenta>();

            detalle.Add(detalleCuentaSeleccionada);

            if (await cbl.editarPedidodeCuenta(cuentaSeleccionada.idcuenta, detalle))
            {
                await obtenerCuentaxmesa(mesaSeleccionada.Nummesa);
                btnDetallesCuentaxMesa = false;
                btnCategoria = false;
                NotifyPropertyChanged("btnDetallesCuentaxMesa");

            }

        }


        private bool editarPedidodeCuenta_CanExecuted()
        {
            bool sepuedeeditar = false;
            if (detalleCuentaSeleccionada != null)
            {
                sepuedeeditar = true;
            }

            return sepuedeeditar;
        }

        private async void eliminarCategoria_Executed()
        {
            
            CategoriaBL cbl = new CategoriaBL();
        
            if (await cbl.eliminarCategoria(categoriaSeleccionada.idCategoria))
            {
               obtenerCategorias();
                categoriaSeleccionada = null;
                btnCategoria = false;
            }

        }

        private bool eliminarCategoria_CanExecuted()
        {
            bool sepuedeeditar = false;
            if (categoriaSeleccionada != null)
            {
                sepuedeeditar = true;
            }

            return sepuedeeditar;
        }


        public async void editarCategoria_Executed()
        {

            CategoriaBL cbl = new CategoriaBL();

            if (await cbl.updateCategoria(categoriaSeleccionada))
            {
                
                obtenerCategorias();
                categoriaSeleccionada = null;
                btnCategoria = false;
                
            }

        }

        public bool editarCategoria_CanExecuted()
        {
            bool sepuedeeditar = false;
            if (categoriaSeleccionada != null)
            {
                
                sepuedeeditar = true;
            }

            return sepuedeeditar;
        }


        public async void añadirCategoria_Executed()
        {

            CategoriaBL cbl = new CategoriaBL();

            if (await cbl.addCategoria(categoriaaAñadir))
            {
                productoSeleccionado = null;
                obtenerCategorias();
            }

        }


        public async void añadirPedidoaCuenta_Executed()
        {
            bool añadido;
            CuentaBL cbl = new CuentaBL();
            if (cuentaSeleccionada == null)
            {
                 añadido = await cbl.añadirCuenta(mesaSeleccionada.Nummesa);
                if (añadido) await obtenerCuentaxmesa(mesaSeleccionada.Nummesa);

            }

            
            List<Listdetallecuenta> detalles = new List<Listdetallecuenta>();

            detalles.Add(nuevaComandaAñadir);
            Cuenta cuentaaux = new Cuenta(cuentaSeleccionada.idcuenta,mesaSeleccionada.Nummesa,detalles,"1/1/1",0,0);

            if (await cbl.añadirPedidoaCuenta(cuentaaux)) 
            {
                await obtenerCuentaxmesa(mesaSeleccionada.Nummesa);
                detalleCuentaSeleccionada = null;
            }

        }

        public async void añadirMesa_Executed()
        {
            MesaBL mb = new MesaBL();
            if(await mb.addmesa())
            {
                obtenerMesas();
            }
        }




        public async void editarProducto_Executed()
        {

            ProductoBL cbl = new ProductoBL();

            if (await cbl.updateProducto(productoSeleccionado))
            {

                obtenerProductosxCategoria();
                productoSeleccionado = null;
                btnProductos = false;

            }

        }

        public bool editarProducto_CanExecuted()
        {
            bool sepuedeeditar = false;
            if (productoSeleccionado != null)
            {

                sepuedeeditar = true;
            }

            return sepuedeeditar;
        }


        public async void añadirProducto_Executed()
        {

            ProductoBL cbl = new ProductoBL();

            if (await cbl.addProducto(productoaAñadir))
            {
                productoSeleccionado = null;
                obtenerProductosxCategoria();
            }

        }

        private async void eliminarProducto_Executed()
        {

            ProductoBL cbl = new ProductoBL();

            if (await cbl.deleteProducto(productoSeleccionado.idproducto))
            {
                obtenerProductosxCategoria();
                productoSeleccionado = null;
                btnProductos = false;
            }

        }

        private bool eliminarProducto_CanExecuted()
        {
            bool sepuedeeditar = false;
            if (productoSeleccionado != null)
            {
                sepuedeeditar = true;
            }

            return sepuedeeditar;
        }

        private async void habilitarProducto_Executed()
        {

            ProductoBL cbl = new ProductoBL();
            productodesSeleccionado.operativo = 1;
            if (await cbl.updateProducto(productodesSeleccionado))
            {
                obtenerProductosdes();
                productodesSeleccionado = null;
                
            }

        }

        private bool habilitarProducto_CanExecuted()
        {
            bool sepuedeeditar = false;
            if (productodesSeleccionado != null)
            {
                sepuedeeditar = true;
            }

            return sepuedeeditar;
        }

        private async void habilitarCategoria_Executed()
        {

            CategoriaBL cbl = new CategoriaBL();
            categoriadesSeleccionada.operativo = 1;
            if (await cbl.updateCategoria(categoriadesSeleccionada))
            {
                obtenerCategoriasdes();
                categoriadesSeleccionada = null;

            }

        }

        private bool habilitarCategoria_CanExecuted()
        {
            bool sepuedeeditar = false;
            if (categoriadesSeleccionada != null)
            {
                sepuedeeditar = true;
            }

            return sepuedeeditar;
        }


        private async void eliminarNuevaComanda_Executed()
        {

            NuevaComandaBL cbl = new NuevaComandaBL();

            if (await cbl.eliminarNuevaComanda(nuevaComandaSeleccionada.idCuenta,nuevaComandaSeleccionada.producto.idproducto))
            {
                obtenerNuevasComandas();
                productoSeleccionado = null;
                btnProductos = false;
            }

        }

        private bool eliminarNuevaComanda_CanExecuted()
        {
            bool sepuedeeditar = false;
            if (nuevaComandaSeleccionada != null)
            {
                sepuedeeditar = true;
            }

            return sepuedeeditar;
        }


        #endregion

        #endregion
    }
}
