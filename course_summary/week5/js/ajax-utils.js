(function (global) {
    var ajaxUtils = {};

    // Returns an HTTP request object
    function getRequestObject() {
        if(window.XMLHttpRequest) { // Check the window has XMLHttpRequest Object
            return (new XMLHttpRequest);
        }
        else if(window.ActiveXObject){ // if the previous is not found checks for AcriveXObject
            return (new ActiveXObject);
        }
        else {
            global.alert("AJAX is not supported");
            return (null);
        }
    }

    // Make an AJAX GET request to 'requestUrl'
    ajaxUtils.sendGetRequest = function (requestUrl, responseHandler) {
        var request = getRequestObject(); // Storing the returned object from the getRequestObject method
        request.onreadystatechange = function () { // This is a diff stage of the network communication btw the client and server
            handleResponse(request, responseHandler); // When the response back from server this fuction is executed 
        };
        request.open("GET", requestUrl, true); // Making the GET request asynchronous by passing true
        request.send(null) // POST only, in the null you can send the body 
    };

    /*
        Only call user provided 'responseHandlers'
        function if response is ready
        and not an error
    */ 
   function handleResponse(request, responseHandler) {
    if((request.readyState) == 4 && (request.status == 200)) {
        responseHandler(request);
    }
   }

   // Expose utility to the global object
   global.$ajaxUtils = ajaxUtils;
})(window);