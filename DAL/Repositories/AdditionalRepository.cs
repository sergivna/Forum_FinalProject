using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class AdditionalRepository: IAdditionalRepository
    {
        private readonly Context context;
        public AdditionalRepository(Context context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await context.Countries.ToListAsync();
        }
    }
}
