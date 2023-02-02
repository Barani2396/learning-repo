// AJAX

document.addEventListener("DOMContentLoaded", function() { 
    
    // Unobstructive event binding
    document.getElementById("ajButton1").addEventListener("click", function() {

        // Call server to get the name from txt file
        $ajaxUtils.sendGetRequest("/course_summary/week5/data/name.txt", function (request) {
            var name = request.responseText;
            document.querySelector("#servName1").innerHTML = `Hello ${name} `
        });

        $ajaxUtils.sendGetRequest("/course_summary/week5/data/familyName.txt", function (request) {
            var name = request.responseText;
            document.querySelector("#servFamilyName1").innerHTML = `${name}!`;
        });
    });

    document.getElementById("ajButton2").addEventListener("click", function() {

        // Call server to get the name from json file
        $ajaxUtils.sendGetRequest("/course_summary/week5/data/detail.json", function (request) {
            var res = request.response;
            var resObj = JSON.parse(res);
            document.querySelector("#servDetail").innerHTML = 
                `<h2>My name is ${resObj.firstName} ${resObj.lastName}</h2>
                <p>I did my Master in ${resObj.school.pg} and my UG in ${resObj.school.ug}.</p>
                `
        });
    });
});