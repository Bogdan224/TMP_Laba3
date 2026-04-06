using System.Windows.Controls;

namespace TMP_Laba3_Libraries.MyMenu
{
    public class MenuBuilder
    {
        private Menu _menu;

        public MenuBuilder() { 
            _menu = new Menu();
        }

        public void AddMenuItem(MenuItemInfo menuItem)
        {
            _menu.Items.Add(InitializeMenuItem(menuItem));
        }

        private MenuItem InitializeMenuItem(MenuItemInfo menuItem)
        {
            MenuItem res = new MenuItem();
            res.Name = menuItem.Name;
            res.CommandParameter = menuItem.Command;

            foreach (var item in menuItem.Items)
            {
                res.Items.Add(InitializeMenuItem(item));
            }

            return res;
        }

        public Menu Build()
        {
            return _menu;
        }
    }
}
