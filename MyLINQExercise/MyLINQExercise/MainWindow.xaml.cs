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

namespace MyLINQExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Lists
        private List<Student> studentList = new List<Student>
            {
                new Student {First="Bob", Last="Jones", ID=111, Age=15, Scores= new List<int> {69, 92, 81, 60}},
                new Student {First="Claire", Last="Simpson", ID=112, Age=17, Scores= new List<int> {75, 84, 83, 39}},
                new Student {First="John", Last="Feetham", ID=113, Age=21, Scores= new List<int> {65, 94, 65, 91}},
                new Student {First="Jonathan", Last="Potts", ID=114, Age=10, Scores= new List<int> {97, 83, 85, 62}},
                new Student {First="Pepe", Last="Garcia", ID=115, Age=20, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Samantha", Last="Fakhouri", ID=116, Age=17, Scores= new List<int> {99, 86, 90, 54}},
                new Student {First="Roger", Last="Song", ID=117, Age=19, Scores= new List<int> {60, 72, 64, 45}},
                new Student {First="Hugo", Last="Garcia", ID=118, Age=15, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Richard", Last="Ammerman", ID=119, Age=14, Scores= new List<int> {68, 79, 81, 92}},
                new Student {First="Kevin", Last="Adamson", ID=120, Age=11, Scores= new List<int> {68, 71, 81, 79}},
                new Student {First="Jeet", Last="Singh", ID=121, Age=12, Scores= new List<int> {96, 85, 91, 60}}
            };

        private List<Staff> teacherList = new List<Staff>
            {
                new Staff {First="Jeet", Last="Singh", ID=900},
                new Staff {First="Richard", Last="Potter", ID=901},
                new Staff {First="Terry", Last="Woodward", ID=902},
                new Staff {First="Bob", Last="Feetham", ID=903},
                new Staff {First="Jane", Last="Feetham", ID=904},
                new Staff {First="Oliver", Last="Jones", ID=905},
                new Staff {First="Rafael", Last="Sacramento", ID=906},
                new Staff {First="John", Last="Smith", ID=907},
                new Staff {First="Pepe", Last="Garcia", ID=908}
            };

        private List<Course> courseList = new List<Course>
            {
                new Course{Code="100AB",Name="Intro To Computers",Semester="Fall",Duration=15},
                new Course{Code="101AB",Name="Programming I",Semester="Winter",Duration=15},
                new Course{Code="102AB",Name="Programming II",Semester="Fall",Duration=15},
                new Course{Code="103AB",Name="Database I",Semester="Summer",Duration=5},
                new Course{Code="104AB",Name="Database II",Semester="Summer",Duration=5},
                new Course{Code="303ER",Name="Applied Mathematics",Semester="Summer",Duration=5},
                new Course{Code="304ER",Name="Pure Mathematics",Semester="Fall",Duration=15},
                new Course{Code="588A",Name="English Language",Semester="Winter",Duration=10},
                new Course{Code="589A",Name="English Literature",Semester="Winter",Duration=10},
                new Course{Code="588B",Name="More English Language",Semester="Fall",Duration=10},
                new Course{Code="589B",Name="More English Literature",Semester="Fall",Duration=10},
                new Course{Code="123Z",Name="Basic Biology",Semester="Winter",Duration=15},
                new Course{Code="123Y",Name="Basic Chemistry",Semester="Fall",Duration=15},
                new Course{Code="123X",Name="Basic Physics",Semester="Summer",Duration=8}
            };

        public MainWindow()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.Width;
            this.SizeToContent = SizeToContent.Height;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            cmbList.Items.Add("Student List");
            cmbList.Items.Add("Staff List");
            cmbList.Items.Add("Course List");

        }

        private void CmbList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbList.SelectedIndex == 0)
            {
                dgList.ItemsSource = studentList;
            }
            else if (cmbList.SelectedIndex == 1)
            {
                dgList.ItemsSource = teacherList;
            }
            else if (cmbList.SelectedIndex == 2)
            {
                dgList.ItemsSource = courseList;
            }
            else
            {
                dgList.ItemsSource = null;
            }
        }

        //Students who are uncer 18 years of age (youngest first)
        private void RbtnUnder18_Click(object sender, RoutedEventArgs e)
        {
            var studentUnder18 = from s in studentList
                                 where s.Age < 18
                                 orderby s.Age
                                 select s;

            foreach (Student s in studentUnder18)
            {
                txtOutput.Text += string.Format("{0}, {1} - Age: {2}\n", s.Last, s.First, s.Age);
            }
        }

        // Students who are teenagers (alphabetical order by last name
        private void RbtnTeenAgers_Click(object sender, RoutedEventArgs e)
        {
            var teenStudents = from s in studentList
                               where s.Age > 12 && s.Age < 20
                               orderby s.Last
                               select s;
            txtOutput.Text += "\n";

            foreach (Student s in teenStudents)
            {
                txtOutput.Text += string.Format("{0}, {1} - Age: {2}\n", s.Last, s.First, s.Age);
            }
        }

        //Students who scored 80 or more in their last test (order by score descending)
        private void RbtnScored80_Click(object sender, RoutedEventArgs e)
        {
            var scored80 = from s in studentList
                               where s.Scores[3] >= 80
                               orderby s.Scores[3] descending
                               select s;
            txtOutput.Text += "\n";

            foreach (Student s in scored80)
            {
                txtOutput.Text += string.Format("{0}, {1} - Score: {2}\n", s.Last, s.First, s.Scores[3]);
            }
        }

        // Students who scored over 320 marks in total (across all their tests)
        private void RbtnScored320_Click(object sender, RoutedEventArgs e)
        {
            var scored320 = from s in studentList
                            where (s.Scores.Sum() > 320)
                            select s;

            txtOutput.Text += "\n";

            foreach (Student s in scored320)
            {
                txtOutput.Text += string.Format("{0}, {1} - Total Score: {2}\n", s.Last, s.First, s.Scores.Sum());
            }
        }
   
        // Students who scored at least 60 in all their tests 
        private void RbtnScored60_Click(object sender, RoutedEventArgs e)
        {
            var scored60 = from s in studentList
                            where (s.Scores.Sum() >= 60)
                            select s;

            txtOutput.Text += "\n";

            foreach (Student s in scored60)
            {
                txtOutput.Text += string.Format("{0}, {1} - Total Score: {2}\n", s.Last, s.First, s.Scores.Sum());
            }
        }

        // Students grouped by first letter of last name  
        private void RbtnFirstLetter_Click(object sender, RoutedEventArgs e)
        {
            var list = from s in studentList
                       group s by s.Last[0] 
                       into studentGroups
                       orderby studentGroups.Key
                       select studentGroups;

            txtOutput.Text += "\n";

            foreach (var group in list)
            {
                txtOutput.Text += group.Key.ToString();

                foreach (Student s in group)
                {
                    txtOutput.Text += string.Format("\t{0}, {1}\n", s.Last, s.First);
                }
            }
        }

        // Average score of each test 
        private void RbtnAverageScore_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "\n";
            var studentAvg = from s in studentList
                             select s.Scores[0];
            txtOutput.Text += "Exam 1 average = " + studentAvg.Average() + "\n";

            studentAvg = from s in studentList
                         select s.Scores[1];
            txtOutput.Text += "Exam 2 average = " + studentAvg.Average() + "\n";

            studentAvg = from s in studentList
                         select s.Scores[2];
            txtOutput.Text += "Exam 3 average = " + studentAvg.Average() + "\n";

            studentAvg = from s in studentList
                         select s.Scores[3];
            txtOutput.Text += "Exam 4 average = " + studentAvg.Average() + "\n";
        }

        // Students who are also teachers
        private void RbtnStudentsAlsoTeachers_Click(object sender, RoutedEventArgs e)
        {
            var studentTeacher = from s in studentList
                                 join t in teacherList
                                 on new { s.First, s.Last }
                                 equals new { t.First, t.Last }
                                 select s.First + " " + s.Last;

            txtOutput.Text = "\n";
            foreach (var s in studentTeacher)
            {
                txtOutput.Text += s + "\n";
            }
        }


        // Courses of a duration of 15 weeks (alphabetical order by name)
        private void RbtnCourses15_Click(object sender, RoutedEventArgs e)
        {
            var courses15Weeks = from c in courseList
                                 where c.Duration == 15
                                 orderby c.Name
                                 select c;

            txtOutput.Text = "\n";
            foreach (var c in courses15Weeks)
            {
                txtOutput.Text += "- " + c.Name + "\n";
            }
        }


        // Courses held in the Winter semester (order by duration)
        private void RbtnCoursesWinter_Click(object sender, RoutedEventArgs e)
        {
            var winterCourses = from c in courseList
                                where c.Semester == "Winter"
                                orderby c.Duration
                                select c;

            txtOutput.Text = "\n";
            foreach (var c in winterCourses)
            {
                txtOutput.Text += "- " + c.Name + "\n";
            }
        }


        // Courses grouped by semester
        private void RbtnCoursesbySemester_Click(object sender, RoutedEventArgs e)
        {
            var courseGroupSemeter = from c in courseList
                                     group c by c.Semester
                         into courseGroup
                                     orderby courseGroup.Key
                                     select courseGroup;

            txtOutput.Text = "\n";
            foreach (var group in courseGroupSemeter)
            {
                txtOutput.Text += group.Key + "\n";
                foreach (Course course in group)
                {
                    txtOutput.Text += string.Format("\t{0}\n", course.Name);
                }
            }
        }
    }

    class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }

    class Staff
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
    }


    class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public int Duration { get; set; }
    }

    class Room
    {
        public string Code { get; set; }
    }

    class Schedule
    {
        public string Room { get; set; }
        public string Course { get; set; }
    }

}
