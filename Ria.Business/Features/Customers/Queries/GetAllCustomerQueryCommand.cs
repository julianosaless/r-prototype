using MediatR;
using Ria.Business.Features.Customers.Response;


namespace Ria.Business.Features.Customers.Queries
{
    public class GetAllCustomerQueryCommand : IRequest<IEnumerable<GetAllCustomerResponse>>
    {
    }
}
