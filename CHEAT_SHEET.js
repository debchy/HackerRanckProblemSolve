/*********** ARRAY *********/
//array operation
let fruits = ['Apple', 'Banana']

console.log(fruits.length)
// 2

let first = fruits[0]
// Apple

let last = fruits[fruits.length - 1]
// Banana

//Loop over an Array
fruits.forEach(function(item, index, array) {
  console.log(item, index)
})
// Apple 0
// Banana 1

let newLength = fruits.push('Orange')
// ["Apple", "Banana", "Orange"]

let last = fruits.pop() // remove Orange (from the end)
// ["Apple", "Banana"]
// last = "Orange"

let first = fruits.shift() // remove Apple from the front
// ["Banana"]
// first = "Apple"

//Add an item to the beginning of an Array
let newLength = fruits.unshift('Strawberry') // add to the front
// ["Strawberry", "Banana"]

//Find the index of an item in the Array
let pos = fruits.indexOf('Banana')// 1

//Remove an item by index position  
let removedItem = fruits.splice(pos, 1) // this is how to remove an item
// ["Strawberry", "Mango"]

//Remove items from an index position
let vegetables = ['Cabbage', 'Turnip', 'Radish', 'Carrot']
let pos = 1
let n = 2
let removedItems = vegetables.splice(pos, n)
// this is how to remove items, n defines the number of items to be removed,
// starting at the index position specified by pos and progressing toward the end of array.
// vegetables= ["Cabbage", "Carrot"] (the original array is changed)
// removedItems=["Turnip", "Radish"]

//Copy an Array
let shallowCopy = fruits.slice() // this is how to make a copy

//push multiple items
const fruits = []
fruits.push('banana', 'apple', 'peach')
console.log(fruits.length) // 3

//verify an object as array
Array.isArray(fruits)
//Returns true if the argument is an array, or false otherwise.

//The find() method returns the value of the first element in the provided array that satisfies the provided
//undefined if not found.
const array1 = [5, 12, 8, 130, 44];
const found = array1.find(element => element > 10);
console.log(found);// expected output: 12

//Array.prototype.indexOf()
//The indexOf() method returns the first index at which a given element can be found in the array, 
//or -1 if it is not present.
const beasts = ['ant', 'bison', 'camel', 'duck', 'bison'];
console.log(beasts.indexOf('bison'));// expected output: 1
// start from index 2
console.log(beasts.indexOf('bison', 2));// expected output: 4
console.log(beasts.indexOf('giraffe'));// expected output: -1

//Array.prototype.lastIndexOf()
console.log(animals.lastIndexOf('bison'));// expected output: 4

//The includes() method determines whether an array includes a certain value among its entries, returning true or false as appropriate.
const array1 = [1, 2, 3];
console.log(array1.includes(2));// expected output: true

//keys()
var arr = ['a', , 'c'];
var sparseKeys = Object.keys(arr);
var denseKeys = [...arr.keys()];
console.log(sparseKeys); // ['0', '2']
console.log(denseKeys);  // [0, 1, 2]

//map()
//The map() method creates a new array populated with the results of calling a provided function on every element in the calling array.
const array1 = [1, 4, 9, 16];
// pass a function to map
const map1 = array1.map(x => x * 2);
console.log(map1);// expected output: Array [2, 8, 18, 32]

//Array.reduce()
console.log(array1.reduce((previousValue, currentValue) => previousValue + currentValue)); // expected output: 20

//Array.prototype.reverse()
const reversed = array1.reverse(); //16,9,4,1

//sort ascending order
var numbers = [4, 2, 5, 1, 3];
numbers.sort((a, b) => a - b);
const students = [
    { name: "Alex",   grade: 15 },
    { name: "Devlin", grade: 15 },
    { name: "Eagle",  grade: 13 },
    { name: "Sam",    grade: 14 },
  ];
//After sorting this array by grade in ascending order:
students.sort((firstItem, secondItem) => firstItem.grade - secondItem.grade);

//Array.prototype.join()
const elements = ['Fire', 'Air', 'Water'];
console.log(elements.join());// expected output: "Fire,Air,Water"
console.log(elements.join(''));// expected output: "FireAirWater"
console.log(elements.join('-'));// expected output: "Fire-Air-Water"


