using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Shop.Dal.Data.Repositary.Contracts
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get;  }
        IFrequencyRepository Frequencies { get; }

        void Save();
    }
}
