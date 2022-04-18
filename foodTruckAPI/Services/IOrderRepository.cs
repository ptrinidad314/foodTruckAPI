using foodTruckAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodTruckAPI.Services
{
    public interface IOrderRepository
    {
        CreateOrderResultDTO CreateOrder(OrderDTO orderDTO);
    }
}
