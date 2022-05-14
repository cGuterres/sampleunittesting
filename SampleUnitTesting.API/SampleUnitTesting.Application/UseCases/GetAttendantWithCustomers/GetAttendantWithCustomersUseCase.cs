using Dawn;
using Microsoft.Extensions.Logging;
using OneOf;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Application.UseCases;

public sealed class GetAttendantWithCustomersUseCase : IGetAttendantWithCustomersUseCase
{
    private readonly ILogger<GetAttendantWithCustomersUseCase> _logger;
    private readonly IAttendantRepository _repository;

    public GetAttendantWithCustomersUseCase(ILogger<GetAttendantWithCustomersUseCase> logger, IAttendantRepository repository)
    {
        Guard.Argument(logger, nameof(logger)).NotNull();
        Guard.Argument(repository, nameof(repository)).NotNull();

        _logger = logger;
        _repository = repository;
    }

    public async Task<OneOf<UseCaseResponse<Attendant>, UseCaseResponse<UseCaseErrorResponse>>> ExecuteAsync(int id)
    {
        try
        {
            Guard.Argument(id, nameof(id)).NotZero().NotNegative();

            var attendant = await _repository.FindWithCustomersAsync(id);

            if (attendant is null)
            {
                return new UseCaseResponse<UseCaseErrorResponse>("Attendant not found");
            }

            return new UseCaseResponse<Attendant>(attendant);

        }
        catch (ArgumentOutOfRangeException ex)
        {
            _logger.LogError(ex, "Invalid param {id} on {Method}", nameof(id), nameof(IGetAttendantWithCustomersUseCase.ExecuteAsync));

            return new UseCaseResponse<UseCaseErrorResponse>(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error on {Method}", nameof(IGetAttendantWithCustomersUseCase.ExecuteAsync));

            return new UseCaseResponse<UseCaseErrorResponse>("Unexpected error on get an attendant");
        }
    }
}
