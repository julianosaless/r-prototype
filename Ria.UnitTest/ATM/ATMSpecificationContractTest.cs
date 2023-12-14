using FluentAssertions;
using Xunit;

using Ria.Business.Features.ATM.Request;
using Ria.UnitTest.Unit.Tests.Infrastructure;
using Ria.Business.Features.ATM.Response;

namespace Ria.Unit.Tests.ATM
{
    [Trait("RIA", "ATM.API.Specification")]
    public class ATMSpecificationContractTest
    {
        [Theory]
        [APISpecificationContract("ATM/Data/atm-payout-request.json", typeof(CreatePayOutRequest))]
        public void Should_create_api_atm_payout_request(APISpecificationContractResponse specificationContract)
        {
            specificationContract
                .OriginalContent
                .Content
                .Should()
                .Be(specificationContract.ApplicationContent.Content);
        }

        [Theory]
        [APISpecificationContract("ATM/Data/atm-payout-response.json", typeof(CreatePayOutResponse))]
        public void Should_create_api_atm_payout_response(APISpecificationContractResponse specificationContract)
        {
            specificationContract
                .OriginalContent
                .Content
                .Should()
                .Be(specificationContract.ApplicationContent.Content);
        }
    }
}
