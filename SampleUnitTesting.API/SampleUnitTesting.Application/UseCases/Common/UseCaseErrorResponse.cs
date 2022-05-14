namespace SampleUnitTesting.Application.UseCases;

public sealed class UseCaseErrorResponse
{
    public UseCaseErrorResponse(string errorMessage)
    {
        ErrorMessage = errorMessage;
        UseCaseResponseCode = UseCaseResponseCode.Error;
    }

    public string? ErrorMessage { get; set; }
    public UseCaseResponseCode UseCaseResponseCode { get; set; }
}
