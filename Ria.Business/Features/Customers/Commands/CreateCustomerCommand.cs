using Ria.Common.Commands;
using Ria.Business.Features.Customers.Request;

namespace Ria.Business.Features.Customers.Commands
{
    public class CreateCustomerCommand : CommandBase<bool>
    {
        public List<CreateCustomerRequest> CreateCustomers = new();

        public override bool IsValid()
        {
            var customers = CreateCustomers
             .Select((value, index) => new { value, index })
             .ToList();

            foreach (var customer in customers)
            {
                AddIdValidation(customer.index, customer.value);
                AddFirstNameValidation(customer.index, customer.value);
                AddLastNameValidation(customer.index, customer.value);
                AddAgeValidation(customer.index, customer.value);
            }
            return base.IsValid();
        }

        private void AddIdValidation(int index, CreateCustomerRequest createCustomer)
        {
            if (createCustomer.Id <= 0)
            {
                AddError($"[{index}].{nameof(createCustomer.Id)}", @$"The field {nameof(createCustomer.Id)} is required.");
            }
        }

        private void AddFirstNameValidation(int index, CreateCustomerRequest createCustomer)
        {
            if (string.IsNullOrEmpty(createCustomer.FirstName))
            {
                AddError($"[{index}].{nameof(createCustomer.FirstName)}", @$"The field {nameof(createCustomer.FirstName)} is required.");
            }
        }

        private void AddLastNameValidation(int index, CreateCustomerRequest createCustomer)
        {
            if (string.IsNullOrEmpty(createCustomer.FirstName))
            {
                AddError($"[{index}].{nameof(createCustomer.FirstName)}", @$"The field {nameof(createCustomer.FirstName)} is required.");
            }
        }

        private void AddAgeValidation(int index, CreateCustomerRequest createCustomer)
        {
            if (createCustomer.Age <= 18)
            {
                AddError($"[{index}].{nameof(createCustomer.Age)}", @$"{nameof(createCustomer.Age)} must be above 18.");
            }

            if (createCustomer.Age >= 120)
            {
                AddError($"[{index}].{nameof(createCustomer.Age)}", @$"{nameof(createCustomer.Age)} must be below 120.");
            }
        }
    }
}
