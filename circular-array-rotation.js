//https://www.hackerrank.com/challenges/circular-array-rotation/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign

function circularArrayRotation(a, k, queries) {
    // Write your code here
    while(k!=0){
        k--;
        let val=a.pop();
        a.unshift(val);
    }
    let result=[]
    queries.forEach(element => {
        result.push(a[element])
    });

    return result;
}

//https://www.hackerrank.com/challenges/permutation-equation/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=7-day-campaign
function permutationEquation(p) {
    // Write your code here
    let output=[];
    for(let i=0;i<p.length;i++){
        output.push(get(p,get(p,i+1)+1)+1) 
    }

    function get(p,i){
        
        let val=p.indexOf(i);
        return val;
    }

    return output;
}

//console.log(permutationEquation([2, 3, 1]));

//https://www.hackerrank.com/challenges/funny-string/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=7-day-campaign
function funnyString(s) {
    // Write your code here
    //let given_arr=s.split('');
    //let opp_str=given_arr.reverse();
    let is_funny=true;
    let max=s.length;
    for(let i=0;i<max-1;i++){
        console.log(Math.abs(given_arr[0].charCodeAt(0)-given_arr[i+1].charCodeAt(0)));
        // if(Math.abs(given_arr[i].charCodeAt(0)-given_arr[i+1].charCodeAt(0))!=Math.abs(opp_str[i].charCodeAt(0)-opp_str[i+1].charCodeAt(0))){
        //     is_funny=false;
        //     break;
        // }
        if(Math.abs(s.charCodeAt(i)-s.charCodeAt(i+1))!=Math.abs(s.charCodeAt(max-1-i)-s.charCodeAt(max-1-i-1))){
            is_funny=false;
            break;
        }
    }

    return is_funny?"Funny": "Not Funny"

}
//console.log(funnyString("acxz"))

//https://www.hackerrank.com/challenges/maximizing-xor/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
function maximizingXor(l, r) {
    // Write your code here
    let max=0;
    for(let i=l;i<=r;i++){
        for(let j=i;j<=r;j++)
        {    let xor=i^j
            if(max< xor)max=xor;
        }
    }

    return max;
}
//console.log(maximizingXor(10,15))


//https://www.hackerrank.com/challenges/sparse-arrays/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
/*
 * Complete the 'matchingStrings' function below.
 *
 * The function is expected to return an INTEGER_ARRAY.
 * The function accepts following parameters:
 *  1. STRING_ARRAY strings
 *  2. STRING_ARRAY queries
 */

function matchingStrings(strings, queries) {
    // Write your code here
    let result=[];
    queries.forEach(str=>{
        result.push(strings.filter(a=>a==str).length)
    })

    return result;
}
//console.log(matchingStrings(['aba','baba','aba','xzxb'],['aba','xzxb','ab']))


https://www.hackerrank.com/challenges/2d-array/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=7-day-campaign
/*
 * Complete the 'hourglassSum' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts 2D_INTEGER_ARRAY arr as parameter.
 */

function hourglassSum(arr) {
    // Write your code here
    function getHourglassSum(arr,i,j){
        let total=0;
        for(let a=i;a<i+3;a++){
            for(let b=j;b<j+3;b++){
                if(a!=i+1)total+=arr[a][b];
                else {total+=arr[i+1][j+1]; break;}
            }
        }

        return total
    }

    let maxTotal=-64;
    for(let i=0;i<4;i++){
        for(let j=0;j<4;j++)
        {
            let current=getHourglassSum(arr,i,j);
            if(maxTotal<current)maxTotal=current;
        }
    }

    return maxTotal;
}
// console.log(hourglassSum([
//     [ 1, 1, 1, 0, 0, 0 ],
//     [ 0, 1, 0, 0, 0, 0 ],
//     [ 1, 1, 1, 0, 0, 0 ],
//     [ 0, 0, 2, 4, 4, 0 ],
//     [ 0, 0, 0, 2, 0, 0 ],
//     [ 0, 0, 1, 2, 4, 0 ]
//   ]))


  https://www.hackerrank.com/challenges/find-digits/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=7-day-campaign
/*
 * Complete the 'findDigits' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts INTEGER n as parameter.
 */

function findDigits(n) {
    // Write your code here
    let totalDivisors=0, isEven=(n%2==0);
    let numStr=(n+'').split('');
    numStr.forEach(elem=>{
        if(elem==1)totalDivisors++;
        else if(elem==0);
        else if(elem==2 && isEven)totalDivisors++;
        else if(n%elem==0)totalDivisors++;
    })

    return totalDivisors;
}
//console.log(findDigits(1012));



//https://www.hackerrank.com/challenges/extra-long-factorials/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
/*
 * Complete the 'extraLongFactorials' function below.
 *
 * The function accepts INTEGER n as parameter.
 */

function extraLongFactorials(n) {
    // Write your code here
    n=BigInt(n)
    let factorial=n=>{
        
        return n==1n? 1n:  n *factorial(n-1n)
    }

    return factorial(n).toString()
}

//console.log(extraLongFactorials(30))



//https://www.hackerrank.com/challenges/ctci-fibonacci-numbers/problem?h_l=interview&isFullScreen=false&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=recursion-backtracking
function fibonacci(n) {
    if(n==0)return 0;
    else if(n==1) return 1
    else return fibonacci(n-1)+fibonacci(n-2)
}
//console.log(fibonacci(2))


//***///https://www.hackerrank.com/challenges/ctci-recursive-staircase/problem?h_l=interview&isFullScreen=true&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=recursion-backtracking
//Solution: https://www.geeksforgeeks.org/count-ways-reach-nth-stair-using-step-1-2-3/
function stepPerms(n) {
    // Write your code here
    
    const recurse=a=>{
        if(a==2)return 2;
        else if(a==1)return 1;
        else if(a==0)return 1;
        else if(a<0) return 0;
        else{            
            return recurse(a-1)+recurse(a-2)+recurse(a-3)
        }
    }
    
    return recurse(n)
}

function stepPerms_count(n) {
    let template=Array(n+1);
    template[0]=1;
    template[1]=1;
    template[2]=2;

    for(let i=3;i<=n;i++){
        template[i]=template[i-1]+template[i-2]+template[i-3]
    }
    //console.log(template)
    return template[n];
}
// console.log(stepPerms(6)%1000000007);
// [35,    30,    33,    36,    20].forEach(n=>{
//     console.log(stepPerms_count(n)%10000000007)
// })


//https://www.hackerrank.com/challenges/abbr/problem?isFullScreen=true&h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dynamic-programming
/*
 * Complete the 'abbreviation' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts following parameters:
 *  1. STRING a
 *  2. STRING b
 */

function abbreviation(a, b) {
    // Write your code here
    for(let i=0;i<a.length;i++){
        let char=a.charCodeAt(i)
    }
    
}

