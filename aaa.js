const https = require('https');

https.get('https://coderbyte.com/api/challenges/json/age-counting', (resp) => {
    resp.on('data',res=>{
        console.log(res.toString())
    })
  let data = '';

  // parse json data here...
  
  console.log(resp);

});
// let val ="key=IAfpK, age=32, key=WNVdi, age=64, key=jp9zt, age=40, key=9snd2, age=32";
// console.log(val.split(', '))
// let all=val.split(', ');
// let output="";
// for(let i=1;i< all.length;i=i+2){
//     if(all[i]=="age=32"){ 
//         output+=all[i-1]+', '+all[i]+'\n';}
//         //age32.push(i-1);age32.push(i)}
// }
// output=output.substring(0,output.length-2)
// console.log(output)
// var crypto = require('crypto')
// output=crypto.createHash('sha1').update(output).digest("hex")
// console.log(output);
// const fs= require('fs');
// fs.writeFileSync('output.txt',output);


let R = 3;
let C = 4;
 
function printMaxSubSquare(M) {
    let i,j;
    let S = [];
 
    for ( var y = 0; y < R; y++ ) {
        S[ y ] = [];
        for ( var x = 0; x < C; x++ ) {
            S[ y ][ x ] = 0;
        }
    }
    console.log("S",S)
    let max_of_s, max_i, max_j;
     
    /* Set first column of S[][]*/
    for(i = 0; i < R; i++)
        S[i][0] = M[i][0];
     
    /* Set first row of S[][]*/
    for(j = 0; j < C; j++)
        S[0][j] = M[0][j];
         
    /* Construct other entries of S[][]*/
    for(i = 1; i < R; i++)
    {
        for(j = 1; j < C; j++)
        {
            if(M[i][j] == 1)
                {
                    S[i][j] = Math.min(S[i][j-1],Math.min( S[i-1][j],
                                S[i-1][j-1])) + 1;
                    //console.log("S[i][j]",S[i][j])
                            }
            else
                S[i][j] = 0;
        }
    }
     
    /* Find the maximum entry, and indexes of maximum entry
        in S[][] */
    max_of_s = S[0][0]; max_i = 0; max_j = 0;
    for(i = 0; i < R; i++)
    {
        for(j = 0; j < C; j++)
        {
            if(max_of_s < S[i][j])
            {
                max_of_s = S[i][j];
                max_i = i;
                max_j = j;
            }
        }            
    }
 
    console.log("Maximum size sub-matrix is: \n");
    for(i = max_i; i > max_i - max_of_s; i--)
    {
        for(j = max_j; j > max_j - max_of_s; j--)
        {
            console.log( M[i][j] , " ");
        }
        console.log("\n");
    }
}
 
 
/* Driver code */
let M = [[0, 1, 1, 1],
         [1, 1, 0, 1],
         [0, 1, 1, 0]];
                     
printMaxSubSquare(M);