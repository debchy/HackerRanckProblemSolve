/**Possible Path

 * Adam is standing at point (a,b) in an infinite 2D grid. 
 * He wants to know if he can reach point (x,y) or not. 
 * The only operation he can do is to move to point (a+b,b),(a,a+b),(a-b,b) or (a,b-a) from some point . 
 * It is given that he can move to any point on this 2D grid, i.e., 
 * the points having positive or negative (X or Y) co-ordinates.
 * Tell Adam whether he can reach  or not.
 * Output Format
For each test case, display YES or NO that indicates if Adam can reach (x,y) or not.

Constraints
0 ≤ T ≤ 1000
0 ≤ a,b,x,y ≤ 1018

Sample Input

3
1 1 2 3
2 1 2 3
3 3 1 1

Sample Output

YES
YES
NO
 */

 function solve(a, b, x, y) {
    // Write your code here
    while(x!=y){
        if(x>y)x=x-y;
        else y=y-x;
    }
    while(a!=b){
        if(a>b)a=a-b;
        else b=b-a;
    }

    if(a==x)return "YES"
    else return "No"
}


solve(1,1,2,3);