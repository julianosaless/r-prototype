using System.Net;
using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using Ria.Api.Infrastructure;
using Ria.Business.Features.Customers.Commands;
using Ria.Business.Features.Customers.Request;
using Ria.Business.Features.Customers.Response;
using Ria.Business.Features.Customers.Queries;


namespace Ria.WebApi.Controllers.Customers
{
    [Produces("application/json")]
    [Route("api/customers")]
    public class CustomerController : ApiControllerBase
    {
        private readonly IMediator Mediator;

        public CustomerController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<GetAllCustomerResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetAllCustomerResponse>>> GetAllCustomerAsync()
        {
            var customers = await Mediator.Send(new GetAllCustomerQueryCommand());
            return StandardOk(customers);
        }

        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<GetAllCustomerResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GetAllCustomerResponse>>> CreateCustomerAsync([FromBody] List<CreateCustomerRequest> request)
        {
            var commandResponse = await Mediator.Send(new CreateCustomerCommand
            {

                CreateCustomers = request
            });

            if (!commandResponse.Validation.IsValid)
            {
                return StandardBadRequest(commandResponse.Validation);
            }

            var customers = await Mediator.Send(new GetAllCustomerQueryCommand());
            return StandardOk(customers);
        }
    }
}
