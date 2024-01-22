using ColaPro.Domain.Entities;
using ColaPro.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ColaPro.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        [HttpPost]
        public async ValueTask<IActionResult>PostAsync(Login model)
        {
            await _loginRepository.CreateAsync(model);
            return Ok();
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Login>models = await _loginRepository.GetAllAsync();
            return Ok(models);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int number)
        {
            await _loginRepository.DeleteAsync(number);

            return Ok();
        }

    }
    
}
