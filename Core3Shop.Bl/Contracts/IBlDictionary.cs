using System.Collections.Generic;
using Core3Shop.Models;

namespace Core3Shop.Bl.Contracts
{
    public interface IBlDictionary<T> where T: DictionaryBase
    {
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Save(T entity);
    }
}