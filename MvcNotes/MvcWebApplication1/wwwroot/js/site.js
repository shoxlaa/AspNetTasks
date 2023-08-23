﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    let $adding = $("#add-button").unbind();
    let $refresh = $("#ref").unbind();
    let $listofNotes = $("#list");


    $.get(`/Notes/GetResult`, data => {
        //console.log(data);
        //console.log(object);
        $listofNotes.empty();

        for (const element in data) {
            let objElement = data[element];
            console.log(objElement);
            $listofNotes.append(`
                <li class="list-item" >
                    <div>${objElement.title}</div>
                    <div>${objElement.description}</div>
                    <div>${objElement.dateTime}</div>
                    <div>${objElement.tags}</div>
                    <input  class="edit" type="button" class="edit"  value="edit"/> 
                 </li>`)
        }
    });

    

    $adding.on("click", (e) => {
        let $title = $("#title").val().toString();
        let $description = $("#description").val().toString();
        let $tags = $("#tag").val().toString();

        $.post(`/Notes/Add?title=${$title}&description=${$description}&tags=${$tags}`,
            { title: $title, description: $description, tags: $tags }, data => {
                console.log($title);
                console.log($description);
                //alert(data);
            });
    });

    $refresh.on("click", (e) => {

        $.get(`/Notes/GetResult`, data => {
            //console.log(data);
            //console.log(object);
            $listofNotes.empty();

            for (const element in data)
            {
                let objElement = data[element];
                console.log(objElement);
                $listofNotes.append(`
                <li class="list-item" >
                    <div>${objElement.title}</div>
                    <div>${objElement.description}</div>
                    <div>${objElement.dateTime}</div>
                    <div>${objElement.tags}</div>
                    <input  class="edit" type="button" class="edit"  value="edit"/> 
                 </li>`)
            }
        });

    })
    $listofNotes.on("click", (e) => {
        let $target = $(e.target);
        let buttonDetails = $target.attr("edit");

        let $title = $target.prev().prev().prev().prev();
        let $description = $target.prev().prev().prev();
        let $time = $target.prev().prev();
        let $tags = $target.prev();
        // let $edit = $target.prev();
        console.log($target)



    })

});