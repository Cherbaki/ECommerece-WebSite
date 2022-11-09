using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RealShop.Models;

namespace RealShop.Areas.Identity.Data
{

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(25, ErrorMessage = "Length of firstname can't be more than 25 character!!!")]
        [MinLength(5, ErrorMessage = "Length of firstname can't be less than 5 character!!!")]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Length of lastname can't be more than 25 character!!!")]
        [MinLength(5, ErrorMessage = "Length of lastname can't be less than 5 character!!!")]
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public Image? ProfileImage { get; set; }
        [NotMapped]
        public ICollection<Product>? Products { get; set; }
        [NotMapped]
        public ICollection<Order>? Orders { get; set; }
        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }

}