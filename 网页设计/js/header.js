window.onscroll = function() {
    scrollFunction();
}

function scrollFunction() {
    if (document.body.scrollTop > 1 || document.documentElement.scrollTop > 1) {
        document.getElementById("topnav").style.padding = "5px";
        document.getElementById("topnav").style.fontSize = "20px";
    } else {
        document.getElementById("topnav").style.padding = "30px";
        document.getElementById("topnav").style.fontSize = "25px";
    }
}