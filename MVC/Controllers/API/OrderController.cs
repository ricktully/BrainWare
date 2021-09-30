using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace MVC.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVC.Infrastructure;


    public class OrderController : ControllerBase
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<IEnumerable<MVC.DAL.OrderDto>> GetOrdersAsync(int id = 1)
        {
            return await orderService.GetOrdersForCompanyAsync(id);
        }
    }
}
