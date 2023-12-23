using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IdeliveryService
    {
        deliveryDto MakeDelivery(deliveryDto dishstringDto);
        List<deliveryDto> GetAllDeliveries();
        deliveryDto GetDelivery(int phoneId);
        void CreateDelivery(deliveryDto p);
        void UpdateDelivery(deliveryDto p);
        void DeleteDelivery(int id);
        deliveryDto GetDoneDelivery();
    }
}
