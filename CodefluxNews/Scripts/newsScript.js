var urlToRedirect = '';
var newsArticleId = '';

function Redirect() {
    window.location.href = urlToRedirect;
}

function assignValue() {
    return urlToRedirect = $('#myIdentifier').val();
}

function assignValue2() {
    return newsArticleId = $('#myIdentifier2').val();
}

$(document).ready(function () {
    assignValue2();
    assignValue();
    if (window.location.pathname === '/technology/redirect/' + assignValue2() ) {
        setTimeout('Redirect()', 100);
    }
    else {
        var myDate = $("#myNewTime").text();
        $('.timeHandler').empty();
        $('.timeHandler').append('<h5 id="myNewTime" class="text-muted">' + moment(myDate).fromNow() + '</h5>');
    }
});