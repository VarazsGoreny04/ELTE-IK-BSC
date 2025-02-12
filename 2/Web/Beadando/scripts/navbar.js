function classToggle() {
    const navs = document.querySelectorAll('.navbar_items')

    navs.forEach(nav => nav.classList.toggle('navbar_list-toggle'));
}

document.querySelector('.navbar_link-toggle').addEventListener('click', classToggle);