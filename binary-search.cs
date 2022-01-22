using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class binary_search
    {
        public static int BinarySearch(List<int> list, int key, int stIndex = 0)
        {
            int start = stIndex, end = list.Count - 1, mid = (start + end) / 2;

            while (start <= end)
            {
                if (list[mid] == key) return mid;
                else if (key < list[mid])
                {
                    end = mid-1;
                    mid = (start + end) / 2;
                }
                else
                {
                    start = mid+1;
                    mid = (start + end) / 2;
                }
            }
            return -1;

        }
        
        /// <summary>
        /// Binary search approach.
        /// first take the index of each element of cost list. then sort it 
        /// binary search of moeny-c[i]. if found print both index
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="money"></param>
        public static void whatFlavors1(List<int> cost, int money)
        {
            List<KeyValuePair<int, int>> costDic = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < cost.Count; i++)
            {
                costDic.Add(new KeyValuePair<int, int>(cost[i], i));
            }

            cost.Sort();
            // for(int i=0;i<costDic.Count;i++){
            //     Console.WriteLine(costDic[i].Key+"=>"+costDic[i].Value);
            // }
            for (int i = 0; i < cost.Count - 1; i++)
            {
                int next = money - cost[i];
                Console.Write("next=" + next + " ");
                if (next > 0)
                {

                    int nextI = BinarySearch(cost, next, i + 1);
                    Console.Write("nextI=" + nextI + " ");
                    if (nextI > 0)
                    {
                        int first = 0, second = 0;
                        foreach (var elem in costDic)
                        {
                            if (elem.Key == cost[i]) first = elem.Value;
                            else if (elem.Key == cost[nextI]) second = elem.Value;
                        }
                        if (first < second) Console.WriteLine((first + 1) + " " + (second + 1));
                        else Console.WriteLine((second + 1) + " " + (first + 1));
                        break;
                    }
                }

            }
        }

        //optimized
        /// <summary>
        /// Hash Tables: Ice Cream Parlor
        /// https://www.hackerrank.com/challenges/ctci-ice-cream-parlor/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=search
        /// Each time Sunny and Johnny take a trip to the Ice Cream Parlor, they pool their 
        /// money to buy ice cream. On any given day, the parlor offers a line of flavors. 
        /// Each flavor has a cost associated with it.
        /// Given the value of "money" and the "cost" of each flavor.
        /// help Sunny and Johnny choose two distinct flavors such that they spend their 
        /// entire pool of money during each visit.
        /// print the ID numbers for the two types of ice cream that Sunny and Johnny purchase
        /// 
        /// Solution:
        /// count the frequency of the numbers.
        /// money-ci=cj
        /// find cj in the cost list. if contains then two condition-
        /// if ci!=cj, pick the position of ci and cj
        /// if ci==cj, check ci has more than 1 occurance, then take the both index
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="money"></param>
        public static void whatFlavors(List<int> cost, int money)
        {
            Dictionary<int, int> costDic = new Dictionary<int, int>();
            for (int i = 0; i < cost.Count; i++)
            {
                if (costDic.ContainsKey(cost[i])) costDic[cost[i]]++;
                else costDic.Add(cost[i], 1);
            }

            for (int i = 0; i < cost.Count - 1; i++)
            {
                int first = 0, second = 0;
                int next = money - cost[i];
                //Console.Write("next=" + next + " ");
                if (next > 0 && costDic.ContainsKey(next) && next != cost[i])
                {
                    first = i + 1;
                    second = cost.IndexOf(next) + 1;
                    Console.WriteLine(first + " " + second);
                    break;
                }
                else if (next > 0 && costDic.ContainsKey(next) && next == cost[i] && costDic[next] > 1)
                {
                    first = i + 1;
                    second = cost.IndexOf(next, i + 1) + 1;
                    Console.WriteLine(first + " " + second);
                    break;
                }

            }
        }
    }
}
