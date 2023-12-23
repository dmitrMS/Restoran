using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace BLL.DTO
{
    public class deliveryDto
    {
        [StringLength(8000)]
        public string adress { get; set; }

        public int? id_order { get; set; }

        public int? delivery_price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(8000)]
        public string number_cli { get; set; }
        public deliveryDto() { }
        public deliveryDto(delivery o)
        {
            //name = o.name;
            id = o.id;
            adress = o.adress;
            delivery_price = o.delivery_price;
            number_cli = o.number_cli;
            id_order = o.id_order;
        }
    }
}
