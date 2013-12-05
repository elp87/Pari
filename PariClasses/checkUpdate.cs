using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using wpf = System.Windows;
using winform = System.Windows.Forms;

namespace PariClasses
{
    public static class checkUpdate
    {
        private static readonly string webAdress = "http://psy.elp87.ru/pari/";
        private static XDocument updateList = new XDocument();
        private static double curBuild;
        private static WebClient myWebClient;
        private static downloadWindow updateDownloadWindow = new downloadWindow();
        private static string updateName;

        public static void startCheck()
        {          

            myWebClient = new WebClient();
            curBuild = globalOptions.buildVersion;

            try
            {
                updateList = XDocument.Load(webAdress + "updatelog.xml");
            }
            catch (System.Xml.XmlException ex)
            {
                wpf.MessageBox.Show("Ошибка таблицы обновлений:" + '\n' + ex.Message);
            }
            catch (System.Net.WebException) { }
            catch (Exception ex)
            {
                wpf.MessageBox.Show(ex.Message);
            }

            var versInfo = from versLINQ in updateList.Descendants("up1")
                           where ((Convert.ToInt32(versLINQ.Element("minLastBuild").Value) <= curBuild) && (Convert.ToInt32(versLINQ.Element("maxLastBuild").Value) >= curBuild))
                           select versLINQ;
            foreach (XElement el in versInfo)
            {
                updateName = el.Element("file").Value;
                winform.DialogResult result = winform.MessageBox.Show("Найдено обновление. Хотите обновить приложение?", "Обновление", winform.MessageBoxButtons.YesNo, winform.MessageBoxIcon.Question);
                if (result == winform.DialogResult.No) { return; }
                if (result == winform.DialogResult.Yes) 
                {
                    try
                    {
                        downloadUpdate(updateName);
                        updateDownloadWindow.fileNameLabel.Content += updateName;
                        updateDownloadWindow.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        wpf.MessageBox.Show(ex.Message);
                    }
                }
            } 
        }

        private static void downloadUpdate(string updateName)
        {
            myWebClient.DownloadFileAsync(new Uri(webAdress + updateName), Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\" + updateName);
            myWebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(myWebClient_DownloadProgressChanged);
            myWebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(myWebClient_DownloadFileCompleted);
        }

        static void myWebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 1000;
            updateDownloadWindow.progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            updateDownloadWindow.infoLabel.Content = Convert.ToString(Math.Round(percentage / 10, 2)) + "% (" + Convert.ToString(Math.Round(bytesIn / 1024, 2)) + " / " + Convert.ToString(Math.Round(totalBytes / 1024, 2)) + " kb)";
        }

        static void myWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\" + updateName);
            Environment.Exit(0);
        }

        public static void deleteUpdates()
        {
            try
            {
                string[] updateFilesList = Directory.GetFiles(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\", "*.exe");

                foreach (string file in updateFilesList)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception inEx)
                    {
                        wpf.MessageBox.Show(inEx.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                wpf.MessageBox.Show(ex.Message);
            }
        }
    }
}
