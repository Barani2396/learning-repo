/* Write a function that takes an array of numbers as an argument and filters and returns the even numbers in them. */

var arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

function is_even_num(arr_of_num) {
    return arr_of_num.filter(function(ele) { return ele % 2 == 0; });
}