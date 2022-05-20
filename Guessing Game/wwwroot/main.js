const container = $(".toOverride");
const buttonPeople = $("#buttonPeople");
const buttonDetails = $("#buttonDetails");
const buttonDelete = $("#buttonDelete");

const IdInput = $("#personID");
const deleteInput = $("#DeletePersonID");



const URL1 = "http://localhost:25586/Ajax/People"
const URL2 = "http://localhost:25586/Ajax"
const URL3 = "http://localhost:25586/Ajax/Delete"


buttonPeople.on("click", function () {
    
    $.ajax({
        url: URL1,
        type: "GET",
        contentType: "application/json",
        success: function (data) {
            console.log(data);
            container.empty();
            container.append(data)
        },
        error: function (error) {
            console.log(error);
        },
        complete: function () {
            console.log("Complete fetching");
        },
    })

    
});

buttonDetails.on("click", function (e) {

    let inputValue = IdInput.val();
    
   
    // if value is empty set it to random 1404 number
    if (inputValue === "") {

        inputValue = 1404;
    }


    $.ajax({
        url: URL2 + "/" + inputValue,
        type: "POST",
        contentType: "application/json",
        success: function (data) {
            console.log(data);
            container.empty();
            container.append(data)
        },
        error: function (error) {
            console.log(error);
        },
        complete: function () {
            console.log("Complete fetching");
        },
    })
});



buttonDelete.on("click", function () {

    let inputValue = deleteInput.val();

    // if value is empty set it to random 1404 number
    if (inputValue === "") {

        inputValue = 1404;
    }


    $.ajax({
        url: URL3 + "/" + inputValue,
        type: "POST",
        contentType: "application/json",
        success: function (data,textStatus, xhr) {
            
            container.empty();
            container.append("<br/>");

            container.append("<p> Status code  </p> " + xhr.status + " " + xhr.statusText)
            
            container.append(data)
        },
        error: function (jqXHR, error) {
            
            container.empty();
            container.append("<br/>");
            container.append("<p> Status code </p> " + jqXHR.status + " " + jqXHR.statusText)
        },
        complete: function () {
            console.log("Complete fetching");
        },
    })
});



