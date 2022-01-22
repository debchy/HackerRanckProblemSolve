using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class Result
    {
        /*** https://www.hackerrank.com/challenges/the-love-letter-mystery/problem?isFullScreen=true&utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        To make all words in a letter into palindrome letter, he follows two rules:
            -He can only reduce the value of a letter by 1, i.e. he can change d to c, 
            but he cannot change 'c' to 'd' or 'd' to 'b'.
            -The letter 'a' may not be reduced any further.
            Each reduction in the value of any letter is counted as a single operation. Find the minimum number of operations required to convert a given string into a palindrome.
            return - the minimum number of operations
            example: abcba=>0, abc=>2, abcd=>4(abba)
            algorithm:
            if even number: calculate difference between two half of the letter.
            if odd number: keep center unchanged. calculate the difference of letter from both sides.
        */   
        public static int theLoveLetterMystery(string s)
        {
            int length=s.Length,totalChange=0;
            if(length%2==0){
                //if even
                int t=0,c=(length>>1)-1;
                while(c+t+1<length){
                    int d=Math.Abs(s[c-t]-s[c+1+t]);
                    //Console.WriteLine(s[c-t]+" "+s[c+1+t]+" = "+d);
                    totalChange+=d;
                    t++;
                }
                
            }else{
                //if odd
                int t=1,c=length>>1;
                while(c+t<length){
                    int d=Math.Abs(s[c-t]-s[c+t]);
                    totalChange+=d;
                    t++;
                }
            }
            return totalChange;
        }

    }


    //**** Special string.
    //find substing from a string. pattern: aaa, aba, aabaa, a,b
    //https://www.hackerrank.com/challenges/special-palindrome-again/problem?h_l=interview&isFullScreen=false&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=strings
    static long substrCount(int n, string s) {
        long total = n;
        //case 1: all substring are same character.
        int i=0;
        while(i<n-1){
            int substringLength=1;
            while(i<n-1 && s[i]==s[i+1]){
                substringLength++;
                i++;    
            }
            total+=substringLength*(substringLength-1)/2;  
            i++;           
        }
        //Case 2: for aba, aabaa conditions, need to backtrack and forward track to match palindrome pattern
        int start=1;
        for(i=1;i<n-1;i++){
            while((i+start<n && i-start>=0)  && s[i-start]==s[i+start] && s[i]!=s[i-start]){
                //give condition to brak abCba pattern
                if(start>1 && s[i-start]!=s[i-start+1])break;
                total++;
                start++;
            }
            //Console.WriteLine("i="+i+" start="+start);
            start=1;
        }
        
        return total;
    }
}
