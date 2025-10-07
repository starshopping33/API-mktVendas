using Microsoft.AspNetCore.Mvc;

namespace API_mktVendas.API.Controller
{
    public class AuthController
    {
        [ApiController]
        [Route("auth")]

        public class AuthController : ControllerBase
        {
            [HttpPost("usuario")]
            public async Task<IActionResult>(RegisterDto dto);
        }
    }
}
