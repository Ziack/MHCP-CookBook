
namespace MHCP.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    using MHCP.Domain.BoundedContexts.APR.Contracts.Tasks;
    using SharpArch.Domain;
    using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;

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
            var result = personTask.GetPersonsByAge(10);
            personTask.Close();
            return View();
        }

    }
}
