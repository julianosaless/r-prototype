using MediatR;

using Ria.Common.Commands;
using Ria.Data.Customers;

namespace Ria.Business.Features.Customers.Commands
{
    public class CustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResponseBase<bool>>
    {
        private readonly ICustomerRepository CustomerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public async Task<ResponseBase<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid()) return await Task.FromResult(new ResponseBase<bool>(request.ValidationResult));

                var customers = CustomerRepository.GetAllAsync(cancellationToken);

                await CustomerRepository.CreateAsync(request.CreateCustomers.Select(x => new Entities.Customers.Customer
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                }), cancellationToken);
                return new ResponseBase<bool>(true, request.ValidationResult);
            }
            catch (ArgumentException ex)
            {
                request.AddError("customer", ex.Message);
                return new ResponseBase<bool>(false, request.ValidationResult);
            }
        }
    }
}
