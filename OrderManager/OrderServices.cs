/*
 * Levi Sky Murray Schoen
 * CS 300
 * Kartopia Order Services package, for creating, removing, viewing, and managing orders
 */
using System;
using System.IO;
using System.Collections.Generic;

//Class for testing and debugging order services classes.
public class TestClass
	{
	//Main method of the TestClass class
		public static void Main (string[] args)
	{
		//Output to the console text
		Console.WriteLine ("Order at Kartopia!");
	}
	}
//Class for managing a menu item object
public	class MenuItem
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
		name = toCopy.name;
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
	//MenuItem public function to display the contents of the object
	public int displayMenuItem()
	{
		//Display the name and cost of the menu item
		Console.WriteLine("Item : {0}", name);
		Console.WriteLine("Cost : {0}", cost);
		//Return success flag
		return 1;
	}
	//MenuItem class public function for setting the data members of a MenuItem
	//directly from the user
	public int readMenuItemInfo()
	{
		//Prompt the user for MenuItem info, read it, and set the data members accordingly
		Console.WriteLine ("\nEnter the name of Menu Item : ");
		name = Console.ReadLine ();

		Console.WriteLine ("\nEnter the cost of the menu item in $$.cents format : ");
		cost = Convert.ToDouble(Console.ReadLine ());
		//Return success flag
		return 1;
	}
	//MenuItem class public function for setting the data members of a MenuItem object
	//via paramaters
	public int readMenuItemInfo(double itemCost, String itemName)
	{
		//Set data members to the values passed in
		cost = itemCost;
		name = itemName;
		//Return success flag
		return 1;
	}
	//MenuItem private data member to store the cost of the menu item
		private double cost;
	//MenuItem private data member to store the name of the menu item
		private String name;

	}
