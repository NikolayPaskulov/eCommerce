using System.Web.Mvc;

namespace eCommerce.Web.Areas.Components
{
    public class ComponentsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Components";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Components_default",
                "Components/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, controller = "Components" }
            );
        }
    }
}