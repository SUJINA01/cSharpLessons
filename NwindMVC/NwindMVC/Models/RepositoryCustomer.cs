using Microsoft.EntityFrameworkCore;
namespace NwindMVC.Models
{
    public class RepositoryCustomer
    {
        private readonly NorthWindContext _context;



        public RepositoryCustomer(NorthWindContext context)
        {
            _context = context;
        }



        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }



        public List<int> GetAllCustomerId()
        {
            return (from c in _context.Customers select int.Parse(c.CustomerId)).ToList();
        }



        public Customer GetCustomerByID(string id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }



        public List<Order> FindOrdersByCustomerID(string CustomerID)
        {
            return _context.Orders.Where(o => o.CustomerId == CustomerID).ToList();
        }




    }
}
