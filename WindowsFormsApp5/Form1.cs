using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        Race currentRace;
        Graphics graf;
        int countOfCockroachs;
        Label[] array_of_numbers;
        Label[] array_of_times;
        Label[] array_of_final_places;
        public Form1()
        {
            InitializeComponent();
            graf = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(currentRace == null)
            {
                countOfCockroachs = Convert.ToInt32(numericUpDown1.Value);
                array_of_numbers = new Label[countOfCockroachs];
                array_of_times = new Label[countOfCockroachs];
                array_of_final_places = new Label[countOfCockroachs];
                currentRace = new Race(countOfCockroachs);
                currentRace.Fill_Race_Field();
                array_of_numbers = currentRace.SetArrayOfNumbers(array_of_numbers);
                array_of_times = currentRace.SetArrayofTimes(array_of_times);
                this.Controls.AddRange(array_of_numbers);
                this.Controls.AddRange(array_of_times);
                currentRace.Draw(graf);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(currentRace != null)
            {
                if (timer1.Enabled)
                    timer1.Stop();
                graf.Clear(DefaultBackColor);
                if (array_of_numbers != null)
                    array_of_numbers = null;
                if (array_of_times != null)
                    array_of_times = null;
                if (array_of_final_places != null)
                    array_of_final_places = null;
                if (currentRace != null)
                    currentRace = null;
                Controls.Clear();
                InitializeComponent();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(currentRace != null)
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentRace.Start();
            graf.Clear(DefaultBackColor);
            currentRace.ChangeArrayOfTimes(this.array_of_times);
            currentRace.Draw(graf);
            if (currentRace.Stop() == countOfCockroachs)
            {
                currentRace.Result();
                array_of_final_places = currentRace.SetArrayOfFinalPlaces(array_of_final_places);
                this.Controls.AddRange(array_of_final_places);
                timer1.Stop();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        "Колач Андрей 2221",
        "Автор",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1);
        }
    }
}
