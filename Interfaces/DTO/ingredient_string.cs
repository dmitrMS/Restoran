using DomainModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class ingredientstringDto
    {
        public int id { get; set; }

        public int? id_ingredient { get; set; }

        public int? numb_ingr { get; set; }

        public int? price { get; set; }

        public int? id_dish { get; set; }

        public virtual dish dish { get; set; }

        public virtual ingredient ingredient { get; set; }
        public ingredientstringDto() { }
        public ingredientstringDto(ingredient_string o)
        {
            id = o.id;
            id_dish = o.id_dish;
            id_ingredient = o.id_ingredient;
            numb_ingr = o.numb_ingr;
            price = o.price;
            //DishName = o.dish.name;
        }
    }
}
