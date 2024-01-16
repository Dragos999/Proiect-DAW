using pro.Models;
using pro.Repositories.Generic;

namespace pro.Repositories.DistributorRepo
{
    public interface IDistributorRepo:IGenericRepo<Distributor>
    {
        string DistributorItems(string name);
    }

}
