using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Services
{
    public class OrderService : IOrderService
    {
        public Guid submitOrder(OrderDetails newOrder)
        {
            // Call something in K_OrderManager
            return new Guid();
        }

        public Order getOrder(Guid orderID)
        {
            // Call something in K_OrderManager
            return null;
        }

        public List<Order> getOrders(Guid clientGUID)
        {
            // Call something in K_OrderManager
            return null;
        }

        public bool requestCancel(Guid orderID)
        {
            // Call something in K_OrderManager
            return false;
        }

        public bool delayPickup(Guid orderID, TimeSpan delay)
        {
            // Call something in K_OrderManager
            return false;
        }

        public bool delayDropoff(Guid orderID, TimeSpan delay)
        {
            // Call something in K_OrderManager
            return false;
        }
    }
}
