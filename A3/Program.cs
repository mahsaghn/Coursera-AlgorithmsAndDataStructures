using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Program
    {
        static void Main(string[] args)
        {
           
        }

        public static string Process(string inStr,Func<long,long> longProcessor)
        {
            long n = long.Parse(inStr);
            return longProcessor(n).ToString();
        }

        public static string Process(string inStr, Func<long,long,long> longProcessor)
        {
            var toks = inStr.Split(new char[] {' ' , '\n'} , StringSplitOptions.RemoveEmptyEntries);
            long a = long.Parse(toks[0]);
            long b = long.Parse(toks[1]);
            return longProcessor(a, b).ToString();
        }

        public static long Fibonacci(long n)
        {
            long[] fib = new long[n+1];
            fib[0] = 0;
            if(n>0)
                fib[1] = 1;
            for(int i=2; i<=n;i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }
            return fib[n];
        }

        public static string ProcessFibonacci(string inStr) =>
            Process(inStr, Fibonacci);

        public static long Fibonacci_LastDigit(long n)
        {
            long[] fib = new long[n + 1];
            fib[0] = 0;
            if (n > 0)
                fib[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                fib[i] = (fib[i - 1] + fib[i - 2])%10;
            }
            return fib[n]%10;
        }

        public static string ProcessFibonacci_LastDigit(string inStr) =>
            Process(inStr, Fibonacci_LastDigit);

        public static long GCD(long a, long b)
        {
            long n=0;
            while(b>0)
            {
                n = a % b;
                a = b;
                b = n;
            }
            return a;
        }

        public static string ProcessGCD(string inStr) =>
            Process(inStr, GCD);

        public static long LCM(long a,long b)
        {
            return a*b /GCD(a,b);
        }

        public static string ProcessLCM(string inStr) =>
            Process(inStr, LCM);

        public static long Fibonacci_Mod(long n,long m)
        {
            bool check = false;
            List<long> fib = new List<long>();
            fib.Add(0);
            if(n>0)
                fib.Add(1);
            int i;
            for (i = 2; i <= n; i++)
            {
                fib.Add((fib[i - 1] + fib[i - 2]) % m);
                if (fib[i - 1] == 0 && fib[i] == 1)
                {
                    check = true;
                    break;
                }
            }
            long a;
            if (check)
                a = n % (i - 1);
            else
                a = n;
            return fib[int.Parse(a.ToString())];
        }

        public static string ProcessFibonacci_Mod(string inStr) =>
            Process(inStr, Fibonacci_Mod);

        public static long Fibonacci_Sum(long n)
        {
            bool check = false;
            long sum = 0;
            List<long> fib = new List<long>();
            fib.Add(0);
            if (n > 0)
            {
                fib.Add(1);
                sum++;
            }
            int i;
            for (i = 2; i <= n; i++)
            {
                fib.Add((fib[i - 1] + fib[i - 2]) % 10);
                sum += fib[i];
                if (fib[i - 1] == 0 && fib[i] == 1)
                {
                    check = true;
                    sum--;
                    break;
                }
            }
            sum = sum % 10;
            if (check)
            {
                long resault = 0; ;
                for (int j = 0; j <= n % (i - 1); j++)
                    resault += fib[j];
                return ((n / i) * sum + resault) % 10;
            }
            return sum;
        }

        public static string ProcessFibonacci_Sum(string inStr) =>
            Process(inStr, Fibonacci_Sum);

        public static long Fibonacci_Partial_Sum(long n,long m)
        {
            long sum;
            if(m>n)
            {
                sum = m;
                m = n;
                n = sum;
            }
            long a = Fibonacci_Sum(n);
            a += 10;
            long b = Fibonacci_Sum(m - 1);
            return (a-b)%10;
        }

        public static string ProcessFibonacci_Partial_Sum(string inStr) =>
            Process(inStr, Fibonacci_Partial_Sum);

        public static long Fibonacci_Sum_Squares(long n)
        {
            long a=
                Fibonacci_Mod(n,10) * (Fibonacci_Mod(n,10) + Fibonacci_Mod(n - 1,10));
            return a % 10;
        }

        public static string ProcessFibonacci_Sum_Squares(string inStr) =>
            Process(inStr, Fibonacci_Sum_Squares);




    }
}
