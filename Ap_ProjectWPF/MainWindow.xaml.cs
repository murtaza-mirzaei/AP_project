using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Ap_ProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }
        int[] answers = new int[2];
        List<string> boxes = new List<string>();
        List<NoteBook> people = new List<NoteBook>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int A1 = int.Parse(a1.Text);
            int B1 = int.Parse(b1.Text);
            int C1 = int.Parse(c1.Text);

            int A2 = int.Parse(a2.Text);
            int B2 = int.Parse(b2.Text);
            int C2 = int.Parse(c2.Text);

            if (A1 * B2 - A2 * B1 == 0)
            {
                answers[0] = -100;
            }
            else
            {
                answers[0] = (C1 * B2 - B1 * C2) / (A1 * B2 - B1 * A2);
                answers[1] = (A2 * C2 - C1 * A2) / (A1 * B2 - B1 * A2);
            }

            Textbox_Answer.Text = "x= " + answers[0] + "Y= " + answers[1];

        }


        List<NoteBook> List_button = new List<NoteBook>();


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Age1 = int.Parse(Age.Text);
            string firstname = FirstName.Text;
            string lastname = LastName.Text;
            string city = City.Text;

            Age.Clear();
            FirstName.Clear();
            LastName.Clear();
            City.Clear();

            NoteBook NT = new NoteBook(Age1, firstname, lastname, city, answers[0], answers[1]);
            people.Add(NT);

            StreamWriter s = new StreamWriter(@"../../information.txt", append: true);
            s.WriteLine(NT.__Age);
            s.WriteLine(NT.__FirstName);
            s.WriteLine(NT.__LastName);
            s.WriteLine(NT.__City);          
            s.Close();


        }

        private void checkbox(object sender, RoutedEventArgs e)
        {
            boxes.Add(((CheckBox)sender).Name);
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<string> finalresult = new List<string>();
            for (int i = 0; i < boxes.Count; i++)
            {
                

                if (boxes[i] == "checkbox1")
                {
                    string second = textbox1.Text;
                    IEnumerable<string> result = people.Where(p => p.__Age > int.Parse(second)).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }

                }
                if (boxes[i] == "checkbox2")
                {
                    string third = textbox1.Text;
                    IEnumerable<string> result = people.Where(p => p.__Age < int.Parse(third)).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }
                if (boxes[i] == "checkbox3")
                {
                    string fourth = textbox3.Text;
                    IEnumerable<string> result = people.Where(p => p.__City == fourth).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }
                if (boxes[i] == "checkbox4")
                {
                    string third = textboxX0.Text;
                    string four = textboxY0.Text;
                    IEnumerable<string> result = people.Where(p => p.__X == int.Parse(third) && p.__Y==int.Parse(four)).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }

                if (boxes[i] == "checkbox5")
                {
                    string first = textbox5.Text;
                    IEnumerable<string> result = people.Where(p => p.__FirstName == first).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }

                if (boxes[i] == "checkbox6")
                {
                    string third = textbox6.Text;
                    IEnumerable<string> result = people.Where(p => p.__Age < int.Parse(third)).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }
                if (boxes[i] == "textbox7")
                {
                    string Seven = textbox_7.Text;
                    IEnumerable<string> result = people.Where(p => p.__Age > int.Parse(Seven)).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }
                if (boxes[i] == "checkbox8")
                {
                    string third = textbox_8.Text;
                    IEnumerable<string> result = people.Where(p => p.__City == third ).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }
                if (boxes[i] == "checkbox9")
                {
                    string third = textbox9.Text;
                    IEnumerable<string> result = people.Where(p => p.__FirstName == third).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }
                if (boxes[i] == "checkbox10")
                {
                    string X = textboxX.Text;
                    string Y = textboxY.Text;
                    IEnumerable<string> result = people.Where(p => p.__X == int.Parse(X) && p.__Y == int.Parse(Y)).Select(p => p.__FirstName+" " +p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }
                if (boxes[i] == "checkbox11")
                {
                    string third = textbox11.Text;
                    IEnumerable<string> result = people.Where(p => p.__FirstName == third).Select(p => p.__FirstName + " " + p.__LastName);
                    foreach (string output in result)
                    {
                        finalresult.Add(output);
                    }
                }

              

            }
            foreach(string output in finalresult)
            {
                Final.Text += output;
                Final.Text += Environment.NewLine;
            }
        }

        
    }
}
