using System.IO;
using System.Reflection;
using System.Windows;
using TMP_Laba3_Authorization;
using TMP_Laba3_Menu;

namespace TMP_Laba3
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow(Person person)
        {
            InitializeComponent();

            string dllPath = Assembly.GetExecutingAssembly().Location;
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", ".."));

            DataContext = new MenuWindowViewModel(person, Path.Combine(path, "menu.txt"), Path.Combine(path, "roles.txt"));
        }
    }
}
