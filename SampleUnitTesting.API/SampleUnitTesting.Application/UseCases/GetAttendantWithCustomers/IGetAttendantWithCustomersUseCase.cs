using OneOf;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.Application.UseCases;

public interface IGetAttendantWithCustomersUseCase
{
    Task<OneOf<UseCaseResponse<Attendant>, UseCaseResponse<UseCaseErrorResponse>>> ExecuteAsync(int id);
}
