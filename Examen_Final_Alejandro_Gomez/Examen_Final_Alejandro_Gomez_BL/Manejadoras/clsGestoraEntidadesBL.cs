using Examen_Final_Alejandro_Gomez_DAL.Listados;
using Examen_Final_Alejandro_Gomez_DAL.Manejadoras;
using Examen_Final_Alejandro_Gomez_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Final_Alejandro_Gomez_BL.Manejadoras
{
    public class clsGestoraEntidadesBL //Creo esta clase gestora entidades para que no se me llene el viewModel de instanciaciones de todas las gestoras
    {
        public clsGestoraLuchadorDAL gestoraLuchadorDAL { get; set; }
        public clsGestoraCombateDAL gestoraCombateDAL { get; set; }
        public clsGestoraCasaDAL gestoraCasaDAL { get; set; }
        public clsGestoraCategoriaPremioDAL gestoraCategoriaPremioDAL { get; set; }
        public clsGestoraClasificacionCombateDAL gestoraClasificacionCombateDAL { get; set; }


        public clsGestoraEntidadesBL()
        {
            this.gestoraLuchadorDAL = new clsGestoraLuchadorDAL();
            this.gestoraCombateDAL = new clsGestoraCombateDAL();
            this.gestoraCasaDAL = new clsGestoraCasaDAL();
            this.gestoraCategoriaPremioDAL = new clsGestoraCategoriaPremioDAL();
            this.gestoraClasificacionCombateDAL = new clsGestoraClasificacionCombateDAL();
        }

        /// <summary>
        /// Metodo que devuelve un luchador por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsLuchador getLuchadorPorId(int id)
        {
            clsLuchador luchador;
            luchador = gestoraLuchadorDAL.buscarLuchadorPorId(id);

            return luchador;
        }

        /// <summary>
        /// Metodo que devuelve un combate por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsCombate getCombatePorId(int id)
        {
            clsCombate combate;
            combate = gestoraCombateDAL.buscarCombatePorId(id);

            return combate;
        }

        /// <summary>
        /// Metodo que devuelve una casa por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsCasa getCasaPorId(int id)
        {
            clsCasa casa;
            casa = gestoraCasaDAL.buscarCasaPorId(id);

            return casa;
        }

        /// <summary>
        /// Metodo que devuelve una categoriaPremio por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsCategoriaPremio getCategoriaPremioPorId(int id)
        {
            clsCategoriaPremio categoriaPremio;
            categoriaPremio = gestoraCategoriaPremioDAL.buscarCategoriaPremioPorId(id);
            return categoriaPremio;
        }

        /// <summary>
        /// Metodo que inserta una clasificacion de combate
        /// </summary>
        /// <param name="clasificacionCombate"></param>
        /// <returns></returns>
        public int insertClasificacionCombate(clsClasificacionCombate clasificacionCombate)
        {
            int resultado = 0;
            resultado = gestoraClasificacionCombateDAL.insertClasificacionCombateDAL(clasificacionCombate);

            return resultado;
        }
    }
}
