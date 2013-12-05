using System;
using System.Windows;
using System.Windows.Documents;
using System.IO;

namespace PariWPF
{
    /// <summary>
    /// Логика взаимодействия для Instructions.xaml
    /// </summary>
    public partial class InstructionsWindow : Window
    {
        private int windowUsage;
        public InstructionsWindow()
        {
            InitializeComponent();
            string filename = Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\clManual1.rtf";
            showDocument(filename, 1);
            
        }

        public void showDocument(string filename, int windUsage)
        {
            FlowDocument flowDocument = new FlowDocument();
            TextRange textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);

            try
            {
                using (FileStream fileStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    textRange.Load(fileStream, DataFormats.Rtf);
                    richTextBox1.Document = flowDocument;
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            windowUsage = windUsage;
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                switch (windowUsage)
                {
                    case 1: AnketWindow curAnketWindow = new AnketWindow();
                        this.Hide();
                        curAnketWindow.ShowDialog();
                        break;
                    case 2: TestWindow TestWindow1 = new TestWindow();
                        TestWindow1.Title = AnketWindow.stAnket.surname + " " + AnketWindow.stAnket.name + " - методика PARI";
                        this.Hide();
                        TestWindow1.ShowDialog();
                        break;
                    default: MessageBox.Show("Ошибка окна инструкций");
                        Environment.Exit(0);
                        break;
                }
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
