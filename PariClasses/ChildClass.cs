using System;
using System.Collections.Generic;

namespace PariClasses
{
    /// <summary>Класс ребенка</summary>
    public class ChildClass
    {
        private string name, primOther, secOther, secReason;
        private int age, primReason;
        private bool sex, psyNeed;
        private bool[] secReason1 = new bool[11];
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="sex">Пол</param>
        /// <param name="psyNeed">Необходимость в помощи психолога</param>
        /// <param name="primReason">Основная причина из списка</param>
        /// <param name="primOther">Другая основная причина</param>
        /// <param name="secReason">Список вторичных причин из списка</param>
        /// <param name="secOther">Другая вторичная причина или их перечисление</param>
        public ChildClass(string name, string age, int sex, bool psyNeed, int primReason, string primOther, string secReason, string secOther)
        {
            this.name = name;
            this.age = Convert.ToInt32(age);
            this.sex = (sex == 0) ? true : false;
            this.psyNeed = psyNeed;
            this.primReason = primReason;
            this.primOther = primOther;
            this.secOther = secOther;
            this.secReason = secReason;
            
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="age">Возраст</param>
        /// <param name="sex">Пол</param>
        /// <param name="psyNeed">Необходимость в помощи психолога</param>
        /// <param name="primReason">Основная причина из списка</param>
        /// <param name="primOther">Другая основная причина</param>
        /// <param name="secOther">Другая вторичная причина</param>
        public ChildClass(string name, string age, bool sex, bool psyNeed, int primReason, string primOther, string secOther)
        {
            this.name = name;
            this.age = Convert.ToInt32(age);
            this.sex = sex;
            this.psyNeed = psyNeed;
            this.primReason = primReason;
            this.primOther = primOther;
            this.secOther = secOther;
        }

        /// <summary>Устанавливает вторичную причину</summary>
        public void setSecReason(string value) { this.secReason = value; }

        public string getName() { return name; }
        public string getPrimOther() { return primOther; }
        public string getSecOther() { return secOther; }
        public int getAge() { return age; }
        public int getPrimReason() { return primReason; }
        public bool getSex() { return sex; }
        public bool getPsyNeed() { return psyNeed; }
        public string getSecReason() { return secReason; }

        //public string Primary()
        //{
        //    //string res;
        //    switch (getPrimReason())
        //    {
        //        case 0: return "Сложные отношения с ребенком";
        //        case 1: return "Изменение поведения ребенка";
        //        case 2: return "Страхи (фобии) ребенка";
        //        case 3: return "Агрессивное поведение";
        //        case 4: return "Трудности в обучении";
        //        case 5: return "Трудности в общении с ровесниками (одноклассниками)";
        //        case 6: return "Частые ссоры с другими детьми в семье";
        //        case 7: return "Постоянные споры с отцом";
        //        case 8: return "Постоянные споры с матерью";
        //        case 9: return "Суицидальные попытки";
        //        case 10: return this.getPrimOther(); ;
        //        default: return "";

        //    }
        //}
    }

    public class ListChildClass
    {
        public  List<ChildClass> ownChildList = new List<ChildClass>();
        public  List<ChildClass> careChildList = new List<ChildClass>();        
    }
    public class ChildGridClass
    {
        public string name { get; set; }
        public int age { get; set; }
        public string reason { get; set; }
    }

    
}
