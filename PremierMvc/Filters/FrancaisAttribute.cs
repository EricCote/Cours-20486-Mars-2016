using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PremierMvc.Filters
{
    public class FrancaisAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("fr-CA");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-CA");

            base.OnActionExecuting(filterContext);
        }
    }
}