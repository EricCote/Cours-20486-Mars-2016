using PremierMvc.Filters;
using System.Web;
using System.Web.Mvc;

namespace PremierMvc
{
    public class FilterConfig
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new FrancaisAttribute());
        }
    }
}
