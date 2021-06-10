// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const preloader = document.querySelector("._myPreloader");

let preloaderFunc = null;

if (preloader !== null) {
    if (document.readyState !== "complete") {
        preloaderFunc = setTimeout(function () {
            preloader.style.display = "grid";
            preloader.style.opacity = 1;
        }, 50);
    } 
}

window.addEventListener("DOMContentLoaded", () => {

    if (preloaderFunc !== null) {
        clearInterval(preloaderFunc);
    }
    preloader.style.display = "none";
    console.log("ready");

    const routeList = document.querySelector("._myRouteList"),
        routeItems = document.querySelectorAll("._myRouteList li"),
        airportList = document.querySelector("._myAirportList"),
        airportItems = document.querySelectorAll("._myAirportList li");

    let routeListObj = { listItems: routeItems, list: routeList, togglerFlag: false, toggler: null};
    let airportListObj = { listItems: airportItems, list: airportList, togglerFlag: false, toggler: null};

    checkLength(routeListObj);
    checkLength(airportListObj);
});

let checkLength = (obj) => {
    if (obj.listItems !== null && obj.list !== null && obj.listItems.length > 3)
    {
        obj.togglerFlag = true;
        renderWithToggler(obj)
    };
};

let renderWithToggler = (obj) => {

    obj.list.innerHTML = '';

    let togglerItem = document.createElement("li");
    togglerItem.classList.add("card", "p-2", "mr-3", "mb-3", "align-self-center", "_myRouteList__item");
    let togglerItemContent = document.createElement("span");
    togglerItemContent.classList.add("icon-ellipsis");
    togglerItem.appendChild(togglerItemContent);

    obj.list.appendChild(obj.listItems[0]);
    obj.list.appendChild(togglerItem);
    obj.list.appendChild(obj.listItems[obj.listItems.length - 1]);

    obj.toggler = togglerItem;
    obj.toggler.addEventListener("click", () => {handleToggler(obj)});
};

let handleToggler = (obj) => {
    obj.togglerFlag = !obj.togglerFlag;
    console.log(obj.togglerFlag);
    if (obj.togglerFlag) renderWithToggler(obj);
    else {
        obj.list.innerHTML = '';
        obj.listItems.forEach(item => obj.list.appendChild(item));

        let togglerItem = document.createElement("li");
        togglerItem.classList.add("card", "p-2", "mr-3", "mb-3", "align-self-center", "_myNewToggler");
        let togglerItemContent = document.createElement("span");
        togglerItemContent.classList.add("icon-level-up");
        togglerItem.appendChild(togglerItemContent);
        obj.list.appendChild(togglerItem);

        obj.toggler = togglerItem;
        obj.toggler.addEventListener("click", () => { handleToggler(obj) });
    }
}