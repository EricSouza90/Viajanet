window.onload = function () {
    let data = CollectData();
    SendDataTracking(data);
};


function CollectData() {
    debugger;
    let ip = userip;
    let pageName = location.pathname;
    let browser = navigator.vendor;
    let pageParameters = window.location.search;

    return new DataTracking(ip, pageName, browser, pageParameters);

};