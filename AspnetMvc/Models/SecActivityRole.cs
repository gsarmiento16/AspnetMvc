using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspnetMvc.Models
{
    public class SecActivityRole
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }
        public int SecActivityId { get; set; }
        public virtual Role Role { get; set; }
        public virtual SecActivity SecActivity {get; set;}
        
    }
}