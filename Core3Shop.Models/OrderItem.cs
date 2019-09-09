using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core3Shop.Models
{
    public class OrderItem : DictionaryBase
    {
        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        [Required]
        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ServiceName { get; set; }
    }
}
