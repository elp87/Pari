using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlServerCe;
using PariClasses;

namespace PariTrainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<person> fullPersonList = new List<person>();
        public static List<person> curPersonList = new List<person>();
        public static ListChildClass stListChildClass = new ListChildClass();
        ObservableCollection<ChildGridClass> OwnChildGridColl = new ObservableCollection<ChildGridClass>();
        ObservableCollection<ChildGridClass> CareChildGridColl = new ObservableCollection<ChildGridClass>();
        ObservableCollection<person.lbItem> colFamilyRoleAspects = new ObservableCollection<person.lbItem>();
        ObservableCollection<person.lbItem> colOptimalContactAspects = new ObservableCollection<person.lbItem>();
        ObservableCollection<person.lbItem> colOverDistanceAspects = new ObservableCollection<person.lbItem>();
        ObservableCollection<person.lbItem> colOverConcentrationAspects = new ObservableCollection<person.lbItem>();
        famTypeList familyTypes;
        famStatusList familyStatuses;
        childProblemList childProblems;
        XDocument curOptions;
        SqlCeConnection scc = new SqlCeConnection(@"data source=" + Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\Pari.sdf");//Полный путь прописывается из-за потери стартовой папки при экспорте в другую папку

        
        public MainWindow()
        {
            InitializeComponent();          
            readDataBase();
            checkDemo.checkObj(fullPersonList);
            if (checkDemo.getDemo() == false)
            {
                globalOptions.readOptions();
                if (globalOptions.checkPassword(globalOptions.userName, globalOptions.password)) { }
                else
                {
                    globalOptions.showLoginWindow();
                }
                globalOptions.editFile();
            }
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
            familyStatuses = new famStatusList(curOptions);
            familyStatuses.readList();
            childProblems = new childProblemList(curOptions);
            childProblems.readList();

            checkUpdate.startCheck();
            checkUpdate.deleteUpdates();
        }

        

        private void readDataBase()
        {           

            int i = 1;
            try
            {
                scc.Open();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            SqlCeCommand PerCmd = new SqlCeCommand();
            PerCmd.Connection = scc;
            PerCmd.CommandText = "select * from Per order by Surname";
            SqlCeDataReader reader = PerCmd.ExecuteReader();
            while (reader.Read())
            {
                person CurPerson = new person();
                CurPerson.readSQL(reader);
                listBoxPersons.Items.Add(CurPerson);
                fullPersonList.Add(CurPerson);
                i++;
            }
            scc.Close();
            foreach (person curPerson in fullPersonList)
            {
                curPersonList.Add(curPerson);
            }
        }
        private void ElementSize()
        {
            listBoxPersons.Height = Grid1.ActualHeight;
            tabControl1.Height = Grid1.ActualHeight;
            tabControl1.Width = Grid1.ActualWidth - 250;
            menu1.Width = Grid1.ActualWidth;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ElementSize();
        }
        private void Window_StateChanged(object sender, EventArgs e)
        {
            ElementSize();
        }
        private void listBoxPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stListChildClass.ownChildList.Clear();
            OwnChildGridColl.Clear();
            dataGridOwnChild.Items.Refresh();
            dataGridOwnChild.ItemsSource = OwnChildGridColl;
            dataGridOwnChild.Items.Refresh();
            
            stListChildClass.careChildList.Clear();
            CareChildGridColl.Clear();
            dataGridCareChild.Items.Refresh();
            dataGridCareChild.ItemsSource = CareChildGridColl;
            dataGridCareChild.Items.Refresh();            
                        
            string stringCmd;
            int index = listBoxPersons.SelectedIndex;
            if (index == -1) return;
            textBoxSurname.Text = curPersonList[index].surname;
            textBoxName.Text = curPersonList[index].name;
            labelDate.Content = "Дата заполнения - " + Convert.ToString(curPersonList[index].testDate);
            textBoxSex.Text = (curPersonList[index].sex == true) ? "муж." : "жен.";
            textBoxAge.Text = Convert.ToString(curPersonList[index].age);
            textBoxFamilyStatus.Text = familyStatuses.getName(curPersonList[index].familyStatus);
            textBoxFamilyType.Text = familyTypes.getName(curPersonList[index].familyType);


            try
            {
                scc.Open();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            SqlCeCommand ownChildCmd = new SqlCeCommand();
            ownChildCmd.Connection = scc;

            stringCmd = "select * from Child where parGuid = '" + curPersonList[index].GUID + "' and isOwn = 'true' order by age";
            ownChildCmd.CommandText = stringCmd;
            
            SqlCeDataReader readerOwnChild = ownChildCmd.ExecuteReader();
            while (readerOwnChild.Read())
            {
                ChildClass curChild = new ChildClass(readerOwnChild.GetValue(1).ToString(), readerOwnChild.GetValue(8).ToString(), readerOwnChild.GetBoolean(4),
                                        readerOwnChild.GetBoolean(5), readerOwnChild.GetInt32(9), readerOwnChild.GetValue(2).ToString(), readerOwnChild.GetValue(3).ToString());
                curChild.setSecReason(readerOwnChild.GetValue(10).ToString());
                stListChildClass.ownChildList.Add(curChild);
            }
            foreach (ChildClass curChild in stListChildClass.ownChildList)
            {
                OwnChildGridColl.Add(new ChildGridClass()
                {
                    name = curChild.getName(),
                    age = curChild.getAge(),
                    reason = childProblems.getName(curChild.getPrimReason(), curChild.getPrimOther())
                });
                dataGridOwnChild.Items.Refresh();
            }
            
            SqlCeCommand careChildCmd = new SqlCeCommand();
            careChildCmd.Connection = scc;

            stringCmd = "select * from Child where parGuid = '" + curPersonList[index].GUID + "' and isOwn = 'false' order by age";
            careChildCmd.CommandText = stringCmd;
            SqlCeDataReader readerCareChild = careChildCmd.ExecuteReader();
            while (readerCareChild.Read())
            {
                ChildClass curChild = new ChildClass(readerCareChild.GetValue(1).ToString(), readerCareChild.GetValue(8).ToString(), readerCareChild.GetBoolean(4), 
                                        readerCareChild.GetBoolean(5), readerCareChild.GetInt32(9), readerCareChild.GetValue(2).ToString(), readerCareChild.GetValue(3).ToString());
                curChild.setSecReason(readerCareChild.GetValue(10).ToString());
                stListChildClass.careChildList.Add(curChild);
            }
            foreach (ChildClass curChild in stListChildClass.careChildList)
            {
                CareChildGridColl.Add(new ChildGridClass()
                {
                    name = curChild.getName(),
                    age = curChild.getAge(),
                    reason = childProblems.getName(curChild.getPrimReason(), curChild.getPrimOther())
                });
                dataGridCareChild.Items.Refresh();
            }
            scc.Close();
            if (OwnChildGridColl.Count > 0)
            {
                dataGridOwnChild.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                dataGridOwnChild.Visibility = System.Windows.Visibility.Hidden;
            }
            if (CareChildGridColl.Count > 0)
            {
                dataGridCareChild.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                dataGridCareChild.Visibility = System.Windows.Visibility.Hidden;
            }

            //Вкладка "Аспекты"
            colFamilyRoleAspects = curPersonList[index].genListBox(person.lbFamilyRoleAspects);
            colOptimalContactAspects = curPersonList[index].genListBox(person.lbOptimalContactAspects);
            colOverDistanceAspects = curPersonList[index].genListBox(person.lbOverDistanceAspects);
            colOverConcentrationAspects = curPersonList[index].genListBox(person.lbOverConcentrationAspects);
            listBoxFamilyRole.ItemsSource = colFamilyRoleAspects;
            listBoxOptimalContact.ItemsSource = colOptimalContactAspects;
            listBoxOverDistance.ItemsSource = colOverDistanceAspects;
            listBoxOverConcentration.ItemsSource = colOverConcentrationAspects;            
        }

        private void MenuItemExport_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxPersons.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран элемент для экспорта");
            }
            else
            {
                int index = listBoxPersons.SelectedIndex;
                ExportWindow ExportWindow1 = new ExportWindow();
                ExportWindow1.ShowDialog();
                if (ExportWindow1.doReport == true)
                {
                    Report Report1 = new Report();
                    Report1.CreatePackage(ExportWindow1.filename, fullPersonList[index], stListChildClass, familyStatuses, familyTypes, childProblems);
                }
            }
        }
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = listBoxPersons.SelectedIndex;
            if (index == -1) return;
            string curGUID = curPersonList[index].GUID;

            scc.Open();
            SqlCeTransaction sccTrPer = scc.BeginTransaction();
            SqlCeCommand sccDeletePerCom = scc.CreateCommand();
            sccDeletePerCom.Transaction = sccTrPer;

            try
            {
                sccDeletePerCom.CommandText = "DELETE FROM Per WHERE guid = \'" + curGUID + "\'";
                sccDeletePerCom.ExecuteNonQuery();

                sccTrPer.Commit();
            }
            catch (Exception ex)
            {
                sccTrPer.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                scc.Close();
            }

            scc.Open();
            SqlCeTransaction sccTrChild = scc.BeginTransaction();
            SqlCeCommand sccDeleteChildCom = scc.CreateCommand();
            sccDeleteChildCom.Transaction = sccTrChild;

            try
            {
                sccDeleteChildCom.CommandText = "DELETE FROM Child WHERE parGuid = \'" + curGUID + "\'";
                sccDeleteChildCom.ExecuteNonQuery();

                sccTrChild.Commit();
            }
            catch (Exception ex)
            {
                sccTrChild.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                scc.Close();
            }

            fullPersonList.Clear();
            curPersonList.Clear();
            listBoxPersons.Items.Clear();
            readDataBase();
        }

        private void dataGridOwnChild_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = dataGridOwnChild.SelectedIndex;
            ChildWindow ChildWindow1 = new ChildWindow();
            ChildWindow1.textBoxName.Text = stListChildClass.ownChildList[index].getName();
            ChildWindow1.textBoxAge.Text = Convert.ToString(stListChildClass.ownChildList[index].getAge());
            ChildWindow1.comboBoxSex.SelectedIndex = (stListChildClass.ownChildList[index].getSex() == true) ? 0 : 1;
            ChildWindow1.checkBoxPsyNeed.IsChecked = stListChildClass.ownChildList[index].getPsyNeed();
            if (stListChildClass.ownChildList[index].getPsyNeed() == true)
            {
                ChildWindow1.groupBoxPsy.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ChildWindow1.groupBoxPsy.Visibility = System.Windows.Visibility.Hidden;
            }

            if (stListChildClass.ownChildList[index].getPrimReason() == -5)
            {
                ChildWindow1.textBoxPrimReason.Text = stListChildClass.ownChildList[index].getPrimOther();
            }
            else
            {
                ChildWindow1.textBoxPrimReason.Text = childProblems.getName(stListChildClass.ownChildList[index].getPrimReason());
            }
            childProblems.genListBox(   ChildWindow1.listBoxSecReason,
                                        "",
                                        childProblems.genDBNumList(stListChildClass.ownChildList[index].getSecReason()),
                                        stListChildClass.ownChildList[index].getSecOther()
                                    );    
            ChildWindow1.ShowDialog();
        }

        private void dataGridCareChild_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = dataGridCareChild.SelectedIndex;
            ChildWindow ChildWindow1 = new ChildWindow();
            ChildWindow1.textBoxName.Text = stListChildClass.careChildList[index].getName();
            ChildWindow1.textBoxAge.Text = Convert.ToString(stListChildClass.careChildList[index].getAge());
            ChildWindow1.comboBoxSex.SelectedIndex = (stListChildClass.careChildList[index].getSex() == true) ? 0 : 1;
            ChildWindow1.checkBoxPsyNeed.IsChecked = stListChildClass.careChildList[index].getPsyNeed();
            if (stListChildClass.careChildList[index].getPsyNeed() == true)
            {
                ChildWindow1.groupBoxPsy.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ChildWindow1.groupBoxPsy.Visibility = System.Windows.Visibility.Hidden;
            }

            if (stListChildClass.careChildList[index].getPrimReason() == -5)
            {
                ChildWindow1.textBoxPrimReason.Text = stListChildClass.careChildList[index].getPrimOther();
            }
            else
            {
                ChildWindow1.textBoxPrimReason.Text = childProblems.getName(stListChildClass.careChildList[index].getPrimReason());
            }
            childProblems.genListBox(   ChildWindow1.listBoxSecReason, 
                                        "", 
                                        childProblems.genDBNumList(stListChildClass.careChildList[index].getSecReason()), 
                                        stListChildClass.careChildList[index].getSecOther()
                                    );            
            ChildWindow1.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void textBoxSearch_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBoxSearch.Text = "";
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string searcQuery = textBoxSearch.Text.ToLower();
            if (e.Key == Key.Enter)
            {
                curPersonList.Clear();
                listBoxPersons.Items.Clear();
                var get = from ft in fullPersonList
                          where (ft.surname.ToLower().Contains(searcQuery)) || (ft.name.ToLower().Contains(searcQuery))
                          select ft;
                foreach (person curName in get)
                {
                    curPersonList.Add(curName);
                    listBoxPersons.Items.Add(curName.surname + " " + curName.name);
                }
            }
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutBox AboutBox1 = new AboutBox();
            AboutBox1.ShowDialog();
        }
        private void MenuItemManual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\manual.doc");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Не удается запустить файл инструкции пользователя");
            }
        }   
    }
}
