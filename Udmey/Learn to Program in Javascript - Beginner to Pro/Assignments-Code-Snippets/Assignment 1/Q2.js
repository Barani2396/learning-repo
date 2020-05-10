/* Using the forEach function defined for an array, find the sum of the array of numbers. [function add_all(arr) {...}] */

var arr = [1, 2, 2];
var sum = 0;

function add_all(arr) {
    arr.forEach(iterate);
    alert("The sum of array is " + sum);
    sum = 0;
}

function iterate(item) {
    console.log(item, sum);
    sum = item + sum;
}