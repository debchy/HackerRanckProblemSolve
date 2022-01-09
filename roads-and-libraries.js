function roadsAndLibraries(n, c_lib, c_road, cities) {
    // Write your code here

    let adjacent_matrix=new Array(n);
    let visited=new Array(n).fill(false);
    for(let i=0;i<n;i++){
        adjacent_matrix[i]=[];        
    }
    for(let i=0;i<cities.length;i++){
        let edge=cities[i];
        adjacent_matrix[edge[0]-1].push(edge[1]-1);
    }

    /**
     * Essentially, every connected component needs at least one library. 
     * For every connected component, let count be the number of nodes in the component. 
     * There can be two cases:
If c_road < c_lib, then the minimum cost is to build one library and count - 1 roads to connect the cities.
If c_road > c_lib, then the minimum cost is to build one library for each city.
If c_road = c_lib, then two ways yield the same result so it doesn't matter.
     */
    let count_of_cities=0,total_cost=0;
    for(let i=0;i<n;i++){
        if(!visited[i] && adjacent_matrix[i].length>0)DFS(i);
    }

    //calculate
    let extra_library=visited.filter(v=>!v).length;
    console.log(adjacent_matrix, visited)
    if(cities.length==0)total_cost=c_lib*n;
    else if(c_lib>c_road)total_cost= c_lib+ c_lib*extra_library + c_road*(count_of_cities-1);
    else total_cost=c_lib*n;

    function DFS(i){
        visited[i]=true;
        count_of_cities++;
        for(let j of adjacent_matrix[i]){
            if(!visited[j])DFS(j)
        }
    }

    return total_cost;
}

//console.log(roadsAndLibraries(3,2,1,[[1, 2], [3, 1], [2, 3]]))
//console.log(roadsAndLibraries(5,6,1,[[1, 2], [1, 3], [1, 4]]))
//console.log(roadsAndLibraries(5,92,23,[[2,1], [5,3], [5,1],[3,4],[3,1],[5,4],[4,1],[5,2],[4,2]]))
console.log(roadsAndLibraries(1,5,3,[]))