using BLL.DTO;
using DAL;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private Model1 db;
        public OrderService()
        {
            db = new Model1();
        }
        Random rnd = new Random();
        public orderDto MakeOrder(orderDto orderDto)
        {

            List<dish> orderedDishes = new List<dish>();
            int sum = 0;
            string status = "cook";
            
            if (orderDto.OrderedDishesIds != null)
            {


                foreach (var pId in orderDto.OrderedDishesIds)
                {
                    dish dish = db.dishes.Find(pId);
                    // валидация
                    if (dish == null)
                        throw new Exception("Блюдо не найдено");
                    sum += (int)dish.price;
                    orderedDishes.Add(dish);
                }
            }
            //применяем скидку
            sum = (int)new discount(0.1).GetDiscountedPrice(sum);


            order order = new order
            {
                //id = (int)db.dishes.Local.ToBindingList().Max(x => x.id) + 1+ (rnd.Next()%100),
                order_status = status,
                date = DateTime.Now,
                summ = sum,
                id_stol = orderDto.id_stol
                //dish = orderDto.dish,
                //dish_string = orderedphones

            };
            db.orders.Add(order);
            if (db.SaveChanges() > 0)
                return db.orders.OrderBy(e=>e.id).ToList().Select(i => new orderDto(i)).Last();
            return null;

        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public orderDto GetDoneOrder()
        {
            //if (db.SaveChanges() > 0) return true;
            //p.OrderedDishesIds = db.dish_strings.Where(e => e.id_order == ph.id).Select(i => (int)i.id_dish).ToList();
            order res = db.orders.OrderBy(e=>e.id).ToList().Last();
            //db.orders.Last()
            //res.dish_string= db.dish_strings.Where(e => e.id_order == res.id).ToList();
            db.Entry(res).Collection("dish_string").Load();
            return new orderDto(res);
            //return db.orders.Include("dish_string").ToList().Select(i => new orderDto(i)).Last(); 

        }
        public orderDto GetOrder(int Id)
        {
            return new orderDto(db.orders.Find(Id));
        }
        public void CreateOrder(orderDto p)
        {
            db.orders.Add(new order() { id_stol = p.id_stol, id = p.id, summ = p.summ, order_status = p.order_status});
            Save();
        }
        public void UpdateOrder(orderDto p)
        {
            order ph = db.orders.FirstOrDefault(e=> e.id==p.id);
            ph.id_stol = p.id_stol;
            ph.summ = 0;
            ph.order_status = p.order_status;
            List<dish> orderedDishes = new List<dish>();
            //p.OrderedDishesIds = db.orders.Find(ph.dish_string.Select(i => (int)i.id_dish).ToList());

            p.OrderedDishesIds = db.dish_strings.Where(e=> e.id_order == ph.id).Select(i => (int)i.id_dish).ToList();
            var res = db.dish_strings.Where(e => e.id_order == ph.id && e.id_dish == 1)
                                                          .Select(i => (int)i.numb_dish)
                                                          .FirstOrDefault();
            p.OrderedDishes = String.Join(",", db.dish_strings.Where(e => e.id_order == ph.id).Select(i => i.dish.name + "(" + i.numb_dish + ")").ToList());
            foreach (var pId in p.OrderedDishesIds)
            {
                dish dish = db.dishes.Find(pId);
                // валидация
                if (dish == null)
                    throw new Exception("Блюдо не найдено");
                ph.summ += (int)dish.price * db.dish_strings.Where(e => e.id_order == ph.id && e.id_dish == dish.id)
                                                          .Select(i => (int)i.numb_dish)
                                                          .FirstOrDefault();
                //ph.summ += dish.price;

            }

            //p.OrderedDishes = "";
            //if (p.OrderedDishesIds != null)
            //{


            //    foreach (var pId in p.OrderedDishesIds)
            //    {
            //        dish dish = db.dishes.Find(pId);
            //        // валидация
            //        if (dish == null)
            //            throw new Exception("Блюдо не найдено");
            //        ph.summ += (int)dish.price;
            //        orderedDishes.Add(dish);
            //        p.OrderedDishes += "," + dish.name;

            //    }
            //    if (p.OrderedDishes.Length > 0)
            //        p.OrderedDishes.Remove(0, 1);
            //}
            Save();
        }
        public void DeleteOrder(int id)
        {
            order p = db.orders.Find(id);
            if (p != null)
            {
                db.orders.Remove(p);
                Save();
            }
        }

        public List<orderDto> GetAllOrders()
        {
            var res = db.orders.ToList();
            return res.Select(i => new orderDto(i)).ToList();
        }
    }
}