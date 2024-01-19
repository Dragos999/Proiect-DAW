using Proiect_DAW.Models;
using Proiect_DAW.Repositories.Generic;

namespace Proiect_DAW.Repositories.DistributorRepo
{
    public interface IDistributorRepo : IGenericRepo<Distributor>
    {
        Task<string> DistributorItems(string name);
    }

}
