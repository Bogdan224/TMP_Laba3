using TMP_Laba3_Authorization;

namespace TMP_Laba3_Menu
{
    public class MenuItemInfo
    {
        public string Header { get; set; }
        public string? Command { get; set; }
        public ItemStatus Status { get; set; }
        public List<MenuItemInfo> Items { get; set; }

        public MenuItemInfo(string name, string? command = null)
        {
            Header = name;
            Command = command;
            Status = ItemStatus.VisibleAndAvailable;
            Items = new List<MenuItemInfo>();
        }
    }
}
