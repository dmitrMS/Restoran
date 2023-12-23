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
    public class deliveryService : IdeliveryService
    {
        private Model1 db;
        public deliveryService()
        {
            db = new Model1();
        }

        public deliveryDto MakeDelivery(deliveryDto dishstringDto)
        {
            delivery DishString = new delivery
            {
                id = dishstringDto.id,
                adress = dishstringDto.adress,
                id_order = dishstringDto.id_order,
                number_cli = dishstringDto.number_cli,
                delivery_price = dishstringDto.delivery_price,



            };
            db.deliveries.Add(DishString);
            if (db.SaveChanges() > 0)
                return db.deliveries.ToList().Select(i => new deliveryDto(i)).Last();
            return null;

        }
        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
        public deliveryDto GetDelivery(int Id)
        {
            return new deliveryDto(db.deliveries.Find(Id));
        }
        public void CreateDelivery(deliveryDto p)
        {
            db.deliveries.Add(new delivery() { /*id = (int)db.dishes.Local.ToBindingList().Max(x => x.id),*/ number_cli = p.number_cli, adress = p.adress, id_order = p.id_order, delivery_price = 500 });
            Save();
        }
        public void UpdateDelivery(deliveryDto p)
        {
            delivery ds = db.deliveries.Find(p.id);
            ds.id = p.id;
            ds.adress = p.adress;
            ds.id_order = p.id_order;
            ds.number_cli = p.number_cli;
            ds.delivery_price = p.delivery_price;
            Save();
        }
        public void DeleteDelivery(int id)
        {
            delivery p = db.deliveries.Find(id);
            if (p != null)
            {
                db.deliveries.Remove(p);
                Save();
            }
        }

        public List<deliveryDto> GetAllDeliveries()
        {
            var res = db.deliveries.ToList();
            return res.Select(i => new deliveryDto(i)).ToList();
        }
        public deliveryDto GetDoneDelivery()
        {
            //if (db.SaveChanges() > 0) return true;
            return db.deliveries.ToList().Select(i => new deliveryDto(i)).Last();
        }
    }
}
