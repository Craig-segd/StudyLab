using System.Web.Mvc;
using RequireHttpsAttribute = StudyLab.Services.RequireHttpsAttribute;

namespace StudyLab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
