using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspnetMvc.Models
{
    public class List
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Details { get; set; }
        public string DatePosted { get; set; }
        public string TimePosted { get; set; }
        public string DateEdited { get; set; }
        public string TimeEdited { get; set; }

    }
}