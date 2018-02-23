using Examen_Final_Alejandro_Gomez_DAL.Listados;
using Examen_Final_Alejandro_Gomez_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_BL.Listados
{
    public class clsGestoraListadosBL
    {

        public clsGestoraListadoLuchadoresDAL gestoraListadoLuchadoresDAL { get; set; }
        public clsGestoraListadoCombatesDAL gestoraListadoCombatesDAL { get; set; }
        public clsGestoraListadoCategoriasPremiosDAL gestoraListadoCategoriasPremiosDAL { get; set; }
        public clsGestoraListadoCasasDAL gestoraListadoCasasDAL { get; set; }


        public clsGestoraListadosBL ()
        {
            this.gestoraListadoLuchadoresDAL = new clsGestoraListadoLuchadoresDAL();
            this.gestoraListadoCombatesDAL = new clsGestoraListadoCombatesDAL();
            this.gestoraListadoCategoriasPremiosDAL = new clsGestoraListadoCategoriasPremiosDAL();
            this.gestoraListadoCasasDAL = new clsGestoraListadoCasasDAL();
        }

        /// <summary>
        /// Metodo que devuelve un listado con todos los luchadores
        /// </summary>
        /// <returns></returns>
        public List<clsLuchador> getListadoLuchadores()
        {
            List<clsLuchador> lista;

            lista = gestoraListadoLuchadoresDAL.getListadoLuchadoresDAL();

            return lista;

        }

        public List<clsLuchador> getListadoLuchadoresMenosUno(int id)
        {
            List<clsLuchador> lista;

            lista = gestoraListadoLuchadoresDAL.getListadoLuchadoresMenosUnoDAL(id);

            return lista;
        }

        /// <summary>
        /// Metodo que devuelve un listado con todas las casas
        /// </summary>
        /// <returns></returns>
        public List<clsCasa> getListadoCasas()
        {
            List<clsCasa> lista;

            lista = gestoraListadoCasasDAL.getListadoCasasDAL();

            return lista;

        }

        /// <summary>
        /// Metodo que devuelve un listado con todos los combates
        /// </summary>
        /// <returns></returns>
        public List<clsCombate> getListadoCombates()
        {
            List<clsCombate> lista;

            lista = gestoraListadoCombatesDAL.getListadoCombatesDAL();

            return lista;

        }

        /// <summary>
        /// Metodo que devuelve un listado con todas las categoriasPremios
        /// </summary>
        /// <returns></returns>
        public List<clsCategoriaPremio> getListadoCategoriasPremios()
        {
            List<clsCategoriaPremio> lista;

            lista = gestoraListadoCategoriasPremiosDAL.getListadoCategoriasPremiosDAL();

            return lista;

        }
    }
}
