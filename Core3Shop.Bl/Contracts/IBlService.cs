using Core3Shop.Bl.Models;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Bl.Contracts
{
    public interface IBlService
    {
        void Delete(int id);
        ServiceBlModel Get(int id);
        IEnumerable<ServiceBlModel> GetAll();
        void Save(ServiceBlModel entity);
        IEnumerable<ServiceBlModel> Get(IEnumerable<int> itemIds);
    }
}
