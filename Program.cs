// Домашка Питецкого Владимира
/*Реализуйте класс Дробь. Необходимо хранить числитель и знаменатель в качестве переменных-членов.Реализуйте
функции-члены для ввода данных в переменные-члены, для выполнения арифметических операций(сложение,
вычитание, умножение, деление, и т.д.).*/
using System;
using static System.Console;
namespace calculateHell
{
    public class Fraction
    {
        public double a, b, c;//c нужно для проверки тру кетч
        public string Error = "Красавчик, вот твоя дробь!";//сообщение по умолчанию, но ошибка может его изменить
        public Fraction()//значения по умолчинию
        {
            a = 1;
            b = 99;
            InputFraction(a, b);
        }
        public Fraction(double a, double b)//конструктор
        {
            InputFraction(a, b);
        }
        public void InputFraction(double a, double b)//ручной ввод, он же проверка на вшивость
        {
            this.a = a;
            try
            {
                this.b = b;
                c = a / b;
            }
            catch (DivideByZeroException)// это штука проверяет математические ошибки, а именно деление на ноль.
            {
                Error = "Вай вай вай, все сломал, все поломал";
                Console.WriteLine("Ошибка 0, на ноль делить нельзя!");
            }
        }
        public double result()//дает нам дробь в виде числа с плавующей точкой, и позволяет делать вычисления.
        {
            return a / b;
        }
        public double[] GetFraction() //функция возвращает два числа для просмотра. Это как гетер, только сразу на 2 числа
        {
            double[] numbers = new double[2];
            numbers[0] = a;
            numbers[1] = b;
            return numbers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {           
            WriteLine("Давайте создадим дробь, это будет очень увлекательно!");
            double[] number = new double[2];
            WriteLine("Введите числитель, это та что сверху");
            number[0] = ErrorCatch();//эта функция проверят, что вы жмете именно цифры,а не все что под руку попало
            WriteLine("Введите знаменатель, это та что снизу");
            number[1] = ErrorCatch();//эта функция проверят, что вы жмете именно цифры,а не все что под руку попало
            WriteLine("Идет сотворение дроби");
            Fraction gus = new Fraction(number[0], number[1]);//создаем экземпляр класса.
            WriteLine(gus.Error);//выводим сообщение проверки на ошибки.
            WriteLine(gus.result());//выводим дробь в виде числа.
            ShowFraction(gus);// выводим дробь в виде дроби.
        agane:
            WriteLine("Хочешь сотворить с этой дробью всякое?\nНажми Enter что бы принять или Esc что бы откзаться");
            ConsoleKeyInfo getch = ReadKey(true);//Чуть не помер пока все понял. 
            //это альтернатива _getch() в с++, но только очень крутая. 
            //мы сперва отлавливаем нажатую кнопку, и помещаем информацию в переменную КонсольИнфо. 
            //Можно было бы просто в иф-элс запихнуть РидКей, но это функция. И она бы каждый раз инициализировалась бы.
            //А так все отлично работает.
            if (getch.Key == ConsoleKey.Enter)
            {
                do { Clear(); }
                while (Menu(SetMenu(), gus)); 
            }
            else if (getch.Key == ConsoleKey.Escape)
            {
                WriteLine("Очень жаль = (");
            }
            else
            {
                WriteLine("Неправильно набрана кнопка, тру эгейн лэтер...\n");
                goto agane;//да да, тут я использовал гото в качестве эксперемента, и оно работает. В других местах я пользоволся дувайлом.
            }
            
            static void ShowFraction(Fraction fraction)//функция выводит на экран данные экз.класса в виде дроби.
            {
                double[] AB = new double[2];//я знаю что это бессмыслено и можно сделать все короче на 2 строки.
                AB = fraction.GetFraction();//можно вообще обойтись без пары этих функций. Но если классов будет много, они пригодятся.
                WriteLine(AB[0] + "/" + AB[1]);
            }
            static int SetMenu()//выбор стрелками
            {
                char s = Convert.ToChar(16); // задаем рисунок стрелочку
                char[] cursor = new char[5] { s, ' ', ' ', ' ', ' '};//задаем поле для курсора
                int x = 0;//coordinate cursor
                String[] setMenu = new string[5] { "Сложение", "Вычитание", "Умножене", "Деление", "Выход из программы" };//пункты меню
                do
                {
                    for (int i = 0; i < 5; i++)
                    {
                        WriteLine(cursor[i] + " " + setMenu[i]);//выводит меню на экран.                        
                    }
                    cursor[x] = ' ';//очищает поле для курсора.
                    WriteLine("\nСделайте выбор стрелками вверх или вниз. Подтвердить - Enter");
                    ConsoleKeyInfo getch = ReadKey(true);//хватает стрелки
                    if (getch.Key == ConsoleKey.UpArrow)
                    {
                        if (x > 0) { x--; } else { x = 4; }//стрелка вверх(курсор перескакивает вниз, когда достигает верхней точки
                    }
                    else if (getch.Key == ConsoleKey.DownArrow)
                    {
                        if (x < 4) { x++; } else { x = 0; }//стрелка вниз(курсор перескакивает вверх, когда достигает дна
                    }else if (getch.Key == ConsoleKey.Enter) { return x; }//при нажатии Энтр, завершаем цикл и возвращаем координаты для меню со свичем.
                    cursor[x] = s;//на основе нехитрых вычислений, задаем координаты курсору
                    Clear();//очищаем экран, ведь при следующем цикле откроется меню снова.
                } while (true);
               
            }
            static double ErrorCatch()//ловим ошибки нажатия букав и штук вместо цифры. 
            {//он устроен так, что ни чего не принимает, ведь ошибка крашит программу в момент нажатия неверной кнопки.
                bool error = false;
                double num = 0;
                do
                {                  
                    error = false;
                    try
                    {
                        num = Convert.ToInt32(ReadLine());//он протис ввести число
                    }
                    catch (Exception)//ловит такие ошибки типа, ошибки.
                    {
                        WriteLine("Не туда жмешь!");//нажал букву и все, конец. Хотя нет. Цикл повторится
                        error = true;
                    }
                } while (error == true);//пока не нажмешь нужную кнопку даже не надейся отвертется.
                return num;//возвращает чистенькое число
            }
            static bool Menu(int choice,Fraction fract)//сама менюшка, варианты действий. 
            { bool repeat = false;
                double x = 0;
                switch (choice)
                {
                    case 0:
                        do
                        {
                            WriteLine("Сложение");
                            WriteLine("Введите число с которым будем складывать");
                            x = ErrorCatch();
                            WriteLine($"результат = {fract.result() + x}");//ну тут вроде все понятно
                            WriteLine("\nПовторить?\n Enter - повторить, что бы завершить жми любую другую");
                            if (ReadKey(true).Key == ConsoleKey.Enter) { repeat = true; } else { repeat = false; }
                        } while (repeat != false);//даю возможность поработать с дробью.
                        return true;
                    case 1:
                        do
                        {
                            WriteLine("Вычитание");
                        WriteLine("Введите число которое будем вычитать");
                        x = ErrorCatch();
                            WriteLine($"результат = {fract.result() - x}");
                            WriteLine("\nПовторить? - Enter\nЧто бы вернуться в прошлое меню жми любую другую");
                            if (ReadKey(true).Key == ConsoleKey.Enter) { repeat = true; } else { repeat = false; }
                        } while (repeat != false);
                        return true;
                    case 2:
                        do
                        {
                            WriteLine("Умножение");
                        WriteLine("Введите число на которое будем умножать");
                        x = ErrorCatch();
                            WriteLine($"результат = {fract.result() * x}");
                            WriteLine("\nПовторить? - Enter\nЧто бы вернуться в прошлое меню жми любую другую");
                            if (ReadKey(true).Key == ConsoleKey.Enter) { repeat = true; } else { repeat = false; }
                        } while (repeat != false);
                        return true;
                    case 3:
                        do
                        {
                            WriteLine("Деление");
                        WriteLine("Введите число которое будем делить");
                        x = ErrorCatch();
                            WriteLine($"результат = {fract.result() / x}");
                            WriteLine("\nПовторить? - Enter\nЧто бы вернуться в прошлое меню жми любую другую");
                            if (ReadKey(true).Key == ConsoleKey.Enter) { repeat = true; } else { repeat = false; }
                        } while (repeat != false);
                        return true;
                    case 4:
                        WriteLine("Досвидания!");
                        return false;
                       
                    default://оставил для красоты, но можно удалить.
                        WriteLine("Default case");
                        return true;                  
                       }                
            }
            static void helperButton()//функция которая показывает как программа понимает, какие кнопки нажимаешь
            {//да, это функция помошник, я ее написал, что бы понять как работает захват кнопок. 
                while (true)//путем эксперементов я все же добился результата
                {// ее можно немного доработать что бы увидеть код символа в таблице аске, но тут это особо не нужно.
                    ConsoleKeyInfo cki;//такие микрокоды всегда стараюсь сохранять на облаке. 
                    cki = ReadKey();
                    WriteLine();
                    WriteLine(cki.Key + " " + cki.KeyChar);
                };
            }
           }
    }
}
