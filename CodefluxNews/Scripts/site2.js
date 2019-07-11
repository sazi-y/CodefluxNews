getSimilarCategory();

function getSimilarCategory() {
    //JSON data
    var url = "Top8";
    var dataType = 'application/json; charset=utf-8';

    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'json',
        contentType: dataType,

        success: function (result) {
            for (var i = 0; i < result.length; i++) {
                console.log(result[i]);
            }
            if (result.length !== 0) {
                for (var count = 0; count < result.length; count++) {

                    if (result[count].Picture !== null) {
                        if (count < 4) {
                            if (result[count].Name === "CCN" || result[count].Name === "Neuroscience News" || result[count].Name === "Tech republic") {

                                $('#myDiv').append(
                                    '<div class="col-lg-3 col-sm-3" style="padding-top:55px">'
                                    + ' <a class="HoverTitle" style="text-decoration:none;" href = "' + result[count].Url + '" target="_blank" >'
                                    + '<img style="padding-left:30px" class="img-thumbnail border-0" src="' + result[count].Picture + '" />'
                                    + '<h6><strong>' + result[count].Title + '</strong></h6>'
                                    + '<p>' + mySubstring(result[count].Summary) + ' ...</p>'
                                    + '<div class="noContainer">'

                                    + '<div style="padding-top:30px">'
                                    + '<p>' + dd + " " + monthName(mm) + " " + yy + '</p>'
                                    + '<p style="color:#808080;font-size:70%">' + result[count].Name + ' <br/>' + result[count].CategoryName + '</p>'
                                    + '</div>'
                                    + '</a >'
                                    + '</div>'
                                    + '</div>');
                            }

                            else {
                                $('#myDiv').append(
                                    '<div class="col-lg-3 col-sm-3" style="padding-top:55px">'
                                    + ' <a class="HoverTitle" style="text-decoration:none;" href = "' + result[count].Url + '" target="_blank" >'
                                    + '<img class="img-thumbnail border-0" src="' + result[count].Picture + '" />'
                                    + '<h6><strong>' + result[count].Title + '</strong></h6>'
                                    + '<p>' + mySubstring(result[count].Summary) + ' ...</p>'
                                    + '<div class="noContainer">'

                                    + '<p>' + dd + " " + monthName(mm) + " " + yy + '</p>'
                                    + '<p  style="color:#808080;font-size:70%">' + result[count].Name + '<br/>' + result[count].CategoryName + '</p>'
                                    + '</div>'
                                    + '</a >'
                                    + '</div>');
                            }
                        }

                        else if (count < 9) {
                            if (result[count].Name === "CCN" || result[count].Name === "Neuroscience News" || result[count].Name === "Tech republic") {
                                $('#myRightDiv').append(
                                    '<p>' + '</p>'
                                    + '<p>' + '</p>'
                                    + '<div class="row border-bottom">'
                                    + '<div class="col-lg-2 col-md-2" style="padding-left:35px">'
                                    + '<img style="padding-top:20px" src="' + result[count].Picture + '" /><br/><br/>'

                                    + '</div>'

                                    + ' <div class="col-lg-10 col-sm-10" style="padding-left:60px">'
                                    + ' <a class="HoverTitle" style="text-decoration:none;" target="_blank" href = "' + result[count].Url + '<h6 style="padding-left:40px"><strong>' + result[count].Title
                                    + '</strong> </h6></a>'
                                    + '</div>'
                                );
                            }
                            else {
                                $('#myRightDiv').append(
                                    '<p>' + '</p>'
                                    + '<p>' + '</p>'
                                    + '<div class="row border-bottom">'
                                    + '<div class="col-lg-2 col-sm-2 ">'
                                    + '<img style="width:auto;height:50px"src="' + result[count].Picture + '" /><br/><br/>'
                                    + '</div>'
                                    + ' <div class="col-lg-10 col-md-10"style="padding-left:60px">'
                                    + ' <a class="HoverTitle" style="text-decoration:none;" target="_blank"  href = "' + result[count].Url + '<h6 style="padding-left:50px"><strong>' + result[count].Title
                                    + '</strong> </h6></a>'
                                    + '</div>'
                                );
                            }
                        }

                    }
                    else if (result[count].Picture === null) {
                        if (count < 4) {
                            $('#myDiv').append(

                                '<div class="col-lg-3" style="padding-top:55px">'
                                + ' <a class="HoverTitle" style="text-decoration:none;"href = "' + result[count].Url + '" target="_blank" >'
                                + '<h6><strong>' + result[count].Title + '</strong></h6>'
                                + '<p>' + mySubstring(result[count].Summary) + ' <a href = "' + result[count].Url + '" target="_blank" >...read more</a >' + '</p>'
                                + '<div class="noContainer">'
                                + '<div style="padding-top:30px">'
                                + '<p>' + dd + " " + monthName(mm) + " " + yy + '</p>'
                                + '<p style="color:#808080;font-size:70%">' + result[count].Name + '</p>'
                                + '<p style="font-weight:bold;color:#808080;font-size:10px" >' + result[count].CategoryName + '</p>'
                                + '</div>'
                                + '</div>'
                                + '</a >'
                                + '</div>');
                        }

                    }
                }

            }

        },
        complete: function () {
            $("#progress").hide();
        }, error: function (error) {
            console.log("Unable to fetch data at this moment " + error);
        }
    });
}
function mySubstring(str) {
    return str.substring(0, 100);
}

var today = new Date();
var dd = today.getDate();
var mm = today.getMonth();
var yy = today.getFullYear();

function monthName(dt) {
    mlist = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    return mlist[dt];
}