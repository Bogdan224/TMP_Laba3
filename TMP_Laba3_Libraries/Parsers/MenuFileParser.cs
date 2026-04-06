using System.IO;
using TMP_Laba3_Libraries.MyMenu; 

namespace TMP_Laba3_Libraries.Parsers
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
