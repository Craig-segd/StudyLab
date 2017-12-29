$(document).ready(function () {

    function reload() {
        $.ajax({
            url: "/api/questions/" + $("#page_name").text(),
            method: "GET",
            dataType: "json",
            success: function (data) {
                render(data.length, $(".question").length);
                $.each(data,
                    function (index, element) {
                        $(".jumbotron-questions").show();
                        $("#question" + index).text(element.QuestionText);
                        $("#answer" + index).text(element.AnswerText);
                        $(".delete" + index).attr("data-delete-id", element.Id);
                    });
            },
            error: function (request, error) {
                alert("Request: " + JSON.stringify(request));
            }
        });
    }

    // UPDATE

    reload();
    setInterval(reload, 10000);

    // DELETE

    $("body").on("click",
        ".delete-me",
        function () {

            var button = $(this);

            bootbox.confirm("Are you sure you want to delete the question?",
                function (result) {
                    if (result) {
                        $.ajax({
                            url: "/api/questions/javascript/" + button.attr("data-delete-id"),
                            method: "DELETE",
                            success: function () {
                                toastr.success("Question deleted.");
                                button.parent().remove();
                            },
                            error: function () {
                                toastr.error("Unable to delete question.");
                            }
                        });
                    }
                });

        });

    // HIDE/SHOW ANSWERS

    $("body").on("click",
        ".question",
        function () {
            $(this).next().toggle(500);
        });

    function render(a, b) {
        if (parseInt(a) !== parseInt(b)) {
            for (var i = b; i < a; i++) {
                $(".parent").append("<div class='panel panel-default'>" +
                    "<button id ='" +
                    i +
                    "' type='button' class='close delete" + i + " delete-me' aria-label='Close' data-delete-id =''>" +
                    "<span aria-hidden='true'>&times;</span></button><div id='question" +
                    i +
                    "' class='panel-heading question'></div>" +
                    "<div id='answer" +
                    i +
                    "' class='panel-body answer'></div></div>");
            }
        }
    }


});