using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.DAL
{
    using MVC.DAL;
    using System.Security.AccessControl;

    public class OrderDto
    {
        public int OrderId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public ICollection<Orderproduct> OrderProducts { get; set; }

    }

}