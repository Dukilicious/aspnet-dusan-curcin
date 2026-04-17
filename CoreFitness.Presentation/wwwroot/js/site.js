// *HEADER-NAV* Hamburger off-screen Menu (Mobile)
const hamMenu = document.querySelector(".ham-menu");

const offScreenMenu = document.querySelector(".off-screen-menu");

hamMenu.addEventListener("click", () => {
    hamMenu.classList.toggle("active");
    offScreenMenu.classList.toggle("active");
});



// *FAQ-SECTION* Accordion (AI generated / Youtube video)

const accordions = document.querySelectorAll(".accordion-container");

accordions.forEach(accordion => {
    accordion.addEventListener("click", () => {
        const isActive = accordion.classList.contains("active");

        accordions.forEach(item => item.classList.remove("active"));

        if (!isActive) {
            accordion.classList.add("active");
        }
    });
});

