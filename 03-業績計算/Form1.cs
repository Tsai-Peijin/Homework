using _03_業績計算.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_業績計算
{
    public partial class Form1 : Form
    {
        List<SalesTable> list1 = new List<SalesTable>();
        List<ProductTable> list2 = new List<ProductTable>();

        public Form1()
        {
            InitializeComponent();
            Salesman();
            SaleData();
            Calculation();
        }
        private void Salesman()
        {
            try
            {
                ContactsModel contact = new ContactsModel();
                contact.Database.ExecuteSqlCommand("truncate table [SalesTable]");
                contact.Database.ExecuteSqlCommand("truncate table [ProductTable]");

                contact.SaveChanges();
                contact.SalesTable.Add(new SalesTable() { Salesman = "Bill", Pen = 33, Pencil = 32, Eraser = 56, Ruler = 45, Whiteout = 33, Quantity = (33 * 12 + 32 * 16 + 56 * 10 + 45 * 14 + 33 * 15) });
                contact.SalesTable.Add(new SalesTable() { Salesman = "John", Pen = 77, Pencil = 33, Eraser = 68, Ruler = 45, Whiteout = 23, Quantity = (77 * 12 + 33 * 16 + 68 * 10 + 45 * 14 + 23 * 15) });
                contact.SalesTable.Add(new SalesTable() { Salesman = "David", Pen = 43, Pencil = 55, Eraser = 43, Ruler = 67, Whiteout = 65, Quantity = (43 * 12 + 55 * 16 + 43 * 10 + 67 * 14 + 65 * 15 )});

                contact.ProductTable.Add(new ProductTable() { Products = "原子筆", Sum = 153, Quantity = 153 * 12 });
                contact.ProductTable.Add(new ProductTable() { Products = "鉛筆", Sum = 128, Quantity = 128 * 16 });
                contact.ProductTable.Add(new ProductTable() { Products = "橡皮擦", Sum = 167, Quantity = 167 * 10 });
                contact.ProductTable.Add(new ProductTable() { Products = "直尺", Sum = 157, Quantity = 157 * 14 });
                contact.ProductTable.Add(new ProductTable() { Products = "立可白", Sum = 121, Quantity = 121 * 15 });

                contact.SaveChanges();
                list1 = contact.SalesTable.ToList();
                list2 = contact.ProductTable.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤 {ex.ToString()}");
            }
        }
        private void SaleData()
        {
            dataGridView1.DataSource = list1;
            dataGridView2.DataSource = list2;
        }
        private void Calculation()
        {
            var salesman = list1.Find((x) => x.Quantity == list1.Max((y) => y.Quantity));

            label3.Text = "最佳銷售員：" + salesman.Salesman;

            var product = list2.Find((x) => x.Quantity == list2.Max((y) => y.Quantity));
            label4.Text = "最佳產品：" + product.Products;
        }
    }
}
