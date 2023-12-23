using BLL.DTO;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class IngredientService : IingrdientService
    {
        private Model1 db;
        public IngredientService()
        {
            db = new Model1();
        }
        //public bool MakeDish(dishDto DishDto)
        //{
        //    dish Dish = new dish
        //    {
        //        name = DishDto.name,
        //        id = DishDto.id,
        //        weight = DishDto.weight,
        //        price = DishDto.price,
        //        time_cook = DishDto.time_cook,
        //        category = DishDto.category


        //    };
        //    db.dishes.Add(Dish);
        //    if (db.SaveChanges() > 0)
        //        return true;
        //    return false;

        //}
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public ingredientDto GetIngredient(int Id)
        {
            return new ingredientDto(db.ingredients.Find(Id));
        }
        //public void CreateDish(ingredientDto p)
        //{
        //    db.dishes.Add(new ingredient() { name = p.name, id = p.id, weight = p.weight, price = p.price, time_cook = p.time_cook, category = p.category });
        //    Save();
        //}
        public void UpdateIngredient(ingredientDto p)
        {
            ingredient dish = db.ingredients.Find(p.id);
            dish.name = p.name;
            dish.storage = p.storage;
            dish.price = p.price;

            //dish.time_cook = p.time_cook;
            //dish.category = p.category;
            Save();
        }
        public void DeleteIngredient(int id)
        {
            ingredient p = db.ingredients.Find(id);
            if (p != null)
            {
                db.ingredients.Remove(p);
                Save();
            }
        }

        public List<ingredientDto> GetAllIngredients()
        {
            var res = db.ingredients.ToList();
            return res.Select(i => new ingredientDto(i)).ToList();
        }
    }
}
