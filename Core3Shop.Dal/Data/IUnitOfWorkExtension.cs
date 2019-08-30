using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Dal.Data.Repository.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Dal.Data
{
    //private static class IUnitOfWorkExtension
    //{
    //    //TODO: move logic to dictionary in UnitOfWork
    //    private static IRepository<T> GetRepositary<T>(this IUnitOfWork unitOfWork) where T: DictionaryBase
    //    {
    //        if(typeof(T) == typeof(Frequency))
    //        {
    //            return unitOfWork.Frequencies as IRepository<T>;
    //        }
    //        if (typeof(T) == typeof(Service))
    //        {
    //            return unitOfWork.Services as IRepository<T>;
    //        }
    //        if (typeof(T) == typeof(Category))
    //        {
    //            return unitOfWork.Categories as IRepository<T>;
    //        }
    //        return null;
    //    }
    //}
}
