window.onload = function () {

    $('input.item-packed').change(function (event) {
        event.stopPropagation();
        let ListId = $('.ListId').val();
        let CategoryId = event.currentTarget.parentElement.parentElement.children[0].getAttribute('id').split("-")[1];
        let ItemId = event.currentTarget.parentElement.getAttribute('id').split("-")[1];
        let IsItemPacked = $(event.currentTarget).prop("checked") == true ? 1 : 0;

        $.ajax({
            type: "POST",
            url: "/List/SetPacked",
            content: "application/json; charset=utf-8",
            dataType: "text",
            data: {
                ListId: ListId,
                CategoryId: CategoryId,
                ItemId: ItemId,
                IsPacked: IsItemPacked               
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