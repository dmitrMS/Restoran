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
    public class IngredientStringService : IingredientStringService
    {
        private Model1 db;
        public IngredientStringService()
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
        public ingredientstringDto GetIngredientString(int Id)
        {
            return new ingredientstringDto(db.ingredient_strings.Find(Id));
        }
        //public void CreateDish(ingredientDto p)
        //{
        //    db.dishes.Add(new ingredient() { name = p.name, id = p.id, weight = p.weight, price = p.price, time_cook = p.time_cook, category = p.category });
        //    Save();
        //}
        public void UpdateIngredientString(ingredientstringDto p)
        {
            ingredient_string dish = db.ingredient_strings.Find(p.id);
            //dish.name = p.name;
            dish.id_ingredient = p.id_ingredient;
            dish.price = p.price;
            dish.id_dish = p.id_dish;
            dish.numb_ingr = p.numb_ingr;
            //dish.time_cook = p.time_cook;
            //dish.category = p.category;
            Save();
        }
        public void DeleteIngredientString(int id)
        {
            ingredient p = db.ingredients.Find(id);
            if (p != null)
            {
                db.ingredients.Remove(p);
                Save();
            }
        }

        public List<ingredientstringDto> GetAllIngredientsString()
        {
            var res = db.ingredient_strings.ToList();
            return res.Select(i => new ingredientstringDto(i)).ToList();
        }
    }
}