/********* STRING ***********/
const string1 = "A string primitive";
const string2 = 'Also a string primitive';
const string3 = `Yet another string primitive`;
const string4 = new String("A String object");

'cat'.charAt(1) // returns "a"
'cat'[1] // returns "a"

//string compare
function isEqual(str1, str2){ return str1.toUpperCase() === str2.toUpperCase()}

let s1 = '2 + 2'              // creates a string primitive
let s2 = new String('2 + 2')  // creates a String object
console.log(eval(s1))         // returns the number 4
console.log(eval(s2))         // returns the string "2 + 2"
//A String object can always be converted to its primitive counterpart with the valueOf() method.
console.log(eval(s2.valueOf()))  // returns the number 4

//The includes() method performs a case-sensitive search to determine whether one string may be found within another string, returning true or false as appropriate.
const sentence = 'the quick brown fox jumps over the lazy dog.';
const word = 'fox';
sentence.includes(word)//true

//The indexOf() method returns the index within the calling String object of the first occurrence of the specified value, starting the search at fromIndex. Returns -1 if the value is not found.
indexOf(searchValue)
indexOf(searchValue, fromIndex)
sentence.indexOf(word)//16
sentence.indexOf('the',1)//31

//lastIndexOf()
//The index of the last character in the string to be considered as the beginning of a match. The default value is +Infinity. If fromIndex >= str.length, the whole string is searched. If fromIndex < 0, the behavior will be the same as if it would be 0.
lastIndexOf(searchValue)
lastIndexOf(searchValue, fromIndex)

//Using endsWith()
endsWith(searchString)
endsWith(searchString, length)
//length Optional:
//If provided, it is used as the length of str. Defaults to str.length
let str = 'To be, or not to be, that is the question.'
console.log(str.endsWith('question.'))  // true
console.log(str.endsWith('to be'))      // false
console.log(str.endsWith('to be', 19))  // true

//String.prototype.match()
const str = 'For more information, see Chapter 3.4.5.1';
const re = /see (chapter \d+((\.\d)*))/i;
const found = str.match(re); //["see Chapter 3.4.5.1", "Chapter 3.4.5.1", ".4.5.1", ".1"]

//String.prototype.replace()
//The replace() method returns a new string with some or all matches of a pattern replaced by a replacement.
const p = 'The quick brown fox jumps over the lazy dog. If the dog reacted, was it really lazy?';
console.log(p.replace('dog', 'monkey'));// expected output: "The quick brown fox jumps over the lazy monkey. If the dog reacted, was it really lazy?"
const regex = /Dog/ig;
console.log(p.replace(regex, 'ferret'));// expected output: "The quick brown fox jumps over the lazy ferret. If the dog reacted, was it really lazy?"
console.log(p.replaceAll('dog', 'monkey'));

//String.prototype.search()
//The search() method executes a search for a match between a regular expression and this String object.
const regex = /[^\w\s]/g; // any character that is not a word character or whitespace
console.log(p.search(regex)); // expected output: 43

//String.prototype.split()
//The split() method divides a String into an ordered list of substrings, puts these substrings into an array, and returns the array.
split()
split(separator)
split(separator, limit)

const words = p.split(' '); //aarray of words
const chars = str.split(''); // array UTF-16 character
const strCopy = str.split(); // single item array

//Reversing a String using split()
const str = 'asdfghjkl'
const strReverse = str.split('').reverse().join(''); //'lkjhgfdsa'

//String.prototype.startsWith()
const str1 = 'Saturday night plans';
console.log(str1.startsWith('Sat'));// expected output: true
console.log(str1.startsWith('Sat', 3));// expected output: false

//String.prototype.substring()
substring(indexStart)
substring(indexStart, indexEnd)
const str = 'Mozilla';
console.log(str.substring(1, 3));// expected output: "oz"
console.log(str.substring(2));// expected output: "zilla"

//String.prototype.toLowerCase()
//String.prototype.toUpperCase()

