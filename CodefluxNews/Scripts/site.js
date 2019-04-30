var pageSize = 10;
var pageIndex = 0;

var canISendRequest = true;

//$(window).scroll(function () {
//    if ($(window).scrollTop() ===
//        $(document).height() - $(window).height()) {
//        if (canISendRequest) {
//            getSimilarCategory();
//            resizeAllGridItems();
//            imagesHaveLoaded();
//        }
//        else {
//            $(".noContent").show();
//            cannotSendRequest();
//        }
//    }
//});

$(window).scroll(function () {
    scrollFunction();
    if (canISendRequest) {
        if ($(window).scrollTop() ===
            $(document).height() - $(window).height()) {
            getSimilarCategory();
            resizeAllGridItems();
            imagesHaveLoaded();
        }
    }
    else {
        $(".noContent").show();
        cannotSendRequest();
    }
});

$(window).on('load', function () {
    $('#myTime').append('<p>' + dd + " " + monthName(mm) + " " + yy + '</p>');
    getSimilarCategory();
    resizeAllGridItems();
    imagesHaveLoaded();
});

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}

//check the condition of the page
function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("myBtn").style.display = "block";
    } else {
        document.getElementById("myBtn").style.display = "none";
    }
}

function getChangedCategory(catDropped) {
    return categoryDrop.options[categoryDrop.selectedIndex].innerHTML;
}

function resetIndex() {
    return pageIndex = 0;
}

function resetIndex2() {
    return pageIndex2 = 0;
}

var today = new Date();
var dd = today.getDate();
var mm = today.getMonth();
var yy = today.getFullYear();

function monthName (dt) {
    mlist = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    return mlist[dt];
}

function getSimilarCategory() {

    //JSON data
    var url = "Home/GetCategory";
    var dataType = 'application/json; charset=utf-8';
    var data = { 'Category': getChangedCategory($('#catDropped')), "pageindex": pageIndex, "pagesize": pageSize };
    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'json',
        contentType: dataType,
        data: data,
        success: function (result) {

            if (result.length !== 0) {
                $(".noContent").hide();
                canSendRequest();
                for (var count = 0; count < result.length; count++) {
                    //getInfinite();
                    resizeAllGridItems();
                    imagesHaveLoaded();
                    if (result[count].Picture !== null) {
                        $('#myDiv').append('<div class="item karya" id="ItemsId">'
                            + '<div class="content">'

                            + '<img src="' + result[count].Picture + '" width="100%" />'
                            + '<p style="font-weight:bold;color:#02D21C;font-size:10px">' + result[count].CategoryName + '</p>'
                            + '<h4>' + result[count].Title + '</h4>'

                            + '<p>' + mySubstring(result[count].Summary) + '<a href="' + result[count].Url + '">...More</a>' + '</p>'
                            + '<p>' + 'Source:' + '</p>' + '<p style="font-weight:bold;color:#add8e6;">' + result[count].Name + '</p>'

                            + '</div>'
                            + '</div>');
                    }
                    else {
                        $('#myDiv').append('<div class="item karya" id="ItemsId">'
                            + '<div class="content">'
                            + '<p style="font-weight:bold;color:#02D21C;font-size:10px">' + result[count].CategoryName + '</p>'
                            + '<h4>' + result[count].Title + '</h4>'
                            + '<p>' + mySubstring(result[count].Summary) + '<a href="' + result[count].Url + '">...More</a>' + '</p>'
                            + '<p>' + 'Source:' + '</p>' + '<p style="font-weight:bold;color:#add8e6;">' + result[count].Name + '</p>'
                            + '</div>'
                            + '</div>');
                    }
                }
                pageIndex += 1;

                console.log('Data received: ');
                console.log(result);
            }
            else {
                $(".noContent").show();
                cannotSendRequest();

            }
        },
        beforeSend: function () {
            $("#progress").show();
        },
        complete: function () {
            $("#progress").hide();
        }, error: function (error) {
            console.log("Unable to fetch data at this moment " + error);
        }
    });
}

