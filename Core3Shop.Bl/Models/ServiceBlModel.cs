using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Bl.Models
{
    public class ServiceBlModel
    {
        public Service ServiceModel { get; set; }
        public double TotalPrice
        {
            get
            {
                return this.ServiceModel.Price * this.ServiceModel.Frequency.TimesPerYear;
            }
        }
    }
}
