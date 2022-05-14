using System;
using System.Collections.Generic;

namespace asdfteste
{
    internal class Program
    {
        delegate void Printer();

        static void Main(string[] args)
        {
            List<Printer> printes = new List<Printer>();
            int i = 0;
            for (; i < 10; i++)
            {
                printes.Add(delegate 
                {
                    Console.WriteLine(i);
                });
            }

            foreach (var printer in printes)
            {
                printer();
            }
        }
    }
}
