using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_停車費率
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = $"進場時間：{dateTimePicker1.Text}";
            label2.Text = $"出場時間：{dateTimePicker2.Text}";
            DateTime start = new DateTime(dateTimePicker1.Value.Year , dateTimePicker1.Value.Month , dateTimePicker1.Value.Day , dateTimePicker1.Value.Hour , dateTimePicker1.Value.Minute,0);
            DateTime end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, 0);
            TimeSpan time = (end - start);
            int min = (int)(time.TotalMinutes);
            
            decimal money = 0;
            if (min <= 120)
            {
                money = decimal.Floor(min / 30) * 30;
            }
            else if (min > 240)
            {
                money = decimal.Floor(min / 30) * 60;
            }
            else
            {
                money = decimal.Floor(min / 30) * 40;
            }
            label3.Text = $"停車費用：{money}";
        }

    }
}
