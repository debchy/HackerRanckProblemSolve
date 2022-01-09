function MatrixChallenge(strArr) { 

    // code goes here  
    let mainA=[];
    let myA=[];//resulted matrix
    let Row=strArr.length;
    let Column=strArr[0].length;
    for(let r=0;r<Row;r++)
    {
      myA[r]=[];
      mainA[r]=strArr[r].split(''); 
      for(let c=0;c<Column;c++){
        myA[r][c]=0;
        if(r==0)myA[0][c]=mainA[0][c]; //filling first row   
      }
      myA[r][0]=mainA[r][0];//filling first column
    }
    console.log(mainA)
  
    //now calculate the matrix from second row and second column 
    let resultedMax=0;
    for(let r=1;r<Row;r++){
      for(let c=1;c<Column;c++){
        if(mainA[r][c]==1){
          myA[r][c]=Math.min(myA[r][c-1],myA[r-1][c],myA[r-1][c-1])+1;
          //keep a record of max
          if(resultedMax<myA[r][c])resultedMax=myA[r][c];
        }
        else myA[r][c]=0;
      }
    }
    console.log(myA)
    
    
    
    
    
    return resultedMax; 
  
  }
     
  console.log("Max",MatrixChallenge(["0111", "1111", "1111", "1111"]));