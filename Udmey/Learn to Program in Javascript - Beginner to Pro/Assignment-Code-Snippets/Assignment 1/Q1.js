/* Write a javascript function named is_integer which checks if the passed argument is an integer. 
You can use any mathematical operator or functions defined in the Math object. */

function is_interger(a) {
    if (typeof(a) === Number) {
        return "This is a number";
    } else {
        return "This is a " + typeof(a);
    }
}