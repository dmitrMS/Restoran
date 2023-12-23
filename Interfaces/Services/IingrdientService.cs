using BLL.DTO;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IingrdientService
    {
         
        
            List<ingredientDto> GetAllIngredients();
            ingredientDto GetIngredient(int phoneId);
            //void CreateDish(dishDto p);
            void UpdateIngredient(ingredientDto p);
            void DeleteIngredient(int id);

            //List<ManufacturerDto> GetManufacturers();
        
    }
}
