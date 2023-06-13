using System;
using System.Collections.Generic;

namespace DEMOFiltros.Models.Services
{
    public class AccountServices : IAccountServices
    {
        public bool CheckCredentials(string username, string password)
        {
            return username == password;
        }

        public IEnumerable<string> GetRolesForUser(string userName)
        {
            if (userName.Equals("john", StringComparison.OrdinalIgnoreCase))
            {
                yield return "admin";
            }
        }
    }
}