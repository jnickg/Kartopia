using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics.Contracts;

namespace K_Services
{
    [ServiceContract]
    public interface IFoodCartService
    {
        [OperationContract]
        List<MenuItemInfo> getFoodCartMenu(FoodCartInfo thisCart);

        [OperationContract]
        List<FoodCartInfo> getFoodCarts();

        [OperationContract]
        List<MenuItemInfo> getMenuItemMatches(string searchParam);

        [OperationContract]
        List<FoodCartInfo> getFoodCartMatches(string searchParam);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "K_Services.ContractType".

    /// <summary>
    /// A class-based structure representing one food cart in a food cart menu item database.
    /// </summary>
    [DataContract]
    public class FoodCartInfo
    {
        Guid _cartID;
        List<MenuItemInfo> _menuItems;
        string _name = "FoodCartName";
        TimeSpan _openTime;
        TimeSpan _closeTime;

        public FoodCartInfo()
        {
            this._menuItems = new List<MenuItemInfo>();
            this._cartID = Guid.NewGuid();
            this._openTime = TimeSpan.FromHours(9);
            this._closeTime = TimeSpan.FromHours(5);
        }

        public FoodCartInfo(string name, List<MenuItemInfo> menuItems)
        {
            Contract.Requires((name != string.Empty) && menuItems.Count > 0);
            this._name = name;
            this._menuItems = menuItems;
            this._cartID = Guid.NewGuid();
            this._openTime = TimeSpan.FromHours(9);
            this._closeTime = TimeSpan.FromHours(5);
        }

        public override string ToString()
        {
            return _name;
        }

        /// <summary>
        /// The time the Food Cart represented by this FoodCartInfo opens
        /// </summary>
        [DataMember]
        public TimeSpan openTime
        {
            get { return _openTime; }
            set { _openTime = value; }
        }
        /// <summary>
        /// The time the Food Cart represented by this FoodCartInfo closes
        /// </summary>
        [DataMember]
        public TimeSpan closeTime
        {
            get { return _closeTime; }
            set { _closeTime = value; }
        }
        /// <summary>
        /// The "database" GUID representing this Food Cart
        /// </summary>
        [DataMember]
        public Guid cartID
        {
            get { return this._cartID; }
            set { this._cartID = value; }
        }
        /// <summary>
        /// The name of this Food Cart
        /// </summary>
        [DataMember]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// The Food in this Cart
        /// </summary>
        [DataMember]
        public List<MenuItemInfo> menuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }
    }
    /// <summary>
    /// A class-based structure representing one menu item entry in a food cart menu item database.
    /// </summary>
    [DataContract]
    public class MenuItemInfo
    {
        Guid _itemID;
        string _cartName = "CartName";
        string _name = "MenuItemName";
        int _cost;

        public MenuItemInfo()
        {
            this._itemID = Guid.NewGuid();
            this._cost = 0;
        }

        public MenuItemInfo(MenuItemInfo toCopy)
        {
            this.itemID = toCopy.itemID;
            this.cartName = toCopy.cartName;
            this.name = toCopy.name;
            this.cost = toCopy.cost;
        }

        public MenuItemInfo(string name, int cost, string cartName)
        {
            Contract.Requires((name != string.Empty) && (cost > 0),
                "One cannot simply create a Menu item with no name or cost");
            this._itemID = Guid.NewGuid();
            this._cartName = cartName;
            this._name = name;
            this._cost = cost;
        }

        public override string ToString()
        {
            return _name;
        }

        public string CostDisplayString
        {
            get
            {
                return String.Format("{0:C} - {1}",
                    Decimal.Divide((decimal)this.cost, 100), this.name);
            }
        }

        public string LongDisplayString
        {
            get
            {
                return String.Format("{0:C} - {1} ({2})",
                    Decimal.Divide((decimal)this.cost, 100),
                    this.name,
                    this._cartName);
            }
        }

        /// <summary>
        /// The "database" GUID representing this Menu Item
        /// </summary>
        [DataMember]
        public Guid itemID
        {
            get { return this._itemID; }
            set
            {
                Contract.Requires(value != Guid.Empty);
                this._itemID = value;
            }
        }
        /// <summary>
        /// The cart from which this Menu Item came
        /// </summary>
        [DataMember]
        public string cartName
        {
            get { return _cartName; }
            set { _cartName = value; }
        }
        /// <summary>
        /// The name of this Menu Item
        /// </summary>
        [DataMember]
        public string name
        {
            get { return _name; }
            set
            {
                Contract.Requires(value != string.Empty);
                _name = value;
            }
        }
        /// <summary>
        /// The cost in cents of this Menu Item
        /// </summary>
        [DataMember]
        public int cost
        {
            get { return _cost; }
            set
            {
                Contract.Requires(value > 0);
                _cost = value;
            }
        }
    }
}
