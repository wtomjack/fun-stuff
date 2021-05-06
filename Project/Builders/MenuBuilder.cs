using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Project.Database;
using Project.Models;

namespace Project.Builders
{
    public class MenuBuilder
    {
        public Menu Build()
        {
           
            var dataArgs = new Dictionary<string, string> { { "MenuItem", "123" } };
            var getData = new DataAccessService(dataArgs);
            var menuItems = getData.LoadMenuItems();
            this.BuildMenuRoutes(menuItems);

            return new Menu
            {
                MenuItems = menuItems
            };
        }

        private void BuildMenuRoutes(List<MenuItem> menuItems)
        {
            foreach(var item in menuItems)
            {
                foreach(var subItem in item.SubItem)
                {
                    if(subItem.URL == null)
                    {
                        subItem.URL = $"{subItem.RouteController.Trim()}/{subItem.RouteMethod.Trim()}";
                    }
                }
            }
        }
    }
}