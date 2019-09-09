using Core3Shop.Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.ViewModels
{
    public class ServiceDetailsViewModel
    {
        public ServiceBlModel Service { get; set; }
        public bool IsInCart { get; set; }
    }
}
