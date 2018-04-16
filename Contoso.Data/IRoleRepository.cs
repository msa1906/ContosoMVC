using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    interface IRoleRepository: IDisposable
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleByID(int RoleId);
        void InsertRole(Role Role);
        void DeleteRole(int RoleID);
        void UpdateRole(Role Role);
        void Save();
    }
}
