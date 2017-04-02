using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspnetMvc.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
    }
}