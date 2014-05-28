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

    /// <summary>
    /// The customer-generated details of a new order, to be used in the creation of a new
    /// Order object or entry in the order database.
    /// </summary>
    [DataContract]
    public class OrderDetails
    {
        Dictionary<MenuItemInfo, int> _itemAndQuantity;

        /// <summary>
        /// A set of MenuItemInfo objects, representing the unique food items to 
        /// be ordered, with an associated value indicating the number of which
        /// should be added to an order
        /// </summary>
        [DataMember]
        public Dictionary<MenuItemInfo, int> itemAndQuantity
        {
            get { return _itemAndQuantity; }
            set { _itemAndQuantity = value; }
        }
    }
    /// <summary>
    /// The system-generated data for an order, to be added to the order database or
    /// generated from the order database.
    /// </summary>
    [DataContract]
    public class Order
    {
        Guid _orderID;
        TimeSpan _created;
        TimeSpan _pickup;
        TimeSpan _dropoff;
        Dictionary<MenuItemInfo, bool> _itemAndIsStarted;
        bool _paid;

        /// <summary>
        /// The order's unique GUID
        /// </summary>
        [DataMember]
        public Guid orderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        /// <summary>
        /// The exact time the order was created.
        /// </summary>
        [DataMember]
        public TimeSpan created
        {
            get { return _created; }
            set { _created = value; }
        }
        /// <summary>
        /// The exact time the order is to be / was picked up.
        /// </summary>
        [DataMember]
        public TimeSpan pickup
        {
            get { return _pickup; }
            set { _pickup = value; }
        }
        /// <summary>
        /// The exact time the order is to be / was dropped off.
        /// </summary>
        [DataMember]
        public TimeSpan dropoff
        {
            get { return _dropoff; }
            set { _dropoff = value; }
        }
        /// <summary>
        /// A set of MenuItemInfo objects, each one representing one instance of the Menu
        /// Item to be cooked, and an associated boolean value indicating whether that
        /// dish has been started.
        /// </summary>
        [DataMember]
        public Dictionary<MenuItemInfo, bool> itemAndIsStarted
        {
            get { return _itemAndIsStarted; }
            set { _itemAndIsStarted = value; }
        }
        /// <summary>
        /// Whether this Order has been paid for.
        /// </summary>
        [DataMember]
        public bool paid
        {
            get { return _paid; }
            set { _paid = value; }
        }
    }
}
