using ASPNET_MVC_ANGULAR.DAL;
using ASPNET_MVC_ANGULAR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC_ANGULAR.Controllers
{
    public class RestauranteController : Controller
    {
        // GET: Restaurante
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetRestaurantes()
        {

            List<Restaurante> lstRestaurantes = new List<Restaurante>();

            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    lstRestaurantes = rc.Restaurantes.ToList();
                    return Json(lstRestaurantes, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        
        public JsonResult GetRestaurante(int id)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    var restaurante = rc.Restaurantes.Find(id);
                    return Json(restaurante, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public JsonResult GetRestaurantePorNome(string nome)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    var restaurante = rc.Restaurantes.Where(x=> x.Nome.Contains(nome)).ToList();
                    return Json(restaurante, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        public ViewResult EditarRestaurante()
        {
            return View();

        }

        [HttpPost]
        public ViewResult EditarRestaurante(Restaurante restaurante)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    var rest = rc.Restaurantes.Find(restaurante.RestauranteId);
                    rest.Nome = restaurante.Nome;
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
        public JsonResult CriarRestaurante(Restaurante novoRestaurante)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    rc.Restaurantes.Add(novoRestaurante);
                    rc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        public ViewResult CriarRestaurante()
        {

            return View();
        }

        public JsonResult ExcluirRestaurante(Restaurante restaurante)
        {
            try
            {
                using (RestauranteContext rc = new RestauranteContext())
                {
                    var r = rc.Restaurantes.Find(restaurante.RestauranteId);
                    rc.Restaurantes.Remove(r);
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
}