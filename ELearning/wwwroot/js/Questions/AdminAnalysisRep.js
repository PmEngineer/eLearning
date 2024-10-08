$(function () {
    var $elem = $('body');
    $('#nav_up').fadeIn('slow');
    $('#nav_down').fadeIn('slow');
    $(window).bind('scrollstart', function () {
        $('#nav_up,#nav_down').stop().animate({ 'opacity': '0.2' });
    });
    $(window).bind('scrollstop', function () {
        $('#nav_up,#nav_down').stop().animate({ 'opacity': '1' });
    });
    $('#nav_down').click(
        function (e) {
            $('html, body').animate({ scrollTop: $elem.height() }, 800);
        }
    );
    $('#nav_up').click(
        function (e) {
            $('html, body').animate({ scrollTop: '0px' }, 800);
        }
    );
});

$(window).scroll(function () {
    var height = $(window).scrollTop();
    $("#back2Top").css("display", "block")
    if (height > 70) {
        $('#back2Top').fadeIn();
    } else {
        $('#back2Top').fadeOut();
    }

});
$(document).ready(function () {
    $("#back2Top").click(function (event) {
        event.preventDefault();
        $("html, body").animate({ scrollTop: 0 }, "slow");
        return false;
    });
    $("#nav_down").click(function (event) {
        event.preventDefault();
        $("html, body").animate({ scrollDown: 0 }, "slow");
        return false;
    });

});

$(document).ready(function () {
    SubjectList();


});
function Print() {
    location.href("/")
    libBtnWrapEl.style.display = "none";
}
function SubjectList() {

    $('#questionSearch_LessonId').empty();
    var Lession = "";
    var SubjectID = $('#questionSearch_SubjectId').val();

    $.ajax({
        type: "GET",
        url: "/Master/GetLessonList?Id=" + SubjectID,
        dataType: "json",
        success: function (result) {
            console.log(result);
            Lession = Lession + '<option value="0">Select Lesson</option>';
            for (i = 0; i < result.length; i++) {
                if (@Model.questionSearch.LessonId == result[i].id) {
                    Lession = Lession + '<option value="' + result[i].id + '" selected>' + result[i].name + '</option>';
                }
                else if (SubjectID == 11) {
                    Lession = Lession + '<option value="' + result[i].id + '">' + result[i].hindiName + '</option>';
                }
                else {
                    Lession = Lession + '<option value="' + result[i].id + '">' + result[i].name + '</option>';
                }

            }
            $('#questionSearch_LessonId').append(Lession);

        }
    });
    //$('#questionSearch_LessonId').val(@Model.questionSearch.LessonId);
    //console.log(@Model.questionSearch.LessonId);
}
function OpenEdit(e) {
    let height = screen.height;
    let width = screen.width;
    window.open(e, "", "width=" + width + ",height=" + height);

}

function display_c() {
    var refresh = 1000;
    mytime = setTimeout('display_ct()', refresh)
}
function display_ct() {
    if (localStorage.getItem("LocateKey") == "1") {
        localStorage.setItem("LocateKey", "0");
        location.reload(true);

    }
    var refresh = 1000;
    mytime = setTimeout('display_ct()', refresh)
}

$(document).ready(function () {
    display_c();
    Userprivillage('@Model.userId', @Model.submenuId);
});
function Reset() {
    window.location.replace("/AdminAnalysisRep");
}

function show(i) {
    $("#solution" + i).toggle();
}