function getCategoryList() {
    resetIndex();
    $('#myDiv').empty();
    //JSON data
    var url = "Home/GetCategory";
    var dataType = 'application/json; charset=utf-8';
    var data = { 'Category': getChangedCategory($('#catDropped')), "pageindex": pageIndex, "pagesize": pageSize };
    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'json',
        contentType: dataType,
        data: data,
        success: function (result) {

            if (result.length !== 0) {
                $(".noContent").hide();
                canSendRequest();
                for (var count = 0; count < result.length; count++) {
                    //getInfinite();
                    resizeAllGridItems();
                    imagesHaveLoaded();
                    if (result[count].Picture !== null) {
                        $('#myDiv').append('<div class="item karya" id="ItemsId">'
                            + '<div class="content">'

                            + '<img src="' + result[count].Picture + '" width="100%" />'
                            + '<p style="font-weight:bold;color:#02D21C;font-size:10px">' + result[count].CategoryName + '</p>'
                            + '<h4>' + result[count].Title + '</h4>'

                            + '<p>' + mySubstring(result[count].Summary) + '<a href="' + result[count].Url + '">...More</a>' + '</p>'
                            + '<p>' + 'Source:' + '</p>' + '<p style="font-weight:bold;color:#add8e6;">' + result[count].Name + '</p>'

                            + '</div>'
                            + '</div>');
                    }
                    else {
                        $('#myDiv').append('<div class="item karya" id="ItemsId">'
                            + '<div class="content">'
                            + '<p style="font-weight:bold;color:#02D21C;font-size:10px">' + result[count].CategoryName + '</p>'
                            + '<h4>' + result[count].Title + '</h4>'
                            + '<p>' + mySubstring(result[count].Summary) + '<a href="' + result[count].Url + '">...More</a>' + '</p>'
                            + '<p>' + 'Source:' + '</p>' + '<p style="font-weight:bold;color:#add8e6;">' + result[count].Name + '</p>'
                            + '</div>'
                            + '</div>');
                    }
                }
                pageIndex += 1;

                console.log('Data received: ');
                console.log(result);
            }
            else {
                $(".noContent").show();
                cannotSendRequest();
            }
        },
        beforeSend: function () {
            $("#progress").show();
        },
        complete: function () {
            $("#progress").hide();
        }, error: function (error) {
            console.log("Unable to fetch data at this moment " + error);
        }
    });
}

function cannotSendRequest() {
    return canISendRequest = false;
}

function canSendRequest() {
    return canISendRequest = true;
}

function mySubstring(str) {
    return str.substring(0, 100);
}

function getInfinite() {

    $(".karya").slice(16).hide();
    //var mincount = 2;
    var maxcount = 4;

    $(window).scroll(function () {
        if ($(window).scrollTop() + $(window).height() >= $(document).height() - 50) {
            $(".karya").slice(maxcount).slideDown(200);
            // mincount = mincount + 2;
            maxcount = maxcount + 4;
            resizeAllGridItems();
        }
    });
}


//================================================================================================================================
//resizeAllGridItems();
imagesHaveLoaded();

//window.addEventListener("load", resizeAllGridItems);
window.addEventListener("resize", resizeAllGridItems);

function resizeGridItem(item) {
    grid = document.getElementsByClassName("masonry")[0];
    rowHeight = parseInt(window.getComputedStyle(grid).getPropertyValue('grid-auto-rows'));
    rowGap = parseInt(window.getComputedStyle(grid).getPropertyValue('grid-row-gap'));
    rowSpan = Math.ceil((item.querySelector('.content').getBoundingClientRect().height + rowGap) / (rowHeight + rowGap));
    item.style.gridRowEnd = "span " + rowSpan;
}

function resizeAllGridItems() {
    allItems = document.getElementsByClassName("item");
    for (x = 0; x < allItems.length; x++) {
        resizeGridItem(allItems[x]);
    }
}

function imagesHaveLoaded() {
    allItems = document.getElementsByClassName("item");
    for (x = 0; x < allItems.length; x++) {
        imagesLoaded(allItems[x], resizeInstance);
    }
}

function resizeInstance(instance) {
    item = instance.elements[0];
    resizeGridItem(item);
}