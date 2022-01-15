using System;
using System.Collections.Generic;
using System.Linq;
class Result
{
    public static void Main()
    {
        
        //Console.WriteLine(activityNotifications(new List<int> { 1, 2, 4, 4, 5, 6, 7, 8 }, 4));
        Console.WriteLine(activityNotifications(new List<int> { 2, 3, 4, 2, 3, 6, 8, 4, 5 }, 5));

    }
        /// <summary>
        /// https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
        /// Solutuion: https://medium.com/weekly-webtips/sorting-code-challenge-breakdown-19229b32be02
        ///If the amount spent by a client on a particular day is greater than or equal to 
        ///twice (2x) the median spending amount of a specified number of trailing days—days 
        ///which precede the present day—the bank will send the client a notification of potential
        /// fraudulent activity. 
        ///</summary>
        /// <param name="expenditure"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int activityNotifications(List<int> expenditure, int d)
        {
            int[] countCalculator=new int[expenditure.Max()+1];
            //do the calculation of total expenditure for first period(d)
            for(int i = 0; i < d; i++)
            {
                countCalculator[expenditure[i]]++;
            }

            int numberOfNotice = 0;
            for (int i = 0; i < expenditure.Count - d ; i++)
            {
                List<int> sub = expenditure.GetRange(i, d);
                float median = FindMedianOpt(countCalculator,d);
                if (median * 2 <= expenditure[i + d ]) numberOfNotice++;
                countCalculator[expenditure[i]]--;
                countCalculator[expenditure[i+d]]++;

            }
            return numberOfNotice;
        }
        //The median of a list of numbers can be found by first sorting the numbers ascending.
        //If there is an odd number of values, the middle one is picked. 
        //If there is an even number of values, the median is then defined 
        //to be the average of the two middle values.
        public static float FindMedian(List<int> list)
        {
            list.Sort();
            if (list.Count % 2 != 0) return list[(int)Math.Ceiling((decimal)list.Count / 2)];
            else
            {
                return (float)(list[list.Count / 2] + list[(list.Count / 2) - 1]) / 2;
            }
        }

        public static float FindMedianOpt(int[] list,int duration)
        {
            int sum_of_day = 0;
            for(int i = 0; i < list.Length; i++)
            {
                sum_of_day += list[i];
                if (sum_of_day * 2 > duration) return i;//odd number of duration. so median achived
                else if (sum_of_day * 2 == duration)
                {
                    var j = i+1;
                    while (list[j] == 0 && j< list.Length) j++;
                    return (float)(i + j) / 2;
                }
            }
            return 0;
        }

}