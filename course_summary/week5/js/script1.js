// Week 5 - JS Contents

console.log("Week 5 - Course works");
console.log("Check the .js files under week5 folder");
console.log("----------------------------------------\n");
console.log("\n");

// Document object model manipulation 

console.log("DOM Manipulation");
console.log("Window object will have a document property under it which itself an object, contains collection of html element objects of the current document");
console.log("----------------------------------------\n");
console.log("Window.document")
console.log(window.document);
console.log("The Document object is a instace of HTMLDocument object");
console.log("document instanceof HTMLDocument: " + (document instanceof HTMLDocument));
console.log("\n");

/* 
    DOMContentLoaded event fires when the HTML document has been completely parsed, 
    and all deferred scripts (<script defer src="…"> and <script type="module">) have 
    downloaded and executed. It doesn't wait for other things like images, subframes, 
    and async scripts to finish loading.
*/
document.addEventListener("DOMContentLoaded", function() {
    function sayHello(event) {
        this.textContent = "Said it";
        var name = document.getElementById("userName").value;
        var message = "<h3>Hello " + name + "!</h3>"; 
        if(name == "") {
             message = `<h3 style="color:red;">Pls enter a name</h3>`;
        }
        document.getElementById("greetingContent").innerHTML = message;
        document.getElementById("additionalContent1").innerHTML = "Check the console for the event object of this button";
        console.log("Event: ");
        console.log(event);
        console.log("\n");
    }
    
    // Unobstructive event binding
    document.querySelector("#sayHello").addEventListener("click", sayHello);

});
