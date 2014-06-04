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
        DateTime _created;
        TimeSpan _pickup;
        TimeSpan _dropoff;
        Dictionary<MenuItemInfo, PrepStatus> _itemAndIsStarted;
        bool _paid;

        public Order(OrderDetails details)
        {
            this._orderID = Guid.NewGuid();
            this._paid = false;
            this._created = DateTime.Now;
            this._pickup = TimeSpan.FromMinutes(15);
            this._dropoff = TimeSpan.FromMinutes(30);
            // Create new instance for each instance of an ordered item
            this._itemAndIsStarted = new Dictionary<MenuItemInfo, PrepStatus>();
            foreach (MenuItemInfo item in details.itemAndQuantity.Keys)
            {
                for (int i = 0; i < details.itemAndQuantity[item]; ++i)
                {
                    this.itemAndIsStarted.Add(
                        new MenuItemInfo(item),
                        PrepStatus.OK_CANCEL
                    );
                }
            }
        }
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
        public DateTime created
        {
            get { return _created; }
            set { _created = value; }
        }
        /// <summary>
        /// The exact time the order is to be / was picked up.
        /// </summary>
        [DataMember]
        public DateTime pickup
        {
            get {
                return _created + _pickup;
            }
            set {
                _pickup = value - _created; 
            }
        }
        /// <summary>
        /// The exact time the order is to be / was dropped off.
        /// </summary>
        [DataMember]
        public DateTime dropoff
        {
            get
            {
                return _created + _dropoff;
            }
            set
            {
                _dropoff = value - _created;
            }
        }
        /// <summary>
        /// A set of MenuItemInfo objects, each one representing one instance of the Menu
        /// Item to be cooked, and an associated boolean value indicating whether that
        /// dish has been started.
        /// </summary>
        [DataMember]
        public Dictionary<MenuItemInfo, PrepStatus> itemAndIsStarted
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
        /// <summary>
        /// An enumeration of all functionally-significant prep statuses for any MenuItemInfo
        /// in an Order.
        /// </summary>
        private enum PrepStatus
        {
            OK_CANCEL,
            NO_CANCEL
        }
    }
}
