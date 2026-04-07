using System.IO;

namespace TMP_Laba3_Menu
{
    public static class MenuFileParser
    {
        public static MenuInfo Parse(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("Файл меню не найден!");

            MenuInfo menuInfo = new MenuInfo();

            throw new NotImplementedException();

            return menuInfo;
        }
    }
}
