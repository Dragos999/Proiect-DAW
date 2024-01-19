using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Models.Base;

namespace Proiect_DAW.Repositories.Generic
{
    public interface IGenericRepo<Ent> where Ent : BaseEntity
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
