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
using Microsoft.Win32;
using PariTrainer;

namespace PariTrainer
{
    /// <summary>
    /// Логика взаимодействия для ExportWindow.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        public string filename;
        public bool doReport = false;
       
        public ExportWindow()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog();
            Dialog.FileName = "Document"; 
            Dialog.DefaultExt = ".doc"; 
            Dialog.Filter = "Text documents (.docx)|*.docx"; 
            bool? result = Dialog.ShowDialog();
            if (result == true)
            {
                filename = Dialog.FileName;
                labelFileName.Content = filename;                
            }
            

        }

        private void buttonExport_Click(object sender, RoutedEventArgs e)
        {
            doReport = true;
            this.Hide();                        
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
