using pro.Models;
using pro.Repositories.DistributorRepo;

namespace pro.Services.DistributorService
{
    public class DistributorService:IDistributorService
    {
        private readonly IDistributorRepo _distributorRepo;
        public DistributorService(IDistributorRepo distributorRepo)
        {
            _distributorRepo = distributorRepo;
        }

        public async Task<List<Distributor>> GetDistributors()
        {
            return await _distributorRepo.Get();
        }

        public string AddDistributor(Distributor distributor)
        {
            
            string mes1= _distributorRepo.Add(distributor);
            string mes2= _distributorRepo.Save();
            return (mes1 + "\n" + mes2);
        }
        public async Task<string> RemoveDistributor(Guid id)
        {

            string mes1=await _distributorRepo.DeleteById(id);
            string mes2=await _distributorRepo.SaveAsync();
            return (mes1 + "\n" + mes2);
        }
        public async Task<string> DistributorItems(string name)
        {
            return await _distributorRepo.DistributorItems(name);
        }
    }
}
