using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.ViewModels
{
    public class ServiceDetailsViewModel
    {
        public Service Service { get; set; }
        public bool IsInCart { get; set; }
        public double TotalPrice { get; set; }
    }
}
