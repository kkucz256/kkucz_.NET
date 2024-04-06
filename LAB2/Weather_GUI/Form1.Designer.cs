using System.Windows.Forms;

namespace Weather_GUI
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            city_textbox = new RichTextBox();
            label2 = new Label();
            delete_btn = new Button();
            wipe_btn = new Button();
            weather_btn = new Button();
            current_weather = new RichTextBox();
            no_radio = new RadioButton();
            yes_radio = new RadioButton();
            label3 = new Label();
            history_txt = new RichTextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label4 = new Label();
            sorting = new ComboBox();
            asc_radio = new RadioButton();
            desc_radio = new RadioButton();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(249, 239, 219);
            label1.Location = new Point(102, 81);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter the city:";
            // 
            // city_textbox
            // 
            city_textbox.BackColor = Color.FromArgb(157, 188, 152);
            city_textbox.BorderStyle = BorderStyle.None;
            city_textbox.ForeColor = Color.FromArgb(44, 120, 101);
            city_textbox.Location = new Point(42, 99);
            city_textbox.Name = "city_textbox";
            city_textbox.Size = new Size(207, 26);
            city_textbox.TabIndex = 1;
            city_textbox.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22F);
            label2.ForeColor = Color.FromArgb(249, 239, 219);
            label2.Location = new Point(282, 55);
            label2.Name = "label2";
            label2.Size = new Size(119, 41);
            label2.TabIndex = 3;
            label2.Text = "History:";
            label2.Click += label2_Click;
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.FromArgb(157, 188, 152);
            delete_btn.FlatStyle = FlatStyle.Popup;
            delete_btn.ForeColor = Color.FromArgb(44, 120, 101);
            delete_btn.Location = new Point(544, 350);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(244, 51);
            delete_btn.TabIndex = 4;
            delete_btn.Text = "Delete last item";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // wipe_btn
            // 
            wipe_btn.BackColor = Color.FromArgb(157, 188, 152);
            wipe_btn.FlatStyle = FlatStyle.Popup;
            wipe_btn.ForeColor = Color.FromArgb(44, 120, 101);
            wipe_btn.Location = new Point(282, 350);
            wipe_btn.Name = "wipe_btn";
            wipe_btn.Size = new Size(242, 51);
            wipe_btn.TabIndex = 5;
            wipe_btn.Text = "Wipe history";
            wipe_btn.UseVisualStyleBackColor = false;
            wipe_btn.Click += wipe_btn_Click;
            // 
            // weather_btn
            // 
            weather_btn.BackColor = Color.FromArgb(157, 188, 152);
            weather_btn.FlatStyle = FlatStyle.Popup;
            weather_btn.ForeColor = Color.FromArgb(44, 120, 101);
            weather_btn.Location = new Point(41, 214);
            weather_btn.Name = "weather_btn";
            weather_btn.Size = new Size(207, 33);
            weather_btn.TabIndex = 6;
            weather_btn.Text = "Get weather";
            weather_btn.UseVisualStyleBackColor = false;
            weather_btn.Click += weather_btn_Click;
            // 
            // current_weather
            // 
            current_weather.BackColor = Color.FromArgb(157, 188, 152);
            current_weather.BorderStyle = BorderStyle.None;
            current_weather.ForeColor = Color.FromArgb(44, 120, 101);
            current_weather.Location = new Point(41, 305);
            current_weather.Name = "current_weather";
            current_weather.Size = new Size(208, 96);
            current_weather.TabIndex = 7;
            current_weather.Text = "";
            // 
            // no_radio
            // 
            no_radio.AutoSize = true;
            no_radio.ForeColor = Color.FromArgb(249, 239, 219);
            no_radio.Location = new Point(148, 171);
            no_radio.Name = "no_radio";
            no_radio.Size = new Size(41, 19);
            no_radio.TabIndex = 13;
            no_radio.TabStop = true;
            no_radio.Text = "No";
            no_radio.UseVisualStyleBackColor = true;
            // 
            // yes_radio
            // 
            yes_radio.AutoSize = true;
            yes_radio.ForeColor = Color.FromArgb(249, 239, 219);
            yes_radio.Location = new Point(100, 171);
            yes_radio.Name = "yes_radio";
            yes_radio.Size = new Size(42, 19);
            yes_radio.TabIndex = 12;
            yes_radio.TabStop = true;
            yes_radio.Text = "Yes";
            yes_radio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(249, 239, 219);
            label3.Location = new Point(102, 153);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 11;
            label3.Text = "Add to history?";
            // 
            // history_txt
            // 
            history_txt.BackColor = Color.FromArgb(157, 188, 152);
            history_txt.BorderStyle = BorderStyle.None;
            history_txt.ForeColor = Color.FromArgb(44, 120, 101);
            history_txt.Location = new Point(282, 99);
            history_txt.Name = "history_txt";
            history_txt.Size = new Size(506, 245);
            history_txt.TabIndex = 14;
            history_txt.Text = "";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(249, 239, 219);
            label4.Location = new Point(102, 287);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 15;
            label4.Text = "Current city:";
            // 
            // sorting
            // 
            sorting.BackColor = Color.FromArgb(157, 188, 152);
            sorting.FlatStyle = FlatStyle.Flat;
            sorting.ForeColor = Color.FromArgb(44, 120, 101);
            sorting.FormattingEnabled = true;
            sorting.Items.AddRange(new object[] { "Id", "Pressure", "Temp" });
            sorting.Location = new Point(667, 48);
            sorting.Name = "sorting";
            sorting.Size = new Size(121, 23);
            sorting.TabIndex = 16;
            sorting.SelectedIndexChanged += sorting_SelectedIndexChanged;
            // 
            // asc_radio
            // 
            asc_radio.AutoSize = true;
            asc_radio.ForeColor = Color.FromArgb(249, 239, 219);
            asc_radio.Location = new Point(667, 77);
            asc_radio.Name = "asc_radio";
            asc_radio.Size = new Size(44, 19);
            asc_radio.TabIndex = 17;
            asc_radio.TabStop = true;
            asc_radio.Text = "Asc";
            asc_radio.UseVisualStyleBackColor = true;
            asc_radio.CheckedChanged += asc_radio_CheckedChanged;
            // 
            // desc_radio
            // 
            desc_radio.AutoSize = true;
            desc_radio.ForeColor = Color.FromArgb(249, 239, 219);
            desc_radio.Location = new Point(738, 77);
            desc_radio.Name = "desc_radio";
            desc_radio.Size = new Size(50, 19);
            desc_radio.TabIndex = 18;
            desc_radio.TabStop = true;
            desc_radio.Text = "Desc";
            desc_radio.UseVisualStyleBackColor = true;
            desc_radio.CheckedChanged += desc_radio_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 22F);
            label5.ForeColor = Color.FromArgb(249, 239, 219);
            label5.Location = new Point(582, 55);
            label5.Name = "label5";
            label5.Size = new Size(79, 41);
            label5.TabIndex = 19;
            label5.Text = "Sort:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(99, 136, 137);
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(desc_radio);
            Controls.Add(asc_radio);
            Controls.Add(sorting);
            Controls.Add(label4);
            Controls.Add(history_txt);
            Controls.Add(no_radio);
            Controls.Add(yes_radio);
            Controls.Add(label3);
            Controls.Add(current_weather);
            Controls.Add(weather_btn);
            Controls.Add(wipe_btn);
            Controls.Add(delete_btn);
            Controls.Add(label2);
            Controls.Add(city_textbox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox city_textbox;
        private Label label2;
        private Button delete_btn;
        private Button wipe_btn;
        private Button weather_btn;
        private RichTextBox current_weather;
        private RadioButton no_radio;
        private RadioButton yes_radio;
        private Label label3;
        private RichTextBox history_txt;
        private ContextMenuStrip contextMenuStrip1;
        private Label label4;
        private ComboBox sorting;
        private RadioButton asc_radio;
        private RadioButton desc_radio;
        private Label label5;
    }
}
