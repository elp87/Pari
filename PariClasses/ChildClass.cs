using System;
using System.Collections.Generic;

namespace PariClasses
{
    /// <summary>Класс ребенка</summary>
    public class ChildClass
    {
        #region Constructors
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
        #endregion

        #region Properties
        public string name { get; set; }
        public string primOther { get; set; }
        public string secOther { get; set; }
        public string secReason { get; set; }
        public int age { get; set; }
        public int primReason { get; set; }
        public bool sex { get; set; }
        public bool psyNeed { get; set; }
        public bool isOwn { get; set; }
        #endregion

        #region Methods
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
        #endregion
        
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
