// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#personDetails").delegate("div", "click", function (e) {
    $("#personDetails .hover").removeClass("hover");
    $(this).addClass("hover");
    func();
});

let name = "", emailAddress = "", phoneNumber = "";

let func = () => {
    var selectedTxt = $("#personDetails .hover").text().split(" ");
    var index = 1;
    for (var i of selectedTxt) {
        if (i != "" && i.length > 2) {
            switch (index) {
                case 1:
                    name = i;
                    break;
                case 2:
                    emailAddress = i;
                    break;
                case 3:
                    phoneNumber = i;
            }
            index++;
        }
    }
    $("#personName").html(name);
    $("#personEmailAddress").html(emailAddress);
    $("#mobileNumber").html(phoneNumber);
    let editLink = `/PersonDetails/Edit/${name}`, deleteLink = `/PersonDetails/Delete/${name}`;
    $("#editButton").attr('href', editLink);
    $("deleteButton").attr('href', deleteLink);
};