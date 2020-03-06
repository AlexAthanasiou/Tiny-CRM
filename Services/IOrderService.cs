using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCrm.Model;
using TinyCrm.Model.Options;

namespace TinyCrm.Services {
    interface IOrderService 
    {
        bool AddNewOrder(AddOrderOptions options);

        Order GetOrderDetails(Order order);

        bool UpdateOrder(int? id, UpdateOrderOptions options);

        Order GetOrderById(int? id);


    }
}
