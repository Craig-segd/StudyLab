// GET ALL ACCOUNT MESSAGES

$(".body-content").on("click",
    function () {
        $(".message_container").hide();

    });

setInterval(GetMessage, 3000);

$(".messageBtn").on("click",
    function () {
        $(".message_container").slideToggle(100);
        GetMessage();

    });


function GetMessage() {

    if ($(".email").attr("id") !== undefined) {

        $.ajax({
            url: ("/api/messages/" + $(".message_container").attr("id")),
            method: "GET",
            dataType: "json",
            success: function(data) {
                Render(data.length, $(".subject").length);
                $(".badge").html(data.length);
                $.each(data,
                    function(index, element) {
                        $("#subject" + index).text("Subject: "+ element.SubjectText);
                        $("#message" + index).text(element.MessageText);
                        $("#messageTime" + index).text(moment(element.DateTimeSent).format("ddd HH:mm"));
                        $("#messageSender" + index).text("From: " + element.RecieverUsername);
                        $(".delete" + index).attr("data-deletemessage-id", element.Id);
                    });
            },
            error: function() {

            }
        });
    }
}

function Render(a, b) {

    if (parseInt(a) !== parseInt(b)) {
        for (var i = b; i < a; i++) {

            $(".message_container").append("<div class='panel panel-default messageCon'>" +
                "<button id ='" +
                i +
                "' type='button' class='close delete" +
                i +
                " delete-message' aria-label='Close' data-deletemessage-id =''>" +
                "<span aria-hidden='true'>&times;</span></button>" +
                "<div id='subject" +
                i +
                "' class='panel-heading subject'></div>" +
                "<div class='mc' id='messageContainer'><div class='ms' id='messageSender" + i + "'></div><div class='mt' id='messageTime" + i + "'></div></div><div id='message" +
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
            $(this).next().css("display", "none");
            $(this).next().css("overflow", "initial");
            $(this).next().css("max-height", "initial");
            $(this).next().css("margin-bottom", "0px");
            
        } else {
            $(this).next().css("display", "flex");
            $(this).next().css("overflow", "hidden");
            $(this).next().css("max-height", "50px");
            $(this).next().css("margin-bottom", "5px");
            
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
    function () {
        $(".sendMessage_container").slideToggle(100);
        $(".message_container").css("overflow-y", "auto");

    });

$("#submit_messageform").on("click",
    function () {
        $.ajax({
            async: true,
            url: ("/api/messages"),
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(
                {
                    "SubjectText": $("#subjectText_input").val(),
                    "MessageText": $("#messageText_input").val(),
                    "SenderId": $(".message_container").attr("id"),
                    "RecieverUsername": $("#senderText_input").val() /*"b60fcf10-e082-4fe2-9a89-6d5b52820857"*/
                }
            ),
            success: function () {
                $(".successSent").fadeIn(600).delay(1000).fadeOut(600);
            },
            error: function () {
                console.log("ISSUE");
            }
        });
    });

//************** DELETE A MESSAGE **************//


$("body").on("click",
    ".delete-message",
    function () {

        var button = $(this);

        bootbox.confirm("Are you sure you want to delete the message?",
            function (result) {
                if (result) {
                    $.ajax({
                        url: "/api/messages/" + button.attr("data-deletemessage-id"),
                        method: "DELETE",
                        success: function () {
                            toastr.success("Message deleted.");
                            button.parent().remove();
                            GetMessage();
                        },
                        error: function () {
                            toastr.error("Unable to delete message.");
                        }
                    });
                }
            });

    });
