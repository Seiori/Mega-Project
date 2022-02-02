using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega_Project.Numbers
{
    class FindPi
    {
        public static void NthPi()
        {
            //Setting up the Menu UI
            Console.Clear();
            Console.WriteLine("Please Enter the Nth Value of Pi you Would like to Find");

            string input = Console.ReadLine();
            int NthValue = CalculatePi(Int32.Parse(input) - 1);

            Console.WriteLine();
            Console.WriteLine("Number" + input + " in the Pi Sequence is " + NthValue);
            Console.WriteLine();
            Console.WriteLine("If you Would like to go Again, Press 1. Otherwise, Press 2");

            string Choice = Console.ReadLine();

            if (Choice == "1")
            {
                NthPi();
            }
            else if (Choice == "2")
            {
                Console.Clear();
                Program.Main();
            }  
        }
        public static int CalculatePi(int pos)
        {
            List<int> result = new List<int>();
            int digits = 100;
            int[] x = new int[digits * 3 + 2];
            int[] r = new int[digits * 3 + 2];

            for (int j = 0; j < x.Length; j++)
            {
                x[j] = 20;
            }

            int prev = 0;

            for (int i = 0; i < digits; i++)
            {
                int carry = 0;

                for (int j = 0; j < x.Length; j++)
                {
                    int num = (int)(x.Length - j - 1);
                    int dem = num * 2 + 1;
                    x[j] += carry;
                    int q = x[j] / dem;
                    r[j] = x[j] % dem;
                    carry = q * num;
                }

                //Calculate the Digit, but dont Add to the List Right Away
                int digit = (int)(x[x.Length - 1] / 10);

                //Handle Overflow
                if (digit >= 10)
                {
                    digit -= 10;
                    prev++;
                }

                if (i > 0)
                {
                    result.Add(prev);
                }

                //Store the Digit for Next Time, when it Will be the Previous Value

                prev = digit;
                r[x.Length - 1] = x[x.Length - 1] % 10;

                for (int j = 0; j < x.Length; j++)
                {
                    x[j] = r[j] * 10;
                }
            }
            return result[pos];
        }
    }
}