//Class to manage an Order object, storing and manupilating order details
public	class Order
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
		//Node to help us in traversing the list of menu items
		LinkedListNode<MenuItem> head = newItems.First;
		//Loop to add the cost of each menu item to the cost of the order
		while (head != null) {
			orderCost += head.Value.getCost ();
			head = head.Next;
		}
		}
	//Order class copy constructor
		public Order(Order toCopy)
		{
		//Set data members to the value of the Order object passed in
		    items = new LinkedList<MenuItem> (toCopy.items);
		orderPickUpTime = toCopy.orderPickUpTime;
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
	//There is no precondition that the status to be updated will be meaningfull
	public char setStatus(char updatedStatus)
		{
		//Check to see if the udpated status is a delay status
		if (updatedStatus == 'd') 
		{
			//If it is delay the order pickup time by 5 minutes
			orderPickUpTime.AddMinutes (5);
			//Exit and leave the order's status intact
			return this.getStatus ();
		}
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
		Console.WriteLine ("Order ID : {0}" , orderId);
		//Display the id of the food cart making this order
		Console.WriteLine ("Order ID : {0}" ,foodCartId);
		//Display the 
		//Display all menu items this order contains
		LinkedListNode<MenuItem> head = items.First;

		Console.WriteLine ();
		Console.WriteLine ("Menu Items : ");
		//Loop to display all menu items contained in this order object
		while (head != null) 
		{
			head.Value.displayMenuItem ();
			Console.WriteLine ();
			head = head.Next;
		}
		//Display the order pickup time
		Console.WriteLine ("Order Pick Up Time : {0}", orderPickUpTime);

		//Return success flag
		return 1;

	}
	//Order class public function to create an order by taking
	//input from a user
	public int readOrderInfo()
	{
		//Integer to count loop iterations
		int count = 0;
		//character for storing users response
		char response='Q';
		//MenuItem object for storing a menu item
		MenuItem tempItem = new MenuItem ();
		//Do while loop to allow the user to add all the menu items they want
		do {
			//Prompt user for their choice
			Console.WriteLine("\nEnter 'A' to add an item to this order");
			Console.WriteLine("\nEnter 'I' to add the food cart Id for this order");
			Console.WriteLine("\nEnter 'Q' to exit and submit finished order");
			//Read user choice
			response=Char.ToUpper(Convert.ToChar(Console.ReadLine()));

			//If user wanted to add menu item
			if(response=='A')
			{
				//If this is the first item to be added
				if(count==0)
				{
					//Intialize the order's list of menu items
					items=new LinkedList<MenuItem>(); 
				}
				//Read and store the new menu item for this order by calling 
				//the appropriate version of readMenuItemInfo function
				tempItem.readMenuItemInfo();
				//Add this menu to the end of the list of menu items for this order
				items.AddLast(new LinkedListNode<MenuItem>(tempItem));
				//Add the cost of this menu item to order cost
				orderCost+=tempItem.getCost();
				}
			else if(response=='I')
			{
				//Prompt the user for the food cart id
				Console.WriteLine("\nEnter the ID number of the food cart for this order : ");
				//Read and store user's response
				foodCartId=Convert.ToInt32(Console.ReadLine());
			}
			//Else user wants to quit
			else{
				//Display exit message
				Console.WriteLine("\nSubmitting Order");
			}
			//update the loop counter
			++count;
		} while(response == 'A');

		//Set order data members to appropriate values
		if (items != null) {
			orderStatus = 's';
			orderPickUpTime = (DateTime.Now).AddMinutes (40);
		} else {
			orderStatus = 'c';
			orderPickUpTime = DateTime.Now;
			//Return fail flag as no items have been added to this order
			return 0;
		}
		//Return success flag
		return 1;
	}
	//Order class public function to create an order through
	//parameters passed into the function
	public int readOrderInfo(LinkedList<MenuItem> newItems, int foodCartMaker)
	{
		//Intialize the items to the same items as passed in
		items = new LinkedList<MenuItem> (newItems);
		foodCartId = foodCartMaker;
		//Intialize data members to appropriate values
		orderCost = 0;
		orderStatus = 's';
		orderPickUpTime = (DateTime.Now).AddMinutes (40);
		//Node to help us in traversing the list of menu items
		LinkedListNode<MenuItem> head = newItems.First;
		//Loop to add the cost of each menu item to the cost of the order
		while (head != null) {
			orderCost += head.Value.getCost ();
			head = head.Next;
		}
		//Return success flag
		return 1;
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
public	class OrderManager
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
		public int submitOrder(Order newOrder)
		{
		//Add the new order to our queue of current orders
		orderQueue.AddLast (newOrder);
		//Return success flag
		return 1;
		}
	//OrderManager class public function to remove an order from the list of orders in this object
	//For example after an order has been picked up	
	public int removeOrder(Order order)
		{
		//Linked list node to help us in searching through the order queue
		LinkedListNode<Order> head = orderQueue.Find (order);  
		//If we found the order to be removed in the queue
		if (head != null) 
		{
			//Remove the order
			orderQueue.Remove (order);
			//Return successful flag
			return 1;
		} 
		//Else we did not find the order
		else 
		{
			//So return fail flag
			return 0;
		}
		}
	//OrderManager class public function to view an order using the order id for a key
	public int viewOrder(Order order)
		{
		//Call the order objects display function
		order.displayOrder ();
		//Return success flag
		return 1;
		}
	//OrderManager class public function to view a collection of orders by order id
	public int viewOrders(LinkedList<Order> requestedOrders)
	{
		//Node to help us in navigating the list of orders
		LinkedListNode<Order> head = requestedOrders.First;
		//Travese the linked list and display each order
		while (head != null) {
			//Display the order in the current node
			head.Value.displayOrder();
			//Advance our node to the next object in the linked list
			head = head.Next;
		}
		//Return success flag
		return 1;
	}
	//OrderManager class public function to cancel a specified order
	public int cancelOrder(Order order)
		{
		if(order.getStatus()=='s')
			{
			//Linked list node to help us in searching through the order queue
			LinkedListNode<Order> head = orderQueue.Find (order);  
			//If we found the order to be cancelled in the queue
			if (head != null) 
			{
				//Cancel the order
				head.Value.setStatus ('d');
				//Remove the order from the order queue
				orderQueue.Remove (order);
				//Return successful flag
				return 1;
			} 
			//Else we did not find the order
			else 
			{
				//So return fail flag
				return 0;
			}
			}
			else
			{
			Console.WriteLine ("Order not able to be cancelled");
			//Return fail flag
			return 0;
			}
		
		}
	//OrderManager class public function to cancel a specified order
	public int startOrder(Order order)
		{
		//Linked list node to help us in searching through the order queue
		LinkedListNode<Order> head = orderQueue.Find (order);  
		//If we found the order to be started in the queue
		if (head != null) 
		{
			//Mark the order as started
					head.Value.setStatus ('p');
			//Return successful flag
			return 1;
		} 
		//Else we did not find the order
		else 
		{
			//So return fail flag
			return 0;
		}
		}
	//OrderManager class public function to change status to finish for a specified order
	public int finishOrder(Order order)
		{
		//Linked list node to help us in searching through the order queue
		LinkedListNode<Order> head = orderQueue.Find (order);  
		//If we found the order to be finished in the queue
		if (head != null) 
		{
			//Mark the order as finished
			head.Value.setStatus ('f');
			//Return successful flag
			return 1;
		} 
		//Else we did not find the order
		else 
		{
			//So return fail flag
			return 0;
		}
		}
	//OrderManager class public function to delay a specified order
		//Maybe we will whack this functionality....
	public int delayOrder(Order order)
		{
		//Linked list node to help us in searching through the order queue
		LinkedListNode<Order> head = orderQueue.Find (order);  
		//If we found the order to be delayed in the queue
		if (head != null) 
		{
			//Delay the order
			head.Value.setStatus ('d');
			//Return successful flag
			return 1;
		} 
		//Else we did not find the order
		else 
		{
			//So return fail flag
			return 0;
		}
		}
	//OrderManager class data member containing the list of orders being managed
		private LinkedList<Order> orderQueue;
	}

