/*
 * Levi Sky Murray Schoen
 * CS 300
 * Kartopia Order Services package, for creating, removing, viewing, and managing orders
 */
using System;
using System.IO;
using System.Collections.Generic;

////Class for testing and debugging order services classes.
public class TestClass
{
    ////Main method of the TestClass class
    public static void Main(string[] args)
    {
        ////Output to the console text
        Console.WriteLine("Order at Kartopia!\n");
    }
}
////Class for managing a menu item object
public class MenuItem
{
    ////MenuItem class default constructor
    public MenuItem()
    {
        ///Set data members to zero vales
        Cost = 0;
        Name = null;
    }
    ///MenuItem class constructor with args for data membrs
    public MenuItem(double itemCost, String itemName)
    {
        ///Set data members to the values passed in
        Name = itemName;
        Cost = itemCost;
    }
    ///MenuItem class copy constructor
    public MenuItem(MenuItem toCopy)
    {
        ///Intialize data members to the same as the MenuItem object passed in
        Cost = toCopy.Cost;
        Name = toCopy.Name;
    }

    ///MenuItem public function to display the contents of the object
    public int displayMenuItem(TextWriter writer)
    {
        ///Display the name and cost of the menu item
        writer.WriteLine("Item : {0}", Name);
        writer.WriteLine("Cost : {0}", Cost);
        ///Return success flag
        return 1;
    }
    ///MenuItem private data member to store the cost of the menu item
    public double Cost
    {
        get;
        set;
    }
    ///MenuItem private data member to store the name of the menu item
    public String Name
    {
        get;
        set;
    }

}
///Class to manage an Order object, storing and manupilating order details
public class Order
{
    ///Order class default constructor
    public Order()
    {
        ///Intialize data members to default values
        items = null;
        OrderCost = 0;
        OrderStatus = 'c';
        orderCounter = 0;
        OrderId = orderCounter++;
        OrderPickUpTime = (DateTime.Now).AddMinutes(40);
        FoodCartId = 0;
    }
    ///Order class constructor with arguements for a list of menu items
    ///and the id of the food cart making this order
    public Order(LinkedList<MenuItem> newItems, int foodCartMaker)
    {
        ///Intialize the items to the same items as passed in
        items = new LinkedList<MenuItem>(newItems);
        FoodCartId = foodCartMaker;
        ///Intialize data members to appropriate values
        OrderCost = 0;
        OrderStatus = 's';
        orderCounter = 0;
        OrderId = orderCounter++;
        OrderPickUpTime = (DateTime.Now).AddMinutes(40);
        ///Node to help us in traversing the list of menu items
        LinkedListNode<MenuItem> head = newItems.First;
        ///Loop to add the cost of each menu item to the cost of the order
        while (head != null)
        {
            OrderCost += head.Value.Cost;
            head = head.Next;
        }
    }
    ///Order class copy constructor
    public Order(Order toCopy)
    {
        ///Set data members to the value of the Order object passed in
        items = new LinkedList<MenuItem>(toCopy.items);
        OrderPickUpTime = toCopy.OrderPickUpTime;
        OrderCost = toCopy.OrderCost;
        OrderStatus = toCopy.OrderStatus;
        OrderId = toCopy.OrderId;
        FoodCartId = toCopy.FoodCartId;
    }
    ///Order class public mention function to display the contents of the order objects
    public int displayOrder(TextWriter writer)
    {
        writer.WriteLine();
        ///Display order number
        writer.WriteLine("Order ID : {0}", OrderId);
        ///Display the id of the food cart making this order
        writer.WriteLine("Food Cart ID : {0}", FoodCartId);
        ///Display the
        ///Display all menu items this order contains
        LinkedListNode<MenuItem> head = items.First;

        writer.WriteLine();
        writer.WriteLine("Menu Items : ");
        ///Loop to display all menu items contained in this order object
        while (head != null)
        {
            head.Value.displayMenuItem(writer);
            writer.WriteLine();
            head = head.Next;
        }
        ///Display the order pickup time
        writer.WriteLine("Order Pick Up Time : {0}", OrderPickUpTime.ToString());
        ///Return success flag
        return 1;
    }

