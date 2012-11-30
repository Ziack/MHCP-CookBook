using MHCP.Domain.BoundedContexts.APR;
using MHCP.Web.Mvc.Helpers;
using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;

namespace MHCP.Web.Mvc.ViewModels
{
    public class DemoViewModel
    {
        [DropDown(typeof(IAPRWcfService), "GetPersonsByAge", 10)]
        public Person PersonId { get; set; }

    }
}