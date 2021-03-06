using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System;
namespace HackerRank
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World"[0]+(3%5).ToString());
            checkMagazine(new List<string>{"give", "me", "one", "grand", "today", "night"},
            new List<string>{"give", "one", "today", "night"});
        }
        
        /* checkMagazine    * https://www.hackerrank.com/challenges/ctci-ransom-note/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        * Match exact words between two sentence.
        *
        * The function accepts following parameters:
        *  1. STRING_ARRAY magazine
        *  2. STRING_ARRAY note
        */

        public static void checkMagazine(List<string> magazine, List<string> note)
        {
            var answer="Yes";
            Dictionary<string, int> note_dic=new Dictionary<string, int>();
            Dictionary<string, int> mag_dic=new Dictionary<string, int>();
            // foreach(string word in note){
            //     if(!note_dic.ContainsKey(word))note_dic[word]=1; else note_dic[word]++;            
            // }
            note.ForEach(word=>{
                if(!note_dic.ContainsKey(word))note_dic[word]=1; else note_dic[word]++;            
            });
            foreach(string word in magazine){
                if(!mag_dic.ContainsKey(word))mag_dic[word]=1; else mag_dic[word]++;            
            }

            foreach (var word in note)
            {
                if (note_dic[word] > (!mag_dic.ContainsKey(word)?0:mag_dic[word]))
                {
                    answer="No";
                    break;
                }   
            }
            Console.WriteLine( answer);
        }


        /*twoStrings: https://www.hackerrank.com/challenges/two-strings/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        * Complete the 'twoStrings' function below.
        *
        * The function is expected to return a STRING.
        * The function accepts following parameters:
        *  1. STRING s1
        *  2. STRING s2
        */

        public static string twoStrings(string s1, string s2)
        {
            string res="NO";
            var aint=Convert.ToInt32('a');
            var zint=Convert.ToInt32('z');
            
            for(int i=aint;i<=zint;i++){
                char c=Convert.ToChar(i);
                if(s1.IndexOf(c)!=-1 && s2.IndexOf(c)!=-1)return "YES";
            }
        
            return res;
        }


        /*****sherlockAndAnagrams https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        * Given a string of lower alphabet characters, count total substring of this string which are anagram to each other.
        */

        public static int sherlockAndAnagrams(string s)
        {
            var count=0;
            if(s.ToCharArray().Distinct().Count()==s.Count())return count;
            
            for(int len=1;len<s.Count();len++){
                for(int i=0;i<s.Count()-len;i++){
                    for(int j=i+1;j<=s.Count()-len;j++){
                        //Console.WriteLine("=>"+s.Substring(i,len) + " , "+ s.Substring(j,len));
                        if(len==1 && s[i]==s[j])count++;
                        else if(isAnagram(s.Substring(i,len), s.Substring(j,len))){
                            count++;
                        }
                    }
                }
            }
            
            return count;
        }
        
        public static bool isAnagram(string s1,string s2){
            var retVal=true;
            char[] s1_a=s1.ToCharArray();
            char[] s2_a=s2.ToCharArray();
            IEnumerable<char> distinct=(s1+s2).ToCharArray().Distinct();
            foreach(var e in distinct){
                int s1c=s1_a.Count(c=>c==e);
                int s2c=s2_a.Count(c=>c==e);
                //Console.WriteLine(s1c+","+s2c+","+(char)i);
                if(s1c!=s2c)return false;
            }
            // for(int i=(int)'a';i<=(int)'z';i++)
            // {
            //     int s1c=s1_a.Count(c=>c==(char)i);
            //     int s2c=s2_a.Count(c=>c==(char)i);
            //     //Console.WriteLine(s1c+","+s2c+","+(char)i);
            //     if(s1c!=s2c)return false;
            // }
            return retVal;
        }

        /****Solution referance: https://www.geeksforgeeks.org/count-total-anagram-substrings/*/
        public static int sherlockAndAnagrams_2(string s)
        {
            var count=0;
            if(s.ToCharArray().Distinct().Count()==s.Count())return count;
            
            Dictionary<string, int> subset=new Dictionary<string, int>();
            
            for(int i=0;i<s.Count();i++){
                for(int j=i;j<s.Count();j++){
                    dynamic sub=s.Substring(i,j-i+1).ToCharArray();
                    Array.Sort(sub);
                    sub=new string(sub);
                    Console.Write("=>"+sub );
                    
                    if(subset.ContainsKey(sub))subset[sub]++;
                    else subset.Add(sub,1);                
                    Console.Write("="+subset[sub] );
                }
            }
            Console.WriteLine("" );
            //Once occurrence 'o' of each frequency array is stored, 
            //total anagrams will be the sum of o*(o-1)/2 for all different frequency arrays 
            //because if a particular substring has 'o' anagrams in string 
            //total o*(o-1)/2 anagram pairs can be formed.
            foreach(var key in subset.Keys){                
                count+=(subset[key]*(subset[key]-1))/2;
                Console.WriteLine(key+"="+subset[key] +"; "+ (subset[key]*(subset[key]-1))/2);
            }
            return count;
        }


        //Maximum number of toy: https://www.hackerrank.com/challenges/mark-and-toys/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
        public static int maximumToys(List<int> prices, int k)
        {
            int max=0,totalCost=0;
            prices.Sort();
            for(int i=0;i<prices.Count;i++){
                totalCost+=prices[i];
                if(totalCost>k)return i;
                Console.Write(prices[i]+" ");
            }
            return max;
        }

        //remove alternating char https://www.hackerrank.com/challenges/alternating-characters/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=strings
        //AAABBB=>AB
        public static int alternatingCharacters(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length - 1;i++)
            {
                if (s[i] == s[i + 1])
                {
                    count++;
                    //s.Remove(i + 1, 1);
                    //Console.WriteLine(s +" "+count);
                }
            }

            return count;
        }

        //**** https://www.hackerrank.com/challenges/sherlock-and-valid-string/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=strings
        //Sherlock and the Valid String:
        //Sherlock considers a string to be valid if all characters of the string appear 
        //the same number of times. It is also valid if he can remove just 1 character at 1 index 
        //in the string, and the remaining characters will occur the same number of times.
        public static string isValid_SherlockString(string s)
        {
            Dictionary<int, int> dic=new Dictionary<int, int>();
            int minCount=s.Length,maxCount=0;
            for(int i=97;i<123;i++){
                int count=s.Count(c=>c==i);
                if(count>0){
                    if(minCount>=count)minCount = count;
                    if(maxCount<count)maxCount=count;
                    if(dic.ContainsKey(count))dic[count]++;else dic[count]=1;                
                }            
            }
            Console.WriteLine("Dic");
            foreach( int key in dic.Keys){
                Console.WriteLine(key+"=>"+dic[key]);
            }
            int minCountCharLength=dic[minCount];
            int maxCountCharLength=dic[maxCount];
            
            if(maxCount==minCount){
                return "YES";
            }else{
                if(dic.Count==2&& maxCountCharLength==1 && maxCount-minCount==1)return "YES";
                else if(dic.Count==2 && minCountCharLength==1 &&  minCount==1)return "YES";
                else return "NO";
            }
        }

        


        //* Beautiful Binary String:
        //https://www.hackerrank.com/challenges/beautiful-binary-string/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        //Alice has a binary string. She thinks a binary string is beautiful if and only if 
        //it doesn't contain the substring 010.
        //In one step, Alice can change a  to a  or vice versa. Count and print the 
        //minimum number of steps needed to make Alice see the string as beautiful.
        //0101010 => 0111011 
        public static int beautifulBinaryString(string b)
        {
            int count=0;
            for(int i=0;i<b.Length-2;i++){
                if(b[i]=='0' && b[i+1]=='1' && b[i+2]=='0'){
                    count++;
                    i+=2;
                }
            }
            return count;
        }

        /**** Lily's Homework: https://www.hackerrank.com/challenges/lilys-homework/problem?isFullScreen=true&utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        George can swap any two elements of the array any number of times. 
        An array is beautiful if the sum of |arr[i]-arr[i-1]| among 0<i<n is minimal.

        Given the array "arr", determine and return the minimum number of swaps that should be performed 
        in order to make the array beautiful.
        example: 3 4 2 5 1 => 2 swap
                 2 5 3 1   => 2 swap
        */
        public static int lilysHomework(List<int> arr)
        {        
            int val=minSwap(arr.ToArray());
            int val2=minSwap(arr.ToArray(),true);
            return Math.Min(val, val2);
        }
        public static int minSwap(int[] nums, bool isReverse=false){
            int[] nums_copy=new int[nums.Length];
            nums.CopyTo(nums_copy, 0);
            if(isReverse){
                Array.Sort(nums, new Comparison<int>((a,b)=>{return b.CompareTo(a);}));
            }
            else Array.Sort(nums);
            int changes=0;
            
            Dictionary<int, int> hm=new Dictionary<int, int>();
            for(int i=0;i<nums_copy.Length;i++){
                hm[nums_copy[i]]=i;
            }
            
            for(int i=0;i<nums_copy.Length;i++){
                if(nums_copy[i]!=nums[i]){
                    //as the sorted value and real value is not same
                    //exchange the pointer of both value in hash_map
                    int indexOfCurrent=hm[nums_copy[i]];
                    int indexOfOld=hm[nums[i]];
                    hm[nums_copy[i]]=indexOfOld;
                    hm[nums[i]]=indexOfCurrent;
                    //swap the position of both value
                    int tmp=nums_copy[i];                
                    nums_copy[i]=nums_copy[indexOfOld];
                    nums_copy[indexOfOld]=tmp;
                    changes++;
                }
            }
            
            return changes;
        }

        /**https://www.hackerrank.com/challenges/gem-stones/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        arr=["abca","abcb","bc"] - here bc is common in all three element. so 2 jemstones. 
        Find Jemstones. Node: a char can occur multiple times in same sting.
        */
        public static int gemstones(List<string> arr)
        {
            Dictionary<char, int> ht=new Dictionary<char, int>();
            int commons=0;
            for(int i='a';i<='z';i++){
                char c=(char)i;
                ht.Add(c,0);
                for(int j=0;j<arr.Count;j++){
                    if(arr[j].IndexOf(c)!=-1){
                        ht[c]++;
                    }                
                }
                if(ht[c]==arr.Count)commons++;
            }
            
            return commons;
        }


        /**https://www.hackerrank.com/challenges/making-anagrams/problem?isFullScreen=true
        Given two strings, s1 and s2, that may not be of the same length, 
        determine the minimum number of character deletions required to make s1 and s2 anagrams. 
        Any characters can be deleted from either of the strings.
        In other words, both strings must contain the same exact letters in the same exact frequency. 
        For example, bacdc and dcbac are anagrams, but bacdc and dcbad are not.
        EXample: s1=abc, s2=amnop. Output=6
        */
        public static int makingAnagrams(string s1, string s2)
        {        
            int notMatched=0;
            for(int i='a';i<='z';i++){
                char c=(char)i;
                int c1=s1.Count(a=>a==c);
                int c2=s2.Count(a=>a==c);
                notMatched+=Math.Abs(c1-c2);
            }
            return notMatched;
        }

        /*** pairs https://www.hackerrank.com/challenges/pairs/problem?h_l=interview&isFullScreen=true&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=search
        Given an array of integers and a target value, determine the number of pairs of array 
        elements that have a difference equal to the target value.
        example: k=2 arr = [1, 5, 3, 4, 2]
        There are 3 pairs of integers in the set with a difference of 2: [5,3], [4,2] and [3,1]
        */
        public static int pairs(int k, List<int> arr)
        {
            //sort descending
            arr.Sort((a,b)=>b-a);
            int totalPair=0, max=arr[0],min=arr.Last();
            Dictionary<int, int> hm=new Dictionary<int, int>();
            for(int i=0;i<arr.Count;i++){
                if(hm.ContainsKey(arr[i])){
                    hm[arr[i]]++;                
                }
                else hm.Add(arr[i], 1);   
            }
            //just find the subtracted value of each key is already exist or not
            foreach(int key in hm.Keys){
                Console.WriteLine(key+"="+hm[key]);
                int sub=key-k;
                //as I have a sorted array, I can omit the subtraction that is less then min value
                if(sub>=min){
                    //here we go
                    if(hm.ContainsKey(sub)){
                        totalPair++;
                    }                
                }
                else break;
            }
            return totalPair;
        }

        /******* sherlock-and-array : https://www.hackerrank.com/challenges/sherlock-and-array/problem
        Watson gives Sherlock an array of integers. His challenge is to find an element
         of the array such that the sum of all elements to the left is equal to the sum of 
         all elements to the right.
         -You will be given arrays of integers and must determine whether there is an element 
         that meets the criterion. If there is, return YES. Otherwise, return NO.
         example: arr=[5,6,8,11] - 8 is between two subarrays that sum to 11.
        */
        public static string balancedSums(List<int> arr)
        {
            int i=0,j=1;
            long left=0, right=0;
            //first accumulate all values except first value.
            for(i=1;i<arr.Count;i++)right+=(long)arr[i];
            
            if(left==right)return "YES";
            
            //reduce value from right and increate value from left gradually
            //if they matched, return yes
            for(i=0,j=1;j<arr.Count;i++,j++){
                right-=(long)arr[j];
                left+=(long)arr[i];
                if(left==right)return "YES";
            }
            
            return "NO";
        }


        /** Cavity Map: https://www.hackerrank.com/challenges/cavity-map/problem
        You are given a square map as a matrix of integer strings. Each cell of the map has a value denoting its depth. We will call a cell of the map a cavity if and only if this cell is not on the border of the map and each cell adjacent to it has strictly smaller depth. Two cells are adjacent if they have a common side, or edge.

        Find all the cavities on the map and replace their depths with the uppercase character X
        Example: grid=['989','191','111']
        result: grid=['989','1X1','111']
        The center cell was deeper than those on its edges: [8,1,1,1]. The deep cells in the top two corners do not share an edge with the center cell, and none of the border cells is eligible
        */
        public static List<string> cavityMap(List<string> grid)
        {
            List<string> final=new List<string>();
            final.Add(grid[0]);
            if(grid.Count>2){
                for(int i=1;i<grid.Count-1;i++){
                    char[] current=grid[i].ToCharArray();
                    
                    for(int j=1;j<current.Length-1;j++){
                        if((current[j]>current[j-1] && current[j]>current[j+1]) &&
                        (current[j]>grid[i-1][j] && current[j]>grid[i+1][j])   
                        ){
                            current[j]='X';
                            j++;
                        }
                    }
                    final.Add(new String(current));
                    
                }
            }
            if(grid.Count>1)final.Add(grid[grid.Count-1]);
            
            return final;
        }

    }


}