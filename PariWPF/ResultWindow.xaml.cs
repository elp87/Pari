using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    
    public partial class ResultWindow : Window
    {
        ObservableCollection<person.lbItem> colFamilyRoleAspects = new ObservableCollection<person.lbItem>();
        ObservableCollection<person.lbItem> colOptimalContactAspects = new ObservableCollection<person.lbItem>();
        ObservableCollection<person.lbItem> colOverDistanceAspects = new ObservableCollection<person.lbItem>();
        ObservableCollection<person.lbItem> colOverConcentrationAspects = new ObservableCollection<person.lbItem>();
        public ResultWindow()
        {
            InitializeComponent();
            colFamilyRoleAspects = AnketWindow.stAnket.genListBox(person.lbFamilyRoleAspects);
            colOptimalContactAspects = AnketWindow.stAnket.genListBox(person.lbOptimalContactAspects);
            colOverDistanceAspects = AnketWindow.stAnket.genListBox(person.lbOverDistanceAspects);
            colOverConcentrationAspects = AnketWindow.stAnket.genListBox(person.lbOverConcentrationAspects);
            listBoxFamilyRole.ItemsSource = colFamilyRoleAspects;
            listBoxOptimalContact.ItemsSource = colOptimalContactAspects;
            listBoxOverDistance.ItemsSource = colOverDistanceAspects;
            listBoxOverConcentration.ItemsSource = colOverConcentrationAspects;            
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();            
        }

        private void colorDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            colorDescriptionWindow cdw = new colorDescriptionWindow();
            cdw.ShowDialog();

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            listBoxOptimalContact.Margin = new Thickness(33, 305, (Grid1.ActualWidth / 2) + 75, 0);
            listBoxOverDistance.Margin = new Thickness(33, 438, (Grid1.ActualWidth / 2) + 75, 0);
            listBoxOverConcentration.Margin = new Thickness((Grid1.ActualWidth / 2) + 75, 305, 33, 0);
            colorDescriptionButton.Margin = new Thickness((Grid1.ActualWidth / 2) - 83, 514,(Grid1.ActualWidth / 2) - 83,0) ;
        }
    }
}

