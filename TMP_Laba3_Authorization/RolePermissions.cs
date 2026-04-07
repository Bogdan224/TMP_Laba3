using TMP_Laba3_Authorization;

public class RolePermissions
{
    public UserRole Role { get; set; }
    public int RoleKey { get; set; }
    public string RoleName { get; set; }
    public Dictionary<string, MenuPermission> Permissions { get; set; }

    public RolePermissions()
    {
        Permissions = new Dictionary<string, MenuPermission>();
    }
}