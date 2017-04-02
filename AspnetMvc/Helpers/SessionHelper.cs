using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspnetMvc.Database;
using AspnetMvc.Models;
namespace AspnetMvc.Helpers
{
    public class SessionHelper
    {
        public Role getUserRole(User user)
        {
            Role role = new Role();
            using (var db = new DataContext())
            {
                var userRole = user.UserRoles.FirstOrDefault();
                role = db.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefault();
            }
            return role;
        }
    }
}