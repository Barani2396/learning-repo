/* Given a javascript array of objects having a radius property as shown [{radius: 5}, {radius: 9}, {radius: 2}], 
write a comparator function to sort it. */

var rads = [{ radius: 5 }, { radius: 9 }, { radius: 2 }];

function comparator(x, y) {
    return (x.radius - y.radius);
}

rads.sort(comparator);