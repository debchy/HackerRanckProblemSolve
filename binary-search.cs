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

    /**** Tripple Sum: https://www.hackerrank.com/challenges/triple-sum/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=search
     Given 3 arrays a,b,c of different sizes, find the number of distinct triplets (p,q,r) 
    where p is an element of a, written as p=>a, q=>b , and r=>c, satisfying the criteria: p<=q and q>=r. 

    For example, given a=[3,5,7], b=[3,6] and c=[4,6,9], we find four distinct triplets:
    (3,6,4),(3,6,6),(3,6,9), (5,6,6)
     */
    public class TrippleSum
    {
        // Complete the triplets function below.    
        static long triplets(int[] a, int[] b, int[] c)
        {
            Array.Sort(a);
            Array.Sort(c);

            List<int> a_dic = a.Distinct().ToList();
            List<int> b_dic = b.Distinct().ToList();
            List<int> c_dic = c.Distinct().ToList();

            long matches = 0;
            int aCount = 0, cCount = 0;
            foreach (var bkey in b_dic)
            {
                aCount = BinarySearchSpecial(a_dic, bkey);//a_dic.Count(s=>s<=bkey);
                cCount = BinarySearchSpecial(c_dic, bkey);//c_dic.Count(s=>s<=bkey);
                matches += ((long)aCount * (long)cCount);
                aCount = 0; cCount = 0;
            }
            return matches;
        }

        /*This will return the exact position or 
        if not found it will return The much element is smaller than the key*/
        public static int BinarySearchSpecial(List<int> list, int key)
        {
            int start = 0, end = list.Count - 1, mid = (start + end) / 2;
            while (start <= end)
            {
                if (list[mid] == key) return mid + 1;
                else if (list[mid] < key)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                mid = (start + end) / 2;
            }

            return end + 1;
        }

        
        /** This will compare a key to find the exact element that is greater than it. if not found any greater, it will return -1
         Console.WriteLine(BinarySearchSpecial_getGreater(new List<long>{ 1, 1, 2, 2, 3, 3 }, 2)); => output 3
            Console.WriteLine(BinarySearchSpecial_getGreater(new List<long> { 1, 1, 2, 2, 3, 3 }, 3)); => output -1
            Console.WriteLine(BinarySearchSpecial_getGreater(new List<long> { 1, 1, 2, 2, 3, 3 }, 0)); => output 1
         */
        public static long BinarySearchSpecial_getGreater(List<long> list, long key)
        {
            int start = 0, end = list.Count - 1, mid = (start + end) / 2;
            while (start <= end)
            {
                if (list[mid] <= key)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                mid = (start + end) / 2;
            }

            if (end + 1 < list.Count) return list[end + 1];
            else return -1;
        }
    }
}
