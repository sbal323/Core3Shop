using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core3Shop.Models
{
    public class Category: DictionaryBase
    {
        [Required]
        [Display(Name="Category Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
    }
}
