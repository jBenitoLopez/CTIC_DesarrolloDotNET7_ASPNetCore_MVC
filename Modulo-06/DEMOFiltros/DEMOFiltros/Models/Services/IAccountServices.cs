using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DEMOFiltros.Models.Services
{
    public interface IAccountServices
    {
        bool CheckCredentials(string username, string password);
        IEnumerable<string> GetRolesForUser(string userName);
    }
}
