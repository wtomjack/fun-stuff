using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Mapper
{
    public static class Mapper
    {
        public static void MenuMapper(List<SubItem> subItems, List<MenuItem> menuItems)
        {
            foreach (var item in menuItems){
                item.SubItem.AddRange(subItems.Where(sub => sub.SubItemKey == item.Id));
            }
        }
    }
}