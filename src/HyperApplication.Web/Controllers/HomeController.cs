using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HyperApplication.EFCore;
using HyperApplication.Entities;
using HyperApplication.Services;
using HyperApplication.Repository;

namespace HyperApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        private DataContext<Customer> _context;
        private ICustomerService _customerService;
        private ICustomerRepository _customerRepository;
        public HomeController(DataContext<Customer> context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            var customers = _customerService.Queryable().ToList();
            ViewBag.Customers = customers;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
