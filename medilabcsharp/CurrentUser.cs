 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medilabcsharp
{
    public static class CurrentUser
    {
        public static int Id { get; private set; }
        public static string Role { get; private set; }
        public static string Name { get; private set; }
        public static DateTime LoginTime { get; private set; }
        public static bool IsAuthenticated => Id > 0;

        public static void Login(int id, string role, string name)
        {
            Id = id;
            Role = role;
            Name = name;
            LoginTime = DateTime.Now;
        }

        public static void Logout()
        {
            Id = 0;
            Role = string.Empty;
            Name = string.Empty;
            LoginTime = DateTime.MinValue;
        }
    }
}
