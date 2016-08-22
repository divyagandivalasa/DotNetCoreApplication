using HyperApplication.EFCore;
using HyperApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperApplication.Services
{
    public interface ICustomerService : IService<Customer>
    {
        //List<Customer> GetCustomers();
        //Customer GetCustomer(int id);
    }
}
