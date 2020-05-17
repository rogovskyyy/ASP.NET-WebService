using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserApi.Dto;
using UserApi.Service;
using UserApi.Token;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("/authorize")]
    public class AuthorizeController : Controller
    {
        public AuthorizeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private readonly IUserRepository _userRepository;

        [HttpPost]
        public IActionResult Authorize([FromBody] AuthorizeDto dto)
        {
            var users = _userRepository.FindBy(u => u.Email == dto.Email && u.Password == dto.Password);
            if (users.Any())
            {
                return Ok(new
                {
                    token = new TokenBuilder().Build(dto),
                });
            }

            return BadRequest("Bad authorization credentials given");
        }
    }
}