function subscribeToClick() {
    var elements = document.querySelectorAll(".map rect[id^=rect_]");
    Array.prototype.forEach.call(elements, function (el, i) {
        el.addEventListener('click', function () {
            var id = el.id.substring(5);
            //window.location = "/" + id;
            window.open("/" + id);
        }, false);
    });
}

function setOccupied(occupied) {
    occupied.occupied.forEach(function (item, i) {
        var elName = "rect_" + item;
        element = document.getElementById(elName);
        //element.classList.remove('auditory');
        element.classList.add('auditory-occupied');
    });
}