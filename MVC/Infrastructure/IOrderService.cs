using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Infrastructure
{
    public interface IOrderService
    {
        System.Threading.Tasks.Task<List<MVC.DAL.OrderDto>> GetOrdersForCompanyAsync(int CompanyId);
    }
}
