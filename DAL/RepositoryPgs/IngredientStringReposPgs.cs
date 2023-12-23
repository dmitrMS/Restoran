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
    public class IngredientStringReposPgs : IRepository<ingredient_string>
    {
        private Model1 db;

        public IngredientStringReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<ingredient_string> GetList()
        {
            return db.ingredient_strings.ToList();
        }

        public ingredient_string GetItem(int id)
        {
            return db.ingredient_strings.Find(id);
        }

        public void Create(ingredient_string Dish)
        {
            db.ingredient_strings.Add(Dish);
        }

        public void Update(ingredient_string Dish)
        {
            db.Entry(Dish).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ingredient_string Dish = db.ingredient_strings.Find(id);
            if (Dish != null)
                db.ingredient_strings.Remove(Dish);
        }
    }
}
