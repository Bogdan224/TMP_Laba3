namespace TMP_Laba3_Menu
{
    public class MenuItemInfo
    {
        public string Name { get; set; }
        public string? Command { get; set; }
        public bool IsVisible { get; set; }
        public List<MenuItemInfo> Items { get; set; }

        public MenuItemInfo(string name, bool isVisible, string? command = null)
        {
            Name = name;
            Command = command;
            IsVisible = isVisible;
            Items = new List<MenuItemInfo>();
        }
    }
}
