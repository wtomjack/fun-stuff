using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class MenuItem : Item
    {
        private List<SubItem> _menuItems;
         
        public string Id { get; set; }
        public List<SubItem> SubItem
        {
            get
            {
                return this._menuItems ?? (this._menuItems = new List<SubItem>());
            }
            set
            {
                this._menuItems = value;
            }
        }
    }

    public class Item
    {
        public string Title { get; set; }
        public string RouteController { get; set; }

        public string RouteMethod { get; set; }
    }

    public class SubItem : Item
    {
        public string SubItemKey { get; set; }

        public string URL { get; set; }
    }
}