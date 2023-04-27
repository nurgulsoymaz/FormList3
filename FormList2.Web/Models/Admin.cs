using FormList2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
//using System.Security.Claims;
using System;
using System.ComponentModel.DataAnnotations;

namespace FormList2.Web.Models
{

   
    public class Admin
    {
        [Key] 
        public int AdminId { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
