using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp02._06
{
    /*
    Создайте класс «Кредитная карточка». Вам необходимо
    хранить информацию о номере карты, ФИО владельца,
    CVC, дата завершения работы карты и т.д. Предусмотреть
    механизмы для инициализации полей класса. Если значение
    для инициализации неверное, генерируйте исключение.
     */
    class ExceptionCard : ApplicationException
    {
        public ExceptionCard(string message) : base(message) { }
        public ExceptionCard() : this("Ошибка не определена") { }

    }
    class CreditCard
    {
        private string _firstName;
        private string _lastName;
        private string _cvc;
        private DateTime _dateEnd;
        private string _numberCard;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value.IndexOfAny("0123456789".ToCharArray()) != -1)
                    throw new ExceptionCard("в имени содержатся недопустимые символы");
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value.IndexOfAny("0123456789".ToCharArray()) != -1)
                    throw new ExceptionCard("в фамилии содержатся недопустимые символы");
                _lastName = value;
            }
        }
        public string Cvc
        {
            get
            {
                return _cvc;
            }
            set
            {
                if (value.Length != 3) throw new ExceptionCard("длина CVC больше или меньше допустимого значения");
                if (int.TryParse(value, out int i) == false) throw new ExceptionCard("в CVC имеются недопустимые символы");
                _cvc = value;
            }
        }
        public DateTime DateEnd
        {
            get
            {
                return _dateEnd;
            }
            set
            {
                if (value.Year < DateTime.Now.Year) throw new ExceptionCard("срок действия карты истек");
                _dateEnd = value;
            }
        }
        public string NumberCard
        {
            get
            {
                return _numberCard;
            }
            set
            {
                if (value.Length != 16) throw new ExceptionCard("Неверно указан номер карты");
                //if (int.TryParse(value, out int i) == false) throw new ExceptionCard("в номере имеются недопустимые символы");
                _numberCard = SplitNumberCard(value);
            }
        }

        /*public CreditCard() :
            this("0000000000000000",
            "нет_имени", "нет_фамилии",
            "111", DateTime.Now)
        { }*/
        /*public CreditCard(
            string numberCard,
            string firstName,
            string lastName,
            string cvc,
            DateTime dateTime)
        {
            NumberCard = numberCard;
            FirstName = firstName;
            LastName = lastName;
            Cvc = cvc;
            DateEnd = dateTime;
        }*/

        public string Display()
        {
            return String.Format("Номер карты: {0}\n" +
                "Имя владельца: {1, 20:S}\n" +
                "CVC : {2, 20:D}\n" +
                "Срок действия карты: {3, 20:D}\n",
                NumberCard, FirstName + " " + LastName,
                Cvc, DateEnd.Month + "/" + DateEnd.Year);
        }

        private string SplitNumberCard(string str)
        {
            string numStr = "";
            int partSize = str.Length / 4;
            for (int i = 0; i < partSize; i++)
            {
                numStr += str.Substring(i * partSize, partSize) + " ";
            }
            return numStr.Trim();
        }
    }
    internal class Program
    {
        /* static void f1()
         {
             f2();
         }
         static void f2()
         {
             throw new Exception("MyException");
         }
         static void f()
         {
             try
             {
                 f1();
             }
             catch (Exception w)
             {
                 Console.WriteLine(w.Message);
                 Console.WriteLine(w.StackTrace);
             }
         }

         static int DivisionNumbers(int n1, int n2)
         {
             int res = 0;
             try
             {
                 res = n1 / n2;
             }
             catch (DivideByZeroException ex)
             {
                 throw new Exception("Дополнительная информация", ex);
             }
             return res;
         }

         *//*
         Пользователь вводит с клавиатуры в строку набор
         символов от 0-9. Необходимо преобразовать строку в
         число целого типа. Предусмотреть случай выхода за 
         границы диапазона, определяемого типом int. Используйте
         механизм исключений.*/
        /*
        static int InitNum()
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(Console.ReadLine(), 2);
                Console.WriteLine(num);
            }
            catch (FormatException f) { Console.WriteLine(f.Message + $" проблема в переменной {nameof(num)}"); }
            catch (OverflowException f) { Console.WriteLine(f.Message); }

            return num;
        }

        *//*
        Пользователь вводит с клавиатуры в строку набор
        0 и 1. Необходимо преобразовать строку в число целого типа 
        в десятичном представлении. Предусмотреть
        случай выхода за границы диапазона, определяемого
        типом int, неправильный ввод. Используйте механизм
        исключений.*/

        static void Main(string[] args)
        {
            /*int[] arr = new int[5];
            int n = 0;

            *//*try
            {
                for (int i = -3; i <= 3; i++)
                {
                    try
                    {
                        arr[n] = 10 / i;
                        Console.WriteLine(arr[n]);
                        n++;
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }*/

            /*int num1, num2, res = 0;

            try
            {
                num1 = int.Parse(Console.ReadLine());
                num2= int.Parse(Console.ReadLine());

                res = DivisionNumbers(num1, num2);
                Console.WriteLine(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }*/
            /*

            //f();

            //InitNum();
            //InitNum();
            //InitNum();

            *//*byte b = 255;
            float f;
            int i;
            Console.WriteLine(b);
            try
            {
                byte c = checked(((byte)(b + 2)));
                    Console.WriteLine(c);
            }
            catch(OverflowException e) { Console.WriteLine(e.Message); }*/
            /*
            Console.WriteLine(nameof(e.Summer));*/

            try
            {
                CreditCard creditCard1 = new CreditCard
                {
                    NumberCard = "0076453812356221",
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Cvc = "004",
                    DateEnd = new DateTime(2029, 2, 15)
                };
                Console.WriteLine(creditCard1.Display());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            try
            {
                CreditCard creditCard2 = new CreditCard
                {
                    NumberCard = "07645R8123562217",
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Cvc = "004",
                    DateEnd = new DateTime(2029, 2, 15)
                };
                Console.WriteLine(creditCard2.Display());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            try
            {
                CreditCard creditCard3 = new CreditCard
                {
                    NumberCard = "07645О8123562217",
                    FirstName = "Ив2н",
                    LastName = "Иванов",
                    Cvc = "004",
                    DateEnd = new DateTime(2029, 2, 15)
                };
                Console.WriteLine(creditCard3.Display());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            try
            {
                CreditCard creditCard4 = new CreditCard
                {
                    NumberCard = "0764538123562217",
                    FirstName = "Иван",
                    LastName = "Ив6нов",
                    Cvc = "004",
                    DateEnd = new DateTime(2029, 2, 15)
                };
                Console.WriteLine(creditCard4.Display());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            try
            {
                CreditCard creditCard5 = new CreditCard
                {
                    NumberCard = "0764538123562217",
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Cvc = "04",
                    DateEnd = new DateTime(2029, 2, 15)
                };
                Console.WriteLine(creditCard5.Display());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            try
            {
                CreditCard creditCard6 = new CreditCard
                {
                    NumberCard = "0764538123562217",
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Cvc = "w04",
                    DateEnd = new DateTime(2029, 2, 15)
                };
                Console.WriteLine(creditCard6.Display());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            try
            {
                CreditCard creditCard7 = new CreditCard
                {
                    NumberCard = "0764538123562217",
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Cvc = "004",
                    DateEnd = new DateTime(2020, 2, 15)
                };
                Console.WriteLine(creditCard7.Display());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();

            /*try
            {
                CreditCard creditCard8 = new CreditCard("00764538123562217", "", "", "", new DateTime(1, 1, 1));
                creditCard8.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            try
            {
                CreditCard creditCard9 = new CreditCard("00764538123562217", null, null, "000", new DateTime(1, 1, 1));
                creditCard9.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            Console.ReadKey();

        }

    }

}
