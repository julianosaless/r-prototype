using MediatR;

using Ria.Business.Features.Customers.Response;
using Ria.Data.Customers;


namespace Ria.Business.Features.Customers.Queries
{
    public class CustomerQueryHandler : IRequestHandler<GetAllCustomerQueryCommand, IEnumerable<GetAllCustomerResponse>>
    {
        private readonly ICustomerRepository CustomerRepository;

        public CustomerQueryHandler(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public async Task<IEnumerable<GetAllCustomerResponse>> Handle(GetAllCustomerQueryCommand request, CancellationToken cancellationToken)
        {
            var customers = await CustomerRepository.GetAllAsync(cancellationToken);
            return customers.Select(x => new GetAllCustomerResponse
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age
            });
        }
    }
}
