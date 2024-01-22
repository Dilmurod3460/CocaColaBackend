using ColaPro.Domain.Entities;
using ColaPro.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ColaPro.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(Request request)
        {
            await _requestRepository.CreateAsync(request);
            return Ok();
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<Request> requests = await _requestRepository.GetAllAsync();
            return Ok(requests);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int number)
        {
            await _requestRepository.DeleteAsync(number);

            return Ok();
        }
    }
}
