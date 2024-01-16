using pro.Models;

namespace pro.Services.DistributorService
{
    public interface IDistributorService
    {
        Task<List<Distributor>> GetDistributors();

        string AddDistributor(Distributor distributor);
        string RemoveDistributor(Guid id);
        string DistributorItems(string name);
    }
}
