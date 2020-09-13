using System;
using System.Linq;

namespace Moscal
{
    public class Struct
    {
        public DateTime FirstField { get; private set; }
        public DateTime SecondField { get; private set; }
        public Struct(DateTime first, DateTime second)
        {
            FirstField = first;
            SecondField = second;
        }
    }
    class Program
    {
        static Struct[] Sort(Struct[] dates)
        {
            for (int indexFirst = 0; indexFirst < dates.Count(); indexFirst++)
            {
                int indexMax = 0;
                for (int indexSecond = 0; indexSecond < dates.Count() - indexFirst; indexSecond++)
                {
                    if (dates[indexSecond].FirstField > dates[indexMax].FirstField)// если первая дата больше
                    {
                        indexMax = indexSecond;
                    }
                    else if (dates[indexSecond].FirstField == dates[indexMax].FirstField) // если первая дата равная
                    {
                        if (dates[indexSecond].SecondField > dates[indexMax].SecondField) // если вторая дата больше
                        {
                            indexMax = indexSecond;
                        }
                    }
                }
                Struct extraVar = dates[indexMax]; // перенос в конец максимум
                dates[indexMax] = dates[dates.Count() - indexFirst - 1];
                dates[dates.Count() - indexFirst - 1] = extraVar;
            }
            return dates;
        }
        static void Main(string[] args)
        {
            // записать заполнение и вызов сортировки массива
            Console.WriteLine("Enter count of dates to random: "); // ввод кол-ва элементов
            int count = Convert.ToInt16(Console.ReadLine());
            Struct[] dates = new Struct[count];
            Random random = new Random();
            Console.WriteLine("Array before sort:");
            for (int index = 0; index < count; index++) // генерация дат в цикле
            {
                int month = random.Next(1, 12);
                int day = random.Next(1, 31);
                int year = random.Next(1, 4000);
                DateTime firstField = new DateTime(year, month, day);
                month = random.Next(1, 12);
                day = random.Next(1, 31);
                year = random.Next(1, 4000);
                DateTime secondField = new DateTime(year, month, day);
                dates[index] = new Struct(firstField, secondField);
                Console.Write(dates[index].FirstField);
                Console.Write("   ");
                Console.WriteLine(dates[index].SecondField);
            }            
            dates = Sort(dates); // сортировка
            Console.WriteLine("Array after sort:");
            for (int index = 0; index < count; index++)
            {
                Console.Write(dates[index].FirstField);
                Console.Write("   ");
                Console.WriteLine(dates[index].SecondField);
            }
        }
    }
}
