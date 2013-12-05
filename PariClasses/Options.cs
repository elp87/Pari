using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace PariClasses
{
    public abstract class opt
    {
        public string name { get; set; }
        public int dbNum { get; set; }
        public int progNum { get; set; }
        public bool visible { get; set; }

        public opt()
        {
            progNum = -2;
        }
    }

    public abstract class optList
    {
        public List<opt> ItemList = new List<opt>();
        public string name { get; set; }
        protected XDocument xmlOptions;

        public optList(XDocument xmlOptions, string name)
        {
            this.xmlOptions = xmlOptions;
            this.name = name;
        }

        public abstract void readList();

        public int getDBNum(int progNum)
        {
            if (progNum == -1) return -1;
            //Если элемент не выбран и это разрешено логикой (например ComboBoxPrimReason при isPsyNeed = false),
            //то идет завершение метода с передачей значения -1
            
            int returnValue = 0;
            int returnCount = 0;
            var getDBNUM = from ft in ItemList
                           where ft.progNum == progNum
                           select ft.dbNum;
            foreach (int curDBNum in getDBNUM)
            {
                returnValue = curDBNum;
                returnCount++;
            }
            if (returnCount != 1)
            {
                MessageBox.Show("Ошибка файла настроек", name);
            }
            return returnValue;
        }
        public string getName(int DBNum)
        {
            if (DBNum == -1) return "";
            //Если элемент не выбран и это разрешено логикой (например ComboBoxPrimReason при isPsyNeed = false),
            //то идет завершение метода с передачей пустой строки

            int returnCount = 0;
            string returnValue = "";
            var get = from ft in ItemList
                      where ft.dbNum == DBNum
                      select ft.name;
            foreach (string curName in get)
            {
                returnValue = curName;
                returnCount++;
            }
            if (returnCount != 1)
            {
                MessageBox.Show("Ошибка файла настроек", name);
            }
            return returnValue;
        }

        public void genComboBox(ComboBox startComboBox, string textColor)
        {            
            foreach (opt curOpt in ItemList)
            {
                ComboBoxItem cbItem = new ComboBoxItem();
                BrushConverter bc = new BrushConverter();
                cbItem.Background = (Brush)bc.ConvertFrom(textColor);
                if (curOpt.visible == true)
                {
                    cbItem.Content = curOpt.name;
                    startComboBox.Items.Add(cbItem);
                }
            }
        }
    }

    public static class Options
    {
        public static XDocument readXML()
        {
            XDocument options = new XDocument();
            try
            {
                options = XDocument.Load(Environment.GetEnvironmentVariable("appdata") + @"\Felicia\Pari\options.xml");
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            return options;
        }
    }

    public class famType : opt { }
    public class famStatus : opt { }
    public class childProblem : opt { }

    public class famTypeList : optList
    {
        public famTypeList(XDocument xmlOptions) : base(xmlOptions, "famType") { }

        public override void readList()
        {
            int allItemNum = 0;
            int visItemNum = 0;

            var makeInfo = from curOpt in xmlOptions.Descendants(name)
                           select curOpt;
            foreach (var item in makeInfo.Distinct())
            {
                try
                {
                    ItemList.Add(new famType()
                    {
                        name = item.Element("name").Value,
                        dbNum = Convert.ToInt16(item.Element("num").Value),
                        visible = Convert.ToBoolean(item.Element("visible").Value)
                    });
                    if (ItemList[allItemNum].visible == true)
                    {
                        ItemList[allItemNum].progNum = visItemNum;
                        visItemNum++;
                    }
                }
                catch (System.NullReferenceException ex)
                {
                    MessageBox.Show("XML Read - " + ex.Message + " - " + name + " - " + Convert.ToString(allItemNum), "XML Read");
                    Environment.Exit(0);
                }
                catch (System.FormatException ex)
                {
                    MessageBox.Show("XML Read - " + ex.Message + " - " + name + " - " + Convert.ToString(allItemNum), "XML Read");
                    Environment.Exit(0);
                }

                allItemNum++;
            }
        }
    }

    public class famStatusList : optList
    {
        public famStatusList(XDocument xmlOptions) : base(xmlOptions, "famStatus") { }

        public override void readList()
        {
            int allItemNum = 0;
            int visItemNum = 0;

            var makeInfo = from curOpt in xmlOptions.Descendants(name)
                           select curOpt;
            foreach (var item in makeInfo.Distinct())
            {
                ItemList.Add(new famStatus()
                {
                    name = item.Element("name").Value,
                    dbNum = Convert.ToInt16(item.Element("num").Value),
                    visible = Convert.ToBoolean(item.Element("visible").Value)
                });
                if (ItemList[allItemNum].visible == true)
                {
                    ItemList[allItemNum].progNum = visItemNum;
                    visItemNum++;
                }
                allItemNum++;
            }
        }
    }

    public class childProblemList : optList
    {
        public childProblemList(XDocument xmlOptions) : base(xmlOptions, "childProblem") { }

        public override void readList()
        {
            int allItemNum = 0;
            int visItemNum = 0;

            var makeInfo = from curOpt in xmlOptions.Descendants(name)
                           select curOpt;
            foreach (var item in makeInfo.Distinct())
            {
                ItemList.Add(new childProblem()
                {
                    name = item.Element("name").Value,
                    dbNum = Convert.ToInt16(item.Element("num").Value),
                    visible = Convert.ToBoolean(item.Element("visible").Value)
                });
                if (ItemList[allItemNum].visible == true)
                {
                    ItemList[allItemNum].progNum = visItemNum;
                    visItemNum++;
                }
                allItemNum++;
            }
            ItemList.Add(new childProblem()
            {
                name = "Другое",
                dbNum = -5,
                visible = true,
                progNum = visItemNum
            });
        }
        public string getName(int DBNum, string Other)
        {
            if (DBNum == -1) return "";
            int returnCount = 0;
            string returnValue = "";
            var get = from ft in ItemList
                      where ft.dbNum == DBNum
                      select ft.name;
            foreach (string curName in get)
            {
                returnValue = curName;
                returnCount++;
            }
            if (DBNum == -5)
            {
                return Other;
            }
            if (returnCount != 1)
            {
                MessageBox.Show("Ошибка файла настроек", name);
            }
            return returnValue;
        }
        public void genListBox(ListBox startListBox, string textColor)
        {
            foreach (opt curOpt in ItemList)
            {
                ListBoxItem lbItem = new ListBoxItem();
                BrushConverter bc = new BrushConverter();
                lbItem.Background = (Brush)bc.ConvertFrom(textColor);
                if (curOpt.visible == true)
                {
                    lbItem.Content = curOpt.name;
                    startListBox.Items.Add(lbItem);
                }
            }
        }
        public void genListBox(ListBox startListBox, string textColor, List<int> listDBNum, string textOther)
        {
            foreach (int i in listDBNum)
            {
                ListBoxItem lbItem = new ListBoxItem();
                if (textColor != "")
                {
                    BrushConverter bc = new BrushConverter();
                    lbItem.Background = (Brush)bc.ConvertFrom(textColor);
                }
                lbItem.Content = this.getName(i, textOther);
                startListBox.Items.Add(lbItem);
            }
        }

        public string genDBNumArray(ListBox startListBox)
        {
            string returnValue = "";
            foreach (ListBoxItem lbItem in startListBox.Items)
            {
                int index = startListBox.Items.IndexOf(lbItem);
                if (lbItem.IsSelected)
                {
                    returnValue += Convert.ToString(getDBNum(index)) + ",";
                }
            }
            return returnValue;
        }

        public List<int> genDBNumList(string text)
        {
            List<int> ListDBNum = new List<int>();
            int start = 0;
            string num = "";
            int count = text.Length;
            for (int i = 0; i < count; i++)
            {
                if (text[i] == ',')
                {
                    for (int j = start; j < i; j++)
                    {
                        num += text[j];
                    }
                    int n = Convert.ToInt32(num);
                    ListDBNum.Add(n);
                    num = "";
                    start = i + 1;
                }
            }
            return ListDBNum;
        }
    }
    
}
