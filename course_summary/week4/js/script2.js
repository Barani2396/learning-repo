// JS objects and functions

console.log("Object creation with new keyword & object constructor");
console.log("----------------------------------------\n");
var company = new Object();
company.name = "Google";
company.ceo = new Object();
company.ceo.firstName = "Sundar";
company.ceo.lastName = " Pichai";
company["Stock of company"] = 1303000000000;
console.log("Object name company1 holding google details");
console.log(company);
console.log("\n");

console.log("Object creation with object literal syntax");
console.log("----------------------------------------\n");
var company = {
    name: "FB",
    ceo: {
        lirstName: "Mark",
        lastName: "Zuckberg"
    },
    "Stock of company": 320000000000,
};
console.log("Object name company holding faceBook details");
console.log(company);
console.log("\n");

console.log("Functions");
console.log("Functions are objects and they are first class data types");
console.log("----------------------------------------\n");
function multiply(x, y) {
    return x * y;
}
console.log(multiply(2,2));
multiply.version = "v.1.0.0";
console.log("The function multiply declared here has a property but won't be logged as the way objects logged, instead the log the function itself\n");
console.log(multiply);
console.log("To access the the property of a function use normal dot operator");
console.log("multiply.version is " + multiply.version);
console.log("\n");

console.log("Functions factory");
console.log("----------------------------------------\n");
function makeMultiplier(multiplier) {
    var myFunc = function (x) {
        return multiplier * x;
    }
    return myFunc;
}
var multiplyBy3 = makeMultiplier(3);
console.log(multiplyBy3(10));
console.log("\n");

console.log("Passing functions as arguments");
console.log("----------------------------------------\n");
function doOperationOn(x , operation) {
    return operation(x);
}
var result = doOperationOn(5, multiplyBy3);
console.log(result);
console.log("\n");

console.log("Copy by value");
console.log("----------------------------------------\n");
var a = 7;
var b = a;
console.log("a: "+ a);
console.log("b: "+ b);
var b = 5;
console.log("After updating b = 5")
console.log("a: "+ a);
console.log("b: "+ b);
console.log("\n");

console.log("Copy by reference");
console.log("----------------------------------------\n");
var c = { x: 7 }
var d = c;
console.log("Object c");
console.log(c);
console.log("Object d");
console.log(d);
d.x = 5;
console.log("After updating d.x = 5")
console.log("Object c also changes");
console.log(c);
console.log("Object d");
console.log(d);
console.log("\n");

console.log("'this' Keyword");
console.log("----------------------------------------\n");
function test() {
    console.log("'this' keyword under function referes to window object, which is the outer most env or global scope");
    console.log(this);
    this.myName = "Barani";
}
test();
console.log(window);
console.log("Window obj has a new property added called myName");
console.log(window.myName);
console.log("\n");

console.log("Function constructor");
console.log("Function constructors aren't normal function they create objects and they don't return anything")
console.log("----------------------------------------\n");
function Circle(radius) {
    this.radius = radius;
}
Circle.prototype.getArea = function() {
    return Math.PI * Math.pow(this.radius, 2);
}
var myCircle = new Circle(5);
console.log("myCircle object");
console.log(myCircle);
var myOtherCircle = new Circle(5);
console.log("myOtherCircle object");
console.log(myOtherCircle);
console.log("\n");

console.log("Object literals & 'this'");
console.log("If a 'this' keyword used under a inner function of an object it is pointed to window object so a workaround need to be in place");
console.log("----------------------------------------\n");
var literalCircle = {
    radius: 10,
    getArea: function () {
        var self = this;
        console.log(this);
        var increaseRadius = function() {
            self.radius = 20
        }
        increaseRadius();
        return Math.PI * Math.pow(this.radius, 2);
    },
}
console.log(literalCircle .getArea());
console.log("\n");

