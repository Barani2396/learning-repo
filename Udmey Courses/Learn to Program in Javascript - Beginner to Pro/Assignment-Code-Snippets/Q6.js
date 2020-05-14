/* Write a javascript function named reverse which takes a string argument and returns the reversed string. */

function reverse(str) {
    var str_r = [];
    var j = str.length - 1;
    for (var i = 0; i < str.length; i++) {
        str_r[i] = str[j];
        j--;
    }
    return str_r.join("");
}

var str = reverse("void");