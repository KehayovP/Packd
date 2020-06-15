window.onload = function () {

    $('input.item-packed').change(function (event) {
        event.stopPropagation();
        let IsItemPacked = $(event.currentTarget).prop("checked") == true ? 1 : 0;
        let ListContentId = event.currentTarget.parentElement.children[1].getAttribute('value');

        $.ajax({
            type: "POST",
            url: "/List/SetPacked",
            content: "application/json; charset=utf-8",
            dataType: "text",
            data: {
                IsPacked: IsItemPacked,
                ListContentId: ListContentId
            },
            success: function () {
                console.log("Item successfully updated.");
            },
            error: function () {
                alert("There has been an error processing the data.");
            }
        });
    });
}