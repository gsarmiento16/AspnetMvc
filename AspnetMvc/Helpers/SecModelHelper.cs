using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspnetMvc.Models;
using AspnetMvc.Database;

namespace AspnetMvc.Helpers
{
    public class SecModelHelper : IDisposable
    {
        bool _disposed;
       /* private readonly DataContext dbc;

        public SecModelHelper(DataContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            this.dbc = dbContext;
        }*/


        public IList<SecModelAttributeRole> getSecModelAttributesRole(string modelName, User user)
        {
            IList<SecModelAttributeRole> list = new List<SecModelAttributeRole>();
            
            using (var db = new DataContext())
            {
                var secModelAttributesRole = db.SecModelAttributesRoles.Where(w => w.SecModelRoleId == user.UserRoles.FirstOrDefault().Id && w.SecModelRole.SecModel.Name.Equals(modelName)).ToList();
                list = secModelAttributesRole.ToList();
            }
            return list;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SecModelHelper()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {

            }

            _disposed = true;
        }
    }
}