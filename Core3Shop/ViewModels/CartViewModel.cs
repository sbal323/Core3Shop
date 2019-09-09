using Core3Shop.Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.ViewModels
{
    public class CartViewModel
    {
        public List<ServiceBlModel> SelectedServices { get; set; }
        public double TotalPrice { get; set; }
    }
}
