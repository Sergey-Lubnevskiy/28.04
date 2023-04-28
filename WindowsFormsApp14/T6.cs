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
    public partial class Task6 : Form
    {
        List<CompanyEmployees> employees = null;
        public Task6()
        {
            InitializeComponent();

            employees = new List<CompanyEmployees>
{
    new CompanyEmployees("Белюга", "Татьяна", "Сергеевна", new DateTime(1985, 1, 1), "+380963852741", "Улица Шевченко", 6, "10"),
    new CompanyEmployees("Седенкова", "Анастасия", "Максимовна", new DateTime(1986, 2, 5), "+380789456123", "Улица Шевченко", 6, "11"),
    new CompanyEmployees("Храмова", "Полина", "Дмитриевна", new DateTime(1987, 3, 2), "+380741852963", "Улица Шевченко", 6, "12"),
    new CompanyEmployees("Бирт", "Елизавета", "Александровна", new DateTime(1988, 4, 6), "+380147258369", "Улица Шевченко", 6, "13"),
    new CompanyEmployees("Власова", "Мария", "Борисовна", new DateTime(1989, 5, 3), "+380357896214", "Улица Шевченко", 6, "14"),
    new CompanyEmployees("Пискунова", "Валерия", "Александровна", new DateTime(1990, 6, 7), "+380965874123", "Улица Шевченко", 6, "15"),
    new CompanyEmployees("Бажаткова", "Элина", "Эдуардовна", new DateTime(1991, 7, 8), "+380325419687", "Улица Шевченко", 6, "16"),
    new CompanyEmployees("Казанцева", "Елизавета", "Александровна", new DateTime(1992, 8, 9), "+380365472189", "Улица Шевченко", 6, "17"),
    new CompanyEmployees("Прокопенко", "Алина", "Дмитривена", new DateTime(1993, 9, 11), "+380784512369", "Улица Шевченко", 6, "18"),
    new CompanyEmployees("Моругина", "Ирина", "Николаевна", new DateTime(1994, 10, 12), "+380365874120", "Улица Шевченко", 6, "19"),
    new CompanyEmployees("Мощева", "Алина", "Георгиевна", new DateTime(1995, 11, 20), "+380320145987", "Улица Шевченко", 6, "20"),
    new CompanyEmployees("Лебедева", "Екатерина", "Сергеевна", new DateTime(1996, 12, 21), "+380366584921", "Улица Шевченко", 6, "21") };


            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Дата рождения");
            listView1.Columns.Add("Телефон");
            listView1.Columns.Add("Улица");
            listView1.Columns.Add("Номер дома");
            listView1.Columns.Add("Номер кв.");
            foreach (CompanyEmployees employee in employees)
            {
                ListViewItem item = new ListViewItem(employee.LastName);
                item.SubItems.Add(employee.FirstName);
                item.SubItems.Add(employee.MiddleName);
                item.SubItems.Add(employee.BirthDate.ToShortDateString());
                item.SubItems.Add(employee.Phone);
                item.SubItems.Add(employee.Street);
                item.SubItems.Add(employee.HouseNumber.ToString());
                item.SubItems.Add(employee.ApartmentNumber);

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
            string street = textBox1.Text;
            listView1.Items.Clear();
            int totalAge = 0;

            foreach (CompanyEmployees employee in employees)
            {
                if ((street == employee.Street) && (employee.HouseNumber % 2 == 0))
                {
                    ListViewItem item = new ListViewItem(employee.LastName);
                    totalAge += DateTime.Now.Year - employee.BirthDate.Year;
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.Phone);
                    item.SubItems.Add(employee.Street);
                    item.SubItems.Add(employee.HouseNumber.ToString());
                    item.SubItems.Add(employee.ApartmentNumber);

                    listView1.Items.Add(item);
                }
            }

            double averageAge = totalAge / listView1.Items.Count;
            MessageBox.Show($"Средний возраст сотрудников: {averageAge:F1} лет");

        }
    }
    class CompanyEmployees
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public CompanyEmployees(string lastName, string firstName, string middleName, DateTime birthDate, string phone, string street, int houseNumber, string apartmentNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            Phone = phone;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
        }
    }


}