using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using System.Windows;

namespace PariClasses
{
    public static class globalOptions
    {
        private static XDocument options = new XDocument();
        public static string userName { get; set; }
        public static string password { get; set; }
        public static double buildVersion { get; set; }
        public static string progDir { get; set; }

        public static void readOptions()
        {          
            //Чтение документта
            try
            {
                options = XDocument.Load(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\mdsOpt.xml");
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.IO.Directory.CreateDirectory(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari");
                writeFile(Assembly.GetExecutingAssembly(), "mdsOpt.xml", Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\mdsOpt.xml");
                try
                {
                    options = XDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("PariClasses.mdsOpt.xml"));
                }
                catch (Exception InnerEx)
                {
                    MessageBox.Show(InnerEx.Message);
                    Environment.Exit(0);
                }
            }

                //Если файл не существует - записать из ресурсов
            catch (System.IO.FileNotFoundException)//Исключение файл не найден
            {
                writeFile(Assembly.GetExecutingAssembly(), "mdsOpt.xml", Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\mdsOpt.xml");
                try
                {
                    options = XDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("PariClasses.mdsOpt.xml"));
                }
                catch (Exception InnerEx)
                {
                    MessageBox.Show(InnerEx.Message);
                    Environment.Exit(0);
                }
            }

            //Linq запрос
            var PariInfo = from userLINQ in options.Descendants("PARI") 
                           select userLINQ;
            foreach (XElement el in PariInfo)
            {
                try { userName = el.Element("username").Value; }
                catch (NullReferenceException) { userName = ""; }

                try { password = el.Element("password").Value; }
                catch (NullReferenceException) { password = ""; }

                try { buildVersion = Convert.ToDouble(el.Element("build").Value); }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                    Environment.Exit(0);
                }

                try 
                { 
                    progDir = el.Element("progPath").Value;
                    if (progDir == "")
                    {
                        progDir = AppDomain.CurrentDomain.BaseDirectory; ;
                    }                    
                }
                catch (NullReferenceException)
                {
                    progDir = AppDomain.CurrentDomain.BaseDirectory;
                }
            }
        
        }

        public static void editFile()
        {
            XElement PariNode = options.Element("options").Element("PARI");

            PariNode.SetElementValue("username", userName);
            PariNode.SetElementValue("password", password);
            PariNode.SetElementValue("build", buildVersion);
            PariNode.SetElementValue("progPath", AppDomain.CurrentDomain.BaseDirectory);

            options.Save(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\mdsOpt.xml");            
        }

        public static void writeFile(Assembly targetAssembly, string resourceName, string filepath)
        {
            using (Stream s = targetAssembly.GetManifestResourceStream(targetAssembly.GetName().Name + "." + resourceName))
            {
                try
                {
                    if (s == null)
                    {
                        throw new Exception("Невозможно найти внедренный ресурс '" + resourceName + "'");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                byte[] buffer = new byte[s.Length];
                s.Read(buffer, 0, buffer.Length);
                using (BinaryWriter sw = new BinaryWriter(File.Open(filepath, FileMode.Create)))
                {
                    sw.Write(buffer);
                }
            }
            
        }

        public static bool checkPassword(string inUsername, string inPassword)
        {
            string Hash;
            string temp = "";
            string genPass = "";
            byte[] userByte;
            userByte = Encoding.Default.GetBytes(inUsername + "PARI");
            var hashVar = MD5.Create();
            byte[] result = hashVar.ComputeHash(userByte);
            Hash = BitConverter.ToString(result).Replace("-", string.Empty);

            for (int i = 1; i < Hash.Length + 1; i++)
            {
                temp += Hash[i - 1];
                if ((i % 5 == 0) && (i != 0))
                {
                    genPass += temp + "-";
                    temp = "";
                }
            }
            genPass = genPass.Remove(genPass.Length - 1);
            return (genPass == inPassword) ? true : false;
        }

        public static void showLoginWindow()
        {
            LoginWindow curLoginWindow = new LoginWindow();
            curLoginWindow.ShowDialog();
            userName = curLoginWindow.textBox1.Text;
            password = curLoginWindow.textBox2.Text;
            if (checkPassword(userName, password)) { }
            else
            {
                MessageBox.Show("Неверный логин/пароль");
                showLoginWindow();
            }
        }

        /*public static void AddFileSecurity(string fileName)
        {
            System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
            string user = wi.Name;
            // Get a FileSecurity object that represents the
            // current security settings.
            FileSecurity fSecurity = File.GetAccessControl(fileName);

            // Add the FileSystemAccessRule to the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule(user, FileSystemRights.FullControl, AccessControlType.Allow));

            // Set the new access settings.
            File.SetAccessControl(fileName, fSecurity);

        }*/


    }
}
