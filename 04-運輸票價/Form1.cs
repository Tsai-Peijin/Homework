using _04_運輸票價.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_運輸票價
{
    public partial class Form1 : Form
    {
        List<ContactsTable> list = new List<ContactsTable>();
        StartStation startstation = new StartStation();
        EndStation endStation = new EndStation();
        public Form1()
        {
            InitializeComponent();
            TicketFare();
            toSouthRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            startComboBox.SelectedIndexChanged += StartComboBox_SelectedIndexChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (toSouthRadioButton.Checked)
            {
                SetToSouthStartCombobox();
            }
            else
            {
                SetToNorthStartCombobox();
            }
        }
        private void SetToSouthStartCombobox()
        {
            //  startComboBox.DataSource = list.GroupBy((x) => x.StartStation).Select((x) => x.Key).ToList();
            startComboBox.DataSource = list.Distinct(startstation).Select((x) => x.StartStation).ToList();
        }

        private void SetToNorthStartCombobox()
        {
            //  startComboBox.DataSource = list.GroupBy((x) => x.EndStation).Select((x) => x.Key).ToList();
            startComboBox.DataSource = list.Distinct(endStation).Select((x) => x.EndStation).ToList();
        }

        private void StartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toSouthRadioButton.Checked)
            {
                SetToSouthEndCombobox();
            }
            else
            {
                SetToNorthEndCombobox();
            }
        }
        //
        private string GetStartStation()
        {
            return startComboBox.SelectedItem.ToString();
        }
        private void SetToSouthEndCombobox()
        {
            string start = GetStartStation();
            endComboBox.DataSource = list.Where((x) => x.StartStation == start).Select((x) => x.EndStation).ToList();
        }
        private void SetToNorthEndCombobox()
        {
            string start = GetStartStation();
            endComboBox.DataSource = list.Where((x) => x.EndStation == start).Select((x) => x.StartStation).ToList();
        }

        private void TicketFare()
        {
            try
            {
                ContactsModel contacts = new ContactsModel();
                contacts.Database.ExecuteSqlCommand("truncate table [ContactsTable]");

                contacts.SaveChanges();
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台北", EndStation = "新竹", TicketFare = 177 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台北", EndStation = "台中", TicketFare = 375 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台北", EndStation = "嘉義", TicketFare = 598 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台北", EndStation = "台南", TicketFare = 738 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台北", EndStation = "高雄", TicketFare = 842 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "新竹", EndStation = "台中", TicketFare = 197 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "新竹", EndStation = "嘉義", TicketFare = 421 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "新竹", EndStation = "台南", TicketFare = 560 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "新竹", EndStation = "高雄", TicketFare = 755 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台中", EndStation = "嘉義", TicketFare = 224 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台中", EndStation = "台南", TicketFare = 363 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台中", EndStation = "高雄", TicketFare = 469 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "嘉義", EndStation = "台南", TicketFare = 139 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "嘉義", EndStation = "高雄", TicketFare = 245 });
                contacts.ContactsTable.Add(new ContactsTable() { StartStation = "台南", EndStation = "高雄", TicketFare = 106 });
                contacts.SaveChanges();

                list = contacts.ContactsTable.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤 {ex.ToString()}");
            }
        }
        public class StartStation : IEqualityComparer<ContactsTable>
        {
            public bool Equals(ContactsTable x, ContactsTable y)
            {
                return x.StartStation == y.StartStation;
            }

            public int GetHashCode(ContactsTable obj)
            {
                return obj.StartStation.GetHashCode();
            }
        }
        public class EndStation : IEqualityComparer<ContactsTable>
        {
            public bool Equals(ContactsTable x, ContactsTable y)
            {
                return x.EndStation == y.EndStation;
            }

            public int GetHashCode(ContactsTable obj)
            {
                return obj.EndStation.GetHashCode();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string start, end;
            var fare = new ContactsTable();
            start = startComboBox.SelectedItem.ToString();
            end = endComboBox.SelectedItem.ToString();

            if (toSouthRadioButton.Checked)
            {
                fare = list.FirstOrDefault((x) => x.StartStation == start && x.EndStation == end);
            }
            else
            { fare = list.FirstOrDefault((x) => x.StartStation == end && x.EndStation == start); }


            decimal money;
            if (checkBox1.Checked && checkBox2.Checked)
            {
                money = Math.Ceiling((fare.TicketFare * 2) * 0.81m);
            }
            else if (checkBox1.Checked)
            {
                money = Math.Ceiling(fare.TicketFare * 2 * 0.9m);
            }
            else if (checkBox2.Checked)
            {
                money = Math.Ceiling(fare.TicketFare * 0.9m);
            }
            else
            {
                money = fare.TicketFare;
            }

            label4.Text = money.ToString();
        }
    }
}
