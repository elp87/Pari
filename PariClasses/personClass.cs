using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlServerCe;

namespace PariClasses
{
    /// <summary>Обычный класс человека</summary>
    public class person 
    {
        /// <summary>Вспомогательный класс для генерирования ListBox аспектов</summary>
        public class lbItem
        {
            /// <summary> Возвращает или задает текст ListBoxItem в формате %aspectName% - %aspectValue%
            public string Text { get; set; }

            /// <summary>Возвращает или задает текст всплывающей подсказки для ListBoxItem</summary>
            public string Tip { get; set; } // Подсказка

            /// <summary>Возвращает или задает значение балла аспекта для данного ListBoxItem</summary>
            public int Value { get; set; } //Значение
        }
        
        ///<summary>Возвращает или задает фамилию человека</summary>
        public string surname { get; set; }

        ///<summary>Возвращает или задает имя человека</summary>
        public string name { get; set; }

        ///<summary>Возвращает или задает GUID для базы данных на человека</summary>
        public string GUID { get; set; }

        ///<summary>Возвращает или задает возраст человека</summary>
        public int age { get; set; }

        ///<summary>Возвращает или задает количество своих детей</summary>
        public int ownChildCount { get; set; }

        ///<summary>Возвращает или задает количество приемных детей</summary>
        public int careChildCount { get; set; }

        ///<summary>Возвращает или задает категорию семьи</summary>
        public int familyType { get; set; }

        ///<summary>Возвращает или задает семейное положение</summary>
        public int familyStatus { get; set; }

        ///<summary>Возвращает или задает пол. true - муж, false - жен</summary>
        public bool sex { get; set; }

        ///<summary> Возвращает или задает время и дату прохождения теста</summary>
        public DateTime testDate { get; set; }

                
        //Списки аспектов
        /// <summary>Возвращает список номеров аспектов для "Отношение к семейной роли"</summary>
        public static readonly int[] lbFamilyRoleAspects = { 2, 4, 6, 10, 12, 16, 18, 22} ;
        //Отношение родителей к ребенку
        /// <summary>Возвращает список номеров аспектов для "Оптимальный эмоциональный контакт"</summary>
        public static readonly int[] lbOptimalContactAspects = { 0, 13, 14, 20 };
        /// <summary>Возвращает список номеров аспектов для "Излишняя эмоцмональная дистанция"</summary>
        public static readonly int[] lbOverDistanceAspects = { 7, 8, 15 };
        /// <summary>Возвращает список номеров аспектов для "Излишняя концентрация на ребенке"</summary>
        public static readonly int[] lbOverConcentrationAspects = { 1, 3, 5, 9, 11, 17, 19, 21 };
        
        protected aspect[] aspectArray = new aspect[23];
        
        public person()
        {
            for (int i = 0; i < 23; i++)
            {
                aspectArray[i] = new aspect();
                aspectArray[i].Value = 0;
            }
            aspectArray[0].Name = "Вербализация";
            aspectArray[1].Name = "Чрезмерная забота";
            aspectArray[2].Name = "Зависимость от семьи";
            aspectArray[3].Name = "Подавление воли";
            aspectArray[4].Name = "Ощущение самопожертвования";
            aspectArray[5].Name = "Опасение обидеть";
            aspectArray[6].Name = "Семейные конфликты";
            aspectArray[7].Name = "Раздражительность";
            aspectArray[8].Name = "Излишняя строгость";
            aspectArray[9].Name = "Исключение внутрисемейных влияний";
            aspectArray[10].Name = "Сверхавторитет родителей";
            aspectArray[11].Name = "Подавление агрессивности";
            aspectArray[12].Name = "Неудовлетворенность ролью хозяйки";
            aspectArray[13].Name = "Партнерские отношения";
            aspectArray[14].Name = "Развитие активности ребенка";
            aspectArray[15].Name = "Уклонение от конфликта";
            aspectArray[16].Name = "Безучастность мужа";
            aspectArray[17].Name = "Подавление сексуальности";
            aspectArray[18].Name = "Доминирование матери";
            aspectArray[19].Name = "Чрезвычайное вмешательство в мир ребенка";
            aspectArray[20].Name = "Уравненные отношения";
            aspectArray[21].Name = "Стремление ускорить развитие ребенка";
            aspectArray[22].Name = "Несамостоятельность матери";
        }

