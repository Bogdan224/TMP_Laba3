namespace TMP_Laba3_Authorization
{
    public class MenuPermission
    {
        public string Header { get; set; }
        public int Depth { get; set; }
        public int AccessLevel { get; set; }  // 0 - доступно, 1 - только видимо, 2 - скрыто
        public List<MenuPermission> Children { get; set; }

        public MenuPermission()
        {
            Children = new List<MenuPermission>();
        }

        public ItemStatus GetItemStatus()
        {
            return AccessLevel switch
            {
                0 => ItemStatus.VisibleAndAvailable,
                1 => ItemStatus.Visible,
                2 => ItemStatus.NotVisible,
                _ => throw new Exception()
            };
        }
    }
}
