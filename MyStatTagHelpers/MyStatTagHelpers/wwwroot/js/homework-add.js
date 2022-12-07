$(function () {
    let $title = $("#model-title");
    let $description = $("#model-description");
    let $button = $("#button-add");

    $button.on("click", () => {
        let title = $title.val();
        let description = $description.val();
        $.ajax({
            url: "/HomeWork/Add",
            contentType: "application/json",
            type: "POST",
            data: JSON.stringify(
                {
                    Title: title,
                    File: description
                }),
            success: function () {
                alert("Done");
            }
        })
    })
})
