using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Services
{
    public class OrderService : IOrderService
    {
        Dictionary<Guid, List<Order>> _currentOrders = new Dictionary<Guid, List<Order>>();

        public Guid submitOrder(OrderDetails details, Guid cartID)
        {
            Order instantiatedOrder = new Order(details);
            if (_currentOrders.ContainsKey(cartID))
            {
                _currentOrders[cartID].Add(instantiatedOrder);
            }
            else
            {
                List<Order> newlist = new List<Order>();
                newlist.Add(instantiatedOrder);
                _currentOrders.Add(cartID, newlist);
            }
            return instantiatedOrder.orderID;
        }

        public Order getOrder(Guid orderID)
        {
            foreach (Guid g in _currentOrders.Keys)
            {
                foreach (Order o in _currentOrders[g])
                {
                    if (o.orderID == orderID)
                    {
                        return o;
                    }
                }
            }
            return null;
        }

        public List<Order> getOrders(Guid clientGUID)
        {
            if (_currentOrders.ContainsKey(clientGUID))
            {
                return _currentOrders[clientGUID];
            }
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
