/**DFS:
 * Depth-first search is an algorithm for traversing or searching tree or graph data structures. 
 * The algorithm starts at the root node (selecting some arbitrary node as the root node in the 
 * case of a graph) and explores as far as possible along each branch before backtracking. 
 * So the basic idea is to start from the root or any arbitrary node and mark the node and 
 * move to the adjacent unmarked node and continue this loop until there is no unmarked 
 * adjacent node. Then backtrack and check for other unmarked nodes and traverse them. Finally, 
 * print the nodes in the path.
 * 
 * Algorithm: 
1. Create a recursive function that takes the index of the node and a visited array.
2. Mark the current node as visited and print the node.
3. Traverse all the adjacent and unmarked nodes and call the recursive function with the 
index of the adjacent node.


DFS for disconnected graph:
1. Create a recursive function that takes the index of the node and a visited array.
2. Mark the current node as visited and print the node.
3. Traverse all the adjacent and unmarked nodes and call the recursive function with the index of 
the adjacent node.
4. Run a loop from 0 to the number of vertices and check if the node is unvisited in the previous DFS, 
call the recursive function with the current node.

Complexity Analysis: 

Time complexity: O(V + E), where V is the number of vertices and E is the number of edges in the graph.
Space Complexity: O(V), since an extra visited array of size V is required
*/

class Graph{
    constructor(total_vertices){
        this.total_vertices=total_vertices;
        this.adjacent_matrix=new Array(total_vertices);
        for(let i=0;i<total_vertices;i++) this.adjacent_matrix[i]=[];
    }

    addEdge(from_vertice,to_vertice){
        this.adjacent_matrix[from_vertice].push(to_vertice);
    }

    DFS(vertice){
        let visited_matrix=new Array(this.total_vertices).fill(false);
        this.DFS_main(vertice,visited_matrix);
    }

    DFS_main(vertice, visited_matrix){
        console.log(vertice +' -> ');
        visited_matrix[vertice]=true;

        for(let adjacent of this.adjacent_matrix[vertice]){
            if(!visited_matrix[adjacent])this.DFS_main(adjacent,visited_matrix)
        }
    }
}

let g=new Graph(4);
g.addEdge(0, 1);
g.addEdge(0, 2);
g.addEdge(1, 2);
g.addEdge(2, 0);
g.addEdge(2, 3);
g.addEdge(3, 3);
console.log("Following is Depth First Traversal (starting from vertex 2)<br>");
g.DFS(2);