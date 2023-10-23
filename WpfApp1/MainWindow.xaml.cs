using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StepItAcademyContext academyContext = new StepItAcademyContext();   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Groupp groupp = new Groupp();
            groupp.Name = group.Text;
            academyContext.Groupps.Add(groupp);
            academyContext.SaveChanges();   
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Teacher teacher= new Teacher();
            teacher.Name = teachername.Text;
            teacher.Permission = teacherpermission.Text;
            teacher.GrouppId = int.Parse(teachergroupid.Text);
            academyContext.Teachers.Add(teacher);
            academyContext.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.Name = studentname.Text;
            student.Surname = studentsurname.Text;
            student.GrouppId = int.Parse(studentgroupid.Text);
            student.Birthday = studentdate.SelectedDate.Value;
            academyContext.Students.Add(student);
            academyContext.SaveChanges();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(removegroup.Text);
            foreach (var item in academyContext.Groupps.ToList())
            {
                if (item.Id == id)
                {
                    academyContext.Groupps.Remove(item);

                }
            }
        }




        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int id2 = int.Parse(removeteacherr.Text);
            foreach (var item in academyContext.Teachers.ToList())
            {
                if (item.Id == id2)
                {
                    academyContext.Teachers.Remove(item);
                }
            }
        }





        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            int id3 = int.Parse(removestudent.Text);
            foreach (var item in academyContext.Students.ToList())
            {
                if (item.Id == id3)
                {
                    academyContext.Students.Remove(item);
                }
            }
        }
    }
}
