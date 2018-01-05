$(document).ready(function () {

    // GET ALL TYPES

    $.ajax({
        url: "/api/types",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $.each(data,
                function (index, element) {
                    $(".type").append("<option value=" + element.Id + ">" + element.Name + "</option>");
                });
        }
    });

    // RE-POPULATE QUESTION DATA

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
            error: function () {
                console.log("Server error: Could not retrieve data");
            }
        });
    }

    function render(a, b) {
        if (parseInt(a) !== parseInt(b)) {

            for (var i = 0; i < a; i++) {

                if ($(".parent").attr("id") === "True") {

                    $(".parent").append("<div class='panel panel-default'>" +
                        "<button id ='" +
                        i +
                        "' type='button' class='close delete" +
                        i +
                        " delete-me' aria-label='Close' data-delete-id =''>" +
                        "<span aria-hidden='true'>&times;</span></button>" +
                        "<div id='question" +
                        i +
                        "' class='panel-heading question'></div>" +
                        "<div id='answer" +
                        i +
                        "' class='panel-body answer'></div></div>");
                } else {
                    $(".parent").append("<div class='panel panel-default'>" +
                        "<div id='question" +
                        i +
                        "' class='panel-heading question'></div>" +
                        "<div id='answer" +
                        i +
                        "' class='panel-body answer'></div></div>");
                }


            }
        }
    }

    reload();
    setInterval(reload, 8000);

    // ADD QUESTION (POST)

    $("#submit_form").on("click",
        function (data) {
            $("form[name='AddaQuestion']").
                validate({
                    rules: {
                        questionText: "required",
                        answerText: "required"
                    },
                    messages: {
                        questionText: "Question field cannot be left blank",
                        answerText: "Answer field cannot be left blank"

                    }
                });
            if ($("form[name='AddaQuestion']").valid())
            {
                $.ajax({
                url: "/api/questions",
                method: "POST",
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify([
                    {
                        "QuestionText": $("#questionText_input").val(),
                        "AnswerText": $("#answerText_input").val(),
                        "TypeId": $(".type").val()
                    }]),
                success: function () {
                    $(".light_box").fadeToggle();
                },
                error: function () {
                    data.preventDefault();
                    console.log("Error");
                }
            });
            }
            
        });


    // DELETE

    $("body").on("click",
        ".delete-me",
        function () {

            var button = $(this);

            bootbox.confirm("Are you sure you want to delete the question?",
                function (result) {
                    if (result) {
                        $.ajax({
                            url: "/api/questions/" + $("#page_name").text() + "/" + button.attr("data-delete-id"),
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

    // ADD QUESTION LIGHTBOX

    $(".addQuestion").on("click",
        function (e) {
            e.preventDefault();
            $(".light_box").fadeToggle();
        });
    $(".close_button").on("click",
        function () {
            $(".light_box").fadeToggle();

        });



    // HIDE/SHOW ANSWERS

    $("body").on("click",
        ".question",
        function () {
            $(this).next().toggle(100);
        });

    


});