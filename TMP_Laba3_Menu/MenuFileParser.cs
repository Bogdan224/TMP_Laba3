using System.IO;
using System.Reflection;
using System.Windows.Controls;
using TMP_Laba3_Authorization;

namespace TMP_Laba3_Menu
{
    public static class MenuFileParser
    {
        public static MenuInfo Parse(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл меню не найден!");

            MenuInfo menuInfo = new MenuInfo();

            var items = File.ReadLines(filePath);

            foreach(var item in items)
            {
                var tmp = item.Split(' ');
                tmp[1] = tmp[1].Replace('_', ' ');

                var tmpItem = new MenuItemInfo(tmp[1], tmp.Length > 2 ? tmp[2] : null);

                if (tmp[0] == "0")
                    menuInfo.MenuItems.Add(tmpItem);
                else
                    GetLastItem(menuInfo.MenuItems.Last(), Convert.ToInt32(tmp[0])).Items.Add(tmpItem);
            }

            return menuInfo;
        }

        private static MenuItemInfo GetLastItem(MenuItemInfo menuItemInfo, int depth, int currentDepth = 1)
        {
            if (currentDepth == depth)
                return menuItemInfo;

            return GetLastItem(menuItemInfo.Items.Last(), depth, currentDepth++);
        }
    }
}
