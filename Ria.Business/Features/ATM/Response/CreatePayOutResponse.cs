namespace Ria.Business.Features.ATM.Response
{
    public record CreatePayOutResponse
    {
        public CreatePayOutResponse(IEnumerable<string> combinations)
        {
            Combinations = combinations;
        }
        public IEnumerable<string> Combinations { get; init; }
    }
}
