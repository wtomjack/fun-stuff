using System;
using System.Collections.Generic;
using Project.Models;

namespace Project
{
    public class Menu
    {
        private List<MenuItem> _menuItems;

        public List<MenuItem> MenuItems
        {
            get
            {
                return this._menuItems ?? new List<MenuItem>();
            }
            set
            {
                this._menuItems = value;
            }
        }
    }

}