using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspnetMvc.Models
{
    public class SecModelAttributeRole
    {
        [Key]
        public int Id { get; set; }
        public int SecModelRoleId { get; set; }
        public int SecModelAttributeId { get; set; }
        public Boolean AllowCreate { get; set; }
        public Boolean AllowRead { get; set; }
        public Boolean AllowUpdate { get; set; }

        public virtual SecModelRole SecModelRole { get; set; }
        public virtual SecModelAttribute SecModelAttribute { get; set; }
    }
}