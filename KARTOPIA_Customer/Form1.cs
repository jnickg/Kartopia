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
        BindingList<FoodCartInfo> foodcarts;
        BindingList<MenuItemInfo> currentOrder = new BindingList<MenuItemInfo>();
        private static Random rnd = new Random(1337);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<FoodCartInfo> carts = new List<FoodCartInfo>();
            for (int i = 0; i < 3; i++)
            {
                carts.Add(randomFoodCart());
            }
            FoodCartManager = new FoodCartService(carts);

            OrderManager = new OrderService();
            foreach(FoodCartInfo cart in carts)
            {
                for (int i = 0; i < 4; i++)
                {
                    //OrderManager.submitOrder(randomOrder(cart), cart.cartID);
                }
            }
            foodcarts = new BindingList<FoodCartInfo>(FoodCartManager.getFoodCarts());
            comboBox_karts.DataSource = foodcarts;
            comboBox_karts.DisplayMember = "name";
            comboBox_karts.ValueMember = "cartID";
            listBox_order.DataSource = currentOrder;
            listBox_order.DisplayMember = "name";
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
            FoodCartInfo rtn = new FoodCartInfo();
            Array values = Enum.GetValues(typeof(foodkart));
            foodkart randomkart = (foodkart)values.GetValue(rnd.Next(values.Length));
            rtn.name = randomkart.ToString();
            List<MenuItemInfo> foooood = rtn.menuItems;
            for (int i = 0; i < 4; i++)
            {
                foooood.Add(randomFood(rtn));
            }
            return new FoodCartInfo(randomkart.ToString(), foooood);
        }

        private static MenuItemInfo randomFood(FoodCartInfo kart)
        {
            Array values = Enum.GetValues(typeof(foodstuff));
            foodstuff randomfood = (foodstuff)values.GetValue(rnd.Next(values.Length));
            return new MenuItemInfo(randomfood.ToString(), randomPrice(), kart.name);
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

        private void button_placeOrder_Click(object sender, EventArgs e)
        {
            OrderDetails newOrder = new OrderDetails();
            var dic = newOrder.itemAndQuantity;
            foreach (MenuItemInfo mii in currentOrder)
            {
                if (dic.ContainsKey(mii))
                {
                    dic[mii]++;
                }
                else
                {
                    dic.Add(mii, 1);
                }
            }
            Guid orderID = OrderManager.submitOrder(newOrder, Guid.NewGuid());
            currentOrder.Clear();
            this.updateCost();
            Form2 newOrderForm = new Form2(orderID, OrderManager);
            newOrderForm.Show();
        }

        private void textBox_srch_TextChanged(object sender, EventArgs e)
        {
            List<MenuItemInfo> data = FoodCartManager.getMenuItemMatches(textBox_srch.Text);
            BindingList<MenuItemInfo> binder = new BindingList<MenuItemInfo>(data);
            listBox_srch_rslt.DataSource = binder;
            listBox_srch_rslt.DisplayMember = "LongDisplayString";
        }

        private void comboBox_karts_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingList<MenuItemInfo> binder
                = new BindingList<MenuItemInfo>(
                    ((FoodCartInfo)comboBox_karts.SelectedItem).menuItems);
            comboBox_food.DataSource = binder;
            comboBox_food.DisplayMember = "CostDisplayString";
            comboBox_food.ValueMember = "itemID";
        }

        private void updateCost()
        {
            OrderDetails costgetter = new OrderDetails();
            var dic = costgetter.itemAndQuantity;
            foreach (MenuItemInfo mii in currentOrder)
            {
                if (dic.ContainsKey(mii))
                {
                    dic[mii]++;
                }
                else
                {
                    dic.Add(mii, 1);
                }
            }
            label_cost.Text = String.Format("{0:C}", Decimal.Divide((decimal)costgetter.TotalCost, 100)); 

        }

        private void button_add_select_Click(object sender, EventArgs e)
        {
            currentOrder.Add((MenuItemInfo)comboBox_food.SelectedItem);
            this.updateCost();
        }

        private void button_rmv_Click(object sender, EventArgs e)
        {
            MenuItemInfo rmv = listBox_order.SelectedItem as MenuItemInfo;
            currentOrder.Remove(rmv);
            this.updateCost();
        }

        private void buttonadd_srch_Click(object sender, EventArgs e)
        {
            currentOrder.Add((MenuItemInfo)listBox_srch_rslt.SelectedItem);
            this.updateCost();
        }
    }
}
