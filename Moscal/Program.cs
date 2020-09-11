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
                    if (dates[indexSecond].FirstField > dates[indexMax].FirstField)
                    {
                        indexMax = indexSecond;
                    }
                    else if (dates[indexSecond].FirstField == dates[indexMax].FirstField)
                    {
                        if (dates[indexSecond].SecondField > dates[indexMax].SecondField)
                        {
                            indexMax = indexSecond;
                        }
                    }
                }
                Struct extraVar = dates[indexMax];
                dates[indexMax] = dates[dates.Count() - indexFirst - 1];
                dates[dates.Count() - indexFirst - 1] = extraVar;
            }
            return dates;
        }
        static void Main(string[] args)
        {
            // записать заполнение и вызов сортировки массива
        }
    }
}
