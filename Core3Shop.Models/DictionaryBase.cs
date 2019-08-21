using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core3Shop.Models
{
    public class DictionaryBase
    {
        [Key]
        public int Id { get; set; }
    }
}
