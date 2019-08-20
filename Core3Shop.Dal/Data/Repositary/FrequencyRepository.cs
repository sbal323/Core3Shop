using Core3Shop.Dal.Data.Repositary.Contracts;
using Core3Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Core3Shop.Dal.Data.Repositary
{
    public class FrequencyRepository : Repository<Frequency>, IFrequencyRepository
    {
        public FrequencyRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
