namespace Ria.Business.Features.ATM.Request
{
    public record CreatePayOutRequest
    {
        /// <summary>
        ///  ATM Amout
        /// </summary>
        /// <example>
        ///  100
        /// </example>
        public int Amount { get; init; }
    }
}
