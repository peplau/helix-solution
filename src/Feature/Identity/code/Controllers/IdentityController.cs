using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.Identity.Controllers
{
    public class IdentityController : Controller
    {
        public ActionResult SiteName()
        {
            return View();
        }
    }
}