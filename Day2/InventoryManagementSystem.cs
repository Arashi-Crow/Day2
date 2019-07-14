using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day2
{
    class InventoryManagementSystem
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("UtilityCloset.txt");
            string[] codes = sr.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            PartA(codes);
            PartB(codes);
            Console.ReadKey();
        }

        private static void PartA(string[] codes)
        {
            int two = 0;
            int three = 0;
            Dictionary<char, int> repeatedChars = new Dictionary<char, int>();
            foreach (string code in codes)
            {
                foreach (char c in code.ToCharArray())
                {
                    repeatedChars.TryGetValue(c, out int i);
                    repeatedChars[c] = i + 1;
                }
                if (repeatedChars.ContainsValue(2))
                {
                    two++;
                }
                if (repeatedChars.ContainsValue(3))
                {
                    three++;
                }
                repeatedChars.Clear();
            }
            Console.WriteLine("Part A ");
            Console.WriteLine($"Checksum {two} * {three} = {two * three}");
        }

        private static void PartB(string[] codes)
        {
            int distance = 0;
            StringBuilder boxId = new StringBuilder();
            string common = "";
            foreach (string code1 in codes)
            {
                foreach (string code2 in codes)
                {
                    for (int i = 0; i < code1.Length; i++)
                    {
                        if (code1[i] != code2[i])
                        {
                            if (distance++ > 1)
                            {
                                break;
                            }
                        }
                        else
                        {
                            boxId.Append(code1[i]);
                        }
                    }

                    if (distance == 1)
                    {
                        common = boxId.ToString();
                        break;
                    }
                    distance = 0;
                    boxId.Clear();
                }
            }
            Console.WriteLine("Part B ");
            Console.WriteLine("Correct BoxId= " + common);

        }


    }
}
