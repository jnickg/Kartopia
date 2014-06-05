using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using K_Services;

namespace KARTOPIA_Customer
{
    public partial class Form1 : Form
    {
        private OrderService OrderManager;
        private FoodCartService FoodCartManager;
        List<FoodCartInfo> foodcarts;
        private static Random rnd = new Random(1337);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<FoodCartInfo> carts = new List<FoodCartInfo>();
            for (int i = 0; i < 10; i++)
            {
                carts.Add(randomFoodCart());
            }
            FoodCartManager = new FoodCartService(carts);

            OrderManager = new OrderService();
            foreach(FoodCartInfo cart in carts)
            {
                for (int i = 0; i < 4; i++)
                {
                    OrderManager.submitOrder(randomOrder(cart), cart.cartID);
                }
            }
            foodcarts = FoodCartManager.getFoodCarts();
            comboBox_kart.DataSource = foodcarts;
            comboBox_kart.DisplayMember = "name";
            comboBox_kart.ValueMember = "cartID";
            
        }

        private static OrderDetails randomOrder(FoodCartInfo kart)
        {
            Dictionary<MenuItemInfo, int> orderItems = new Dictionary<MenuItemInfo, int>();
            for (int i = 0; i < 10; i++)
            {
                int foodIndex = rnd.Next(kart.menuItems.Count);
                int quantity = randomQty();
                if (orderItems.ContainsKey(kart.menuItems[foodIndex]))
                {
                    orderItems[kart.menuItems[foodIndex]]++;
                }
                else
                {
                    orderItems.Add(kart.menuItems[foodIndex], quantity);
                }
            }
            return new OrderDetails(orderItems);
        }

        private static FoodCartInfo randomFoodCart()
        {
            Array values = Enum.GetValues(typeof(foodkart));
            foodkart randomkart = (foodkart)values.GetValue(rnd.Next(values.Length));
            List<MenuItemInfo> foooood = new List<MenuItemInfo>();
            for (int i = 0; i < 10; i++)
            {
                foooood.Add(randomFood());
            }
            return new FoodCartInfo(randomkart.ToString(), foooood);
        }

        private static MenuItemInfo randomFood()
        {
            Array values = Enum.GetValues(typeof(foodstuff));
            foodstuff randomfood = (foodstuff)values.GetValue(rnd.Next(values.Length));
            return new MenuItemInfo(randomfood.ToString(), randomPrice());
        }

        private static int randomPrice()
        {
            return rnd.Next(1, 40) * 25;
        }

        private static int randomQty()
        {
            return rnd.Next(1,5);
        }

        private enum foodstuff
        {
            Hamburger,
            HotDog,
            Milkshake,
            Fries,
            Salad,
            Gyro,
            Fruit,
            FriedRice,
            BanhMi,
            JackFruit,
            GrilledCheese
        }

        private enum foodkart
        {
            MacsMarket,
            FreeBurger,
            GoodBurger,
            ShivShakes,
            EuroTrip,
            VietYum,
            NguyenNguyenSituation,
            JackFruitAnonymous,
            PBJsGrilled,
            ABCheese,
            GrossMcGnarlyBuns,
            BurgersGalore,
            BoogerBurgers,
            WhatEvenIsThisFood,
            PortlandSoupCompany
        }
    }
}
