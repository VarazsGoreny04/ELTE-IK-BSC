window.onscroll = function() {scroll()};

function scroll() {
    let nav = document.getElementById("totop");

    if (document.body.scrollTop > 300 || document.documentElement.scrollTop > 300) {
        nav.style.display = "grid";
    } else {
        nav.style.display = "none";
    }
}

function toTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
