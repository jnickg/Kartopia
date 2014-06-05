namespace KARTOPIA_Customer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_kart = new System.Windows.Forms.ComboBox();
            this.comboBox_food = new System.Windows.Forms.ComboBox();
            this.button_add_select = new System.Windows.Forms.Button();
            this.listBox_srch_rslt = new System.Windows.Forms.ListBox();
            this.buttonadd_srch = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_srch = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_placeOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_rmv = new System.Windows.Forms.Button();
            this.listBox_order = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_kart
            // 
            this.comboBox_kart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_kart.FormattingEnabled = true;
            this.comboBox_kart.Location = new System.Drawing.Point(8, 58);
            this.comboBox_kart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_kart.Name = "comboBox_kart";
            this.comboBox_kart.Size = new System.Drawing.Size(179, 24);
            this.comboBox_kart.TabIndex = 0;
            // 
            // comboBox_food
            // 
            this.comboBox_food.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_food.FormattingEnabled = true;
            this.comboBox_food.Location = new System.Drawing.Point(8, 124);
            this.comboBox_food.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_food.Name = "comboBox_food";
            this.comboBox_food.Size = new System.Drawing.Size(179, 24);
            this.comboBox_food.TabIndex = 1;
            // 
            // button_add_select
            // 
            this.button_add_select.Location = new System.Drawing.Point(8, 158);
            this.button_add_select.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_add_select.Name = "button_add_select";
            this.button_add_select.Size = new System.Drawing.Size(180, 28);
            this.button_add_select.TabIndex = 2;
            this.button_add_select.Text = "Add";
            this.button_add_select.UseVisualStyleBackColor = true;
            // 
            // listBox_srch_rslt
            // 
            this.listBox_srch_rslt.FormattingEnabled = true;
            this.listBox_srch_rslt.ItemHeight = 16;
            this.listBox_srch_rslt.Location = new System.Drawing.Point(8, 81);
            this.listBox_srch_rslt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox_srch_rslt.Name = "listBox_srch_rslt";
            this.listBox_srch_rslt.Size = new System.Drawing.Size(179, 68);
            this.listBox_srch_rslt.TabIndex = 3;
            // 
            // buttonadd_srch
            // 
            this.buttonadd_srch.Location = new System.Drawing.Point(8, 158);
            this.buttonadd_srch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonadd_srch.Name = "buttonadd_srch";
            this.buttonadd_srch.Size = new System.Drawing.Size(180, 28);
            this.buttonadd_srch.TabIndex = 2;
            this.buttonadd_srch.Text = "Add";
            this.buttonadd_srch.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(405, 148);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2MinSize = 150;
            this.splitContainer1.Size = new System.Drawing.Size(420, 256);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_kart);
            this.groupBox1.Controls.Add(this.button_add_select);
            this.groupBox1.Controls.Add(this.comboBox_food);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(200, 256);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Item";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Food";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Karts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_srch);
            this.groupBox2.Controls.Add(this.listBox_srch_rslt);
            this.groupBox2.Controls.Add(this.buttonadd_srch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(215, 256);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search Results";
            // 
            // textBox_srch
            // 
            this.textBox_srch.Location = new System.Drawing.Point(9, 33);
            this.textBox_srch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_srch.Name = "textBox_srch";
            this.textBox_srch.Size = new System.Drawing.Size(177, 22);
            this.textBox_srch.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.MinimumSize = new System.Drawing.Size(420, 554);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2MinSize = 250;
            this.splitContainer2.Size = new System.Drawing.Size(420, 569);
            this.splitContainer2.SplitterDistance = 256;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_placeOrder);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button_rmv);
            this.groupBox3.Controls.Add(this.listBox_order);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(420, 308);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Order";
            // 
            // button_placeOrder
            // 
            this.button_placeOrder.Location = new System.Drawing.Point(8, 265);
            this.button_placeOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_placeOrder.Name = "button_placeOrder";
            this.button_placeOrder.Size = new System.Drawing.Size(180, 28);
            this.button_placeOrder.TabIndex = 3;
            this.button_placeOrder.Text = "Place Order";
            this.button_placeOrder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 245);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Cost: ";
            // 
            // button_rmv
            // 
            this.button_rmv.Location = new System.Drawing.Point(9, 165);
            this.button_rmv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_rmv.Name = "button_rmv";
            this.button_rmv.Size = new System.Drawing.Size(179, 28);
            this.button_rmv.TabIndex = 1;
            this.button_rmv.Text = "Remove Selected";
            this.button_rmv.UseVisualStyleBackColor = true;
            // 
            // listBox_order
            // 
            this.listBox_order.FormattingEnabled = true;
            this.listBox_order.ItemHeight = 16;
            this.listBox_order.Location = new System.Drawing.Point(8, 23);
            this.listBox_order.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox_order.Name = "listBox_order";
            this.listBox_order.Size = new System.Drawing.Size(179, 132);
            this.listBox_order.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 569);
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(414, 605);
            this.Name = "Form1";
            this.Text = "KARTOPIA Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_kart;
        private System.Windows.Forms.ComboBox comboBox_food;
        private System.Windows.Forms.Button button_add_select;
        private System.Windows.Forms.ListBox listBox_srch_rslt;
        private System.Windows.Forms.Button buttonadd_srch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_srch;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_placeOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_rmv;
        private System.Windows.Forms.ListBox listBox_order;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

