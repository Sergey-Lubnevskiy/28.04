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
    public partial class Task7 : Form
    {
        List<CompanyEmployees2> employees2 = null;
        public Task7()
        {
            InitializeComponent();
            employees2 = new List<CompanyEmployees2>
            {
                new CompanyEmployees2("Белюга", "Татьяна", "Сергеевна", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Седенкова", "Анастасия", "Максимовна", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Храмова", "Полина", "Дмитриевна", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Бирт", "Елизавета", "Александровна", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Власова", "Мария", "Борисовна", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Пискунова", "Валерия", "Александровна", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Бажаткова", "Элина", "Эдуардовна", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Казанцева", "Елизавета", "Александровна", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Прокопенко", "Алина", "Дмитривена", new DateTime(1995, 6, 20), "Одесса"),
                new CompanyEmployees2("Моругина", "Ирина", "Николаевна", new DateTime(1995, 6, 20), "Одесса")
            };
            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Дата рождения");
            listView1.Columns.Add("Место рождения");
            foreach (CompanyEmployees2 employee in employees2)
            {
                ListViewItem item = new ListViewItem(employee.LastName);
                item.SubItems.Add(employee.FirstName);
                item.SubItems.Add(employee.MiddleName);
                item.SubItems.Add(employee.BirthDate.ToShortDateString());
                item.SubItems.Add(employee.LivePlase);
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
            int year = int.Parse(textBox1.Text);
            listView1.Items.Clear();

            foreach (CompanyEmployees2 employee in employees2)
            {
                if (year == employee.BirthDate.Year)
                {
                    ListViewItem row = new ListViewItem("Введённый вами год");
                    row.SubItems.Add("");
                    row.SubItems.Add("");
                    listView1.Items.Add(row);

                    ListViewItem item = new ListViewItem(employee.LastName);
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.LivePlase);
                    listView1.Items.Add(item);
                }
            }
            foreach (CompanyEmployees2 employee in employees2)
            {
                if (employee.BirthDate.Year == 1985)
                {
                    ListViewItem row = new ListViewItem("Сотрудник рожденный в год быка");
                    row.SubItems.Add("");
                    row.SubItems.Add("");
                    listView1.Items.Add(row);

                    ListViewItem item = new ListViewItem(employee.LastName);
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.LivePlase);
                    listView1.Items.Add(item);
                }
            }
        }
    }
    class CompanyEmployees2
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string LivePlase { get; set; }

        public CompanyEmployees2(string lastName, string firstName, string middleName, DateTime birthDate, string livePlase)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            LivePlase = livePlase;
        }
    }
}