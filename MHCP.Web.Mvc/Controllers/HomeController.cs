
namespace MHCP.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    using SharpArch.Domain;
    using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;
    using MHCP.Domain.BoundedContexts.DRG;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        private IAPRWcfService personTask;

        public HomeController(IAPRWcfService personTask)
        {
            Check.Require(personTask != null, "personTask may not be null");
            this.personTask = personTask;
        }

        public ActionResult Index()
        {
            var p = new Pedido();
            p.Articulos = new List<Articulo>();
            return View(p);
        }

        [HttpGet]
        public virtual PartialViewResult AgregarArticulo()
        {
            var model = new Articulo();
            return PartialView("_Articulo" , model);
        }

    }
}
