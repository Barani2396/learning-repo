// jQuery's DOMContentLoaded event
$(function () {
    // Hidding nav list on button blur
    $(".navbar-toggler").blur(function (event) {
        var screenWidth = window.innerWidth;
        if (screenWidth < 992) {
            $(".navbar-collapse").collapse("hide");
        }
    });

     // Active menu bar
     $("ul li .nav-link, #special-tile, #menu-tile").click(function () {
        $('li .nav-link').removeClass("active");
        if(this.id == "special-tile" || this.id == "menu-tile") {
            $("a[href='#menu']").addClass("active");
        } else {
            $(this).addClass("active");
        }
    });
});

// IIFE
(function(global) {
    var sh = {};

    var homeHtml = "snippets/home.html";
    var allMenuUrl = "https://coursera-jhu-default-rtdb.firebaseio.com/categories.json";
    var menuTitleHtml = "snippets/menu-item-title.html";
    var menuHtml = "snippets/menu-item.html";
    var categoryItemsUrl = "https://coursera-jhu-default-rtdb.firebaseio.com/menu_items/";
    var categoryTitleHtml = "snippets/category-title.html"
    var categoryHtml = "snippets/category.html"

    var insertHtml = function (selector, html) {
        var targetElement = document.querySelector(selector);
        targetElement.innerHTML = html;
    };

    // Show loading icon
    var showLoading = function (selector) {
        var html = '<div class="text-center">';
        html += '<img src="images/ajaxLoading.gif"></div>';
        insertHtml(selector, html);
    };

    var insertProperty = function (string, propName, propValue) {
        var propToReplace = "{{" + propName + "}}";
        string = string.replace(new RegExp(propToReplace, "g"), propValue);
        return string;
    };

    document.addEventListener("DOMContentLoaded", function(event) {

        showLoading("#main-content");
        $ajaxUtils.sendGetRequest(homeHtml, function(request) {
            document.querySelector("#main-content").innerHTML = request.responseText;
        }, false);

        $sh.loadMenuItems = function () {
            showLoading("#main-content");
            $ajaxUtils.sendGetRequest(allMenuUrl, buildAndShowMenuHtml)
        };

        $sh.loadCategoryItems = function (categoryShort) {
            showLoading("#main-content");
            $ajaxUtils.sendGetRequest(`${categoryItemsUrl}${categoryShort}.json`, buildAndShowCategoryHtml)
        };

        function buildAndShowMenuHtml (menu) {
            $ajaxUtils.sendGetRequest(menuTitleHtml, function (menuTitleHtml) {
                $ajaxUtils.sendGetRequest(menuHtml, function (menuHtml) {
                    var menuViewHtml = buildMenuViewHtml(menu, menuTitleHtml, menuHtml);
                    insertHtml("#main-content", menuViewHtml);
                },false);
            }, false);
        }

        function buildAndShowCategoryHtml (category) {
            $ajaxUtils.sendGetRequest(categoryTitleHtml, function (categoryTitleHtml) {
                $ajaxUtils.sendGetRequest(categoryHtml, function (categoryHtml) {
                    var categoryViewHtml = buildCategoryViewHtml(category, categoryTitleHtml, categoryHtml);
                    insertHtml("#main-content", categoryViewHtml);
                },false);
            }, false);
        }

        function buildMenuViewHtml(menu, menuTitleHtml, menuHtml) {
            var finalHtml = menuTitleHtml.responseText;

            menu = JSON.parse(menu.responseText);
            
            finalHtml += '<div class="container"><section class="row justify-content-center">';
            
            for (var i = 0; i < menu.length; i++) {
                var html = menuHtml.responseText;
                var name = "" + menu[i].name;
                var short_name = menu[i].short_name;
                html = insertProperty (html, 'name', name);
                html = insertProperty (html, 'short_name', short_name);
                finalHtml += html;
            }

            finalHtml += '</section></div>';
            
            return finalHtml;
        }

        function buildCategoryViewHtml(category, categoryTitleHtml, categoryHtml) {
            category = JSON.parse(category.responseText);
            categoryTitleHtml = categoryTitleHtml.responseText;
            categoryHtml = categoryHtml.responseText;

            categoryTitleHtml = insertProperty(categoryTitleHtml, "name", category.category.name);

            categoryTitleHtml = insertProperty(categoryTitleHtml, "special_instructions", category.category.special_instructions);

            var finalHtml = categoryTitleHtml;

            finalHtml += `<div class="container"><section class="row">`

            var categoryItems = category.menu_items;
            var catShortName = category.category.short_name;
            for (var i = 0; i < categoryItems.length; i++) {
                var html = categoryHtml;
                var fhtml = `<div class="menu-item-tile col-lg-6 mb-lg-5 mb-3"><div class="row text-md-start text-center">`;
                var lhtml = `</div></div>`;
                html = insertProperty(html, "short_name", categoryItems[i].short_name);
                html = insertProperty(html, "catShortName", catShortName);
                html = insertItemPrice(html, "price_small", categoryItems[i].price_small);
                html = insertItemPortionName(html, "small_portion_name",categoryItems[i].small_portion_name);
                html = insertItemPrice(html, "price_large", categoryItems[i].price_large);
                html = insertItemPortionName(html, "large_portion_name", categoryItems[i].large_portion_name);
                html = insertProperty(html, "name", categoryItems[i].name);
                html = insertProperty(html, "description", categoryItems[i].description);
                finalHtml += fhtml + html + lhtml;
            }            

            finalHtml += `</section></div>`

            return finalHtml;
        }
    });

    function insertItemPrice(html, pricePropName, priceValue) {
        if(!priceValue) {
            return insertProperty(html, pricePropName, "");
        }

        priceValue = "$" + priceValue.toFixed(2);
        html = insertProperty(html, pricePropName, priceValue);
        return html;
    }

    function insertItemPortionName(html, portionPropName, portionValue) {
        if(!portionValue) {
            return insertProperty(html, portionPropName, "");
        }

        portionValue = "(" + portionValue + ")";
        html = insertProperty(html, portionPropName, portionValue);
        return html;
    }

    global.$sh = sh;
})(window);