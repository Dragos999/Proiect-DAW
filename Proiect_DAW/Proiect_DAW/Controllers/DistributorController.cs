using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Helpers.Attributes;
using Proiect_DAW.Services.DistributorService;
using Proiect_DAW.Models;
using Proiect_DAW.Roles;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : Controller
    {
        private readonly IDistributorService _distributorService;
        public DistributorController(IDistributorService distributorService)
        {
            _distributorService = distributorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<List<Distributor>> GetDistributors()
        {
            return await _distributorService.GetDistributors();
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        public string AddDistributor(Distributor distributor)
        {
            return _distributorService.AddDistributor(distributor);
        }

        [Authorize(Role.Admin)]
        [HttpDelete]
        public async Task<string> DeleteById(Guid id)
        {
            return await _distributorService.RemoveDistributor(id);
        }

        [Authorize(Role.User, Role.Admin)]
        [HttpGet("GetDistIt")]
        public async Task<string> DistributorItems(string name)
        {
            return await _distributorService.DistributorItems(name);
        }
    }
}
