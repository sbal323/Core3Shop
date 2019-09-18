using Core3Shop.Dal.Data.Repository.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Dal.Data.Repositary.Contracts
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get;  }
        IRepository<Frequency> Frequencies { get; }
        IRepository<Service> Services { get; }
        IRepository<Order> Orders { get; }
        IUserRepository Users { get; }

        void Save();
        IRepository<T> GetDictionaryRepositary<T>() where T : DictionaryBase;
    }
}
