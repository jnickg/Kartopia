using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace K_Services
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        Guid submitOrder(OrderDetails newOrder);

        [OperationContract]
        Order getOrder(Guid orderID);

        [OperationContract]
        List<Order> getOrders(Guid clientGUID);

        [OperationContract]
        bool requestCancel(Guid orderID);

        [OperationContract]
        bool delayPickup(Guid orderID, TimeSpan delay);

        [OperationContract]
        bool delayDropoff(Guid orderID, TimeSpan delay);
    }

    [DataContract]
    public class OrderDetails
    {
        Dictionary<MenuItemInfo, int> _itemAndQuantity;

        [DataMember]
        public Dictionary<MenuItemInfo, int> itemAndQuantity
        {
            get { return _itemAndQuantity; }
            set { _itemAndQuantity = value; }
        }
    }

    [DataContract]
    public class Order
    {
        Guid _orderID;
        TimeSpan _created;
        TimeSpan _pickup;
        TimeSpan _dropoff;
        Dictionary<MenuItemInfo, bool> _itemAndIsStarted;

        [DataMember]
        public Guid orderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        [DataMember]
        public TimeSpan created
        {
            get { return _created; }
            set { _created = value; }
        }
        [DataMember]
        public TimeSpan pickup
        {
            get { return _pickup; }
            set { _pickup = value; }
        }
        [DataMember]
        public TimeSpan dropoff
        {
            get { return _dropoff; }
            set { _dropoff = value; }
        }
        [DataMember]
        public Dictionary<MenuItemInfo, bool> itemAndIsStarted
        {
            get { return _itemAndIsStarted; }
            set { _itemAndIsStarted = value; }
        }
    }
}
