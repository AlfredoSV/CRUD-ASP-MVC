using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsuariosMVC.Models;

namespace UsuariosMVC.Controllers
{
    public class HomeController : Controller
    {
        private AccesoUsuario acceso = null;
        // GET: Home
        public ActionResult Index()
        {

            if (Session["usuario"] == null)
            {
                return View();

            }


            return RedirectToAction("Ingresar");
        }


        public ActionResult Ingresar(FormCollection datosUsuario)
        {
            var accesoBan = String.Empty;

            if (ModelState.IsValid && Session["usuario"] == null && datosUsuario["Usu_Name"] != null && datosUsuario["Usu_Pass"] != null)
            {
                acceso = new AccesoUsuario();
                accesoBan = acceso.validarUsu(datosUsuario["Usu_Name"], datosUsuario["Usu_Pass"]);
                if (accesoBan.Equals("1"))
                {
                    Session.Add("usuario",datosUsuario["Usu_Name"]);
                    TempData["datosIncorrectos"] = null;

                }
            }

            if (Session["usuario"] == null || accesoBan.Equals("0"))
            {
                TempData["datosIncorrectos"] = "1";
                return RedirectToAction("Index");
            }
           
            return View();

        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Remove("usuario");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Alta(FormCollection formCollection)
        {
            var strEstatusOp = String.Empty;
            var vistaRetorno = String.Empty;
            if (ModelState.IsValid)
            {
                Alumno alumno = new Alumno()
                {
                    Nombre = formCollection["Nombre"],
                    ApellidoP = formCollection["ApellidoP"],
                    ApellidoM = formCollection["ApellidoM"],
                    Edad = Int32.Parse(formCollection["Edad"]),
                    Email = formCollection["Email"],
                    Carrera = formCollection["Carrera"],
                    Campus = formCollection["Campus"],
                    Calle = formCollection["Calle"],
                    Colonia = formCollection["Colonia"],
                    CP = formCollection["CP"],
                    HermanosInstitu = formCollection["HermanosInstitu"],
                    Manzana = Int32.Parse(formCollection["Manzana"]),
                    NoExt = formCollection["NoExt"],
                    NoInt = formCollection["NoInt"],
                    Num1 = formCollection["Num1"],
                    Num2 = formCollection["Num2"],
                    Num3 = formCollection["Num3"],
                    PromedioMedioSup = decimal.Parse(formCollection["PromedioMedioSup"])

                };

                MantenimientoAlumno mantenimientoAlumno = new MantenimientoAlumno();
                strEstatusOp = mantenimientoAlumno.altaAlumno(alumno);

            }

            if (strEstatusOp.Equals("1"))
            {
                vistaRetorno = "Exito";
            }else if (strEstatusOp.Equals("0"))
            {
                vistaRetorno = "Error";
                
            }
            
            return View(vistaRetorno);
        }

        [HttpGet]
        public ActionResult ListarAlumnos()
        { 

            if (Session["usuario"] == null)
            {
                //TempData["datosIncorrectos"] = "1";
                return RedirectToAction("Index");
            }
            MantenimientoAlumno alumnos = new MantenimientoAlumno();

            return View(alumnos.Listar());
        }



        [HttpGet]
        public ActionResult DetalleAlumno(int id_Alumno)
        {
            if (Session["usuario"] == null)
            {

                return RedirectToAction("Index");
            }
            MantenimientoAlumno alumno = new MantenimientoAlumno();
                        
            return View(alumno.DetalleAlumno(id_Alumno));
        }

        [HttpGet]
        public ActionResult ModificarForm(int id_Alumno)
        {

            if (Session["usuario"] == null)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ModificarGuardar(FormCollection datosMadificados)
        {
            return View();
        }

        [HttpGet]
        public ActionResult BorrarAlumno(int id_Alumno)
        {
            MantenimientoAlumno eliminarAlumno = new MantenimientoAlumno();
            eliminarAlumno.EliminarAlumno(id_Alumno);
            return RedirectToAction("ListarAlumnos");
        }

    }


}
