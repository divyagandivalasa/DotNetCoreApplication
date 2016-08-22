using HyperApplication.EFCore;
using HyperApplication.Entities;

namespace HyperApplication.Repository
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {
        public CustomerRepository(DataContext<Customer> context) : base(context)
        {
        }
    }
}
