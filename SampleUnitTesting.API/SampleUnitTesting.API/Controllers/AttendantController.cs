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
        public async Task<IActionResult> FindAllWithCustomersAsync()
        {
            var result = await _attendantRepository.FindAllWithCustomersAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindWithCustomers([FromRoute] int id)
        {
            var result = await _attendantRepository.FindWithCustomersAsync(id);

            return Ok(result);
        }
    }
}
