namespace KARTOPIA_Customer
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label_submit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_dropoff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox_items = new System.Windows.Forms.ListBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.timer_cookstart = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Submitted";
            // 
            // label_submit
            // 
            this.label_submit.AutoSize = true;
            this.label_submit.Location = new System.Drawing.Point(73, 13);
            this.label_submit.Name = "label_submit";
            this.label_submit.Size = new System.Drawing.Size(35, 13);
            this.label_submit.TabIndex = 1;
            this.label_submit.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Delivery:";
            // 
            // label_dropoff
            // 
            this.label_dropoff.AutoSize = true;
            this.label_dropoff.Location = new System.Drawing.Point(71, 30);
            this.label_dropoff.Name = "label_dropoff";
            this.label_dropoff.Size = new System.Drawing.Size(35, 13);
            this.label_dropoff.TabIndex = 3;
            this.label_dropoff.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ordered Items:";
            // 
            // listBox_items
            // 
            this.listBox_items.Enabled = false;
            this.listBox_items.FormattingEnabled = true;
            this.listBox_items.Location = new System.Drawing.Point(12, 90);
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.Size = new System.Drawing.Size(242, 160);
            this.listBox_items.TabIndex = 5;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(19, 285);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "CANCEL";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // timer_cookstart
            // 
            this.timer_cookstart.Tick += new System.EventHandler(this.timer_cookstart_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 331);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.listBox_items);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_dropoff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_submit);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_submit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_dropoff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_items;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Timer timer_cookstart;

    }
}