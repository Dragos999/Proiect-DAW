using Proiect_DAW.Models;

namespace Proiect_DAW.Services.DistributorService
{
    public interface IDistributorService
    {
        Task<List<Distributor>> GetDistributors();

        string AddDistributor(Distributor distributor);
        Task<string> RemoveDistributor(Guid id);
        Task<string> DistributorItems(string name);
    }
}
