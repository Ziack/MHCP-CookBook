using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections;
using SharpArch.Domain;

namespace MHCP.Web.Mvc.Helpers
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class DropDownAttribute : UIHintAttribute
    {
        private readonly Type _serviceType;
        private readonly string _comboBoxServiceMethods;
        private readonly object[] _arguments;


        public DropDownAttribute(Type serviceType, string methodName, params object[] arguments)
            : this(methodName, "DropDown", serviceType, arguments)
        {
        }

        public DropDownAttribute(string methodName, string templateName, Type serviceType, params object[] arguments)
            : base(templateName)
        {
            _serviceType = serviceType;
            _comboBoxServiceMethods = methodName;
            _arguments = arguments;
        }


        public IEnumerable<SelectListItem> GetMethodResult()
        {
            Check.Require(_serviceType != null, "Service class type is needed.");
            var task = MvcApplication.container.Resolve(_serviceType);
            
            var methodInfo = _serviceType.GetMethod(_comboBoxServiceMethods);
            Check.Require(methodInfo != null, String.Format("Method Name '{0}' doesn't exist in '{1}'.", _comboBoxServiceMethods, _serviceType));
            
            IList result = methodInfo.Invoke(task, _arguments) as IList;
            return new SelectList(result);

        }
    }
}