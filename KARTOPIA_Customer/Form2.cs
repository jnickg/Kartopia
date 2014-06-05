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
        public Form2(Guid orderID, OrderService svc)
        {
            InitializeComponent();

            this.manager = svc;
            this.order = svc.getOrder(orderID);

            label_submit.Text = order.created.ToString();
            label_dropoff.Text = order.dropoff.ToString();

            foreach (MenuItemInfo mii in order.itemAndIsStarted.Keys)
            {
                listBox_items.Items.Add(mii.LongDisplayString + order
            }
        }
    }
}
