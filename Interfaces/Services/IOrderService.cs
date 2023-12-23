using BLL.DTO;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOrderService
    {
        orderDto MakeOrder(orderDto orderDto);
        orderDto GetDoneOrder();
        List<orderDto> GetAllOrders();
        void UpdateOrder(orderDto p);
        orderDto GetOrder(int Id);
        void DeleteOrder(int id);
    }
}