        /// <summary>
        /// Устанавливает анкетные данные на человека
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="sex">Пол</param>
        /// <param name="familyStatus">Семейное положение</param>
        /// <param name="age">Возраст</param>
        /// <param name="familyType">Категория семьи</param>
        /// <param name="ownChildCount">Кол-во своих детей</param>
        /// <param name="careChildCount">Кол-во приемных детей</param>
        public void setPerson(string surname, string name, int sex, int familyStatus, string age, int familyType, int ownChildCount, int careChildCount)
        {
            this.surname = surname;
            this.name = name;
            this.sex = (sex == 0) ? true : false;
            this.familyStatus = familyStatus;
            this.age = Convert.ToInt32(age);
            this.familyType = familyType;
            this.ownChildCount = ownChildCount;
            this.careChildCount = careChildCount;
        }

        /// <summary>Устанавливает время и дату тестирования</summary>
        public void setTestDate(DateTime testDate) { this.testDate = testDate; }

        /// <summary>
        /// Возвращает значение выбранного аспекта
        /// </summary>
        /// <param name="index">Номер аспекта</param>
        public int getAspect(int index) { return aspectArray[index].Value; }

        /// <summary>
        /// Возвращает название выбранного аспекта
        /// </summary>
        /// <param name="index">Номер аспекта</param>
        public string getAspectName(int index)
        {
            return aspectArray[index].Name;
        }       
        
        /// <summary>
        /// Конвертирует результат SQL-запроса в данные на человека
        /// </summary>
        public void readSQL(SqlCeDataReader reader)
        {
            surname = reader.GetValue(1).ToString();
            name = reader.GetValue(2).ToString();
            age = Convert.ToInt32(reader.GetValue(3));
            ownChildCount = Convert.ToInt32(reader.GetValue(4));
            careChildCount = Convert.ToInt32(reader.GetValue(5));
            familyType = Convert.ToInt32(reader.GetValue(6));
            familyStatus = Convert.ToInt32(reader.GetValue(7));
            sex = Convert.ToBoolean(reader.GetValue(8));
            testDate = Convert.ToDateTime(reader.GetValue(9));
            
            for (int i = 0; i < 23; i++)
            {
                int ordinal = i + 10;
                aspectArray[i].Value = Convert.ToInt32(reader.GetValue(ordinal));
            }
            GUID = reader.GetValue(33).ToString();
        }
        
        /// <summary>
        /// Возвращает коллекцию для ListBox'ов аспектов
        /// </summary>
        /// <param name="indexes">Массив индексов аспектов</param>
        public ObservableCollection<lbItem> genListBox(int[] indexes)
        {
            ObservableCollection<lbItem> curCollection = new ObservableCollection<lbItem>();
            foreach (int i in indexes)
            {
                if (aspectArray[i].Value <= 8)
                {
                    lbItem curItem = new lbItem()
                    {
                        Text = aspectArray[i].Name + " - " + Convert.ToString(aspectArray[i].Value),
                        Tip = "Ниже нормы",
                        Value = aspectArray[i].Value
                    };
                    curCollection.Add(curItem);
                }
            }
            foreach (int i in indexes)
            {
                if (aspectArray[i].Value >= 18)
                {
                    lbItem curItem = new lbItem()
                    {
                        Text = aspectArray[i].Name + " - " + Convert.ToString(aspectArray[i].Value),
                        Tip = "Выше нормы",
                        Value = aspectArray[i].Value
                    };
                    curCollection.Add(curItem);
                }
            }
            foreach (int i in indexes)
            {
                if ((aspectArray[i].Value > 8) && (aspectArray[i].Value < 18))
                {
                    lbItem curItem = new lbItem()
                    {
                        Text = aspectArray[i].Name + " - " + Convert.ToString(aspectArray[i].Value),
                        Tip = "В норме",
                        Value = aspectArray[i].Value
                    };
                    curCollection.Add(curItem);
                }
            }
            return curCollection;                       
        }
        public override string ToString()
        {
            return (this.surname + " " + this.name);
        }
    }

    /// <summary>Расширенный класс человека, включающий в себя вопросы теста</summary>
    public class AdPerson : person
    {
        private answer[] answArray = new answer[115];

