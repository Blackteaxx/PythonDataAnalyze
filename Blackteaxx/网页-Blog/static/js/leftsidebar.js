window.addEventListener('resize', handleResize);

function handleResize() {
    var width = window.innerWidth
    if(width > 1000) {
        document.getElementById("myleftsidebar").style.visibility = "visible";
        document.getElementById("myrightsidebar").style.visibility = "visible";
    } else {
        document.getElementById("myleftsidebar").style.visibility = "hidden";
        document.getElementById("myrightsidebar").style.visibility = "hidden";
    }
}




