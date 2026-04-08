using System.IO;
using System.Windows;
using System.Windows.Input;
using TMP_Laba3_Authorization;
using TMP_Laba3_Menu;

namespace TMP_Laba3
{
    public class MenuWindowViewModel
    {
        private Person _person;
        private RolePermissions _currentRolePermissions;
        public IEnumerable<MenuItemModel> MenuItems { get; set; }

        public MenuWindowViewModel(Person person, string menuPath, string rolesPath)
        {
            _person = person;
            _currentRolePermissions = GetParsedRolePermissions(rolesPath);
            MenuItems = GetParsedMenuItems(menuPath);
        }

        private IEnumerable<MenuItemModel> GetParsedMenuItems(string path)
        {
            MenuInfo menuInfo = MenuFileParser.Parse(path);
            MenuBuilder builder = new MenuBuilder();

            foreach (var item in menuInfo.MenuItems)
            {
                builder.AddMenuItem(item);
            }

            var items = builder.Build();

            return ConvertToMenuModels(items);
        }

        private RolePermissions GetParsedRolePermissions(string path)
        {
            var allRoles = RolePermissionsParser.Parse(path);

            if (!allRoles.ContainsKey(_person.Role))
                throw new Exception("Роль пользователя не найдена!");

            return allRoles[_person.Role];
        }

        private List<MenuItemModel> ConvertToMenuModels(IEnumerable<MenuItemInfo> items, int depth = 0)
        {
            var result = new List<MenuItemModel>();

            foreach (var item in items)
            {
                var permission = GetPermissionForMenuItem(item.Header, depth);

                if (permission?.AccessLevel == 2)
                    continue;

                ItemStatus status = permission != null
                    ? permission.GetItemStatus()
                    : ItemStatus.VisibleAndAvailable;

                ICommand command = null;
                if (!string.IsNullOrEmpty(item.Command) && status == ItemStatus.VisibleAndAvailable)
                {
                    command = new RelayCommand(
                        (o) => MessageBox.Show(item.Command),
                        (o) => status == ItemStatus.VisibleAndAvailable
                    );
                }

                var model = new MenuItemModel(item.Header, command, item.Command)
                {
                    Status = status
                };

                model.Items = ConvertToMenuModels(item.Items, depth + 1);

                if (model.Command == null && model.Items.Count == 0)
                    continue;

                result.Add(model);
            }

            return result;
        }

        private MenuPermission GetPermissionForMenuItem(string header, int depth)
        {
            if (_currentRolePermissions == null)
                return null;

            if (_currentRolePermissions.Permissions.ContainsKey(header))
            {
                var perm = _currentRolePermissions.Permissions[header];
                if (perm.Depth == depth)
                    return perm;
            }

            foreach (var perm in _currentRolePermissions.Permissions.Values)
            {
                var found = FindPermissionInChildren(perm, header, depth);
                if (found != null)
                    return found;
            }

            return null;
        }

        private MenuPermission FindPermissionInChildren(MenuPermission parent, string header, int depth)
        {
            foreach (var child in parent.Children)
            {
                if (child.Header == header && child.Depth == depth)
                    return child;

                var found = FindPermissionInChildren(child, header, depth);
                if (found != null)
                    return found;
            }
            return null;
        }

        private bool IsCommandAuthorized(string command)
        {
            if (_currentRolePermissions == null)
                return false;
            return true;
        }
    }
}
