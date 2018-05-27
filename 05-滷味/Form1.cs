using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_滷味
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.ValueChanged += NumericUpDown_ValueChanged;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal money = (numericUpDown1.Value * 30) + (numericUpDown2.Value * 15) + (numericUpDown3.Value * 15) + (numericUpDown4.Value * 40);
            textBox1.Text = $"高麗菜 {numericUpDown1.Value}份 {numericUpDown1.Value * 30}元 " +
            $"{Environment.NewLine}豆干 {numericUpDown2.Value}份  {numericUpDown2.Value * 15}元" +
             $"{Environment.NewLine}海帶 {numericUpDown3.Value}份  {numericUpDown3.Value * 15}元" +
            $"{Environment.NewLine}肉片 {numericUpDown4.Value}份  {numericUpDown4.Value * 40}元" +
            $"{Environment.NewLine}{Environment.NewLine}總金額：{money}";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            decimal money = (numericUpDown1.Value * 30) + (numericUpDown2.Value * 15) + (numericUpDown3.Value * 15) + (numericUpDown4.Value * 40);

            decimal Thousand = Math.Floor(money / 1000);
            decimal Five = Math.Floor((money % 1000) / 500);
            decimal Hundred = Math.Floor((money % 500) / 100);
            decimal Fifty = Math.Floor((money % 100) / 50);
            decimal Ten = Math.Floor((money % 50) / 10);
            decimal five = Math.Floor((money % 10) / 5);

            label1.Text = $"1000   {Thousand} 張     " +
                $"500    {Five} 張{Environment.NewLine}" +
                $"100     {Hundred} 張     " +
                $"50      {Fifty} 個{Environment.NewLine}" +
                $"10       {Ten} 個     " +
                $"5        {five} 個";

        }

    }
}
