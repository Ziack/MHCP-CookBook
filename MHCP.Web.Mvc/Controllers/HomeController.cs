
namespace MHCP.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    using MHCP.Domain.BoundedContexts.APR.Contracts.Tasks;
    using SharpArch.Domain;

    public class HomeController : Controller
    {
        private IPersonTasks personTask;

        public HomeController(IPersonTasks personTask)
        {
            this.personTask = personTask;
        }

        public ActionResult Index()
        {
            var result = personTask.GetPersonsByAge(10);
            return View();
        }

    }
}
