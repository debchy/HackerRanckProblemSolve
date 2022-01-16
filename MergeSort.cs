using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankingSolution
{
    public class MergeSort
    {
        public static int merge_sort_main(int[] array)
        {
            int swap_count = merge_sort(array, 0, array.Length-1);

            return swap_count;
        }

        /// <summary>
        /// Time Complexity	
        ///     Best O(n* log n)
        ///     Worst O(n* log n)
        ///     Average O(n* log n)
        /// Space Complexity    O(n)
        /// Stability Yes
        /// Ref: https://www.geeksforgeeks.org/merge-sort/
        /// https://www.programiz.com/dsa/merge-sort
        /// code: https://www.geeksforgeeks.org/counting-inversions/
        /// Drawbacks:
        /// Slower comparative to the other sort algorithms for smaller tasks
        /// Merge sort algorithm requires an additional memory space of 0(n) for the temporary array
        /// It goes through the whole process even if the array is sorted
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int merge_sort(int[] array,int left,int right)
        {
            int swap_count=0, middle = 0;
            if (left < right)
            {
                middle = left + (right - left) / 2;
                swap_count += merge_sort(array, left, middle);

                swap_count += merge_sort(array, middle+1,right);

                swap_count += merge(array, left, middle+1, right);
            }            

            return swap_count;
        }

        private static int merge(int[] array,int left,int middle,int right)
        {
            int swap_count = 0;
            int[] temp = new int[right+1];
            int l = left, //left subarray pointer
                r = middle, //right subarray pointer
                n = left;//resultent array pointer

            while(l<=middle-1 && r <= right)
            {
                if (array[l] <= array[r]) {
                    //take from left array and increase left pointer
                    temp[n++] = array[l++];
                }
                else
                {
                    //take from right array and increase right pointer
                    temp[n++] = array[r++];

                    //THIS LOGIC IS TO FIND NUMBER OF SWAPS
                    //if a[l] is greater than a[r], then there are (mid - l) inversions.
                    //because left and right subarrays are sorted,
                    //so all the remaining elements in left-subarray
                    //(a[l+1], a[l+2] ... a[mid]) will be greater than a[r].
                    swap_count += middle - l;
                }
            }

            //Copy the remaining elements of left subarray (if there are any) to temp
            while(l <= middle - 1)
            {
                temp[n++] = array[l++];
            }

            //Copy the remaining elements of right subarray (if there are any) to temp
            while (r <= right)
            {
                temp[n++] = array[r++];
            }

            //transfer temp to main array
            for(int i = left; i <= right; i++)
            {
                array[i] = temp[i];
            }

            return swap_count;
        }
    }
}
