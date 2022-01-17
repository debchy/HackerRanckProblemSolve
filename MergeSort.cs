using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankingSolution
{
    public class MergeSort
    {
        public static long merge_sort_main(int[] array)
        {
            long swap_count = merge_sort(array.ToList<int>());

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
        /// optimized: https://allhackerranksolutions.blogspot.com/2019/02/merge-sort-counting-inversions-hacker.html#:~:text=In%20an%20array%2C%20%2C%20the%20elements,we%20can%20swap%20adjacent%20elements.&text=Given%20datasets%2C%20print%20the%20number,dataset%20on%20a%20new%20line.
        /// 
        /// Drawbacks:
        /// Slower comparative to the other sort algorithms for smaller tasks
        /// Merge sort algorithm requires an additional memory space of 0(n) for the temporary array
        /// It goes through the whole process even if the array is sorted
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static long merge_sort(List<int> array)
        {
            long swap_count = 0;
            //base case
            if (array.Count <= 1) return 0;

            //recursive case
            int middle = array.Count / 2;
            List<int> left_a = array.GetRange(0,middle);
            swap_count += merge_sort(left_a);

            List<int> right_a = array.GetRange(middle,array.Count- middle);
            swap_count += merge_sort(right_a);

            //swap_count += merge(array, left_a, right_a);
            swap_count += merge_opt(array, left_a, right_a, middle);
            
            return swap_count;
        }

        private static long merge(List<int> main_arr, List<int> left_arr, List<int> right_arr)
        {
            long swap_count = 0;
            int i=0, j=0, n = 0;
            int left_len = left_arr.Count;
            int right_len = right_arr.Count;

            while(i<left_len && j < right_len)
            {
                if (left_arr[i] <= right_arr[j])
                {
                    main_arr[n++] = left_arr[i++];
                }
                else
                {
                    main_arr[n++] = right_arr[j++];
                    //THIS LOGIC IS TO FIND NUMBER OF SWAPS
                    //if a[l] is greater than a[r], then there are (mid - l) inversions.
                    //because left and right subarrays are sorted,
                    //so all the remaining elements in left-subarray
                    //(a[l+1], a[l+2] ... a[mid]) will be greater than a[r].
                    swap_count += left_len - i;
                }
            }
            //Copy the remaining elements of left subarray (if there are any) to main array
            while (i < left_len)
            {
                main_arr[n++] = left_arr[i++];
            }

            //Copy the remaining elements of right subarray (if there are any) to main array
            while (j<right_len)
            {
                main_arr[n++] = right_arr[j++];
            }

            return swap_count;
        }

        private static long merge_opt(List<int> main_arr, List<int> left_arr, List<int> right_arr, int mid)
        {            
            long swap_count = 0;
            int arr_length = main_arr.Count;
            int left_ptr = 0, right_ptr = 0, right_range = arr_length - mid;

            for(int i = 0; i < arr_length; i++)
            {
                if (left_ptr < mid && (right_ptr >= right_range || left_arr[left_ptr]<=right_arr[right_ptr]))
                {
                    main_arr[i] = left_arr[left_ptr++];
                    swap_count += right_ptr;
                }
                else if (right_ptr < right_range)
                {
                    main_arr[i] = right_arr[right_ptr++];
                }
            }

            return swap_count;
        }
    }
}
