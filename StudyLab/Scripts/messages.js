// GET ALL ACCOUNT MESSAGES

$(".body-content").on("click",
    function () {
        $(".message_container").hide();

    });

GetMessage();

$(".messageBtn").on("click",
    function () {
        $(".message_container").toggle(100);
        GetMessage();

    });


function GetMessage() {
    $.ajax({
        url: ("/api/messages/" + $(".message_container").attr("id")),
        method: "GET",
        dataType: "json",
        success: function (data) {
            Render(data.length, $(".subject").length);
            $(".badge").html(data.length);
            $.each(data,
                function (index, element) {
                    $("#subject" + index).text(element.SubjectText);
                    $("#message" + index).text(element.MessageText);
                });
        },
        error: function () {

        }
    });
}

function Render(a, b) {

    if (parseInt(a) !== parseInt(b)) {
        for (var i = b; i < a; i++) {

            $(".message_container").append("<div class='panel panel-default messageCon'>" +
                "<div id='subject" +
                i +
                "' class='panel-heading subject'></div>" +
                "<div id='message" +
                i +
                "' class='panel-body message'></div></div>");
        }

    }
}


$("body").on("click",
    ".subject",
    function (data) {
        var check = $(this).next().css("overflow");
        if (check === "hidden") {
            $(this).next().css("overflow", "initial");
            $(this).next().css("max-height", "initial");
            $(this).next().css("margin-bottom", "0px");
        } else {
            $(this).next().css("overflow", "hidden");
            $(this).next().css("max-height", "50px");
            $(this).next().css("margin-bottom", "10px");
        }
    });


$("body").on("mouseover",
    ".subject",
    function () {
        $(this).css("background-color", "#eeeeee");
        $(this).css("cursor", "pointer");
    });

$("body").on("mouseleave",
    ".subject",
    function () {
        $(this).css("background-color", "#f5f5f5");

    });

//************** SEND A MESSAGE **************//

$(".send").on("click",
    function() {
        $(".sendMessage_container").slideToggle(100);
    });
