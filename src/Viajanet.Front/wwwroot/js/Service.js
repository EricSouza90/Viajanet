function SendDataTracking(dataTracking) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:30321/api/DataTracking',
        data: JSON.stringify({
            IP: dataTracking.IP,
            PageName: dataTracking.PageName,
            Browser: dataTracking.Browser,
            PageParameters: dataTracking.PageParameters
        }),
        success: function (data) { },
        contentType: "application/json",
        dataType: 'json'
    });
}