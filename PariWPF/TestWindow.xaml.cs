using System;
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
            if (radioButton1.IsChecked.Value == true) AnketWindow.stAnket.setAnswArray(curQuest - 1, 1);//AnketWindow.stAnket.answArray[curQuest - 1].value = 1;
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

                #region Таблица родителей                
                PARIDataSet.PerDataTable perDT = new PARIDataSet.PerDataTable();
                PARIDataSet.PerRow perrow = perDT.NewPerRow();
                PARIDataSetTableAdapters.PerTableAdapter perAdapter = new PARIDataSetTableAdapters.PerTableAdapter();


                perrow[0] = AnketWindow.stAnket.surname;
                perrow[1] = AnketWindow.stAnket.name;
                perrow[2] = AnketWindow.stAnket.age;
                perrow[3] = AnketWindow.stAnket.ownChildCount;
                perrow[4] = AnketWindow.stAnket.careChildCount;
                perrow[5] = AnketWindow.stAnket.familyType;
                perrow[6] = AnketWindow.stAnket.familyStatus;
                perrow[7] = AnketWindow.stAnket.sex;
                perrow[8] = AnketWindow.stAnket.testDate;
                for (int i = 0; i < 23; i++)
                {
                    string columnName = "a" + Convert.ToString(i);
                    //perrow[columnName] = AnketWindow.stAnket.aspectArray[i].Value;
                    perrow[columnName] = AnketWindow.stAnket.getAspect(i);
                }
                perrow["guid"] = AnketWindow.stAnket.GUID;
                perDT.AddPerRow(perrow);
                try
                {
                    perAdapter.Update(perDT);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion

                #region Таблица детей
                foreach (ChildClass child in AnketWindow.stListChildClass.ownChildList)
                {
                    
                    ChildDataSet.ChildDataTable chDT = new ChildDataSet.ChildDataTable();
                    ChildDataSet.ChildRow chRow = chDT.NewChildRow();
                    ChildDataSetTableAdapters.ChildTableAdapter chAdapter = new ChildDataSetTableAdapters.ChildTableAdapter();
                    chRow[0] = child.getName();
                    chRow[1] = child.getPrimOther();
                    chRow[2] = child.getSecOther();
                    chRow[3] = child.getSex();
                    chRow[4] = child.getPsyNeed();
                    chRow["secReason"] = child.getSecReason();
                    chRow["isOwn"] = true;
                    chRow["parGuid"] = AnketWindow.stAnket.GUID;
                    chRow["age"] = child.getAge();
                    chRow["primReason"] = child.getPrimReason();
                    chDT.AddChildRow(chRow);
                    chAdapter.Update(chDT);
                }
                foreach (ChildClass child in AnketWindow.stListChildClass.careChildList)
                {
                    ChildDataSet.ChildDataTable chDT = new ChildDataSet.ChildDataTable();
                    ChildDataSet.ChildRow chRow = chDT.NewChildRow();
                    ChildDataSetTableAdapters.ChildTableAdapter chAdapter = new ChildDataSetTableAdapters.ChildTableAdapter();
                    chRow[0] = child.getName();
                    chRow[1] = child.getPrimOther();
                    chRow[2] = child.getSecOther();
                    chRow[3] = child.getSex();
                    chRow[4] = child.getPsyNeed();
                    chRow["secReason"] = child.getSecReason();
                    chRow["isOwn"] = false;
                    chRow["parGuid"] = AnketWindow.stAnket.GUID;
                    chRow["age"] = child.getAge();
                    chRow["primReason"] = child.getPrimReason();
                    chDT.AddChildRow(chRow);
                    chAdapter.Update(chDT);
                }
                #endregion
                this.Hide();
                ResultWindow1 = new ResultWindow();
                ResultWindow1.ShowDialog();
                return;
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
            button1.Margin = new Thickness((Grid1.ActualWidth /2 - 50), (Grid1.ActualHeight / 4) * 3, 0, 0);
            labelTimer.Margin = new Thickness(0, 0, 100, 50);            
        }
    }
}
