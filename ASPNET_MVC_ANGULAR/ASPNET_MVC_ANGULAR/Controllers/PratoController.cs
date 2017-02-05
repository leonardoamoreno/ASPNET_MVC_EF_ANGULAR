using ASPNET_MVC_ANGULAR.DAL;
using ASPNET_MVC_ANGULAR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ASPNET_MVC_ANGULAR.Controllers
{
    public class PratoController : Controller
    {
        // GET: Prato
        public ActionResult Index()
        {
        

            return View();
        }
        
        public JsonResult GetPratos()
        {
            
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    var lstPratos = rc.Pratos.Include("Restaurante")
                        .Select(x => new {
                            PratoId = x.PratoId,
                            Nome = x.Nome,
                            Preco = x.Preco,
                            RestauranteId = x.RestauranteId,
                            Restaurante = x.Restaurante
                        }).ToList();
                        
                        
                    return Json(lstPratos, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public JsonResult GetPrato(int id)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    var Prato = rc.Pratos.Find(id);
                    return Json(Prato, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public ViewResult EditarPrato()
        {
            return View();

        }

        [HttpPost]
        public ViewResult EditarPrato(Prato prato)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    var rest = rc.Pratos.Find(prato.PratoId);
                    rest.Nome = prato.Nome;
                    rest.Preco = prato.Preco;
                    rc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }

        [HttpPost]
        public JsonResult CriarPrato(Prato novoPrato)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    rc.Pratos.Add(novoPrato);
                    rc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        public ViewResult CriarPrato()
        {

            return View();
        }

        public JsonResult ExcluirPrato(Prato prato)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    var r = rc.Pratos.Find(prato.PratoId);
                    rc.Pratos.Remove(r);
                    rc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

    }

    public abstract class Controller : System.Web.Mvc.Controller
    {
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new CustomJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}