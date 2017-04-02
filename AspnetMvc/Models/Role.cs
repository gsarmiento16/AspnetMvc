using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetMvc.Models
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRol>();
            SecActivityRoles = new HashSet<SecActivityRole>();
            SecModelRoles = new HashSet<SecModelRole>(); 
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SecModelRole> SecModelRoles { get; set; }
        public virtual ICollection<SecActivityRole> SecActivityRoles { get; set; }
        public virtual ICollection<UserRol> UserRoles { get; set; }

    }
}