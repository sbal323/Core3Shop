using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core3Shop.Models
{
    public class Order: DictionaryBase
    {
        [Required]
        [Display(Name = "Client Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "ZIP Code")]
        public string ZipCode { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public int ItemsCount { get; set; }
        public ICollection<OrderItem> Items { get; set; }

    }
}