        public AdPerson() : base()
        {
            for (int i = 0; i < 115; i++)
            {
                answArray[i] = new answer();
                answArray[i].value = 0;
            }
            answArray[0].quest = "Если дети считают свои взгляды правильными, они могут не соглашаться со взглядами родителей.";
            answArray[1].quest = "Хорошая мать должна оберегать своих детей даже от маленьких трудностей и обид.";
            answArray[2].quest = "Для хорошей матери дом и семья - самое важное в жизни.";
            answArray[3].quest = "Некоторые дети настолько плохи, что ради их же блага нужно научить их бояться взрослых.";
            answArray[4].quest = "Дети должны отдавать себе отчет в том, что родители делают для них очень много.";
            answArray[5].quest = "Маленького ребенка всегда следует крепко держать в руках во время мытья, чтобы он не упал.";
            answArray[6].quest = "Люди, которые думают, что в хорошей семье не может быть недоразумений, не знают жизни.";
            answArray[7].quest = "Ребенок, когда повзрослеет, будет благодарить родителей за строгое воспитание.";
            answArray[8].quest = "Пребывание с ребенком целый день может довести до нервного истощения.";
            answArray[9].quest = "Лучше, если ребенок не задумывается над тем, правильны ли взгляды его родителей";
            answArray[10].quest = "Родители должны воспитывать в детях полное доверие к себе.";
            answArray[11].quest = "Ребенка следует учить избегать драк, независимо от обстоятельств.";
            answArray[12].quest = "Самое плохое для матери, занимающейся хозяйством, чувство, что ей нелегко освободиться от своих обязанностей";
            answArray[13].quest = "Родителям легче приспособиться к детям, чем наоборот";
            answArray[14].quest = "Ребенок должен научиться в жизни многим нужным вещам, и поэтому ему нельзя разрешать терять ценное время";
            answArray[15].quest = "Если один раз согласиться с тем, что ребенок съябедничал, он будет делать это постоянно";
            answArray[16].quest = "Если бы отцы не мешали в воспитании детей, матери бы лучше справлялись с детьми.";
            answArray[17].quest = "В присутствии ребенка не надо разговаривать о вопросах пола.";
            answArray[18].quest = "Если бы мать не руководила домом, мужем и детьми, все происходило бы менее организовано.";
            answArray[19].quest = "Мать должна делать всё, чтобы знать, о чем думают дети";
            answArray[20].quest = "Если бы родители больше интересовались делами своих детей, дети были бы лучше и счастливее";
            answArray[21].quest = "Большинство детей должны самостоятельно справляться с физиологическими нуждами уже с 15 месяцев";
            answArray[22].quest = "Самое трудное для молодой матери - оставаться одной в первые годы воспитания ребенка";
            answArray[23].quest = "Надо способствовать тому, чтобы дети высказывали свое мнение о жизни и семье, даже если они считают. что жизнь в семье неправильная";
            answArray[24].quest = "Мать должна делать всё, чтобы уберечь своего ребенка от разочарований, которые несет жизнь";
            answArray[25].quest = "Женщины, которые ведут беззаботную жизнь, не очень хорошие матери";
            answArray[26].quest = "Надо обязательно искоренять у детей проявления рождающейся ехидности.";
            answArray[27].quest = "Мать должна жертвовать своим счастьем ради счастья ребенка";
            answArray[28].quest = "Все молодые матери боятся своей неопытности в обращении с ребенком.";
            answArray[29].quest = "Супруги должны время от времени ругаться, чтобы доказать свои права.";
            answArray[30].quest = "Строгая дисциплина по отношению к ребенку развивает в нем сильный характер";
            answArray[31].quest = "Матери часто настолько бывают замучены присутствием своих детей, что им кажется, будто они не могут с ними быть ни минуты больше";
            answArray[32].quest = "Родители не должны представать перед детьми в плохом свете";
            answArray[33].quest = "Ребенок должен уважать своих родителей больше других";
            answArray[34].quest = "Ребенок должен всегда обращаться за помощью к родителям или учителям вместо того, чтобы разрешать свои недоразумения в драке";
            answArray[35].quest = "Постоянное пребывание с детьми убеждает мать в том, что ее воспитательные возможности меньше умений и способностей (могла бы, но...).";
            answArray[36].quest = "Родители своими поступками должны завоевывать расположение детей";
            answArray[37].quest = "Дети, которые не пробуют своих сил в достижении успехов, должны знать, что потом в жизни могут встретиться с неудачами";
            answArray[38].quest = "Родители, которые разговаривают с ребенком о его проблемах, должны знать, что лучше ребенка оставить в покое и не вникать в его дела";
            answArray[39].quest = "Мужья, если не хотят быть эгоистами, должны принимать участие в семейной жизни.";
            answArray[40].quest = "Нельзя допускать, чтобы девочки и мальчики видели друг друга голыми";
            answArray[41].quest = "Если жена достаточно подготовлена к самостоятельному решению проблем, то это лучше и для детей, и для мужа";
            answArray[42].quest = "У ребенка не должно быть никаких тайн от своих родителей";
            answArray[43].quest = "Если у Вас принято, что дети рассказывают Вам анекдоты, а Вы — им, то многие вопросы можно решить спокойно и без конфликтов.";
            answArray[44].quest = "Если рано научить ребенка ходить, это благотворно влияет на его развитие";
            answArray[45].quest = "Нехорошо, когда мать одна преодолевает все трудности, связанные с уходом за ребенком и его воспитанием";
            answArray[46].quest = "У ребенка должны быть свои взгляды и возможность их свободно высказывать";
            answArray[47].quest = "Надо беречь ребенка от тяжелой работы";
            answArray[48].quest = "Женщина должна выбирать между домашним хозяйством и развлечениями";
            answArray[49].quest = "Умный отец должен научить ребенка уважать начальство";
            answArray[50].quest = "Очень мало женщин получает благодарность детей за труд, затраченный на их воспитание";
            answArray[51].quest = "Если ребенок попал в беду, в любом случае мать всегда чувствует себя виноватой";
            answArray[52].quest = "У молодых супругов, несмотря на силу чувств, всегда есть разногласия, которые вызывают раздражение";
            answArray[53].quest = "Дети, которым внушили уважение к нормам поведения, становятся хорошими и уважаемыми людьми";
            answArray[54].quest = "Редко бывает, что мать, которая целый день занимается ребенком, сумела быть ласковой и спокойной";
            answArray[55].quest = "Дети не должны вне дома учиться тому, что противоречит взглядам их родителей";
            answArray[56].quest = "Дети должны знать, что нет людей более мудрых, чем их родители";
            answArray[57].quest = "Нет никакого оправдания ребенку, который бьет другого ребенка";
            answArray[58].quest = "Молодые матери страдают по поводу своего заключения дома больше, чем по какой-нибудь другой причине";
            answArray[59].quest = "Заставлять детей отказываться и приспосабливаться — плохой метод воспитания";
            answArray[60].quest = "Родители должны научить детей найти занятие и не терять свободного времени";
            answArray[61].quest = "Дети мучают своих родителей мелкими проблемами, если с самого начала к этому привыкнут";
            answArray[62].quest = "Когда мать плохо выполняет свои обязанности по отношению к детям, это, пожалуй, значит, что отец не выполняет своих обязанностей по содержанию семьи";
            answArray[63].quest = "Детские игры с сексуальным содержанием могут привести детей к сексуальным преступлениям";
            answArray[64].quest = "Планировать должна только мать, так как только она знает, как положено вести хозяйство";
            answArray[65].quest = "Внимательная мать знает, о чем думает ее ребенок";
            answArray[66].quest = "Родители, которые выслушивают с одобрением откровенные высказывания детей о их переживаниях на свиданиях, товарищеских встречах, танцах и т.п., помогают им в более быстром социальном развитии";
            answArray[67].quest = "Чем быстрее слабеет связь детей с семьей, тем быстрее дети научатся разрешать свои проблемы";
            answArray[68].quest = "Умная мать делает все возможное, чтобы ребенок до и после рождения находился в хороших условиях";
            answArray[69].quest = "Дети должны принимать участие в решении важных семейных вопросов";
            answArray[70].quest = "Родители должны знать, как нужно поступать, чтобы дети не попали в трудные ситуации";
            answArray[71].quest = "Слишком много женщин забывает о том, что их надлежащим местом является дом";
            answArray[72].quest = "Дети нуждаются в материнской заботе, которой им иногда не хватает";
            answArray[73].quest = "Дети должны быть более заботливы и благодарны своей матери за труд, вложенный в них";
            answArray[74].quest = "Большинство матерей опасаются мучить ребенка, давая ему мелкие поручения";
            answArray[75].quest = "В семейной жизни существует много вопросов, которые нельзя решить путем спокойного обсуждения";
            answArray[76].quest = "Большинство детей должны воспитываться более строго, чем происходит на самом деле.";
            answArray[77].quest = "Воспитание детей — тяжелая, нервная работа";
            answArray[78].quest = "Дети не должны сомневаться в разумности родителей";
            answArray[79].quest = "Больше всех других дети должны уважать родителей";
            answArray[80].quest = "Не надо способствовать занятиям детей боксом или борьбой, так как это может привести к серьезным проблемам";
            answArray[81].quest = "Одно из плохих явлений заключается в том, что у матери нет свободного времени для любимых занятий";
            answArray[82].quest = "Родители должны считать детей равноправными во всех вопросах жизни";
            answArray[83].quest = "Когда ребенок делает то, что обязан, он находится на правильном пути и будет счастлив";
            answArray[84].quest = "Надо оставить ребенка, которому грустно, в покое и не заниматься им";
            answArray[85].quest = "Самое большое желание любой матери — быть понятой мужем";
            answArray[86].quest = "Одним из самых сложных моментов в воспитании детей являются сексуальные проблемы";
            answArray[87].quest = "Если мать руководит домом и заботится обо всем, вся семья чувствует себя хорошо";
            answArray[88].quest = "Так как ребенок — часть матери, он имеет право знать все о ее жизни";
            answArray[89].quest = "Дети, которым разрешается шутить и смеяться вместе с родителями, легче принимают их советы";
            answArray[90].quest = "Родители должны приложить все усилия, чтобы как можно раньше справляться с физиологическими нуждами";
            answArray[91].quest = "Большинство женщин нуждаются в большем количестве времени для отдыха после рождения ребенка, чем им дается на самом деле";
            answArray[92].quest = "У ребенка должна быть уверенность в том, что его не накажут, если он доверит родителям свои проблемы";
            answArray[93].quest = "Ребенка не нужно приучать к тяжелой работе дома, чтобы он не потерял охоту к любой работе";
            answArray[94].quest = "Для хорошей матери достаточно общения с семьей";
            answArray[95].quest = "Порой родители вынуждены поступать против воли ребенка";
            answArray[96].quest = "Матери жертвуют всем ради блага собственных детей";
            answArray[97].quest = "Самая главная забота матери — благополучие и безопасность ребенка";
            answArray[98].quest = "Естественно, что двое людей с противоположными взглядами в супружестве ссорятся";
            answArray[99].quest = "Воспитание детей в строгой дисциплине делает их более счастливыми";
            answArray[100].quest = "Естественно, что мать \"сходит с ума\", если у нее дети эгоисты и очень требовательны";
            answArray[101].quest = "Ребенок никогда не должен слушать критические замечания о своих родителях";
            answArray[102].quest = "Прямая обязанность детей — доверие по отношению к родителям";
            answArray[103].quest = "Родители, как правило, предпочитают спокойных детей драчунам";
            answArray[104].quest = "Молодая мать несчастна, потому что многие вещи, которые ей хотелось бы иметь, для нее недоступны";
            answArray[105].quest = "Нет никаких оснований, чтобы у родителей было больше прав и привилегий, чем у детей";
            answArray[106].quest = "Чем раньше ребенок поймет, что нет смысла терять время, тем лучше для него";
            answArray[107].quest = "Дети делают все возможное, чтобы заинтересовать родителей своими проблемами";
            answArray[108].quest = "Немногие мужчины понимают, что матери их ребенка тоже нужна радость";
            answArray[109].quest = "С ребенком что-то не в порядке, если он много расспрашивает о сексуальных вопросах";
            answArray[110].quest = "Выходя замуж, женщина должна отдавать себе отчет в том, что будет вынуждена руководить семейными делами";
            answArray[111].quest = "Обязанностью матери является знание тайных мыслей ребенка";
            answArray[112].quest = "Если включать ребенка в домашние заботы, он легче доверяет им свои проблемы";
            answArray[113].quest = "Надо как можно раньше прекратить кормить ребенка грудью и из бутылочки (приучить самостоятельно питаться)";
            answArray[114].quest = "Нельзя требовать от матери слишком большого чувства ответственности по отношению к детям";
        }

