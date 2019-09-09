using Core3Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Shop.Al.Contracts
{
    public interface IAlCart
    {
        CartViewModel GetCart();
        void RemoveFromCart(int serviceId);
    }
}
