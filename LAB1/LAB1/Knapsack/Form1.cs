using static System.Runtime.InteropServices.JavaScript.JSType;
using LAB1;
namespace Knapsack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.knapsack;
        }

        private void calculate_btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(seed_txt.Text, out int seed) &&
                int.TryParse(no_txt.Text, out int number) &&
                int.TryParse(capacity_txt.Text, out int capacity))
            {
                Problem problem = new Problem(number, seed);
                instance_txt.Text = problem.ToString();
                Result result = problem.solve(capacity);
                result_txt.Text = result.ToString();

                no_txt.BackColor = ColorTranslator.FromHtml("#50727B");
                seed_txt.BackColor = ColorTranslator.FromHtml("#50727B");
                capacity_txt.BackColor = ColorTranslator.FromHtml("#50727B");
            }
            else
            {
                result_txt.Clear();
                instance_txt.Clear();
                instance_txt.Text = "Insert integers!!";
            }
        }

        private void ChangeTextBoxColor(RichTextBox textBox)
        {
            if (int.TryParse(textBox.Text, out _))
            {
                textBox.BackColor = ColorTranslator.FromHtml("#B0C5A4");
            }
            else
            {
                textBox.BackColor = ColorTranslator.FromHtml("#D37676");
            }
        }

        private void no_txt_TextChanged_1(object sender, EventArgs e)
        {
            ChangeTextBoxColor(no_txt);
        }

        private void seed_txt_TextChanged_1(object sender, EventArgs e)
        {
            ChangeTextBoxColor(seed_txt);
        }

        private void capacity_txt_TextChanged(object sender, EventArgs e)
        {
            ChangeTextBoxColor(capacity_txt);
        }

    }
}
