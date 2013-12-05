using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PariClasses;

namespace PariWPF
{
    /// <summary>
    /// Логика взаимодействия для ChildAnketWindow.xaml
    /// </summary>
    public partial class ChildAnketWindow : Window
    {
        public int Index;
        public ChildClass curChild;
        public bool isOwn;
        public static bool isClosed;
        bool[] secReason = new bool[11];

        public ChildAnketWindow()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            #region Проверка входных данных
            bool isError = false;
            if (textBoxName.Text == "")
            {
                MessageBox.Show("Не указано имя");
                isError = true;
            }
            try
            {
                if (Convert.ToInt32(textBoxAge.Text) < 0)
                {
                    MessageBox.Show("Возраст не может быть меньше 0");
                    isError = true;
                }
            }
            catch
            {
                MessageBox.Show("Неверно указан возраст");
                isError = true;
            }
            if (comboBoxSex.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран пол");
                isError = true;
            }
            if (checkBoxPsyNeed.IsChecked == true && comboBoxPrimReason.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбрана причина обращения к психологу");
                isError = true;
            }
            if (isError == true) return;
            #endregion

            secReason[0] = checkBox1.IsChecked.Value;
            secReason[1] = checkBox2.IsChecked.Value;
            secReason[2] = checkBox3.IsChecked.Value;
            secReason[3] = checkBox4.IsChecked.Value;
            secReason[4] = checkBox5.IsChecked.Value;
            secReason[5] = checkBox6.IsChecked.Value;
            secReason[6] = checkBox7.IsChecked.Value;
            secReason[7] = checkBox8.IsChecked.Value;
            secReason[8] = checkBox9.IsChecked.Value;
            secReason[9] = checkBox10.IsChecked.Value;
            secReason[10] = checkBox11.IsChecked.Value;

            curChild = new ChildClass(textBoxName.Text, textBoxAge.Text, comboBoxSex.SelectedIndex, checkBoxPsyNeed.IsChecked.Value,
                AnketWindow.childProblems.getDBNum(comboBoxPrimReason.SelectedIndex), textBoxPrimOther.Text, AnketWindow.childProblems.genDBNumArray(listBoxSecReason), textBoxSecOther.Text);

            if (isOwn == true) AnketWindow.stListChildClass.ownChildList.Add(curChild);
            if (isOwn == false) AnketWindow.stListChildClass.careChildList.Add(curChild);

            isClosed = false;
            this.Close();    
        }

        private void checkBoxPsyNeed_Checked(object sender, RoutedEventArgs e)
        {
            groupBoxPsy.Visibility = System.Windows.Visibility.Visible;
        }

        private void checkBoxPsyNeed_Unchecked(object sender, RoutedEventArgs e)
        {
            groupBoxPsy.Visibility = System.Windows.Visibility.Hidden;
        }

        private void comboBoxPrimReason_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxPrimReason.SelectedIndex == comboBoxPrimReason.Items.Count - 1)
            {
                textBoxPrimOther.Visibility = System.Windows.Visibility.Visible;
                labelPrimOther.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                textBoxPrimOther.Visibility = System.Windows.Visibility.Hidden;
                labelPrimOther.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void checkBox11_Checked(object sender, RoutedEventArgs e)
        {
            textBoxSecOther.Visibility = System.Windows.Visibility.Visible;
        }

        private void checkBox11_Unchecked(object sender, RoutedEventArgs e)
        {
            textBoxSecOther.Visibility = System.Windows.Visibility.Hidden;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            isClosed = true;
            this.Close();
        }

        private void listBoxSecReason_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool otherVisible = false;
            foreach (ListBoxItem lbItem in listBoxSecReason.SelectedItems)
            {
                if (AnketWindow.childProblems.getDBNum(listBoxSecReason.Items.IndexOf(lbItem)) == -5)
                {
                    otherVisible = true;
                }
            }
            if (otherVisible)
            {
                textBoxSecOther.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                textBoxSecOther.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
