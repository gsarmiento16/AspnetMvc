using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetMvc.Models
{
    public partial class SecModel
    {
        public SecModel()
        {
            SecModelAttributes = new HashSet<SecModelAttribute>();
            SecModelRoles = new HashSet<SecModelRole>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SecModelAttribute> SecModelAttributes { get; set; }
        public virtual ICollection<SecModelRole> SecModelRoles { get; set; }

    }
}