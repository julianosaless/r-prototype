using System.ComponentModel.DataAnnotations;

namespace Ria.Business.Features.Customers.Response
{
    public record GetAllCustomerResponse
    {
        /// <summary>
        ///  Customer Id
        /// </summary>
        /// <example>
        ///  0
        /// </example>
        [Range(0, int.MaxValue)]

        [Required]
        public int? Id { get; init; }

        /// <summary>
        ///  Customer Firstname Id
        /// </summary>
        /// <example>
        ///  John
        /// </example>
        [StringLength(100)]
        [Required]
        public string? FirstName { get; init; }

        /// <summary>
        /// Customer Lastname
        /// </summary>
        /// <example>
        ///  Doe
        /// </example>
        [StringLength(100)]
        [Required]
        public string? LastName { get; init; }

        /// <summary>
        ///  Customer Age 
        /// </summary>
        /// <example>
        ///  20
        /// </example>
        [Range(19, int.MaxValue)]
        [Required]
        public int? Age { get; init; }
    }
}
