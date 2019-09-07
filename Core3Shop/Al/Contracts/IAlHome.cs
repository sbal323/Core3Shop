using Core3Shop.Models;
using Core3Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.Al.Contracts
{
    public interface IAlHome
    {
        HomeViewModel GetHomeModel();
        ServiceDetailsViewModel GetServiceDetailsModel(int id);
    }
}
