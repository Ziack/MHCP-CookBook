using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MHCP.Web.Mvc.ActionFilters;
using MHCP.Web.Mvc.ViewModels;

namespace MHCP.Web.Mvc.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/

        [FillDropDowns]
        public ActionResult Index()
        {
            return View(new DemoViewModel());
        }

    }
}
