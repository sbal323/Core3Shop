using Core3Shop.Bl.Models;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.ViewModels
{
    public class PlaceOrderViewModel
    {
        public List<ServiceBlModel> SelectedServices { get; set; }
        public Order Order { get; set; }
        public double TotalPrice { get; set; }
    }
}