    ///Ordeer class private data member to aid in generating unique order id's
    private static int orderCounter;
    ///Order class private datat member containing a linked list of menu items
    private LinkedList<MenuItem> items;
    ///Order class private data member to track total cost of order
    public double OrderCost
    {
        get;
        set;
    }
    ///Order class private data member to track the status of the order
    ///Possible values include
    ///s-submitted
    ///c-cancelled
    ///p-prepping
    ///f-finished
    ///r-recieved
    public char OrderStatus
    {
        get
        {
            return OrderStatus;
        }
        set
        {
            ///Check to see if the udpated status is a delay status
            if (value == 'd')
            {
                ///If it is delay the order pickup time by 5 minutes
                OrderPickUpTime.AddMinutes(5);
            }
            ///Set the order status to the arguement passed in
            OrderStatus = value;
        }
    }
    public int OrderId
    {
        get;
        set;
    }
    ///Order class private data member for the food cart that is making this order object
    public int FoodCartId
    {
        get;
        set;
    }
    ///Order class private data member to hold the pickup time for this order object
    public DateTime OrderPickUpTime
    {
        get;
        set;
    }

}
///Class to manage a collection of orders
public class OrderManager
{
    ///OrderManager class default constructor
    public OrderManager()
    {
        orderQueue = null;
    }
    ///OrderManager class constructor with argument for a list of orders
    public OrderManager(LinkedList<Order> newOrderQueue)
    {
        orderQueue = new LinkedList<Order>(newOrderQueue);
    }
    ///OrderManager class copy constructor
    public OrderManager(OrderManager toCopy)
    {
        orderQueue = new LinkedList<Order>(toCopy.orderQueue);
    }
    ///OrderManager class public function to add a order to the list of orders in this object
    public int submitOrder(Order newOrder)
    {
        ///Add the new order to our queue of current orders
        orderQueue.AddLast(newOrder);
        ///Return success flag
        return 1;
    }
    ///OrderManager class public function to remove an order from the list of orders in this object
    ///For example after an order has been picked up
    public int removeOrder(Order order)
    {
        ///Linked list node to help us in searching through the order queue
        LinkedListNode<Order> head = orderQueue.Find(order);
        ///If the list is not empty
        if (head != null)
        {

            ///Try to remove the order
            bool isRemoved = orderQueue.Remove(order);
            ///Return successful flag if we found and removed the order
            if (isRemoved == true)
            {
                return 1;
            }
            ///Else we didnt find the order to be removed
            else
            {
                return 0;
            }
        }
        ///Else there was no orders in our queue to begin with,
        ///and this function trivially fails
        else
        {
            ///So return fail flag
            return 0;
        }
    }
    ///OrderManager class public function to view an order using the order id for a key
    public int viewOrder(Order order, TextWriter writer)
    {
        ///Call the order objects display function
        order.displayOrder(writer);
        ///Return success flag
        return 1;
    }
    ///OrderManager class public function to view a collection of orders by order id
    public int viewOrders(LinkedList<Order> requestedOrders, TextWriter writer)
    {
        ///Node to help us in navigating the list of orders
        LinkedListNode<Order> head = requestedOrders.First;
        ///Travese the linked list and display each order
        while (head != null)
        {
            ///Display the order in the current node
            head.Value.displayOrder(writer);
            ///Advance our node to the next object in the linked list
            head = head.Next;
        }
        ///Return success flag
        return 1;
    }
    //OrderManager class public function to view all the orders for a specific food cart
    public int viewOrders(int foodCartMaker, TextWriter writer)
    {
        //Nde variable to help us in traversing the order queue
        LinkedListNode<Order> head = orderQueue.First;
        //Loop to go through all orders in the order queue
        while (head != null)
        {
            //If the particular order is made by the food cart we are interested in
            if (head.Value.FoodCartId == foodCartMaker)
            {
                //Display it
                head.Value.displayOrder(writer);
            }
            //Advance to the next node
            head = head.Next;
        }
        //Return success flag
        return 1;
    }
    ///OrderManager class public function to cancel a specified order
    public int cancelOrder(Order order, TextWriter writer)
    {
        if (order.OrderStatus == 's')
        {
            ///Linked list node to help us in searching through the order queue
            LinkedListNode<Order> head = orderQueue.Find(order);
            ///If we found the order to be cancelled in the queue
            if (head != null)
            {
                ///Cancel the order
                head.Value.OrderStatus = 'c';
                ///Remove the order from the order queue
                orderQueue.Remove(order);
                ///Return successful flag
                return 1;
            }
            ///Else we did not find the order
            else
            {
                ///So return fail flag
                return 0;
            }
        }
        ///Else the order is not in a state where it can be cancelled
        else
        {
            writer.WriteLine("Order not able to be cancelled");
            ///Return fail flag
            return 0;
        }

    }
    ///OrderManager class public function to cancel a specified order
    public int startOrder(Order order)
    {
        ///Linked list node to help us in searching through the order queue
        LinkedListNode<Order> head = orderQueue.Find(order);
        ///If we found the order to be started in the queue
        if (head != null)
        {
            ///Mark the order as started
            head.Value.OrderStatus = 'p';
            ///Return successful flag
            return 1;
        }
        ///Else we did not find the order
        else
        {
            ///So return fail flag
            return 0;
        }
    }
    ///OrderManager class public function to change status to finish for a specified order
    public int finishOrder(Order order)
    {
        ///Linked list node to help us in searching through the order queue
        LinkedListNode<Order> head = orderQueue.Find(order);
        ///If we found the order to be finished in the queue
        if (head != null)
        {
            ///Mark the order as finished
            head.Value.OrderStatus = 'f';
            ///Return successful flag
            return 1;
        }
        ///Else we did not find the order
        else
        {
            ///So return fail flag
            return 0;
        }
    }
    //OrderManager class public function to return a specfic order by order id
    public Order getOrder(int orderId)
    {
        //Node to help us in traversing the order queue
        LinkedListNode<Order> head = orderQueue.First;
        //Boolean variable to keep track of if we found the order in question
        bool found = false;
        //Loop to go through the order queue and search for the order
        while (head != null && found == false)
        {
            //If the current order is the one we are searching for
            if (head.Value.OrderId == orderId)
            {
                //Set found to true
                found = true;
                //Return the match
                return head.Value;
            }
            //Advance to the next item in the order queue
            head = head.Next;
        }
        //Assuming we didn't find the order we want, create
        //a blank order
        Order order = new Order();
        //And return the blank order
        return order;
    }
    //OrderManager class public function to return a list of all orders
    //made by a particular food cart
    public LinkedList<Order> getOrders(int foodCartMaker)
    {
        //A linked list to hold all the orders from the particular food cart
        LinkedList<Order> foodCartOrders = new LinkedList<Order>();
        //A linked list node to help us in traversing the order queeu
        LinkedListNode<Order> head = orderQueue.First;
        //If nothing in the orderqueue, return an empty list of orders
        if (head == null)
        {
            return foodCartOrders;
        }
        //Loop to check each order in the queue
        while (head != null)
        {
            //If the current order is made by the food cart maker of interest 
            if (head.Value.FoodCartId == foodCartMaker)
            {
                //Add this order to our list to be returned
                foodCartOrders.AddFirst(new Order(head.Value));
            }
            //Advance to the next order in the queue
            head = head.Next;
        }
        //Return the list of orders made by the food cart maker in question
        return foodCartOrders;
    }

    ///OrderManager class public function to delay a specified order
    ///Maybe we will whack this functionality....
    public int delayOrder(Order order)
    {
        ///Linked list node to help us in searching through the order queue
        LinkedListNode<Order> head = orderQueue.Find(order);
        ///If we found the order to be delayed in the queue
        if (head != null)
        {
            ///Delay the order
            head.Value.OrderStatus = 'd';
            ///Return successful flag
            return 1;
        }
        ///Else we did not find the order
        else
        {
            ///So return fail flag
            return 0;
        }
    }
    ///OrderManager class data member containing the list of orders being managed
    private LinkedList<Order> orderQueue;
}
