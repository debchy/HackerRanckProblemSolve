function numberOfItems(s, startIndices, endIndices) {
    // Write your code here
    let o=[]
    for(let i=0;i<startIndices.length;i++){
        let st=startIndices[i]-1,e=endIndices[i]-1;
        let sub=s.substring(st,e+1)
        console.log(sub)
        if(sub.indexOf("|")==-1)o.push(0);
        else if(sub.indexOf("|")==sub.lastIndexOf("|")){
            o.push(0);
        }else{
            sub=sub.substring(sub.indexOf("|"),sub.lastIndexOf("|")+1)
            sub=sub.replace(/\|/g,'');
            console.log("sub",sub)
            o.push(sub.length);
        }
    }
    
    return o
}

console.log(numberOfItems("|**|****|******|*|*||*|******|*||**|",[19],[23]))