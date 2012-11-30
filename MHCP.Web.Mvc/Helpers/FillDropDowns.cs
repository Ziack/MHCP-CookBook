using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MHCP.Web.Mvc.Helpers;

namespace MHCP.Web.Mvc.ActionFilters
{
    public class FillDropDowns : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewModel = filterContext.Controller.ViewData.Model;
            if (viewModel != null)
                setLists(viewModel.GetType(), filterContext.Controller.ViewData);

            base.OnResultExecuting(filterContext);
        }

        private static void setLists(Type viewModelType, IDictionary<string, object> viewData)
        {
            foreach (var property in viewModelType.GetProperties())
            {                
                    dynamic att = GetCustomAttribute(property, typeof(DropDownAttribute));
                    if (att != null)
                    {
                        var viewDataKey = "DDKey_" + property.Name;
                        viewData[viewDataKey] = viewData[viewDataKey] ?? att.GetMethodResult();
                    }                
            }
        }
    } 
}