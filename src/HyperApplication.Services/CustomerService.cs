using HyperApplication.EFCore;
using HyperApplication.Entities;
using HyperApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperApplication.Services
{
    public class CustomerService : Service<Customer>,ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) 
            :base(customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        //public Customer GetCustomer(int id)
        //{
        //    return null;
        //}

        //public List<Customer> GetCustomers()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
