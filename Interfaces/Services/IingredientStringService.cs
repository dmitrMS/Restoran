using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IingredientStringService
    {
        List<ingredientstringDto> GetAllIngredientsString();
        ingredientstringDto GetIngredientString(int phoneId);
        //void CreateDish(dishDto p);
        void UpdateIngredientString(ingredientstringDto p);
        void DeleteIngredientString(int id);
    }
}
