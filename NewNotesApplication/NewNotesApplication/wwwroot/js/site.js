// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    //variables 
    let $list = $(".my-list");
    let $title = $(".title-input");
    let $description = $(".description-input");
    let $tags = $(".tags-input");
    let $addButton = $(".add-button");
    let $refButtom = $(".ref-button");

    let $data = [];

    window.onload = () => {
        $.get(`/Notes/GetResult`, data => {
            //console.log(data);
            //console.log(object);
            $list.empty();
            showItems(data);

            for (const element in data) {
                let objElement = data[element];
                $data.push(objElement);
            }
        });

    }


    function showItems(data) {
        for (const element in data) {
            let objElement = data[element];

            console.log(objElement);
            $list.append(`
                    <div  class="list-group-item list-group-item-action  list-item-cont" aria-current="true">
                        <div class="d-flex w-100 justify-content-between">
                        <h5 class="mb-1 list-item-title">${objElement.title}</h5>
                        <small class="list-item-date">${objElement.dateTime}</small> 

                        </div>  

                        
                     <div class="d-flex w-100 justify-content-between">
                     <p class="mb-1 list-item-description">${objElement.description} .</p>
                     <div> 
                     <button class="edit btn btn-warning w-100 mb-1" > 
                            <i class="bi bi-pen "> </i>
                     </button>
                     <button class="delete btn btn-danger w-100 "  > 
                                <i class="bi bi-trash3-fill"></i>
                     </button>
                      </div>
                     </div>

                     <small class="list-title-tags">${objElement.tags}.</small>
                    </div>
                
                `)

            /*  $data.push(objElement);*/
        }

    }
    //events 
    $list.on("click", (e) => {


        let target = $(e.target);

        //add event to buttons 
        if (target.hasClass("edit")) {

            $description = target.parent().prev();
            $title = $description.parent().prev().children()[0];
            $tags = target.parent().parent().next();
            console.log($description.text());
            console.log($title.innerText);
            console.log($tags.text());


            alert("enter new description ");
            let newDes = prompt("description:", $description.text());

            //alert("enter new title");
            //let newTitle = prompt(" title:", $title.innerText);

            //prompt("enter new tags", $tags.text());
            //let newTags = prompt("tags:", $tags.text());

            $description.text(newDes); 
            
            
        }


    })

    // $title.on("click", ()=> {


    // })
    // $description.on("click", ()=> {


    // })

    // $tags.on("click", ()=> {


    // })
    $addButton.on("click", () => {

        let titleString = $title.val().toString();
        let descriptionString = $description.val().toString();
        let tagsString = $tags.val().toString();
        let date = new Date();

        let dateString = `${date.toLocaleDateString()} ${date.toLocaleTimeString()}`;


        $.post(`/Notes/Add?title=${titleString}&description=${descriptionString}&dateTime=${dateString}&tags=${tagsString}`,
            { title: titleString, description: descriptionString, dateTime: dateString, tags: tagsString }, data => {

                //alert(data);
            });


        $data.push({ title: titleString, dateTime: dateString, description: descriptionString, tags: tagsString })
        console.log($data);
        $list.empty();
        showItems($data);

        //for (const element in $data) {
        //    let objElement = $data[element];
        //    console.log(objElement);
        //    $list.append(`
        //            <div  class="list-group-item list-group-item-action  list-item-cont" aria-current="true">
        //                <div class="d-flex w-100 justify-content-between">
        //                <h5 class="mb-1 list-item-title">${objElement.title}</h5>
        //                <small class="list-item-date">${objElement.dateTime}</small>
        //                </div>
        //             <p class="mb-1 list-item-description">${objElement.description} .</p>
        //             <small class="list-title-tags">${objElement.tags}.</small>
        //            </div>

        //        `)
        //}        
    })

    //$refButtom.on("click", ()=>{
    //    $.get(`/Notes/GetResult`, data => {
    //        //console.log(data);
    //        //console.log(object);
    //        $list.empty();
    //        for (const element in data)
    //        {
    //            let objElement = data[element];
    //            console.log(objElement);
    //            $list.append(`
    //                <div  class="list-group-item list-group-item-action  list-item-cont" aria-current="true">
    //                    <div class="d-flex w-100 justify-content-between">
    //                    <h5 class="mb-1 list-item-title">${objElement.title}</h5>
    //                    <small class="list-item-date">${objElement.dateTime}</small>
    //                    </div>
    //                 <p class="mb-1 list-item-description">${objElement.description} .</p>
    //                 <small class="list-title-tags">${objElement.tags}.</small>
    //                </div>

    //            `)
    //        }
    //    });
    //})



    $lilContainer = $(".container1-1-1-1");

    $lilContainer.on("click", (e) => {

        console.log()
        $target = $(e.target);
       

        $l3 = $(e.target).parent();

        $ll2 = $l3.parent();
        $lll1 = $ll2.parent();
        



        /*let buttonDetails = $target.attr("container1-1");*/
        let v = $target;
        /* console.log($lll1);*/
        /* console.log($ll2); */
        /*console.log($l3);*/

        /* console.log(buttonDetails.text());*/



    })

})