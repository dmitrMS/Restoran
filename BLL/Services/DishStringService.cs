using BLL.DTO;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DishStringService : IDishStringService
    {
        private Model1 db;
        public DishStringService()
        {
            db = new Model1();
        }

        public bool MakeDishString(dishstringDto dishstringDto)
        {
            dish_string DishString = new dish_string
            {
                id = dishstringDto.id,
                id_dish = dishstringDto.id_dish,
                id_order = dishstringDto.id_order,
                numb_dish = dishstringDto.numb_dish,
                price = dishstringDto.price,



            };
            db.dish_strings.Add(DishString);
            if (db.SaveChanges() > 0)
                return true;
            return false;

        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public dishstringDto GetDishString(int Id)
        {
            return new dishstringDto(db.dish_strings.Find(Id));
        }
        public void CreateDishString(dishDto p, int id_order, int number)
        {
            var res = db.dish_strings.Where(e => e.id_order == id_order && e.id_dish == p.id)
                                                          .Select(i => (int)i.id)
                                                          .FirstOrDefault();
            if(res!=0)
            {
                dish_string ds = db.dish_strings.Find(res);
                //ds.id_dish = p.id;
                //ds.id_order = id_order;
                ds.numb_dish += number;
                //ds.price = p.price;
                ds.price = ds.dish.price * ds.numb_dish;
                Save();
                return;
            }
            db.dish_strings.Add(new dish_string() { /*id = (int)db.dishes.Local.ToBindingList().Max(x => x.id),*/ numb_dish = number, id_dish = p.id, id_order = id_order, price = p.price * number });
            Save();
        }
        public void UpdateDishString(dishstringDto p)
        {
            //dish_string ds = db.dish_strings.Include("dish").Find(p.id);
            dish_string ds = db.dish_strings.Include("dish").FirstOrDefault(e => e.id == p.id);
            ds.id_dish = p.id_dish;
            ds.id_order = p.id_order;
            ds.numb_dish = p.numb_dish;
            ds.price = ds.dish.price*p.numb_dish;
            db.Entry(ds).State=EntityState.Modified;
            Save();
        }
        public void DeleteDishString(int id)
        {
            dish_string p = db.dish_strings.Find(id);
            if (p != null)
            {
                db.dish_strings.Remove(p);
                Save();
            }
        }

        public List<dishstringDto> GetAllDishString()
        {
            var res = db.dish_strings.ToList();
            return res.Select(i => new dishstringDto(i)).ToList();
        }
        public List<dishstringDto> GetOrderDishString(int id)
        {
            var res = db.dish_strings.Include("dish").Where(e => e.id_order == id).ToList();
            return res.Select(i => new dishstringDto(i)).ToList();
        }
        public dishstringDto GetDoneDishString()
        {
            //if (db.SaveChanges() > 0) return true;
            return db.dish_strings.Include("dish_string").ToList().Select(i => new dishstringDto(i)).Last();
        }
    }
}