//String.prototype.trim()
//The trim() method removes whitespace from both ends of a string. Whitespace in this context is all the whitespace characters (space, tab, no-break space, etc.) and all the line terminator characters (LF, CR, etc.).
const greeting = '   Hello world!   ';
console.log(greeting.trim());// expected output: "Hello world!";
console.log(greeting.trimStart());// expected output: "Hello world!   ";
console.log(greeting.trimEnd());// expected output: "   Hello world!";


/**** MAP******* */
//The Map object holds key-value pairs and remembers the original insertion order of the keys.
const myMap = new Map()
myMap.set('Jessie', {phone: "213-555-1234", address: "123 N 1st Ave"})
myMap.has('Jessie') // true
myMap.get('Hilary') // undefined
myMap.set('Hilary', {phone: "617-555-4321", address: "321 S 2nd St"})
myMap.get('Jessie') // {phone: "213-555-1234", address: "123 N 1st Ave"}
myMap.delete('Raymond') // false
myMap.delete('Jessie') // true
console.log(myMap.size) // 1

//iteration of map
for (const [key, value] of myMap) {
    console.log(`${key}: ${value}`)
}
for (const key of myMap.keys()) {
    console.log(key)
}
for(const value of myMap.values()){
    console.log(value)
}

myMap.forEach((value,key)=>{ })

//clone Map
const original = new Map([    [1, 'one']  ])
const clone = new Map(original)

// Merging Map
const first = new Map([    [1, 'one'],    [2, 'two'],    [3, 'three']  ]);
const second = new Map([    [1, 'uno'],    [2, 'dos']  ]);

// Merge two maps. The last repeated key wins.
// Spread operator essentially converts a Map to an Array
// Merge maps with an array. The last repeated key wins.
const merged = new Map([...first, ...second]);

/*** Iteration ****/
//for...in
const object = { a: 1, b: 2, c: 3 };
for (const property in object) {
  console.log(`${property}: ${object[property]}`);
}

//for
for (let i = 0; i < 9; i++) {
    console.log(i);
    if (i > 3) break; //exit from for
    if (i === 2)    continue; // skip execution of next statements
    // more statements
}

//Statement - For...Of
const array1 = ['a', 'b', 'c'];
for (const element of array1) {
  console.log(element);//prints a, b, c
}


/**** Class **** */
class Polygon{
    constructor(h,w){
        this.name="poligon";
        this.height=h;
        this.width=w;
    }
}
let p=new Polygon(1,2);

/*** MATH ******** */
Math.round(x)
//Returns the value of the number x rounded to the nearest integer.
console.log(Math.round(5.95), Math.round(5.5), Math.round(5.05)); // expected output: 6 6 5
console.log(Math.round(-5.05), Math.round(-5.5), Math.round(-5.95));// expected output: -5 -5 -6

Math.random()
function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}
console.log(getRandomInt(3));// expected output: 0, 1 or 2
console.log(getRandomInt(1));// expected output: 0
console.log(Math.random());// expected output: a number from 0 to <1

Math.floor()
console.log(Math.floor(5.95));// expected output: 5
console.log(Math.floor(5));// expected output: 5
console.log(Math.floor(-5.05));// expected output: -6

Math.pow(base, exponent)
console.log(Math.pow(7, 3));// expected output: 343
Math.pow(-7, 3);   // -343 (cubes can be negative)
Math.pow(-7, 0.5); // NaN (negative numbers don't have a real square root)
Math.pow(-7, 1/3); // NaN

Math.sqrt(x)
//Returns the positive square root of x.

//Behavior of Math.abs()
Math.abs('-1');     // 1
Math.abs(-2);       // 2
Math.abs(null);     // 0
Math.abs('');       // 0
Math.abs([]);       // 0
Math.abs([2]);      // 2
Math.abs([1,2]);    // NaN
Math.abs({});       // NaN
Math.abs('string'); // NaN
Math.abs();         // NaN

//Using Math.ceil()
Math.ceil(.95);    // 1
Math.ceil(4);      // 4
Math.ceil(7.004);  // 8
Math.ceil(-0.95);  // -0
Math.ceil(-4);     // -4
Math.ceil(-7.004); // -7


console.log(Math.PI);// expected output: 3.141592653589793