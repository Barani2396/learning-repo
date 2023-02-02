// JS arrays, closure, namespaces and IIFEs

console.log("Arrays");
console.log("Arrays are basically objects");
console.log("----------------------------------------\n");
var arr = new Array();
arr[0] = "Barani";
arr[1] = 2;
arr[2] = function (name) {
    return "Hello " + name;
};
arr[3] = { course: "HTML, CSS & JS", author: "Yaakov" };
console.log(arr);
console.log(arr[0]);
console.log(arr[2]("Abi"));
console.log(arr[3].course);
console.log("\n");

console.log("Short hand array creation");
console.log("----------------------------------------\n");
var names = ["Barani", "Arul", "Abi"];
console.log(names);
for (var i = 0; i < names.length; i++) {
    console.log("Name " + names[i] + " in index " + i);
}
names[100] = "Jim";
for (var i = 0; i < names.length; i++) {
    console.log("Name " + names[i]);
}
console.log("\n");

console.log("For in loop (for objects and arrays)");
console.log("----------------------------------------\n");
var names2 = ["Barani", "Arul", "Abi"];
names2.animalName = "Pepper";
for (var name in names2) {
    if(name == "animalName") {
        console.log("Animal's name " + names2[name]);
    }
    else {
        console.log("Person's name " + names2[name]);
    }
}
console.log("\n");

console.log("Closures");
console.log("----------------------------------------\n");
function incrementor(num) {
    function b() {
        console.log("Incrementor " + num);
    }
    b();
    return (
        function (x) {
            return num + x;
        }
    )
}
var incrementByThree = incrementor(3);
console.log(incrementByThree(5));
console.log("\n");

console.log("Namespaces");
console.log("A namespace ensures that all of a given set of objects have unique names so that they can be easily identified. Namespaces are commonly structured as hierarchies to allow reuse of names in different contexts.")
console.log("----------------------------------------\n");
console.log("File1.js with var name = 'Barani'");
var name = "Barani";
console.log("File2.js with var name = 'Bharath'");
var name = "Bharath";
console.log("My name is " + name + ". Expected name is Barani");
console.log("To use namespace define the var's, functions and objs under an Object");
console.log("File1.js with obj1.name = 'Barani'");
var obj1 = {};
obj1.name = "Barani";
obj1.getName = function() {
    return this.name;
}
console.log("File2.js with obj2.name = 'Bharath'");
var obj2 = {};
obj2.name = "Barani";
obj2.getName = function() {
    return this.name;
}
console.log("My name is " + obj1.getName());
console.log("\n");

console.log(" Immediately Invoked Function Expressions (IIFEs)");
console.log("----------------------------------------\n");
(function () {
    console.log("This function is executed immediately by this expression (function () { ... })(); ");
})();
console.log("\n");