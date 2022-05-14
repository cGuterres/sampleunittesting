namespace SampleUnitTesting.Application;

public class UseCaseResponse<T>
{
    public string? ErrorMessage { get; set; }
    public T? Data { get; set; }
    public UseCaseResponseCode ResponseCode { get; set; }

    public UseCaseResponse(string errorMessage)
    {
        ErrorMessage = errorMessage;
        ResponseCode = UseCaseResponseCode.Error;
    }

    public UseCaseResponse(T data)
    {
        Data = data;
        ResponseCode = UseCaseResponseCode.Success;
    }
}

public enum UseCaseResponseCode
{
    Error,
    Warning,
    Success
}
