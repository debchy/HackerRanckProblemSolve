
function climbingLeaderboard(scores, alice) {
  let stTime=new Date();
  console.log("start",stTime);
  scores= scores.filter((v,i,s)=>s.indexOf(v)===i);

  let current= scores.length-1;
  let positions=[];
  for(let score of alice){
    for(let i= current;i>=0;i--){
      current=i;
      if(score > scores[i] && i===0){
        scores.splice(0,0,score);
        positions.push(i+1);
        break;
      }
      else if(score < scores[i]){
        scores.splice(i+1,0,score);
        positions.push(i+1+1)
        break;
      }
      else if(score == scores[i]){positions.push(i+1);break;}
      
    }
    //console.log(current);
      //positions.push(scores.indexOf(score)+1)
  }
  console.log("required",new Date().getTime()-stTime.getTime());
  return positions;
}
function climbingLeaderboard2(scores, alice) {
  let stTime=new Date();
  console.log("start",stTime);
  //scores= scores.filter((v,i,s)=>s.indexOf(v)===i);
  console.log("filter required",new Date().getTime()-stTime.getTime());
  let current= 0;
  let positions=[];
  let a_score=0;
  let old=0;
  for(let a=alice.length-1;a>=0;a--){
      a_score=alice[a];
      
      while(scores[current]==scores[current+1]){
          if(current==scores.length-1)break;
          scores.splice(current+1,1);
      }
      
      let c_score=scores[current];
      while(scores[current]>a_score){
          if(current==scores.length-1)break;
          c_score=scores[++current];}
      //console.log("current score",c_score,"a_score",a_score,"current",current)
      if(c_score<a_score){
          //scores.splice(current,0,a_score);
          positions.push(current+1);
          //console.log("positions",positions)
          current++;
      }else if(c_score==a_score){
          positions.push(current+1);
          //console.log("positions",positions)
          current++;
      }
      else if(current==scores.length-1){
          positions.push(current+1+1);
          //console.log("positions",positions)
      }
      
      //console.log(scores)
  }

  
  console.log("required",new Date().getTime()-stTime.getTime());
  return positions;
}



console.log(climbingLeaderboard(scores, alice))