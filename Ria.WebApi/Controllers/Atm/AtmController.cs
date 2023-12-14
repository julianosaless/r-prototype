using System.Net;
using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using Ria.Business.Features.ATM.Response;
using Ria.Business.Features.ATM.Request;
using Ria.Business.Features.ATM.Commands;
using Ria.Api.Infrastructure;

namespace Ria.Api.Controllers.Atm
{
    [Produces("application/json")]
    [Route("api/atm/[controller]")]
    [ApiController]
    public class PayoutController : ApiControllerBase
    {
        private readonly IMediator Mediator;

        public PayoutController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePayOutResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePayOutResponse>> CreatePayoutAsync(CreatePayOutRequest request)
        {
            var commandResponse = await Mediator.Send(new CreatePayoutCommand
            {

                CreatePayOut = request
            });

            if (!commandResponse.Validation.IsValid)
            {
                return StandardBadRequest(commandResponse.Validation);
            }
            return StandardOk(commandResponse.Entity);
        }
    }
}
