using LAB2;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics.Metrics;
using System.DirectoryServices;
using System.Text.Json;
using System.Windows.Forms;

namespace Weather_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            display_db();
        }

        private async void weather_btn_Click(object sender, EventArgs e)
        {
            string city = city_textbox.Text;
            string response = "";
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            string API_key = "23cdcedd6e46956ea046361eac860a65";

            try
            {
                Database_data existingData = null;

                using (History history = new History())
                {
                    existingData = history.Measurements.FirstOrDefault(item => item.Name.ToLower() == city.ToLower());
                }

                if (existingData != null)
                {
                    current_weather.Text = $"City: {existingData.Name}\nTemp: {existingData.Temp}°C\nFeels_like: {existingData.Feels_like}°C\nPressure: {existingData.Pressure}hPa";
                    MessageBox.Show("Data for this city already exists. You can update it by clearing the latest entires or wiping database.");
                }
                else
                {
                    Weather_API weather = new Weather_API(city, API_key);
                    response = await weather.get_data();
                    Data data = JsonSerializer.Deserialize<Data>(response);

                    Database_data temp = new Database_data()
                    {
                        Name = data.name,
                        Pressure = data.main.pressure,
                        Temp = data.main.temp,
                        Feels_like = data.main.feels_like,
                        Time = formattedTime
                    };

                    current_weather.Text = $"City: {temp.Name}\nTemp: {temp.Temp}°C\nFeels like: {temp.Feels_like}°C\nPressure: {temp.Pressure}hPa";

                    if (yes_radio.Checked)
                    {
                        using (History history = new History())
                        {
                            history.Measurements.Add(temp);
                            await history.SaveChangesAsync();
                        }
                    }

                    history_txt.Clear();
                    display_db();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void wipe_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to wipe all existing data from the database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                using (History history = new History())
                {
                    history.Measurements.RemoveRange(history.Measurements);
                    history.SaveChanges();
                }

                MessageBox.Show("Database wiped successfully.");
                history_txt.Clear();
                display_db();


            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            using (History history = new History())
            {
                Database_data lastItem = history.Measurements.OrderByDescending(item => item.Id).FirstOrDefault();

                history.Measurements.Remove(lastItem);
                history.SaveChanges();

                MessageBox.Show($"Last data entry deleted successfully.");
                history_txt.Clear();
                display_db();
            }

        }

        private void sorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            sort_db();
        }

        private void desc_radio_CheckedChanged(object sender, EventArgs e)
        {
            sort_db();
        }

        private void asc_radio_CheckedChanged(object sender, EventArgs e)
        {
            sort_db();
        }

        void display_db()
        {
            using (History history = new History())
            {

                foreach (var item in history.Measurements)
                {
                    history_txt.AppendText(item.ToString() + "\n");
                }
            }
        }

        void sort_db()
        {
            string selectedSort;
            if (sorting.SelectedItem != null)
            {
                selectedSort = sorting.SelectedItem.ToString().ToLower();
            }
            else
            {
                selectedSort = "id";
            }


            List<Database_data> sortedData;
            using (History history = new History())
            {
                if (asc_radio.Checked)
                {
                    sortedData = history.sort_data_asc(selectedSort);
                    history_txt.Clear();
                    foreach (var item in sortedData)
                    {
                        history_txt.AppendText(item.ToString() + "\n");
                    }
                }

                else if (desc_radio.Checked)
                {
                    sortedData = history.sort_data_desc(selectedSort);
                    history_txt.Clear();
                    foreach (var item in sortedData)
                    {
                        history_txt.AppendText(item.ToString() + "\n");
                    }
                }



            }

        }


    }


}
