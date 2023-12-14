using Newtonsoft.Json;

using Ria.Entities.Customers;

namespace Ria.Data.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private static string FileName => "customers.json";

        public CustomerRepository()
        {

        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var customers = new List<Customer>();

            var hasFile = File.Exists(FileName);
            if (hasFile)
            {
                string data = await File.ReadAllTextAsync(FileName, cancellationToken);
                customers = JsonConvert.DeserializeObject<List<Customer>>(data);
            }
            return customers ?? new List<Customer>();
        }

        public async Task CreateAsync(IEnumerable<Customer> customers, CancellationToken cancellationToken = default)
        {
            foreach (var customer in customers)
            {
                await CreateAsync(customer, cancellationToken);
            }
        }

        public async Task CreateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            var customers = await GetAllAsync(cancellationToken);

            if (customers.Any(x => x.Id == customer.Id))
            {
                return;
            }

            int insertIndex = customers.FindIndex(c =>
                string.Compare(c.LastName, customer.LastName, StringComparison.OrdinalIgnoreCase) > 0 ||
                (string.Compare(c.LastName, customer.LastName, StringComparison.OrdinalIgnoreCase) == 0 &&
                 string.Compare(c.FirstName, customer.FirstName, StringComparison.OrdinalIgnoreCase) > 0));

            if (insertIndex == -1)
                customers.Add(customer);
            else
                customers.Insert(insertIndex, customer);

            await File.WriteAllTextAsync(FileName, JsonConvert.SerializeObject(customers));
        }

    }
}
