using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Program
    {
        private static Dictionary<int, char[]> D =
            new Dictionary<int, char[]>
            {
                [0] = new char[] { '+' },
                [1] = new char[] { '_', ',', '@' },
                [2] = new char[] { 'A', 'B', 'C' },
                [3] = new char[] { 'D', 'E', 'F' },
                [4] = new char[] { 'G', 'H', 'I' },
                [5] = new char[] { 'J', 'K', 'L' },
                [6] = new char[] { 'M', 'N', 'O' },
                [7] = new char[] { 'P', 'Q', 'R', 'S' },
                [8] = new char[] { 'T', 'U', 'V' },
                [9] = new char[] { 'W', 'X', 'Y', 'Z' },
            };


        public static string[] GetNames(int[] phone)
        {
            List<string> result = new List<string>();
            EachLetter(phone,0,ref result,"");
            return result.ToArray();
        }

        private static void EachLetter(int[] phone, int index ,ref List<string> result,string value)
        {
            foreach (char c in D[phone[index]])
            {
                value += c;
                if (index == phone.Length-1)
                    result.Add(value);
                else
                    EachLetter(phone, index + 1,ref result, value);
                value=value.Remove(value.Length - 1,1);
            }
            if (result.Last().First() == D[phone[phone.Length - 1]].Last())
                return;
        }
        static void Main(string[] args)
        {
            int[] phoneNumber = new int[] {0, 9, 1, 2, 2, 2, 4, 2, 5, 2, 5 };

            // چاپ یک رشته حرفی برای شماره تلفن
            for (int i=0; i< phoneNumber.Length; i++)
                Console.Write(D[phoneNumber[i]][0]);
            Console.WriteLine();
        }


    }
}
