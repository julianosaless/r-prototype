using System.Collections.Generic;

using Xunit;
using FluentAssertions;

using Ria.UnitTest.Unit.Tests.Infrastructure;
using Ria.Business.Features.Customers.Request;
using Ria.Business.Features.Customers.Response;

namespace Ria.Unit.Tests.Customers
{
    [Trait("RIA", "Customers.API.Specification")]
    public class CustomerSpecificationContractTest
    {
        [Theory]
        [APISpecificationContract("Customers/Data/customers-post-request.json", typeof(List<CreateCustomerRequest>))]
        public void Should_create_api_customers_post_request_specification(APISpecificationContractResponse specificationContract)
        {
            specificationContract
                .OriginalContent
                .Content
                .Should()
                .Be(specificationContract.ApplicationContent.Content);
        }

        [Theory]
        [APISpecificationContract("Customers/Data/customers-post-response.json", typeof(List<GetAllCustomerResponse>))]
        public void Should_create_api_customers_post_response_specification(APISpecificationContractResponse specificationContract)
        {
            specificationContract
                .OriginalContent
                .Content
                .Should()
                .Be(specificationContract.ApplicationContent.Content);
        }

        [Theory]
        [APISpecificationContract("Customers/Data/customers-get_response.json", typeof(List<GetAllCustomerResponse>))]
        public void Should_create_api_customers_get_request_specification(APISpecificationContractResponse specificationContract)
        {
            specificationContract
                .OriginalContent
                .Content
                .Should()
                .Be(specificationContract.ApplicationContent.Content);
        }


    }
}
