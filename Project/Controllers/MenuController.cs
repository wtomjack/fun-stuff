using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project.Builders;

namespace Project.Controllers
{
    public class MenuController : Controller
    {
        private MenuBuilder builder;

        public MenuController()
        {
            builder = new MenuBuilder();
        }
        public ActionResult Menu()
        {
            var menu = this.builder.Build();

            return this.PartialView(menu);
        }
    }
}