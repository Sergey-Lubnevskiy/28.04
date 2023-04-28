using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Different_tasks_async_await_
{
    public partial class Task10 : Form
    {
        List<Shop> goods = new List<Shop>();
        public Task10()
        {
            InitializeComponent();

            Shop item1 = new Shop("Овощи", "Тыква", "Огород", new DateTime(2023, 6, 10), TimeSpan.FromDays(7));
            Shop item2 = new Shop("Консервы", "Шпроты", "Шпротзавод", new DateTime(2023, 6, 10), TimeSpan.FromDays(365));
            Shop item3 = new Shop("Хлебобулочные изделия", "Плюшки", "Хлебозавод", new DateTime(2023, 6, 10), TimeSpan.FromDays(7));
            Shop item4 = new Shop("Напитки", "Байкал", "озеро", new DateTime(2023, 6, 10), TimeSpan.FromDays(7));
            Shop item5 = new Shop("Молочные продукты", "Сыр", "Веселый молошник", new DateTime(2023, 6, 18), TimeSpan.FromDays(7));
            Shop item6 = new Shop("Фрукты", "Яблуки", "ПолиСад", new DateTime(2023, 6, 10), TimeSpan.FromDays(7));
            Shop item7 = new Shop("Морепродукты", "Рыба", "Робоферма", new DateTime(2023, 6, 10), TimeSpan.FromDays(7));
            Shop item8 = new Shop("Кондитерские изделия", "Пироженное", "Кондитерская", new DateTime(2023, 6, 10), TimeSpan.FromDays(7));
            Shop item9 = new Shop("Мясные продукты", "Телятина", "Горы", new DateTime(2023, 6, 10), TimeSpan.FromDays(7));
            Shop item10= new Shop("Крупы", "Гречка'", "Гречзавод", new DateTime(2023, 6, 10), TimeSpan.FromDays(365));

            goods = new List<Shop> { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 };

            listView1.Columns.Add("Группа");
            listView1.Columns.Add("Товар");
            listView1.Columns.Add("Изготовитель");
            listView1.Columns.Add("Дата изготовления");
            listView1.Columns.Add("Срок годности");

            foreach (Shop shop in goods)
            {
                ListViewItem item = new ListViewItem(shop.Group);
                item.SubItems.Add(shop.Name);
                item.SubItems.Add(shop.Manufacturer);
                item.SubItems.Add(shop.DateManufacture.ToShortDateString());
                item.SubItems.Add(shop.ShelfLife.TotalDays.ToString());
                listView1.Items.Add(item);
            }

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                button1.Enabled = false;

        }
        public async Task FinalCount()
        {
            listView1.Items.Clear();
            DateTime interval = DateTime.Parse(textBox1.Text);
            foreach (Shop shop in goods)
            {
                DateTime shelf = shop.DateManufacture + shop.ShelfLife;
                if (interval > shelf)
                {
                    ListViewItem item = new ListViewItem(shop.Group);
                    item.SubItems.Add(shop.Name);
                    item.SubItems.Add(shop.Manufacturer);
                    item.SubItems.Add(shop.DateManufacture.ToShortDateString());
                    item.SubItems.Add(shop.ShelfLife.TotalDays.ToString());
                    listView1.Items.Add(item);
                }
            }
        }
    }
    public class Shop
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DateManufacture { get; set; }
        public TimeSpan ShelfLife { get; set; }

        public Shop(string group, string name, string manufacturer, DateTime dateManufacture, TimeSpan shelfLife)
        {
            Group = group;
            Name = name;
            Manufacturer = manufacturer;
            DateManufacture = dateManufacture;
            ShelfLife = shelfLife;
        }
    }

}