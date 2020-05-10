/* Write a factorial function that returns the factorial of a given number, n. 
Make sure you return the calculated value and not just print it. [function factorial(n){...}] */

function factorial(val) {
    if (val == 0) {
        return 1;
    } else {
        var t = 1;
        for (i = 1; i < val; i++) {
            t = (val - i) * t;
        }
        val = val * t;
        return val;
    }
}