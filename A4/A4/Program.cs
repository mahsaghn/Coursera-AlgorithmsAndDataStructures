using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A4
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static long ChangingMoney1(long money)
        {
            long coinNum = 0;
            long[] coins = new long[] { 10, 5, 1 };
            foreach (long coin in coins)
            {
                coinNum += money / coin;
                money %= coin;
            }
            return coinNum;
        }

        public static string ProssesChangingMoney1(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)ChangingMoney1);

        public static long MaximizingLoot2(long capacity, long[] weights, long[] values)
        {
            float value = 0;
            List<long> weightsList = weights.ToList();
            List<float> valuePerWeights = new List<float>(weights.Count());
            for (int i = 0; i < weights.Count(); i++)
            {
                valuePerWeights.Add( values[i] /(float) weights[i]);
            }
            float maxVpw = 0;
            long maxWeight = 0;
            int index = 0;
            while (capacity > 0)
            {
                maxVpw = 0;
                index = 0;
                for (int i = 0; i < valuePerWeights.Count(); i++)
                    if (valuePerWeights[i] > maxVpw)
                    {
                        maxVpw = valuePerWeights[i];
                        maxWeight = weightsList[i];
                        index = i;
                    }
                valuePerWeights.RemoveAt(index);
                weightsList.RemoveAt(index);
                if (maxWeight >= capacity)
                {
                    value += maxVpw * capacity;
                    capacity = 0;
                }
                else
                {
                    value += maxVpw * maxWeight;
                    capacity -= maxWeight;
                }
            }
            return (long)value;
        }

        public static string ProssesMaximizingLoot2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingLoot2);

        public static long MaximizingOnlineAdRevenue3(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            long value = 0;
            for (int i = 0; i < adRevenue.Count(); i++)
            {
                for (int j = i; j < adRevenue.Count(); j++)
                {
                    if (adRevenue[j] > adRevenue[i])
                    {
                        long h = adRevenue[j];
                        adRevenue[j] = adRevenue[i];
                        adRevenue[i] = h;

                    }   
                }
            }
            for (int i = 0; i < averageDailyClick.Count(); i++)
            {
                for (int j = i; j < averageDailyClick.Count(); j++)
                {
                    if (averageDailyClick[j] > averageDailyClick[i])
                    {
                        long h = averageDailyClick[j];
                        averageDailyClick[j] = averageDailyClick[i];
                        averageDailyClick[i] = h;

                    }
                }
                value += averageDailyClick[i] * adRevenue[i];

            }
            return value;
        }

        public static string ProssesMaximizingOnlineAdRevenue3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingOnlineAdRevenue3);

        public static long CollectingSignatures4(long tenantCount, long[] startTimes, long[] endTimes)
        {
            List<long> StartTimes = startTimes.ToList();
            List<long> EndTimes = endTimes.ToList();
            long first = 0;
            long last = 0;
            long times = 0;
            long minStart;
            int index = 0;
            while (StartTimes.Count() > 0)
            {
                minStart = StartTimes[0];
                for (int i = 0; i < StartTimes.Count(); i++)
                {
                    if (StartTimes[i] <= minStart)
                    {
                        index = i;
                        minStart = StartTimes[i];
                    }
                }
                if (minStart > last)
                {
                    times++;
                    first = minStart;
                    last = EndTimes[index];
                }
                else
                {
                    if (minStart > first)
                        first = minStart;
                    if (EndTimes[index] < last)
                        last = EndTimes[index];
                }
                StartTimes.RemoveAt(index);
                EndTimes.RemoveAt(index);
            }
            return times;
        }

        public static string ProssesCollectingSignatures4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)CollectingSignatures4);

        public static long[] MaximizeNumberOfPrizePlaces5(long n)
        {
            int i;
            for (i = 0; i < n; i++)
                if (i * (i + 1) / 2 > n)
                    break;
            i--;
            long[] values = new long[i];
            for (int j = 0; j < i; j++)
                values[j] = j + 1;
            values[i - 1] += (n - (i * (i + 1) / 2));
            return values;
        }

        public static string ProssesMaximizeNumberOfPrizePlaces5(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)MaximizeNumberOfPrizePlaces5);

        public static string MaximizeSalary6(long n, long[] numbers)
        {
            int index;
            List<long> numbersList= numbers.ToList();
            string answer = null;
            long maxDigit;
            while(numbersList.Count() >0)
            {
                maxDigit = numbersList[0];
                index = 0;
                for(int i=0;i<numbersList.Count();i++)
                {
                    if(IsMaxDigitOrEqual(numbersList[i],maxDigit))
                    {
                        maxDigit = numbersList[i];
                        index = i;
                    }
                }
                answer += maxDigit;
                numbersList.RemoveAt(index);
            }
            return answer;
        }

        private static bool IsMaxDigitOrEqual(long digit,long maxDigit)
        {
            string Digit = digit.ToString(),
                MaxDigit = maxDigit.ToString();
            long a = long.Parse(Digit + MaxDigit);
            long b = long.Parse(MaxDigit + Digit);
            if (a > b)
                return true;
            return false;
        }

        public static string ProssesMaximizeSalary6(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) MaximizeSalary6);

    }
}
