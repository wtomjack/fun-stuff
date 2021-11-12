using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Project.Builders;

namespace Project.Controllers
{
    public class MLAppDashboardController : Controller
    {
        private MLAppDashboardBuilder builder => new MLAppDashboardBuilder();

        // GET: MLAppDashboard
        public ActionResult Index()
        {
            builder.Build();
            return View();
        }
    }
}