using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelocatedStr
{
    class Program
    {
        static bool IsRelocated(string str1, string str2)
        {
            bool rez = true;
            char[] ch1 = str1.ToCharArray();
            char[] ch2 = str2.ToCharArray();
            if (ch1.Length == ch2.Length)
            {
                for (int i = 0; i < ch1.Length; i++)
                {
                    for (int j = 0; j < ch2.Length; j++)
                    {
                        if (ch1[i] == ch2[j] && ch1[i] != '\0')
                        {
                            ch1[i] = ch2[j] = '\0';
                            break;
                        }
                    }
                }
                for (int i = 0; i < ch1.Length; i++)
                {
                    if (ch1[i] != '\0')
                    {
                        rez = false;
                        break;
                    }
                }
            }
            else
            {
                rez = false;
            }

            return rez;

        }

        static void Main(string[] args)
        {
            String st1 = "kasdfg";
            String st2 = "gfdsad";
            Console.WriteLine("\"{0}\" and \"{1}\" are {2} relocated strings", st1, st2, IsRelocated(st1, st2) ? "" : "not");
            Console.ReadKey();
        }
    }
}
