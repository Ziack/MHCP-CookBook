using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MHCP.Domain.BoundedContexts.DRG.Contracts.Tasks;

namespace MHCP.Web.Mvc.Controllers
{
    public class PedidosController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

    }
}
