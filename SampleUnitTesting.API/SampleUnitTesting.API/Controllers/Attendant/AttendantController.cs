using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using SampleUnitTesting.Application.UseCases;
using Swashbuckle.AspNetCore.Annotations;

namespace SampleUnitTesting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendantController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all attendants withoud customers",
            Description = "",
            OperationId = nameof(FindAllWithCustomersAsync))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Succeed", typeof(IEnumerable<AttendantDto>))]
        [SwaggerResponse(400, "Error", typeof(UseCaseErrorResponse))]
        public async Task<IActionResult> FindAllWithCustomersAsync([FromServices] IGetAllAttendantsUseCase useCase)
        {
            var result = await useCase.ExecuteAsync();
            
            if (result.TryPickT0(out var attendants, out var error))
            {
                return Ok(attendants?.Data?.Select(x => TinyMapper.Map<AttendantDto>(x)));
            }
            else
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{id}/withcustomers")]
        [SwaggerOperation(
            Summary = "Get a detail attendant with your customers",
            Description = "Id is required",
            OperationId = nameof(FindWithCustomersAsync))]
        [Consumes("application/json")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Succeed", typeof(AttendantDto))]
        [SwaggerResponse(400, "Error", typeof(UseCaseErrorResponse))]
        public async Task<IActionResult> FindWithCustomersAsync(
            [FromRoute] int id,
            [FromServices] IGetAttendantWithCustomersUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(id);

            if (result.TryPickT0(out var attendant, out var error))
            {
                return Ok(TinyMapper.Map<AttendantDto>(attendant.Data));
            }
            else
            {
                return BadRequest(error);
            }
        }
    }
}
