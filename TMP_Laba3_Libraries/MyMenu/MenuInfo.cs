using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP_Laba3_Libraries.MyMenu
{
    public class MenuInfo
    {
        public List<MenuItemInfo> MenuItems { get; set; }

        public MenuInfo() 
        { 
            MenuItems = new List<MenuItemInfo>();
        }
    }
}
