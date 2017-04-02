using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetMvc.Models
{
    public partial class SecActivity
    {
        public SecActivity()
        {
            SecActivityRoles = new HashSet<SecActivityRole>();
        }
        public int Id { get; set; }
        public string Name {get; set;}
        public string Note { get; set; }

        public virtual ICollection<SecActivityRole> SecActivityRoles { get; set; }
    }
}