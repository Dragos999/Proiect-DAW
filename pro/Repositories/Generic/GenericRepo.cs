using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using pro.Data;
using pro.Models.Base;

namespace pro.Repositories.Generic
{
    public class GenericRepo<Ent>:IGenericRepo<Ent>where Ent:BaseEntity
    {
        protected readonly proContext _db;
        protected readonly DbSet<Ent> _t;

        public GenericRepo(proContext context)
        {
            _db = context;
            _t = context.Set<Ent>();
        }

        //Get
        public async Task<List<Ent>> Get()
        {
            return await _t.ToListAsync();
        }

        //Create
        public string Add(Ent entity)
        {
            var e = _t.Find(entity.Id);
            if (e == null)
            {
                _t.Add(entity);
                return ("Added successfully!");
            }
            else
            {
                return ("Failed!");
            }
            
        }

        //Update
        public async Task<string> Update(Ent entity)
        {
            var ent = _t.FirstOrDefault(e => e.Id == entity.Id);
            if (ent != null)
            {
                
                _t.Update(entity);
                return ("Update successfull!");
            }
            else
            {
                return ("Update failed!");
            }
        }

        //Find

        public Ent FindById(Guid id)
        {
            return  _t.Find(id);
        }

        //Delete
        public async Task<string> DeleteById(Guid id)
        {
            var ent = _t.FirstOrDefault(e => e.Id == id);
            if (ent != null)
            {
                _t.Remove(ent);
                return ("Removal successfull!");
            }
            else
            {
                return ("Removal failed!");
            }
        }

        //Save

        public string Save()
        {
            try
            {
                _db.SaveChanges();
                return ("DataBase saved!");
            }
            catch 
            {
                return ("Database saving failed!");
            }
        }

        //save async

        public async Task<string> SaveAsync()
        {
            try
            {
                _db.SaveChangesAsync();
                return ("DataBase saved!");
            }
            catch
            {
                return ("Database saving failed!");
            }
        }
    }
}
