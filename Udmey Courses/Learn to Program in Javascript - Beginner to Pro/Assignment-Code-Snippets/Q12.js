/* Write a function that takes an array and a criteria function(for filtering) and 
returns the array of those elements which do not fulfill the criteria. 
The criteria function should take any element as argument and return a boolean value. */

var arr = [];
for (var n = 1; n <= 1000; n++) {
    arr[n - 1] = n;
}

function is_prime(num) {
    var f = 0;
    for (var v = 2; v <= Math.round(num / 2); v++) {
        if (num % v == 0) {
            f = 1;
            break;
        }
    }
    if (f == 0 && num != 1) {
        return true;
    } else {
        return false;
    }
}

function prime_printer(arr_num, filtering) {
    var p_arr = [];
    var j = 0;
    for (var i = 0; i < arr_num.length; i++) {
        if (filtering(arr_num[i])) {
            p_arr[j] = arr_num[i];
            j++;
        }
    }
    return p_arr;
}