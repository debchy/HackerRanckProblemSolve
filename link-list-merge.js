class linkNode{
    constructor(data){
        this.data=data;
        this.next=null;
    }
}
function create_linked_list(array){
    let head=new linkNode(array[0]);
    let temp=head;
    for(i=1;i<array.length;i++){
        temp.next=new linkNode(array[i]);
        temp=temp.next;
    }
    return head;
}
let merge_sorted = function(head1, head2) {
    // if both lists are empty then merged list is also empty
    // if one of the lists is empty then other is the merged list
    if (!head1) {
        return head2;
    } else if (!head2) {
        return head1;
    }

    let mergedHead = null;
    if (head1.data <= head2.data) {
        mergedHead = head1;
        head1 = head1.next;
    } else {
        mergedHead = head2;
        head2 = head2.next;
    }

    let mergedTail = mergedHead;

    while (head1 && head2) {
        let temp = null;
        if (head1.data <= head2.data) {
            temp = head1;
            head1 = head1.next;
        } else {
            temp = head2;
            head2 = head2.next;
        }
        // console.log("temp",temp)
        // console.log("mergedTail1",mergedTail)
        mergedTail.next = temp;
        mergedTail = mergedTail.next;
        //console.log("mergedTail2",mergedTail)
    }

    if (head1) {
        mergedTail.next = head1;
    } else if (head2) {
        mergedTail.next = head2;
    }

    return mergedHead;
};

function isSortedLinkList(head){
    if(!head)return false;
    if(!head.next) return true;

    while(head.next){
        if(head.data>head.next.data){
            return false;
        }
        head=head.next;
    }
    return true;
}

function insertIntoSortedList(head,data){
    let newNode=new linkNode(data);    
    if(!head)head=newNode;//if sullpied head is null put data into head
    else if(head.data>=data){
        //first node is bigger, so insert at the root
        newNode.next=head;
        head=newNode;
    }else{
        let tail=head;
        //iterate until minimum bigger node found
        while(tail && tail.data<data){
            if(!tail.next)break;
            if(tail.next.data>=data)break;
            tail=tail.next;
        }
        if(tail.next){
            //node to insert inside
            newNode.next= tail.next;
            tail.next=newNode;
        }else{
            //end node
            tail.next=newNode;
        }
        
    }

    return head;
}

function deleteFromSortedList(head,data){
    let tail=head,prev=null;

    //if head have the search value
    if(tail && tail.data==data){
        head=tail.next;
        return head;
    }

    //if search value is inside of a list
    while(tail && tail.data!=data){
        prev=tail;
        tail=tail.next;
    }

    //travelling reach the end, data not found
    if(!tail)return head;

    prev.next=tail.next;
    return head;
}


console.log("");
console.log("");
console.log("+++++++++++++++++++++++++++++++++++++++");
console.log("Insertion Sort");
console.log("---------------------------------------");

let merge_sort_node_1 = create_linked_list([1, 3, 5, 6]);
let merge_sort_node_2 = create_linked_list([2, 4, 6, 20, 34]);
let merged_sort = create_linked_list([1, 2, 3, 4, 5, 6, 6, 20, 34]);


let temp_head = merge_sort_node_1;
console.log("1st Linked List");
while (temp_head) {
    console.log(temp_head.data);
    temp_head = temp_head.next;
}

temp_head = merge_sort_node_2;
console.log("2nd Linked List");
while (temp_head) {
    console.log(temp_head.data);
    temp_head = temp_head.next;
}
let result = merge_sorted(merge_sort_node_1, merge_sort_node_2);
temp_head = result;
console.log("is sorted", isSortedLinkList(temp_head));
temp_head = result;
console.log("Result Merge Sorted List");
while (temp_head) {
    console.log(temp_head.data);
    temp_head = temp_head.next;
}
temp_head = insertIntoSortedList(result,0);
temp_head = insertIntoSortedList(temp_head,1)
temp_head = insertIntoSortedList(temp_head,7)
temp_head = insertIntoSortedList(temp_head,6)
temp_head = insertIntoSortedList(temp_head,35)
temp_head = deleteFromSortedList(temp_head,0)
temp_head = deleteFromSortedList(temp_head,6)
temp_head = deleteFromSortedList(temp_head,35)
console.log("3nd Linked List");
while (temp_head) {
    console.log(temp_head.data);
    temp_head = temp_head.next;
}
// let merge_sort_node_1 = create_linked_list([1, 3, 5, 6]);
// console.log("is sorted", isSortedLinkList(temp_head));