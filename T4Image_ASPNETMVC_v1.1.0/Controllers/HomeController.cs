using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T4Image_ASPNETMVC_v1._1._0.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.AddWebConfig = @"
<system.webServer>
    <handlers>
        <add name=""UrlImage"" path=""Images/*"" verb=""GET"" type=""System.Web.Handlers.TransferRequestHandler"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
</system.webServer>
";
            return View();
        }
    }
}