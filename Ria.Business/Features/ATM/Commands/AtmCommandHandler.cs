using MediatR;

using Ria.Common.Commands;
using Ria.Entities.Atm;
using Ria.Business.Features.ATM.Response;

namespace Ria.Business.Features.ATM.Commands
{
    public class AtmCommandHandler : IRequestHandler<CreatePayoutCommand, ResponseBase<CreatePayOutResponse>>
    {
        private readonly AtmManager AtmManager;
        public AtmCommandHandler()
        {
            AtmManager = new AtmManager();
        }
        public Task<ResponseBase<CreatePayOutResponse>> Handle(CreatePayoutCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Task.FromResult(new ResponseBase<CreatePayOutResponse>(request.ValidationResult));

            var combinations = AtmManager.GeneratePayoutCombinations(request.CreatePayOut.Amount);
            return Task.FromResult(new ResponseBase<CreatePayOutResponse>(new CreatePayOutResponse(combinations), request.ValidationResult));
        }
    }
}
