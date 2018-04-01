using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using pruebaLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pruebaLogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var estaAutenticado = User.Identity.IsAuthenticated; //identity nos permite obtener datos del usuario
            if(estaAutenticado)
            {
                var nombreUsuario = User.Identity.Name;
                var id = User.Identity.GetUserId();

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var usuario = db.Users.Where(x => x.Id == id).FirstOrDefault();
                    var emailConfirmado = usuario.EmailConfirmed;

                    var userManager = new UserManager<ApplicationUser>( //userManager, crear manualmente desde aca los usuarios
                        new UserStore<ApplicationUser>(db));

                    //var usuario2 = userManager.FindById(id);

                    var user = new ApplicationUser();
                    user.UserName = "abby";
                    user.Email = "abby@gmail.com";

                    var resultado = userManager.Create(user, "MiPasswordSecreto");
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}