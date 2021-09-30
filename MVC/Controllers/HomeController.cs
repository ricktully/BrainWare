using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.DAL.UOW;
using MVC.Infrastructure;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IOrderService orderService;

        public HomeController(IUnitOfWork unitOfWork,IOrderService orderService,ILogger<HomeController> logger)
        {
            _logger = logger;
            this.orderService = orderService;
            this.orderService.setUnitOfWork(unitOfWork);
        }

        public async Task<IActionResult> Index()
        {
            List<MVC.DAL.OrderDto> orders = null;
            try
            {
                orders = await this.orderService.GetOrdersForCompanyAsync(1);
            }catch(Exception ex)
            {
                _logger.LogError("Error getting orders for company 1",ex);
                throw ex;
            }
            return View(orders);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
