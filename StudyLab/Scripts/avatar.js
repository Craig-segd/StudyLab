    function Avatar() {
    $.ajax({
        url: "/api/upload",
        method: "GET",
        contentType: false,
        processData: false,
        success: function(data) {
            $(".avatar").css("background-image", "url(data:image/png;base64," + data._buffer);
            console.log("Success");
        },
        error: function() {
            console.log("Error");
        }
    });
}

    Avatar();