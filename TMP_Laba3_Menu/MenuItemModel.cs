using System.Reflection.PortableExecutable;
using System.Windows.Controls;
using System.Windows.Input;
using TMP_Laba3_Authorization;

namespace TMP_Laba3_Menu
{
    public class MenuItemModel
    {
        public string Header { get; set; }
        public ICommand Command { get; set; }
        public string? CommandParameter { get; set; }
        public ItemStatus Status { get; set; }
        public List<MenuItemModel> Items { get; set; }

        public MenuItemModel(string name, ICommand command, string? commandParameter = null) 
        {
            Header = name;
            Command = command;
            CommandParameter = commandParameter;
            Status = ItemStatus.VisibleAndAvailable;
            Items = new List<MenuItemModel>();
        }
    }
}
