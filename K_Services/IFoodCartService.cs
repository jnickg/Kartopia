using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
        string _name = "FoodCartName";
        TimeSpan _openTime;
        TimeSpan _closeTime;

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
    }
    /// <summary>
    /// A class-based structure representing one menu item entry in a food cart menu item database.
    /// </summary>
    [DataContract]
    public class MenuItemInfo
    {
        Guid _itemID;
        string _name = "MenuItemName";
        int cost;

        /// <summary>
        /// The "database" GUID representing this Menu Item
        /// </summary>
        [DataMember]
        public Guid itemID
        {
            get { return this._itemID; }
            set { this._itemID = value; }
        }
        /// <summary>
        /// The name of this Menu Item
        /// </summary>
        [DataMember]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// The cost in cents of this Menu Item
        /// </summary>
        [DataMember]
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
