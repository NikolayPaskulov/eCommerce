using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Web.Areas.Components.Controllers
{
	[Authorize(Roles = "admin")]
    public class ComponentsController : Controller
    {
        // GET: Components/Components
        public ActionResult Index()
        {
            return View();
        }
    }
}