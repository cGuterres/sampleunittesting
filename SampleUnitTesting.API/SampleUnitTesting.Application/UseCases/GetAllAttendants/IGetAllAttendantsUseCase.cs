using OneOf;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Application.UseCases;

public interface IGetAllAttendantsUseCase
{
    Task<OneOf<UseCaseResponse<IEnumerable<Attendant>>, UseCaseResponse<UseCaseErrorResponse>>> ExecuteAsync();
}
