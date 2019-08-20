using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core3Shop.Models
{
    public class Frequency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Frequency Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Times per year")]
        public int TimesPerYear { get; set; }
    }
}
