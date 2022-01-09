

function toOneDimentional(twoDimentional){
    let oneD=[]
    for(let arr of twoDimentional){
        oneD=[...oneD,...arr];
    }

    return oneD;
}

function isMagicSquare(oneD){
    let r1=oneD[0]+oneD[1]+oneD[2];
    let r2=oneD[3]+oneD[4]+oneD[5];
    let r3=oneD[6]+oneD[7]+oneD[8];
    let c1=oneD[0]+oneD[3]+oneD[6];
    let c2=oneD[1]+oneD[4]+oneD[7];
    let c3=oneD[2]+oneD[5]+oneD[8];
    let d1=oneD[0]+oneD[4]+oneD[8];
    let d2=oneD[2]+oneD[4]+oneD[6];

    if(r1===r2 && r1===r3 && r1===c1 && r1===c2 && r1===c3 && r1===d1 && r1===d2)return true;
    return false;
}

function diffTwoMagicSquare(sq1,sq2){
    let total_diff=0;
    for(let i=0;i<9;i++){
        total_diff+=Math.abs( sq1[i]-sq2[i]);
    }

    return total_diff;
}
//console.log(isMajicSquare(toOneDimentional(givenMagicSquare)))
let temp=[], minDiff=Math.min();
let magicSquares=[];
let givenMagicSquare=[[2,9,8],
[4,2,7],
[5,6,7]];

let givenMagicSquare_od=toOneDimentional(givenMagicSquare);
var possible_squares = [
    [8, 1, 6, 3, 5, 7, 4, 9, 2],
    [4, 3, 8, 9, 5, 1, 2, 7, 6],
    [2, 9, 4, 7, 5, 3, 6, 1, 8],
    [6, 7, 2, 1, 5, 9, 8, 3, 4],
    [6, 1, 8, 7, 5, 3, 2, 9, 4],
    [8, 3, 4, 1, 5, 9, 6, 7, 2],
    [4, 9, 2, 3, 5, 7, 8, 1, 6],
    [2, 7, 6, 9, 5, 1, 4, 3, 8]
  ];
  for(let i9=0;i9<possible_squares.length;i9++){
    let temp=possible_squares[i9];
    //console.log(isMagicSquare(temp));
    if(isMagicSquare(temp)){
        let td=diffTwoMagicSquare( givenMagicSquare_od,temp);
        console.log(td)
        if(td<minDiff){
            minDiff=td;
            temp.diff=td;
            magicSquares.push(temp);
        }
    }
}

console.log(magicSquares);
console.log(minDiff)