using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using MVC.DAL;
    using System.Data;

    public class OrderService:IOrderService
    {
        private BrainwareContext context;

        public OrderService(BrainwareContext context) {
            this.context = context;
        }

        public async System.Threading.Tasks.Task<List<MVC.DAL.OrderDto>> GetOrdersForCompanyAsync(int CompanyId)
        {
            // Get the orders for company
            var company = await context.Companies
                .Include(x=>x.Orders)
                .ThenInclude(x => x.Orderproducts)
                .ThenInclude(x => x.Product)
                .Where(x=>x.CompanyId==CompanyId).FirstOrDefaultAsync();

            //calculate order total for each ompany order
            var orders = company.Orders;

            var orderDtos = new List<MVC.DAL.OrderDto>();
            foreach (var order in orders)
            {
                var orderTotal = order.Orderproducts.Sum(q => q.Price * q.Quantity);

                //create Dto instance to carry data
                MVC.DAL.OrderDto orderDto = new MVC.DAL.OrderDto
                {
                    OrderTotal = orderTotal.GetValueOrDefault(),
                    CompanyName = company.Name,
                    Description =order.Description,
                    OrderId=order.OrderId,
                    OrderProducts= (List<MVC.DAL.Orderproduct>)order.Orderproducts
                };

                orderDtos.Add(orderDto);
            }
            
            return orderDtos;
        }
    }
}