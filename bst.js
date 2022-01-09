// Binary Search tree class
class BinarySearchTree
{
    constructor()
    {
        // root of a binary search tree
        this.root = null;
    }
 
    // ***** function to be implemented ******
    // helper method which creates a new node to
    // be inserted and calls insertNode
    insert(data)
    {
        // Creating a node and initailising
        // with data
        var newNode = new Node(data);
                        
        // root is null then node will
        // be added to the tree and made root.
        if(this.root === null)
            this.root = newNode;
        else    
            // find the correct position in the
            // tree and add the node
            this.insertNode(this.root, newNode);
    }
    
    // Method to insert a node in a tree
    // it moves over the tree to find the location
    // to insert a node with a given data
    insertNode(node, newNode)
    {
        // if the data is less than the node
        // data move left of the tree
        if(newNode.data < node.data)
        {
            // if left is null insert node here
            // if left is not null recur until null is found
            if(node.left === null) node.left = newNode;
            else this.insertNode(node.left, newNode);
        }
    
        // if the data is more than the node
        // data move right of the tree
        else
        {
            // if right is null insert node here
            if(node.right === null) node.right = newNode;
            else this.insertNode(node.right,newNode);
        }
    }
    // remove(data)
                 
 
    // Helper function
    // findMinNode()
    // getRootNode()
    // inorder(node)
    // preorder(node)              
    // postorder(node)
    // search(node, data)
}

// Node class
class Node
{
    constructor(data)
    {
        this.data = data;
        this.left = null;
        this.right = null;
    }
}

function create_BST(array){
    let bst=new BinarySearchTree();
    for(i=0;i<array.length;i++)bst.insert(array[i]);
    
    return bst.root;
}

let level_order_traversal_1 = function(root) {
    if (!root) {
      return;
    }
  
    let queues = [
      [],
      []
    ];
    let current_queue = queues[0];
    let next_queue = queues[1];
  
    current_queue.push(root);
    let level_number = 0;
  
    while (current_queue.length > 0) {
      let temp = current_queue.shift();
      console.log(temp.data + " ");
      if (temp.left) {
        next_queue.push(temp.left);
      }
  
      if (temp.right) {
        next_queue.push(temp.right);
      }
  
      if (current_queue.length === 0) {
        level_number++;
        current_queue = queues[level_number % 2];
        next_queue = queues[(level_number + 1) % 2];
      }
    }
  };
  
  console.log("");
  console.log("");
  console.log("+++++++++++++++++++++++++++++++++++++++");
  console.log("Level Order Traversal");
  console.log("---------------------------------------");
  var arr = [100,50,200,25,75,350];
  let root = create_BST(arr);
//   console.log("InOrder Traversal:");
//   display_inorder(root);
  console.log("\nLevel Order Traversal1:");
  level_order_traversal_1(root);

/**** validate bst ****/
  let is_bst_rec = function(root, min_value, max_value) {
    if (!root) {
      return true;
    }
  
    if (root.data < min_value || root.data > max_value) {
      return false;
    }
  
    return is_bst_rec(root.left, min_value, root.data) && is_bst_rec(root.right, root.data, max_value);
  };
  
  let is_bst = function(root) {
    return is_bst_rec(root, -Number.MAX_VALUE - 1, Number.MAX_VALUE);
  };
  