        /// <summary>Расчет аспектов</summary>
        public void calcAspect()
        {
            for (int aspI = 0; aspI < 23; aspI++)
            {
                for (int i = 0; i < 5; i++)
                {
                    aspectArray[aspI].Value = aspectArray[aspI].Value + (answArray[aspI + (i * 23)].value);
                }

            }
        }

        /// <summary>
        /// Задает значение ответа для выбранного вопроса
        /// </summary>
        /// <param name="index">Значение ответа</param>
        /// <param name="answ">Индекс вопроса</param>
        public void setAnswArray(int index, int answ)
        {
            answArray[index].value = answ;
        }

        /// <summary>
        /// Возвращает текст выбранного вопроса
        /// </summary>
        /// <param name="index">Индекс вопроса</param>
        public string getQuest(int index)
        {
            return answArray[index].quest;
        }
    }

    /// <summary>Класс аспекта</summary>
    public class aspect
    {
        /// <summary>Возвращает или задает название аспекта</summary>
        public string Name { get; set; }
        /// <summary>Возвращает или задает значение аспекта</summary>
        public int Value { get; set; }        
    }

    /// <summary>Класс вопроса</summary>
    public class answer
    {
        /// <summary>Возвращает или задает значение ответа на вопрос</summary>
        public int value { get; set; }
        /// <summary>Возвращает или задает текст вопроса</summary>
        public string quest { get; set; }        
    }
    
}
