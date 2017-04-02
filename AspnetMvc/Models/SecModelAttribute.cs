using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetMvc.Models
{
    public partial class SecModelAttribute
    {
        public SecModelAttribute()
        {
            SecModelAttributeRoles = new HashSet<SecModelAttributeRole>();
        }
        public int Id { get; set; }
        public int SecModelId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public virtual ICollection<SecModelAttributeRole> SecModelAttributeRoles { get; set; }
        public virtual SecModel SecModel { get; set; }
    }
}