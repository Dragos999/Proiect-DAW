using Microsoft.AspNetCore.Mvc;
using pro.Models.Base;

namespace pro.Repositories.Generic
{
    public interface IGenericRepo<Ent>where Ent:BaseEntity
    {
        //Get
        Task<List<Ent>> Get();
        //Create
        string Add(Ent entity);

        //Delete
        string DeleteById(Guid id);

        //Update
        string Update(Ent entity);


        //Find

        Task<Ent> FindById(Guid id);

        //Save
        string Save();
    }
}
