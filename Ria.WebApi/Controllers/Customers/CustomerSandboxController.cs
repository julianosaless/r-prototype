using System.Text;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Ria.Business.Features.Customers.Response;
using Ria.Business.Features.Customers.Request;


namespace Ria.WebApi.Controllers.Customers
{

    [Route("api/[controller]")]
    public class CustomerSandboxController
    {
        private IHttpClientFactory ClientFactory;

        public CustomerSandboxController(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        [HttpPost()]
        public async Task<ActionResult<List<GetAllCustomerResponse>>> SimulateAsync(int numberOfRequest, string apiUrl)
        {
            var client = ClientFactory.CreateClient("Customers");

       
            for (int i = 0; i < numberOfRequest; i++)
            {
                var randomAge = new Random().Next(10, 90);
                var customers = await GetAsync();
                var newCustomers = new List<CreateCustomerRequest>
                {
                    new() { LastName = "Bbbb", FirstName = "Bbbb", Age = randomAge, Id = customers.Count + 1 },
                    new() { LastName = "Bbbb", FirstName = "Aaaa", Age = randomAge + 2, Id = customers.Count + 2 }
                };

                await PostAsync(JsonConvert.SerializeObject(newCustomers, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                }));
            }
            return await GetAsync();

            async Task PostAsync(string requestBody)
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
                };

                await client.SendAsync(request);
            }

            async Task<List<GetAllCustomerResponse>> GetAsync()
            {
                var response = await client?.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GetAllCustomerResponse>>(responseBody);
            }
        }
    }
}
