// Week 4 - JS Contents

console.log("Week 4 - Course works");
console.log("Check the .js files under week4 folder");
console.log("----------------------------------------\n");
console.log("\n");

// JS types and common language constructs

console.log("Global & function scopes");
console.log("----------------------------------------\n");
var message = "in global";
console.log("global: message = " + message);
var a = function () {
    var message = "inside a";
    console.log("a: message = " + message);
    b();
}
function b() {
    console.log("a: message = " + message);
}
a();
console.log("\n");

console.log("String concatination");
console.log("----------------------------------------\n");
var string = "Hello";
string += " Barani!";
console.log(string);
console.log("\n");

console.log("Regular math operation");
console.log("----------------------------------------\n");
console.log((5 + 4) / 3);
console.log(undefined / 3);
console.log("\n");

console.log("Equality operator");
console.log("----------------------------------------\n");
var x = 4, y = 4;
if(x == y) {
    console.log("x and y are equal");
}
var x = "4";
if(x == y) {
    console.log("x and y are equal though x is string because of double equality operator");
}
console.log("\n");

console.log("Strict equality operator");
console.log("----------------------------------------\n");
var x = 4, y = 4;
var x = "4";
if(x === y) {
    console.log("x and y are equal");
}
else {
    console.log("x and y are't equal because x is a string, since triple equality check for the type first");
}
console.log("\n");

console.log("If statement (all false)");
console.log("----------------------------------------\n");
if(false || null || undefined || 0 || "" || NaN) {
    console.log("This line won't execute");
}
else {
    console.log("All are false");
}
console.log("\n");

console.log("If statement (all true)");
console.log("----------------------------------------\n");
if(true && "Hello" && 1 && -1 && "false") {
    console.log("All are true");
}
console.log("\n");

console.log("For loop");
console.log("----------------------------------------\n");
for (var i = 0; i <=4; i++) {
    console.log("Value of I is " + i);
}
console.log("\n");

console.log("Default values");
console.log("----------------------------------------\n");
function orderChickenWith(sidedish) {
    sidedish = sidedish || "Whatever";
    console.log("Chicken with " + sidedish);
}
orderChickenWith("Rice");
orderChickenWith();
console.log("\n");


