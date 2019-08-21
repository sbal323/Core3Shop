using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core3Shop.Models
{
    public class Service: DictionaryBase
    {

        [Required]
        [Display(Name = "Service Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Service price")]
        public double Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public double ImgeUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Required]
        public int FrequencyId { get; set; }

        [ForeignKey(nameof(FrequencyId))]
        public Frequency Frequency { get; set; }
    }
}
