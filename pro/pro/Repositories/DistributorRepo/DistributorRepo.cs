using pro.Data;
using pro.Models;
using pro.Repositories.Generic;

namespace pro.Repositories.DistributorRepo
{
    public class DistributorRepo:GenericRepo<Distributor>,IDistributorRepo
    {
        public DistributorRepo(proContext context) : base(context)
        {

        }
    }
}
