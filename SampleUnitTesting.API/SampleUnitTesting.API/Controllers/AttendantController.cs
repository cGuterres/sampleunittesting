using Microsoft.AspNetCore.Mvc;
using SampleUnitTesting.Domain;

namespace SampleUnitTesting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendantController : ControllerBase
    {
        private readonly IAttendantRepository _attendantRepository;

        public AttendantController(IAttendantRepository attendantRepository)
        {
            ArgumentNullException.ThrowIfNull(attendantRepository);

            _attendantRepository = attendantRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _attendantRepository.GetAllAsync();

            return Ok(result);
        }
    }
}
