using System.Threading.Tasks;
using Circa.User.Domain.UserProfile.Inputs;
using Microsoft.AspNetCore.Mvc;
using Solari.Vanth.Validation;

namespace Circa.User.WebApi.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class UserProfile : ControllerBase
    {
        [VanthValidator]
        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserProfileInput input)
        {
            return Ok();
        }

    }
}
