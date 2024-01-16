using Microsoft.AspNetCore.Mvc;
using pro.Models;
using pro.Services.DistributorService;

namespace pro.Controllers
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

        [HttpGet]
        public async Task<List<Distributor>> GetDistributors()
        {
            return await _distributorService.GetDistributors();
        }

        [HttpPost]
        public string AddDistributor(Distributor distributor)
        {
            return _distributorService.AddDistributor(distributor);
        }
        [HttpDelete]
        public string DeleteById(Guid id)
        {
            return _distributorService.RemoveDistributor(id);
        }
        [HttpGet("GetDistIt")]
        public string DistributorItems(string name)
        {
            return _distributorService.DistributorItems(name);
        }
    }
}
