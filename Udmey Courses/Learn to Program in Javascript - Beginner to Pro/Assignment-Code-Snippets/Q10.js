/* Write a function that takes an array of numbers and returns the sum of squares of those numbers. 
E.g. if the array passed is [1, 2, 3] then the function should return 14. */

var arr = [1, 2, 3];

function sum_of_squares(arr_of_nums) {
    return arr_of_nums.map(function(ele) { return ele * ele; }).reduce(function(prev, curr) { return prev + curr; }, 0);
}