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
        Task<string> DeleteById(Guid id);

        //Update
        Task<string> Update(Ent entity);


        //Find

        Ent FindById(Guid id);

        //Save
        string Save();

        //Save async

        Task<string> SaveAsync();
    }
}
