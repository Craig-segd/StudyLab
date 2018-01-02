    function Avatar() {
    $.ajax({
        url: "/api/upload/" + $(".email").attr("id"),
        method: "GET",
        contentType: false,
        processData: false,
        success: function(data) {
            $(".avatar").css("background-image", "url(data:image/png;base64," + data._buffer);
            $("#bigImage").css("background-image", "url(data:image/png;base64," + data._buffer);
        },
        error: function() {
        }
    });
}

    Avatar();

    $(".uploadbtn").on("click",
        function () {

            var data = new FormData();
            var files = $(".upload").get(0).files;

            if (files.length > 0) {
                data.append("UploadedImage", files[0]);
            }

            $.ajax({
                url: "/api/upload/" + $(".email").attr("id"),
                method: "POST",
                data: data,
                contentType: false,
                processData: false,
                cache: false,
                success: function () {
                    toastr.success("Image uploaded successfully.");
                    Avatar();
                },
                error: function () {
                    toastr.error("Error uploading image");
                }
            });
        });