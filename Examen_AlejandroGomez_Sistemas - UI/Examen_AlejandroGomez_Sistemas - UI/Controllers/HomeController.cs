using Examen_AlejandroGomez_Sistemas___BL.Listados;
using Examen_AlejandroGomez_Sistemas___BL.Manejadoras;
using Examen_AlejandroGomez_Sistemas___ET;
using Examen_AlejandroGomez_Sistemas___UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen_AlejandroGomez_Sistemas___UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            clsListadoCursos cursos = new clsListadoCursos();

            //List<clsCurso> cursos;

            clsListadoCursosBL listadoCursosBL = new clsListadoCursosBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    cursos.cursos = listadoCursosBL.getListadoCursosBL();
                }
                catch (Exception)
                {

                    return View("PgnError");
                }

            }

            return View(cursos);
        }
        [HttpPost]
        public ActionResult Index(clsCurso curso)
        {
            int id = curso.idCurso;

            List<clsAlumno> alumnos;
            clsListadoAlumnosBL listadoAlumnosBL = new clsListadoAlumnosBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    alumnos = listadoAlumnosBL.getListadoAlumnosPorCursoBL(id);
                }
                catch (Exception)
                {

                    return View("PgnError");
                }

            }


            //return RedirectToAction("ListaAlumnos/"+id);
            return RedirectToAction("ListaAlumnos", alumnos);
        }

        /*
        public ActionResult ListaAlumnos (int id)
        {
            List<clsAlumno> alumnos;
            clsListadoAlumnosBL listadoAlumnosBL = new clsListadoAlumnosBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    alumnos = listadoAlumnosBL.getListadoAlumnosPorCursoBL(id);
                }
                catch (Exception)
                {

                    return View("PgnError");
                }

            }

            return View(alumnos);
        }

    */

        public ActionResult Beca (int id)
        {
            clsAlumnoNombreCurso alumnoNombreCurso;
            clsManejadoraAlumnosBL manejadoraAlumnosBL = new clsManejadoraAlumnosBL();
            clsManejadoraCursosBL manejadoraCursosBL = new clsManejadoraCursosBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    clsAlumno alumno = manejadoraAlumnosBL.getAlumnoPorIdBL(id);
                    String nombreCurso = manejadoraCursosBL.getNombreCursoPorIdBL(alumno.idCurso);
                    alumnoNombreCurso = new clsAlumnoNombreCurso(alumno, nombreCurso);
                }
                catch (Exception)
                {

                    return View("PgnError");
                }

            }
            return View (alumnoNombreCurso);
        }

        [HttpPost]
        public ActionResult Beca (clsAlumno alumno)
        {
            int resultado = 0;
            clsManejadoraAlumnosBL manejadoraAlumnosBL = new clsManejadoraAlumnosBL();

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                try
                {
                    resultado = manejadoraAlumnosBL.asignarBecaAlumnoBL(alumno.idAlumno, alumno.beca);
                }
                catch (Exception)
                {

                    return View("PgnError");
                }

            }
            return RedirectToAction("Index");
        }
    }
}