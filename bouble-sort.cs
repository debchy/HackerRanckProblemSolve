using System;
using System.Collections.Generic;
class Result
{
    //with bouble sort make sowap count https://www.hackerrank.com/challenges/ctci-bubble-sort/problem?isFullScreen=true
    // one ref: https://www.geeksforgeeks.org/bubble-sort/
    public static void countSwaps(List<int> a)
    {
        int totalSwaps=0;
        for(int i=0;i<a.Count;i++){
            for(int j=0;j<a.Count-1;j++){
                if(a[j]>a[j+1]){
                    totalSwaps++;
                    var t=a[j];
                    a[j]=a[j+1];
                    a[j+1]=t;
                }
            }
        }
        Console.WriteLine($"Array is sorted in {totalSwaps} swaps.");
        Console.WriteLine($"First Element: {a[0]}");
        Console.WriteLine($"Last Element: {a.Last()}");
    }

}