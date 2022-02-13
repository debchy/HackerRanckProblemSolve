/****** maximumSum: https://www.hackerrank.com/challenges/maximum-subarray-sum/problem?isFullScreen=true
 * We define the following:

A subarray of array a of length n is a contiguous segment from a[i] through a[j] where 0<=i<=j<n.
The sum of an array is the sum of its elements.
Given an n element array of integers, a, and an integer,m , determine the maximum value of the sum of any of its subarrays modulo m.

Example
a=[1,2,3]
m=2
The following table lists all subarrays and their moduli:

		    sum	%2
[1]		    1	1
[2]		    2	0
[3]		    3	1
[1,2]		3	1
[2,3]		5	1
[1,2,3]		6	0
The maximum modulus is 1.
 * 
 * @param {*} a 
 * @param {*} m 
 * @returns 
 */
function maximumSum(a, m) {
    // Write your code here
    let hm=[];
    let curSumMod=0, max=0;
    a.forEach((val,i)=>{
        curSumMod=(curSumMod+val)%m;
        hm.push([i,curSumMod]);
        max=Math.max(curSumMod,max);
    });
    
    hm.sort((a,b)=>a[1]-b[1]);
    
    hm.forEach((elem,i)=>{
        let curIndex=elem[0], curSumMod=elem[1];
        let j=i+1;
        while(j<hm.length && (hm[j][0]>=curIndex || hm[j][1]==curSumMod))j++;
        
        if(j<hm.length){
            max= Math.max(max, curSumMod-hm[j][1]+m);
        }
    });
    
    return max;
}