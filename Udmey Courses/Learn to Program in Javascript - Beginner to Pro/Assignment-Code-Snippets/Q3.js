/* Write a JavaScript program to convert temperatures to and from celsius, fahrenheit. 
[ Use the formula : c = 5*(f-32)/9, where c = temperature in celsius and f = temperature in fahrenheit] */

function celsius_fahrenheit_converter(temp, cf) {
    if (cf == "C") {
        var c = (5 * (temp - 32)) / 9;
        console.log("The Fahrenheit to celcius conversion is " + c);
    } else if (cf == "F") {
        var f = (temp * 9 / 5) + 32;
        console.log("The celcius to Fahrenheit conversion is " + f);
    } else {
        console.log("Please give any two of the literals 'C/F' as arguments to do the conversion");
    }
}