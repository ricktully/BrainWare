using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.DAL.UOW
{
    public class CompanyRepository : GenericRepository<Company>
    {
        public CompanyRepository(BrainwareContext context) : base(context)
        {
        }
        public async Task<Company> GetFullyLoadedByIdAsync(int id)
        {
            Company company=
            await context.Companies
            .Include(x => x.Orders)
            .ThenInclude(x => x.Orderproducts)
            .ThenInclude(x => x.Product)
            .Where(x => x.CompanyId == id).FirstOrDefaultAsync();

            return company;
        }
        
    }
}
