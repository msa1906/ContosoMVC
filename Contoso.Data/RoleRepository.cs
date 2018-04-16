using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    class RoleRepository: IRoleRepository, IDisposable
    {
        private ContosoContext context;

        public RoleRepository(ContosoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Role> GetRoles()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleByID(int id)
        {
            return context.Roles.Find(id);
        }

        public void InsertRole(Role Role)
        {
            context.Roles.Add(Role);
        }

        public void DeleteRole(int RoleID)
        {
            Role Role = context.Roles.Find(RoleID);
            context.Roles.Remove(Role);
        }

        public void UpdateRole(Role Role)
        {

            context.Entry(Role).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
