namespace Knapsack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            no_txt = new RichTextBox();
            label2 = new Label();
            seed_txt = new RichTextBox();
            label1 = new Label();
            label3 = new Label();
            capacity_txt = new RichTextBox();
            calculate_btn = new Button();
            instance_txt = new RichTextBox();
            result_txt = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // no_txt
            // 
            no_txt.BackColor = Color.FromArgb(80, 114, 123);
            no_txt.BorderStyle = BorderStyle.None;
            no_txt.ForeColor = Color.FromArgb(53, 55, 75);
            no_txt.Location = new Point(56, 29);
            no_txt.Name = "no_txt";
            no_txt.Size = new Size(123, 28);
            no_txt.TabIndex = 0;
            no_txt.Text = "";
            no_txt.TextChanged += no_txt_TextChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(120, 160, 131);
            label2.Location = new Point(56, 11);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 2;
            label2.Text = "Number of items";
            // 
            // seed_txt
            // 
            seed_txt.BackColor = Color.FromArgb(80, 114, 123);
            seed_txt.BorderStyle = BorderStyle.None;
            seed_txt.ForeColor = Color.FromArgb(53, 55, 75);
            seed_txt.Location = new Point(56, 110);
            seed_txt.Name = "seed_txt";
            seed_txt.Size = new Size(123, 28);
            seed_txt.TabIndex = 3;
            seed_txt.Text = "";
            seed_txt.TextChanged += seed_txt_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(120, 160, 131);
            label1.Location = new Point(56, 92);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 4;
            label1.Text = "Seed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(120, 160, 131);
            label3.Location = new Point(56, 174);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 6;
            label3.Text = "Capacity";
            // 
            // capacity_txt
            // 
            capacity_txt.BackColor = Color.FromArgb(80, 114, 123);
            capacity_txt.BorderStyle = BorderStyle.None;
            capacity_txt.ForeColor = Color.FromArgb(53, 55, 75);
            capacity_txt.Location = new Point(56, 192);
            capacity_txt.Name = "capacity_txt";
            capacity_txt.Size = new Size(123, 28);
            capacity_txt.TabIndex = 5;
            capacity_txt.Text = "";
            capacity_txt.TextChanged += capacity_txt_TextChanged;
            // 
            // calculate_btn
            // 
            calculate_btn.BackColor = Color.FromArgb(120, 160, 131);
            calculate_btn.ForeColor = Color.FromArgb(53, 55, 75);
            calculate_btn.Location = new Point(23, 267);
            calculate_btn.Name = "calculate_btn";
            calculate_btn.Size = new Size(198, 171);
            calculate_btn.TabIndex = 7;
            calculate_btn.Text = "Calculate";
            calculate_btn.UseVisualStyleBackColor = false;
            calculate_btn.Click += calculate_btn_Click;
            // 
            // instance_txt
            // 
            instance_txt.BackColor = Color.FromArgb(80, 114, 123);
            instance_txt.BorderStyle = BorderStyle.None;
            instance_txt.ForeColor = Color.FromArgb(53, 55, 75);
            instance_txt.Location = new Point(528, 49);
            instance_txt.Name = "instance_txt";
            instance_txt.Size = new Size(250, 190);
            instance_txt.TabIndex = 8;
            instance_txt.Text = "";
            // 
            // result_txt
            // 
            result_txt.BackColor = Color.FromArgb(80, 114, 123);
            result_txt.BorderStyle = BorderStyle.None;
            result_txt.ForeColor = Color.FromArgb(53, 55, 75);
            result_txt.Location = new Point(528, 311);
            result_txt.Name = "result_txt";
            result_txt.Size = new Size(250, 104);
            result_txt.TabIndex = 9;
            result_txt.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(120, 160, 131);
            label4.Location = new Point(528, 29);
            label4.Name = "label4";
            label4.Size = new Size(113, 15);
            label4.TabIndex = 10;
            label4.Text = "Instance of problem";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(120, 160, 131);
            label5.Location = new Point(528, 293);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 11;
            label5.Text = "Results";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(253, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 250);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 55, 75);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(result_txt);
            Controls.Add(instance_txt);
            Controls.Add(calculate_btn);
            Controls.Add(label3);
            Controls.Add(capacity_txt);
            Controls.Add(label1);
            Controls.Add(seed_txt);
            Controls.Add(label2);
            Controls.Add(no_txt);
            Name = "Form1";
            Text = "Knapsack solver";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox no_txt;
        private Label label2;
        private RichTextBox seed_txt;
        private Label label1;
        private Label label3;
        private RichTextBox capacity_txt;
        private Button calculate_btn;
        private RichTextBox instance_txt;
        private RichTextBox result_txt;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
    }
}
