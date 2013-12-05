using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Windows;
using PariClasses;

namespace PariWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AnketWindow : Window
    {
        
        ChildAnketWindow ChildAnketWindow1;
        //TestWindow TestWindow1;
        famTypeList familyTypes;
        famStatusList familyStatuses;
        public static childProblemList childProblems;
        XDocument curOptions;
        //globalOptions globalOptions;
        public static AdPerson stAnket = new AdPerson();
        public static ListChildClass stListChildClass = new ListChildClass();
        ObservableCollection<ChildGridClass> OwnChildGridColl = new ObservableCollection<ChildGridClass>();
        ObservableCollection<ChildGridClass> CareChildGridColl = new ObservableCollection<ChildGridClass>();

        public AnketWindow()
        {
            InitializeComponent();

            //Проверка на версию демо/полная
            try
            {
                
                PARIDataSet perDS = new PARIDataSet();
                PARIDataSetTableAdapters.PerTableAdapter perAdapter = new PARIDataSetTableAdapters.PerTableAdapter();
                PARIDataSet.PerDataTable perDT = perAdapter.GetData();

                try
                {
                    checkDemo.checkData(perDT);
                }
                catch (System.InvalidOperationException ex)
                {
                    if (ex.Data.Count == 0)
                    {
                        checkDemo.checkData();
                        //return;
                    }
                    else MessageBox.Show(ex.Message);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }

            //Чтение глобальных опций: юзер, пароль, билд, папка
            if (checkDemo.getDemo() == false)
            {
                //globalOptions = new globalOptions();
                globalOptions.readOptions();
                if (globalOptions.checkPassword(globalOptions.userName, globalOptions.password)) { }
                else
                {
                    globalOptions.showLoginWindow();
                }
                globalOptions.editFile();
            }
            //Чтение локальных опций: категории семьи, семейные положения, проблемы детей
            try
            {
                curOptions = Options.readXML();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            
            familyTypes = new famTypeList(curOptions);
            familyTypes.readList();
            familyTypes.genComboBox(comboBoxFamilyType, "#FFB8EBAC");
            familyStatuses = new famStatusList(curOptions); 
            familyStatuses.readList();
            familyStatuses.genComboBox(comboBoxFamilyStatus, "#FFB8EBAC");
            childProblems = new childProblemList(curOptions);
            childProblems.readList();
            dataGridOwnChild.ItemsSource = OwnChildGridColl;
            dataGridCareChild.ItemsSource = CareChildGridColl;
            
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            #region Проверка входных данных
            bool isError = false;
            if (textBoxSurname.Text == "")
            {
                MessageBox.Show("Не указана фамилия");
                isError = true;
            }

            if (textBoxName.Text == "")
            {
                MessageBox.Show("Не указано имя");
                isError = true;
            }

            if (comboBoxSex.SelectedIndex != 0 && comboBoxSex.SelectedIndex != 1)
            {
                MessageBox.Show("Не выбран пол");
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

            if (comboBoxFamilyStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбрано семейное положение");
                isError = true;
            }

            if (comboBoxFamilyType.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбрана семейная форма");
                isError = true;
            }

            if (isError == true) return;
            #endregion

            

            stAnket.setPerson(textBoxSurname.Text, textBoxName.Text, comboBoxSex.SelectedIndex, familyStatuses.getDBNum(comboBoxFamilyStatus.SelectedIndex),
                textBoxAge.Text, familyTypes.getDBNum(comboBoxFamilyType.SelectedIndex), OwnChildGridColl.Count, CareChildGridColl.Count);
            
            
            this.Hide();
            //TestWindow1.Title = stAnket.surname + " " + stAnket.name + " - методика PARI";
            //TestWindow1.Show(); 
            InstructionsWindow curInstructionsWindow = new InstructionsWindow();
            curInstructionsWindow.showDocument(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\clManual2.rtf", 2);
            curInstructionsWindow.ShowDialog();
        }

        private void buttonAddOwnChild_Click(object sender, RoutedEventArgs e)
        {
            ChildAnketWindow1 = new ChildAnketWindow();
            ChildAnketWindow1.isOwn = true;
            ChildAnketWindow.isClosed = true;
            childProblems.genComboBox(ChildAnketWindow1.comboBoxPrimReason, "#FFB8EBAC");
            childProblems.genListBox(ChildAnketWindow1.listBoxSecReason, "#FFB8EBAC");
            ChildAnketWindow1.ShowDialog();
            if (ChildAnketWindow.isClosed == true)
            {
                ChildAnketWindow.isClosed = false;
                return;
            }
            
            OwnChildGridColl.Add(new ChildGridClass() {name=stListChildClass.ownChildList[stListChildClass.ownChildList.Count - 1].getName(), 
                                                       age = stListChildClass.ownChildList[stListChildClass.ownChildList.Count - 1].getAge(),
                                                       reason = childProblems.getName(stListChildClass.ownChildList[stListChildClass.ownChildList.Count - 1].getPrimReason(), stListChildClass.ownChildList[stListChildClass.ownChildList.Count - 1].getPrimOther())
            });
            dataGridOwnChild.Items.Refresh();                                                      
        }

        private void buttonAddCareChild_Click(object sender, RoutedEventArgs e)
        {
            ChildAnketWindow1 = new ChildAnketWindow();
            ChildAnketWindow1.isOwn = false;
            ChildAnketWindow.isClosed = true;
            childProblems.genComboBox(ChildAnketWindow1.comboBoxPrimReason, "#FFB8EBAC");
            childProblems.genListBox(ChildAnketWindow1.listBoxSecReason, "#FFB8EBAC");
            ChildAnketWindow1.ShowDialog();
            if (ChildAnketWindow.isClosed == true)
            {
                ChildAnketWindow.isClosed = false;
                return;
            }
            CareChildGridColl.Add(new ChildGridClass() {name = stListChildClass.careChildList[stListChildClass.careChildList.Count - 1].getName(),
                                                        age = stListChildClass.careChildList[stListChildClass.careChildList.Count - 1].getAge(),
                                                        reason = childProblems.getName(stListChildClass.careChildList[stListChildClass.careChildList.Count - 1].getPrimReason(), stListChildClass.careChildList[stListChildClass.careChildList.Count - 1].getPrimOther())
            });
            dataGridCareChild.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
