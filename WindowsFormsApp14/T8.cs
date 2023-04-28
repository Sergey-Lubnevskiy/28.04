using System;
using System.Collections;
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
    public partial class Task8 : Form
    {
        List<Student> students = null;
        public Task8()
        {
            InitializeComponent();

            Student s1 = new Student("Белюга Т.С.", "Группа КНП-212", 90, 91, 92, new DateTime(2023, 6, 4));
            Student s2 = new Student("Седенкова А.М.", "Группа КНП-212", 70, 71, 72, new DateTime(2023, 6, 4));
            Student s3 = new Student("Храмова П.Д.", "Группа КНП-212", 72, 81, 93, new DateTime(2023, 6, 4));
            Student s4 = new Student("Бирт Е.А.", "Группа КНП-212", 75, 99, 80, new DateTime(2023, 6, 4));
            Student s5 = new Student("Власова М.Б.", "Группа КНП-212", 73, 85, 74, new DateTime(2023, 6, 4));
            Student s6 = new Student("Пискунова В.А.", "Группа КНП-212", 90, 97, 91, new DateTime(2023, 6, 4));
            Student s7 = new Student("Бажаткова Э.Э.", "Группа КНП-212", 83, 79, 78, new DateTime(2023, 6, 4));
            Student s8 = new Student("Казанцева Е.А.", "Группа КНП-212", 86, 85, 71, new DateTime(2023, 6, 4));
            Student s9 = new Student("Прокопенко А.Д.", "Группа КНП-212", 76, 89, 74, new DateTime(2023, 6, 4));
            Student s10 = new Student("Моругина И.Н.", "Группа КНП-212", 85, 92, 89, new DateTime(2023, 6, 4));

            students = new List<Student> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };

            listView1.Columns.Add("ФИО");
            listView1.Columns.Add("Номер группы");
            listView1.Columns.Add("Физика");
            listView1.Columns.Add("Математика");
            listView1.Columns.Add("Информатика");
            listView1.Columns.Add("Дата сдачи экзамена");

            foreach (Student student in students)
            {
                ListViewItem item = new ListViewItem(student.FullName);
                item.SubItems.Add(student.GroupNumber);
                item.SubItems.Add(student.PhysicsGrade.ToString());
                item.SubItems.Add(student.MathGrade.ToString());
                item.SubItems.Add(student.InformaticsGrade.ToString());
                item.SubItems.Add(student.LastExamDate.ToShortDateString());
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
            DateTime dateTime = DateTime.Parse(textBox1.Text);
            listView1.Items.Clear();
            listView1.Columns.Add("Средний балл");

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            foreach (Student student in students)
            {
                if (student.LastExamDate <= dateTime)
                {
                    double GPA = (student.InformaticsGrade + student.MathGrade +
                        student.PhysicsGrade) / 3;
                    ListViewItem item = new ListViewItem(student.FullName);
                    item.SubItems.Add(student.GroupNumber);
                    item.SubItems.Add(student.PhysicsGrade.ToString());
                    item.SubItems.Add(student.MathGrade.ToString());
                    item.SubItems.Add(student.InformaticsGrade.ToString());
                    item.SubItems.Add(student.LastExamDate.ToShortDateString());
                    item.SubItems.Add(GPA.ToString());
                    listView1.Items.Add(item);
                }
            }
            listView1.ListViewItemSorter = new GPAComparer(6);
            listView1.Sort();
        }
    }
    class Student
    {
        public string FullName { get; set; }
        public string GroupNumber { get; set; }
        public int PhysicsGrade { get; set; }
        public int MathGrade { get; set; }
        public int InformaticsGrade { get; set; }
        public DateTime LastExamDate { get; set; }
        public Student(string fullName, string groupNumber, int physicsGrade, int mathGrade, int informaticsGrade, DateTime lastExamDate)
        {
            FullName = fullName;
            GroupNumber = groupNumber;
            PhysicsGrade = physicsGrade;
            MathGrade = mathGrade;
            InformaticsGrade = informaticsGrade;
            LastExamDate = lastExamDate;
        }
    }
    public class GPAComparer : IComparer
    {
        private int column;

        public GPAComparer(int column)
        {
            this.column = column;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = (ListViewItem)x;
            ListViewItem itemY = (ListViewItem)y;

            double gpaX = double.Parse(itemX.SubItems[column].Text);
            double gpaY = double.Parse(itemY.SubItems[column].Text);

            return gpaX.CompareTo(gpaY);
        }
    }
}