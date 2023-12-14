using Ria.Common.Commands;
using Ria.Business.Features.ATM.Request;
using Ria.Business.Features.ATM.Response;

namespace Ria.Business.Features.ATM.Commands
{
    public class CreatePayoutCommand : CommandBase<CreatePayOutResponse>
    {
        public CreatePayOutRequest? CreatePayOut;

        public override bool IsValid()
        {
            AddPayoutAmoutValidation();
            return base.IsValid();
        }

        private void AddPayoutAmoutValidation()
        {
            if (CreatePayOut?.Amount <= 0)
            {
                AddError($"PayOut.{nameof(CreatePayOut.Amount)}", "The amount must be greater than 0.");
            }
        }
    }
}
