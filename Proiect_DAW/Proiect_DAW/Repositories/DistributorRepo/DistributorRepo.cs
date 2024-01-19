using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.Generic;

namespace Proiect_DAW.Repositories.DistributorRepo
{
    public class DistributorRepo : GenericRepo<Distributor>, IDistributorRepo
    {
        public DistributorRepo(proContext context) : base(context)
        {

        }
        public async Task<string> DistributorItems(string name)
        {
            var itemCounter = _t.Join(_db.Item, d => d.Id, i => i.distributorId, (d, i) => new
            {
                dName = d.Name,
                dId = d.Id,
                iId = i.Id
            }).GroupBy(di => new { di.dId, di.dName }).Select(a => new
            {
                dN = a.Key.dName,
                itemCount = a.Count()
            }).Where(a => a.dN == name).Select(a => a.itemCount).FirstOrDefault();

            string mes1 = itemCounter != 0 ? itemCounter.ToString() : "0";

            var items = _t.Join(_db.Item, d => d.Id, i => i.distributorId, (d, i) => new
            {
                iName = i.Name,
                dName = d.Name
            }).Where(a => a.dName == name).Select(a => a.iName).ToList();
            string mes2 = string.Join(", ", items);
            return name + " is distributing " + mes1 + " item(s): " + mes2;
        }
    }
}
