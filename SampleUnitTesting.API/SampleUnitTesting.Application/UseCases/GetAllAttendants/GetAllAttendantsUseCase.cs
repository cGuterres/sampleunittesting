using Dawn;
using Microsoft.Extensions.Logging;
using OneOf;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Application.UseCases;

public sealed class GetAllAttendantsUseCase : IGetAllAttendantsUseCase
{
    private readonly ILogger<GetAllAttendantsUseCase> _logger;
    private readonly IAttendantRepository _repository;

    public GetAllAttendantsUseCase(
        ILogger<GetAllAttendantsUseCase> logger, 
        IAttendantRepository repository)
    {
        Guard.Argument(logger, nameof(logger)).NotNull();
        Guard.Argument(repository, nameof(repository)).NotNull();

        _logger = logger;
        _repository = repository;
    }

    public async Task<OneOf<UseCaseResponse<IEnumerable<Attendant>>, UseCaseResponse<UseCaseErrorResponse>>> ExecuteAsync()
    {
        try
        {
            var attendantsList = await _repository.FindAllAsync();

            return new UseCaseResponse<IEnumerable<Attendant>>(attendantsList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error on {MethodName}", nameof(IGetAllAttendantsUseCase.ExecuteAsync));

            return new UseCaseResponse<UseCaseErrorResponse>("Unexpected error on get all attendants");
        }
    }
}
