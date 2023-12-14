using Ria.Entities.Customers;

namespace Ria.Data.Customers
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default);

        Task CreateAsync(Customer customer, CancellationToken cancellationToken = default);
        Task CreateAsync(IEnumerable<Customer> customers, CancellationToken cancellationToken = default);
    }
}
