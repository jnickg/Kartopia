/*
 * Levi Sky Murray Schoen
 * CS 300
 * Kartopia Order Services package, for creating, removing, viewing, and managing orders
 */
using System;
using System.IO;
using System.Collections.Generic;

//Class for testing and debugging order services classes.
class TestClass
    {
    //Main method of the TestClass class
        public static void Main (string[] args)
        {
        //Output to the console text
            Console.WriteLine ("Order at Kartopia!");
        }

    }
//Class for managing a menu item object
    class MenuItem
    {
//MenuItem class default constructor
        public MenuItem()
        {
//Set data members to zero vales
            cost = 0;
            name = null;
        }
//MenuItem class constructor with args for data membrs
        public MenuItem(double itemCost, String itemName)
        {
//Set data members to the values passed in
            name = itemName;
            cost = itemCost;
        }
    //MenuItem class copy constructor
        public MenuItem(MenuItem toCopy)
        {
        //Intialize data members to the same as the MenuItem object passed in
            cost = toCopy.cost;
            name = new string(toCopy.name);
        }
    //MenuItem public function to return the cost of this menu item
        public double  getCost()
        {
        //Return the cost of this menu item
            return cost;
        }
    //MenuItem public function to return the name of this menu item
        public String getName()
        {
        //Return the name of this menu item
            return name;
        }
    //MenuItem private data member to store the cost of the menu item
        private double cost;
    //MenuItem private data member to store the name of the menu item
        private String name;

    }
//Class to manage an Order object, storing and manupilating order details
    class Order
    {
    //Order class default constructor
        public Order()
        {
        //Intialize data members to default values
            items= null;
        orderCost = 0;
        orderStatus = 'c';
        orderCounter = 0;
        orderId = orderCounter++;
        orderPickUpTime = (DateTime.Now).AddMinutes (40);
        foodCartId = 0;
        }
    //Order class constructor with arguements for a list of menu items 
    //and the id of the food cart making this order
    public Order(LinkedList<MenuItem> newItems, int foodCartMaker)
        {
        //Intialize the items to the same items as passed in
            items = new LinkedList<MenuItem> (newItems);
        foodCartId = foodCartMaker;
        //Intialize data members to appropriate values
        orderCost = 0;
        orderStatus = 's';
        orderCounter = 0;
        orderId = orderCounter++;
        orderPickUpTime = (DateTime.Now).AddMinutes (40);
        }
    //Order class copy constructor
        public Order(Order toCopy)
        {
        //Set data members to the value of the Order object passed in
            items = new LinkedList<MenuItem> (toCopy.items);
        orderPickUpTime = toCopy.getOrderPickUpTime;
        orderCost = toCopy.orderCost;
        orderStatus = toCopy.orderStatus;
        orderId = toCopy.orderId;
        foodCartId = toCopy.foodCartId;
        }
    //Order class public function to return the order status of this order object
        public char getStatus()
        {
        //Return the order status
            return orderStatus;
        }
    //Order class public function to set the order status of this order object
        public char setStatus(char updatedStatus)
        {
        //Set the order status to the arguement passed in
            orderStatus = updatedStatus;
        //Return the updated order status
            return this.getStatus ();
        }
    //Order class public function to get the pickup time for this oder object
    public DateTime getOrderPickUpTime()
        {
        //Return the pickup time for this order object
            return orderPickUpTime;
        }
    //Order class public function to get the food cart id for this order object
    public int getfoodCartId()
    {
        //Return the food cart id for this order object
        return foodCartId;
    }
    //Order class public function to get the orderId associated with this order object
    public int getOrderId()
    {
        //Return teh order id for this order object
        return orderId;
    }
    //Order class public mention function to display the contents of the order objects
    public int displayOrder()
    {
        Console.WriteLine ();
        //Display order number
        Console.WriteLine ("Order ID : {i}" , orderId);
        //Display the id of the food cart making this order
        Console.WriteLine ("Order ID : {i}" ,foodCartId);
        //Display the 
        //Display all menu items this order contains
        LinkedListNode<Menuitems> head = new LinkedListNode<MenuItem> (items.First);

        Console.WriteLine ();

        while (head != null) 
        {
            Console.WriteLine (head.ToString);
            Console.WriteLine ();
            head = head.Next;
        }

    }
    //Ordeer class private data member to aid in generating unique order id's
    private static int orderCounter;    
    //Order class private datat member containing a linked list of menu items
    private LinkedList<MenuItem> items;
    //Order class private data member to track total cost of order
    private double orderCost;
    //Order class private data member to track the status of the order
    //Possible values include
    //s-submitted
    //c-cancelled
    //p-prepping
    //f-finished
    //r-recieved
        private char orderStatus;
        private int orderId;
    //Order class private data member for the food cart that is making this order object
        private int foodCartId;
    //Order class private data member to hold the pickup time for this order object
    private DateTime orderPickUpTime;

    }
//Class to manage a collection of orders
    class OrderManager
    {
    //OrderManager class default constructor
        public OrderManager()
        {
            orderQueue = null;
        }
    //OrderManager class constructor with argument for a list of orders
        public OrderManager(LinkedList<Order> newOrderQueue)
        {
            orderQueue = new LinkedList<Order> (newOrderQueue);
        }
    //OrderManager class copy constructor
        public OrderManager(OrderManager toCopy)
        {
        orderQueue = new LinkedList<Order> (toCopy.orderQueue);
        }
    //OrderManager class public function to add a order to the list of orders in this object
        public int submitOrder(OrderInfo newOrder)
        {
        return 1;
        }
    //OrderManager class public function to remove an order from the list of orders in this object
        //Maybe remove is just the private version of cancel...
    public int removeOrder(Order order)
        {
        return 1;
        }
    //OrderManager class public function to view an order using the order id for a key
    public int viewOrder(Order order)
        {
        return 1;
        }
    //OrderManager class public function to view a collection of orders by order id
    public int viewOrders(List<Order> requestedOrders)
    {
        return 1;
    }
    //OrderManager class public function to cancel a specified order
    public int cancelOrder(Order order)
        {
        return 1;
        }
    //OrderManager class public function to cancel a specified order
    public int startOrder(Order order)
        {
        return 1;
        }
    //OrderManager class public function to change status to finish for a specified order
    public int finishOrder(Order order)
        {
        return 1;
        }
    //OrderManager class public function to delay a specified order
        //Maybe we will whack this functionality....
    public int delayOrder(Order order)
        {
        return 1;
        }
    /*
    //OrderManager class private function to search for and return a order by orderId key
        private Order getOrder(int orderId)
        {
            //Search through the order queue until desired order found,
            //return it, else return null pointer
        }
    */
    //OrderManager class data member containing the list of orders being managed
        private LinkedList<Order> orderQueue;
    }


