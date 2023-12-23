using DomainModel;
using Interfaces.Repository;
using Interfaces.DTO;
//using BLL.DTO;
//using Interfaces.Repository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DAL.RepositoryPgs
{
    public class ReportReposPgs : IReportsRepository
    {
        private Model1 db;
        public ReportReposPgs(Model1 dbcontext)
        {
            this.db = dbcontext;
        }

        public List<SPResult> ExecuteSP(string adress, int numeric, string number)
        {
            Model1 db = new Model1();
            NpgsqlParameter param1 = new NpgsqlParameter("@adress", adress);
            NpgsqlParameter param2 = new NpgsqlParameter("@valueord", numeric);
            NpgsqlParameter param3 = new NpgsqlParameter("@number", number);
            NpgsqlParameter param4 = new NpgsqlParameter("@price", 500);
            NpgsqlParameter param5 = new NpgsqlParameter("@id_del", (int)db.deliveries.Max(x => x.id) + 1);
            var result = db.Database.SqlQuery<SPResult>("select * from new_delivery(@adress,@valueord,@number,@price,@id_del)", new object[] { param1, param2, param3, param4, param5 }).ToList();
            return result;
        }

        public List<ReportData> ReportOrdersWithDelivery(int orderId)
        {
            Model1 db = new Model1();
            var request = db.orders
            .Join(db.deliveries, ph => ph.id, m => m.id_order, (ph, m) => new {
                dish = ph.dish,
                summ = ph.summ,
                adress = m.adress,
                //new_summ = m.delivery_price + ph.summ,
                id_order = m.id_order,
                number_cli = m.number_cli
            })
            .Where(i => i.id_order == orderId/*numericUpDown1.Value*/)
            .Select(i => new ReportData() { Dish = i.dish, Summ = i.summ, adress = i.adress, /*New_summ = i.summ,*/ id_order = i.id_order, number_cli = i.number_cli })
            .ToList();
            return request;
        }
        public int revenueDay()
        {
            DateTime firstDate = DateTime.Now.Date;
            Model1 db = new Model1();
            int result=0;
            var request = db.orders.ToList()
            //.Join(db.deliveries, ph => ph.id, m => m.id_order, (ph, m) => new {
            //    dish = ph.dish,
            //    summ = ph.summ,
            //    adress = m.adress,
            //    //new_summ = m.delivery_price + ph.summ,
            //    id_order = m.id_order,
            //    number_cli = m.number_cli
            //})
            .Where(i => i.date == firstDate/*numericUpDown1.Value*/)
            //.Select(i => new order() { summ = i.summ /*New_summ = i.summ,*/ })
            .ToList();
            foreach( var order in request)
            {
                result += (int)order.summ;
            }
            return result;
        }

        public int revenueMonth()
        {
            DateTime firstDate = DateTime.Now.Date;
            DateTime secondDate = DateTime.Now.Date.AddDays(-30);
            Model1 db = new Model1();
            int result = 0;
            var request = db.orders.ToList()
            //.Join(db.deliveries, ph => ph.id, m => m.id_order, (ph, m) => new {
            //    dish = ph.dish,
            //    summ = ph.summ,
            //    adress = m.adress,
            //    //new_summ = m.delivery_price + ph.summ,
            //    id_order = m.id_order,
            //    number_cli = m.number_cli
            //})
            .Where(i => i.date >= secondDate && i.date <= firstDate/*numericUpDown1.Value*/)
            //.Select(i => new order() { summ = i.summ /*New_summ = i.summ,*/ })
            .ToList();
            foreach (var order in request)
            {
                result += (int)order.summ;
            }
            return result;
        }
        public int profitMonth()
        {
            DateTime firstDate = DateTime.Now.Date;
            DateTime secondDate = DateTime.Now.Date.AddDays(-30);
            Model1 db = new Model1();
            int result = 0;
            int price=0;

            var request = db.orders.ToList()
            .Where(i => i.date >= secondDate && i.date <= firstDate/*numericUpDown1.Value*/)
            .ToList();
            foreach (var order in request)
            {
                    var price_dish_str = order.dish_string.Select(e => new {i= e.dish, j=e.numb_dish  }/*, order.dish_string.Select(j => j.numb_dish)*/ ).ToList();
                //var num_dish_str = order.dish_string.Select(e => e.dish /*.ingredient_string.Select(i => i.price)).ToList()*/).ToList();
                foreach (var elem in price_dish_str)
                {
                        var price_dish = elem.i.ingredient_string/*.Select(e => e.price)*/.ToList();
                        foreach (var el in price_dish)
                        {
                        price += (int)el.price * (int)elem.j;/** price_dish_str.Select(f=>f.j)*//**price_dish_str.numb_dish*/;
                    }
                }

                result += (int)order.summ;
            }
            result = result - price;
            return result;
        }
        public int profitDay()
        {
            DateTime firstDate = DateTime.Now.Date;
            Model1 db = new Model1();
            int result = 0;
            int price = 0;
            var request = db.orders.ToList()
            //.Join(db.deliveries, ph => ph.id, m => m.id_order, (ph, m) => new {
            //    dish = ph.dish,
            //    summ = ph.summ,
            //    adress = m.adress,
            //    //new_summ = m.delivery_price + ph.summ,
            //    id_order = m.id_order,
            //    number_cli = m.number_cli
            //})
            .Where(i => i.date == firstDate/*numericUpDown1.Value*/)
            //.Select(i => new order() { summ = i.summ /*New_summ = i.summ,*/ })
            .ToList();
            foreach (var order in request)
            {
                var price_dish_str = order.dish_string.Select(e => new { i = e.dish, j = e.numb_dish }/*, order.dish_string.Select(j => j.numb_dish)*/ ).ToList();
                //var num_dish_str = order.dish_string.Select(e => e.dish /*.ingredient_string.Select(i => i.price)).ToList()*/).ToList();
                foreach (var elem in price_dish_str)
                {
                    var price_dish = elem.i.ingredient_string/*.Select(e => e.price)*/.ToList();
                    foreach (var el in price_dish)
                    {
                        price += (int)el.price * (int)elem.j;/** price_dish_str.Select(f=>f.j)*//**price_dish_str.numb_dish*/;
                    }
                }

                result += (int)order.summ;
            }
            result = result - price;
            return result;
        }
    }
}
