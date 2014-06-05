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
    public partial class Form2 : Form
    {
        private Order order;
        private OrderService manager;
        private Random r = new Random();
        public Form2(Guid orderID, OrderService svc)
        {
            InitializeComponent();

            this.manager = svc;
            this.order = svc.getOrder(orderID);

            label_submit.Text = order.created.ToString();
            label_dropoff.Text = order.dropoff.ToString();

            rewriteList();

            this.Text = String.Format("Order {0}", order.orderID);
            timer_cookstart.Start();
        }

        private void rewriteList()
        {
            this.listBox_items.Items.Clear();
            foreach (MenuItemInfo mii in order.itemAndIsStarted.Keys)
            {
                StringBuilder item = new StringBuilder();
                item.Append(String.Format("{0}", mii.LongDisplayString));
                if (order.itemAndIsStarted[mii] == Order.PrepStatus.OK_CANCEL)
                {
                    item.Append(" - Unstarted");
                }
                else
                {
                    item.Append(" - Being cooked");
                    button_cancel.Enabled = false;
                }
                listBox_items.Items.Add(item);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (manager.requestCancel(order.orderID))
            {
                MessageBox.Show("Order successfully canceled.", "Canceled");
                this.Close();
            }
            else
            {
                MessageBox.Show("Order could not be canceled canceled.\nOne or more of your items has already been prepared!", "Cancel Failed");
            }
        }

        private void timer_cookstart_Tick(object sender, EventArgs e)
        {
            if (r.Next(0, 1000) < 37)
            {
                int thisIndex = r.Next(order.itemAndIsStarted.Keys.Count);
                var thisItem = order.itemAndIsStarted.Keys.ToList()[thisIndex];
                order.itemAndIsStarted[thisItem] = Order.PrepStatus.NO_CANCEL;
                rewriteList();
            }
        }
    }
}
