using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspnetMvc.Models
{
    public partial class SecModelRole
    {
        public SecModelRole()
        {
            SecModelAttributeRoles = new HashSet<SecModelAttributeRole>();
        }
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int SecModelId { get; set; }
        public Boolean AllowCreate { get; set; }
        public Boolean AllowRead { get; set; }
        public Boolean AllowUpdate { get; set; }
        public Boolean AllowDelete { get; set; }

        public virtual ICollection<SecModelAttributeRole> SecModelAttributeRoles { get; set; }

        public virtual Role Role { get; set; }
        public virtual SecModel SecModel { get; set; }
    }
}