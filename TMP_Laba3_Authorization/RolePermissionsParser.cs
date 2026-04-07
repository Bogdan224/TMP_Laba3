using System.IO;
using TMP_Laba3_Authorization;

public static class RolePermissionsParser
{
    public static Dictionary<UserRole, RolePermissions> Parse(string filePath)
    {
        var roles = new Dictionary<UserRole, RolePermissions>();
        var lines = File.ReadAllLines(filePath);

        int i = 0;
        while (i < lines.Length)
        {
            // Пропускаем пустые строки
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                i++;
                continue;
            }

            // Читаем строку роли: "Boss 0"
            var roleLine = lines[i].Trim();
            if (string.IsNullOrEmpty(roleLine))
            {
                i++;
                continue;
            }

            var roleParts = roleLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (roleParts.Length >= 2)
            {
                if (!Enum.TryParse<UserRole>(roleParts[0], true, out UserRole userRole))
                {
                    throw new InvalidOperationException($"Неизвестная роль: {roleParts[0]}");
                }

                var rolePermissions = new RolePermissions
                {
                    Role = userRole,
                    RoleKey = int.Parse(roleParts[1]),
                    RoleName = roleParts[0]
                };

                // Ищем открывающую скобку
                i++;
                while (i < lines.Length && !lines[i].Contains('{'))
                {
                    i++;
                }

                // Читаем содержимое до закрывающей скобки
                i++;
                var currentPath = new Stack<MenuPermission>();

                while (i < lines.Length)
                {
                    var line = lines[i].Trim();

                    if (line == "}")
                        break;

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        i++;
                        continue;
                    }

                    // Парсим строку: "0 Разное 0"
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 3)
                    {
                        int depth = int.Parse(parts[0]);
                        string header = parts[1];
                        int accessLevel = int.Parse(parts[2]);

                        var permission = new MenuPermission
                        {
                            Header = header,
                            Depth = depth,
                            AccessLevel = accessLevel
                        };

                        // Строим иерархию на основе глубины
                        if (depth == 0)
                        {
                            rolePermissions.Permissions[header] = permission;
                            currentPath.Clear();
                            currentPath.Push(permission);
                        }
                        else
                        {
                            // Находим родителя по глубине
                            while (currentPath.Count > depth)
                            {
                                currentPath.Pop();
                            }

                            if (currentPath.Count == depth && currentPath.Peek() != null)
                            {
                                currentPath.Peek().Children.Add(permission);
                                currentPath.Push(permission);
                            }
                        }
                    }

                    i++;
                }

                roles[userRole] = rolePermissions;
            }

            i++;
        }

        return roles;
    }
}