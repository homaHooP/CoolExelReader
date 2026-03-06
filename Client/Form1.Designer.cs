namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            txt_port = new TextBox();
            txt_ip = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            number = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            button3 = new Button();
            label3 = new Label();
            richTextBox1 = new RichTextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 30);
            label1.Name = "label1";
            label1.Size = new Size(32, 28);
            label1.TabIndex = 0;
            label1.Text = "Ip";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(txt_port);
            groupBox1.Controls.Add(txt_ip);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(948, 120);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Settings";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(469, 25);
            button2.Name = "button2";
            button2.Size = new Size(131, 80);
            button2.TabIndex = 5;
            button2.Text = "Disconnect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(361, 25);
            button1.Name = "button1";
            button1.Size = new Size(102, 80);
            button1.TabIndex = 4;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txt_port
            // 
            txt_port.Location = new Point(67, 71);
            txt_port.Name = "txt_port";
            txt_port.Size = new Size(272, 34);
            txt_port.TabIndex = 3;
            // 
            // txt_ip
            // 
            txt_ip.Location = new Point(68, 33);
            txt_ip.Name = "txt_ip";
            txt_ip.Size = new Size(272, 34);
            txt_ip.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 71);
            label2.Name = "label2";
            label2.Size = new Size(55, 28);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { name, price, number });
            dataGridView1.Location = new Point(7, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(507, 210);
            dataGridView1.TabIndex = 2;
            // 
            // name
            // 
            name.HeaderText = "Product name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 125;
            // 
            // price
            // 
            price.HeaderText = "Price";
            price.MinimumWidth = 6;
            price.Name = "price";
            price.ReadOnly = true;
            price.Width = 125;
            // 
            // number
            // 
            number.HeaderText = "Number";
            number.MinimumWidth = 6;
            number.Name = "number";
            number.ReadOnly = true;
            number.Width = 125;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(12, 138);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(948, 249);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Program";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(835, 137);
            button3.Name = "button3";
            button3.Size = new Size(94, 73);
            button3.TabIndex = 7;
            button3.Text = "Search";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(520, 30);
            label3.Name = "label3";
            label3.Size = new Size(299, 84);
            label3.TabIndex = 6;
            label3.Text = "Enter a name of the product \r\n(to write multiple write them\r\nseparated by a space)";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(520, 117);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(299, 120);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 399);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CoolExelReader";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button button2;
        private Button button1;
        private TextBox txt_port;
        private TextBox txt_ip;
        private Label label2;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Label label3;
        private RichTextBox richTextBox1;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn number;
        private Button button3;
    }
}
