using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPgs
{
    public class IngredientReposPgs : IRepository<ingredient>
    {
        private Model1 db;

        public IngredientReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<ingredient> GetList()
        {
            return db.ingredients.ToList();
        }

        public ingredient GetItem(int id)
        {
            return db.ingredients.Find(id);
        }

        public void Create(ingredient Dish)
        {
            db.ingredients.Add(Dish);
        }

        public void Update(ingredient Dish)
        {
            db.Entry(Dish).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ingredient Dish = db.ingredients.Find(id);
            if (Dish != null)
                db.ingredients.Remove(Dish);
        }
    }
}
