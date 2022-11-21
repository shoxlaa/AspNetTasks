// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    let $adding = $("#add-button").unbind();
    let $refresh = $("#ref").unbind();
    let $listofNotes = $("#list");
    

    $adding.on("click", (e) => {
        let $title = $("#title").val().toString();
        let $description = $("#description").val().toString();

        $.post(`/Notes/Add?title=${$title}&description=${$description}`, { title: $title, description: $description },
            data => {
                console.log($title);
                console.log($description);
                //alert(data);
            });
    });

    $refresh.on("click", (e) => {

        $.get(`/Notes/GetResult`, data => {
            //console.log(data);

            //console.log(object);
            for (const element in data) {
                let objElement = data[element];
                console.log(objElement);
                $listofNotes.append(`<li>
            <div>${objElement.title}</div>
<div>${objElement.description}</div>
<div>${objElement.dateTime}</div>
<div>${objElement.tags}</div>
                        </li>`)
            }


        });

    })
 

});