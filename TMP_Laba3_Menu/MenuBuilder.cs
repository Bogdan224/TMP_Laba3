using System.Windows.Controls;

namespace TMP_Laba3_Menu
{
    public class MenuBuilder
    {
        private List<MenuItemInfo> menuItems { get; set; }

        public MenuBuilder() 
        { 
            menuItems = new List<MenuItemInfo>();
        }

        public void AddMenuItem(MenuItemInfo menuItem)
        {
            menuItems.Add(menuItem);
        }

        public IEnumerable<MenuItemInfo> Build()
        {
            return menuItems;
        }
    }
}
