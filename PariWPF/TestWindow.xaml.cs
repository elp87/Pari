using elp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PariClasses;

namespace PariWPF
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        int curQuest = 1;
        int sec = 0, min = 0;
        ResultWindow ResultWindow1;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        public TestWindow()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string sMin, sSec;
            sec++;
            if (sec < 10)
            {
                sSec = "0" + Convert.ToString(sec);
            }
            else
            {
                sSec = Convert.ToString(sec);
            }
            if (min < 10)
            {
                sMin = "0" + Convert.ToString(min);
            }
            else
            {
                sMin = Convert.ToString(min);
            }
            if (sec == 60)
            {
                sec = 0;
                min++;
                if (min == 20) MessageBox.Show("Прошло 20 минут. Осталось 5 минут до завершения теста");
                if (min == 25) MessageBox.Show("Отведенное время вышло, даются дополнительные минуты на завершение");
            }
            labelTimer.Content = sMin + ":" + sSec;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked.Value == false && radioButton2.IsChecked.Value == false && radioButton3.IsChecked.Value == false && radioButton4.IsChecked.Value == false)
            {
                MessageBox.Show("Не выбран ни один вариант");
                return;
            }
            if (radioButton1.IsChecked.Value == true) AnketWindow.stAnket.setAnswArray(curQuest - 1, 1);
            if (radioButton2.IsChecked.Value == true) AnketWindow.stAnket.setAnswArray(curQuest - 1, 2);
            if (radioButton3.IsChecked.Value == true) AnketWindow.stAnket.setAnswArray(curQuest - 1, 3);
            if (radioButton4.IsChecked.Value == true) AnketWindow.stAnket.setAnswArray(curQuest - 1, 4);

            curQuest++;
            if (curQuest == 116)
            {
                AnketWindow.stAnket.calcAspect();
                AnketWindow.stAnket.setTestDate(DateTime.Now);
                AnketWindow.stAnket.GUID = Guid.NewGuid().ToString();
                timer.Stop();

                if (File.Exists(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\cl.dat") &&
                    File.Exists(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\ch.dat"))
                {
                    
                    Crypt.EncryptFile(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\cl.dat",
                                        Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\cl.csv",
                                        Crypt.EncryptDirection.Decription);

                    return;
                }
                else
                {
                    List<AdPerson> clientList = new List<AdPerson>();
                    clientList.Add(AnketWindow.stAnket);
                    
                    var clFile = File.Create(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\cl.csv");
                    clFile.Close();                                       

                    CSVWriter csvw = new CSVWriter(clientList);
                    csvw.AddColumn("surname", "surname");
                    csvw.AddColumn("name", "name");
                    csvw.AddColumn("age", "age");
                    csvw.AddColumn("ownChildCount", "ownChildCount");
                    csvw.AddColumn("careChildCount", "careChildCount");
                    csvw.AddColumn("familyType", "familyType");
                    csvw.AddColumn("familyStatus", "familyStatus");
                    csvw.AddColumn("sex", "sex");
                    csvw.AddColumn("testDate", "testDate");
                    csvw.AddColumn("GUID", "GUID");
                    for (int i = 0; i < 23; i++)
                    {
                        string columnName = "a" + i.ToString();
                        csvw.AddColumn(columnName, "getAspect", new object[] { i });
                    }
                    csvw.SaveFile(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\cl.csv");
                    //------------------------------------------

                    Crypt.EncryptFile(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\cl.csv",
                                        Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\cl.dat",
                                        Crypt.EncryptDirection.Encryption);
                    
                    

                    return;
                }
                /*
                this.Hide();
                ResultWindow1 = new ResultWindow();
                ResultWindow1.ShowDialog();
                return;*/
            }

            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            radioButton3.IsChecked = false;
            radioButton4.IsChecked = false;

            string Content = Convert.ToString(curQuest) + ". " + AnketWindow.stAnket.getQuest(curQuest - 1);
            labelQuest.Content = new TextBlock() { Text = Content, TextWrapping = TextWrapping.Wrap };

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case (Key.D1):
                    radioButton1.IsChecked = true;
                    button1_Click(sender, e);
                    break;
                case (Key.D2):
                    radioButton2.IsChecked = true;
                    button1_Click(sender, e);
                    break;
                case (Key.D3):
                    radioButton3.IsChecked = true;
                    button1_Click(sender, e);
                    break;
                case (Key.D4):
                    radioButton4.IsChecked = true;
                    button1_Click(sender, e);
                    break;
                case (Key.NumPad1):
                    radioButton1.IsChecked = true;
                    button1_Click(sender, e);
                    break;
                case (Key.NumPad2):
                    radioButton2.IsChecked = true;
                    button1_Click(sender, e);
                    break;
                case (Key.NumPad3):
                    radioButton3.IsChecked = true;
                    button1_Click(sender, e);
                    break;
                case (Key.NumPad4):
                    radioButton4.IsChecked = true;
                    button1_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            labelQuest.Width = Grid1.ActualWidth - 50;
            labelQuest.Height = 150;
            button1.Margin = new Thickness((Grid1.ActualWidth / 2 - 50), (Grid1.ActualHeight / 4) * 3, 0, 0);
            labelTimer.Margin = new Thickness(0, 0, 100, 50);
        }
    }
}
