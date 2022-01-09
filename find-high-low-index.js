let findLowIndex = function(arr, key) {
    let low = 0;
    let high = arr.length - 1;
  
    while (low <= high) {
      let mid = low + Math.floor((high - low) / 2);
      
      if (arr[mid] < key) {
        low = mid + 1;
      } else {
        high = mid - 1;
      }
    }
    
    if (low < arr.length && arr[low] === key) {
      return low;
    }
  
    return -1;
};
  
  let findHighIndex = function(arr, key) {
    let low = 0;
    let high = arr.length - 1;
  
    while (low <= high) {

      let mid = low + Math.floor((high - low) / 2);
      
      if (arr[mid] <= key) {
        low = mid + 1;
      } else {
        high = mid - 1;
      } 
    }

    if (high < arr.length && arr[high] === key) {
      return high;
    }
  
    return -1;
};
  
let binarySearch = function (arr, x) {
  
    let start=0, end=arr.length-1;
         
    // Iterate while start not meets end
    while (start<=end){ 
        // Find the mid index
        let mid=Math.floor((start + end)/2);
  
        // If element is present at mid, return True
        if (arr[mid]===x){ console.log("index",mid); return true;}
 
        // Else look in left or right half accordingly
        else if (arr[mid] < x)   start = mid + 1;
        else end = mid - 1;
    }
  
    return false;
}

  let array = [1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 6, 6, 6];
  
  var key = 5;
  console.log("Low Index of " + key + ": " + (findLowIndex(array, key)));
  console.log("High Index of " + key + ": " + (findHighIndex(array, key)));
  console.log("binarySearch of " + key + ": " + (binarySearch(array, key)));
  key = -2;
  console.log("Low Index of " + key + ": " + (findLowIndex(array, key)));
  console.log("High Index of " + key + ": " + (findHighIndex(array, key)));