function submitform() {
    var i = document.getElementById("myform");
    $("#myform").submit();
    console.log("Submitted");
}

function Append(i, type, img, onlyImg) {

    var table = $(".tabl");
    var row = $("<tr></tr>");
    if (type == 1 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn" ><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td class="QuesHi"><textarea  id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" name="selectedRow" value="' + i + '"  type="radio"/></td><td style="display:none;"><button  class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" type="checkbox" value="' + i + '" id="checkbox' + i + '"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 1 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><textarea  class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" name="selectedRow" value="' + i + '" type="radio"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" type="checkbox"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);

    }
    else if (type == 1 && img == 'noimg' && onlyImg == "onlyImg") {
        row.append('<td><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td><input class="w-50 rc" name="selectedRow" value="' + i + '" type="radio"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger"></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == 'noimg' && onlyImg == "onlyImg") {
        row.append('<td><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td><input class="w-50 rc"  type="checkbox"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger"></button></td>');
        table.append(row);
    }

    CKEDITOR.replace('txtInstructions' + i, { language: 'en' });
    CKEDITOR.replace('hitxtInstructions' + (i), { language: 'hi' });
}
$(document).ready(function () {
    $("#save-btn").click(function () {
        var SubjectId = $("#subjects").val();
        var LessonId = $("#lessons").val();
        var QuestionType = $("#select-question-type").val();
        var Language = $("#select-lang").val();
        var AnswerType = $("#select-option").val();
        var NoOfOption = $("#select-nooptions").val();
        //var EQuestion = $("#EnglishQ").text();
        //var HQuestion = $("#HindiQ").text();


        var item = [];
        var IsCorrect = false;
        var RESULT = true;
        if (Language == "1") {
            var HQuestion = CKEDITOR.instances['HindiQ'].getData();
            var EQuestion = CKEDITOR.instances['EnglishQ'].getData();
            if (AnswerType == 1) {
                var rval1 = $("input[name='selectedRow']:checked").val();
                if (rval1 == null || rval1 == "undefined") {
                    RESULT = false;
                    $(".toast-header").text("Error");
                    $(".toast-body").text("Please Choose Any one Option");

                    $('.toast').toast('show');
                    $('.toast-container').toast('show');
                    return;
                }
                else {
                    for (var i = 1; i <= NoOfOption; i++) {
                        var rval = $("input[name='selectedRow']:checked").val();

                        if (i == rval) {
                            IsCorrect = true;
                        }
                        else {
                            IsCorrect = false;
                        }
                        var obj = {
                            Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + i].getData(),
                            Option_Text_Eng: CKEDITOR.instances['txtInstructions' + i].getData(),
                            IsCorrect: IsCorrect
                        }
                        item.push(obj);
                    }
                }
            }
            else if (AnswerType == 2) {
                for (var i = 1; i <= NoOfOption; i++) {
                    if ($('#checkbox' + i).is(":checked")) {
                        IsCorrect = true;
                    }
                    else {
                        IsCorrect = false;
                    }
                    var obj = {
                        Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + i].getData(),
                        Option_Text_Eng: CKEDITOR.instances['txtInstructions' + i].getData(),
                        IsCorrect: IsCorrect
                    }
                    item.push(obj);
                }
            }
            var r = 0;
            item.forEach(x => {
                if (x.Option_Text_Eng == null || x.Option_Text_Eng == '' || x.Option_Text_Hindi == null || x.Option_Text_Hindi == '') {
                    RESULT = false;
                }


            });


            if (RESULT) {
                var questions
                    = {
                    SubjectId: SubjectId,
                    LessonId: LessonId,
                    QuestionType: QuestionType,
                    Language: Language,
                    AnswerType: AnswerType,
                    NoOfOption: NoOfOption,
                    EQuestion: EQuestion,
                    HQuestion: HQuestion,
                    options: item
                }
                $.ajax({
                    type: "POST",
                    url: "/Master/SaveQuestion",
                    data: questions,
                    dataType: "json",
                    /* contentType: 'application/json; charset=utf-8',*/
                    success: function (data) {

                        window.location.replace("/Question");


                    },
                    error: function () {
                        alert("Error occured!!")
                    }
                });

            }
            else {
                $(".toast-header").text("Error");
                $(".toast-body").text("Please Fill Option");

                $('.toast').toast('show');
                $('.toast-container').toast('show');
            }
        }


        else if (Language == "2") {
            var EQuestion = CKEDITOR.instances['EnglishQ'].getData();
            if (AnswerType == 1) {
                var rval1 = $("input[name='selectedRow']:checked").val();
                if (rval1 == null || rval1 == "undefined") {
                    RESULT = false;
                    $(".toast-header").text("Error");
                    $(".toast-body").text("Please Choose Any one Option");

                    $('.toast').toast('show');
                    $('.toast-container').toast('show');
                    return;
                }
                else {
                    for (var i = 1; i <= NoOfOption; i++) {
                        var rval = $("input[name='selectedRow']:checked").val();

                        if (i == rval) {
                            IsCorrect = true;
                        }
                        else {
                            IsCorrect = false;
                        }
                        var obj = {
                            Option_Text_Eng: CKEDITOR.instances['txtInstructions' + i].getData(),
                            IsCorrect: IsCorrect
                        }
                        item.push(obj);
                    }
                }
            }
            else if (AnswerType == 2) {
                for (var i = 1; i <= NoOfOption; i++) {
                    if ($('#checkbox' + i).is(":checked")) {
                        IsCorrect = true;
                    }
                    else {
                        IsCorrect = false;
                    }
                    var obj = {
                        Option_Text_Eng: CKEDITOR.instances['txtInstructions' + i].getData(),
                        IsCorrect: IsCorrect
                    }
                    item.push(obj);
                }
            }
            var r = 0;
            item.forEach(x => {
                if (x.Option_Text_Eng == null || x.Option_Text_Eng == '') {
                    RESULT = false;
                }


            });
            if (RESULT) {
                var questions
                    = {
                    SubjectId: SubjectId,
                    LessonId: LessonId,
                    QuestionType: QuestionType,
                    Language: Language,
                    AnswerType: AnswerType,
                    NoOfOption: NoOfOption,
                    EQuestion: EQuestion,
                    options: item
                }
                $.ajax({
                    type: "POST",
                    url: "/Master/SaveQuestion",
                    data: questions,
                    dataType: "json",
                    /* contentType: 'application/json; charset=utf-8',*/
                    success: function (data) {

                        window.location.replace("/Question");


                    },
                    error: function () {
                        alert("Error occured!!")
                    }
                });

            }
            else {
                $(".toast-header").text("Error");
                $(".toast-body").text("Please Fill Option");

                $('.toast').toast('show');
                $('.toast-container').toast('show');
            }
        }
        else if (Language == "3") {
            var HQuestion = CKEDITOR.instances['HindiQ'].getData();
            if (AnswerType == 1) {
                var rval1 = $("input[name='selectedRow']:checked").val();
                if (rval1 == null || rval1 == "undefined") {
                    RESULT = false;
                    $(".toast-header").text("Error");
                    $(".toast-body").text("Please Choose Any one Option");

                    $('.toast').toast('show');
                    $('.toast-container').toast('show');
                    return;
                }
                else {
                    for (var i = 1; i <= NoOfOption; i++) {
                        var rval = $("input[name='selectedRow']:checked").val();

                        if (i == rval) {
                            IsCorrect = true;
                        }
                        else {
                            IsCorrect = false;
                        }
                        var obj = {
                            Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + i].getData(),
                            IsCorrect: IsCorrect
                        }
                        item.push(obj);
                    }
                }
            }
            else if (AnswerType == 2) {
                for (var i = 1; i <= NoOfOption; i++) {
                    if ($('#checkbox' + i).is(":checked")) {
                        IsCorrect = true;
                    }
                    else {
                        IsCorrect = false;
                    }
                    var obj = {
                        Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + i].getData(),
                        IsCorrect: IsCorrect
                    }
                    item.push(obj);
                }
            }
            var r = 0;
            item.forEach(x => {
                if (x.Option_Text_Hindi == null || x.Option_Text_Hindi == '') {
                    RESULT = false;
                }


            });
            if (RESULT) {
                var questions
                    = {
                    SubjectId: SubjectId,
                    LessonId: LessonId,
                    QuestionType: QuestionType,
                    Language: Language,
                    AnswerType: AnswerType,
                    NoOfOption: NoOfOption,
                    HQuestion: HQuestion,
                    options: item
                }
                $.ajax({
                    type: "POST",
                    url: "/Master/SaveQuestion",
                    data: questions,
                    dataType: "json",
                    /* contentType: 'application/json; charset=utf-8',*/
                    success: function (data) {

                        window.location.replace("/Question");


                    },
                    error: function () {
                        alert("Error occured!!")
                    }
                });

            }
            else {
                $(".toast-header").text("Error");
                $(".toast-body").text("Please Fill Option");

                $('.toast').toast('show');
                $('.toast-container').toast('show');
            }

        }
    });
    CKEDITOR.replace('EnglishQ', { language: 'en' });
    CKEDITOR.replace('HindiQ',
        {
            language: 'hi'
        });

    $("#select-nooptions").change();
    $("#select-nooptions").val(4);
    for (var i = 1; i <= 4; i++) {
        Append(i, 1, "noimg", "no-onlyImg");
    }
    $("#imgUpload").hide();

    $("#select-option").change(function () {

        $("#imgUpload").hide();

        if ($('#select-option').val() === '1' && $('#select-question-type').val() == '1') {
            $("#imgUpload").hide();
            $("#textboxesEh").show();
            $("#no-of-options").show();
            $(".tabl").show();
            $(".tabl tbody").empty();
            for (var i = 1; i <= 4; i++) {
                Append(i, 1, "noimg", "no-onlyImg");
            }
        }
        else if ($('#select-option').val() == '2' && $('#select-question-type').val() == '1') {

            $("#imgUpload").hide();
            $("#textboxesEh").show();
            $("#no-of-options").show();
            $(".tabl").show();
            $(".tabl tbody").empty();
            for (var i = 1; i <= 4; i++) {
                Append(i, 2, "noimg", "no-onlyImg");
            }
        }
        else if ($('#select-option').val() == '3' /*&& $('#select-question-type').val() == '1'*/) {

            $("#imgUpload").hide();
            $("#no-of-options").hide();
            console.log("Paragraph");
            $("#QuesEn").show();
            $("QuesHi").show();
            $(".tabl tbody").empty();
            $(".tabl").hide();
        }
        else if ($('#select-option').val() == '1' && $('#select-question-type').val() == '2') {
            $("#no-of-options").show();
            $(".tabl").show();

            $("#imgUpload").show();
            $(".tabl tbody").empty();
            for (var i = 1; i <= 4; i++) {
                Append(i, 1, "img", "no-onlyImg");
            }
        }
        else if ($('#select-option').val() == '2' && $('#select-question-type').val() == '2') {
            $("#no-of-options").show();
            $(".tabl").show();

            $("#imgUpload").show();
            $(".tabl tbody").empty();
            for (var i = 1; i <= 4; i++) {
                Append(i, 2, "img", "no-onlyImg");
            }

        }
        else if ($('#select-option').val() == '1' && $('#select-question-type').val() == '3') {
            $("#no-of-options").show();
            $(".tabl").show();

            $("#imgUpload").show();
            $("#HindiQuestion").hide();
            $(".textareas").hide();

            $("#textboxesEh").hide();
            $(".tabl tbody").empty();
            for (var i = 1; i <= 4; i++) {
                Append(i, 1, "noimg", "onlyImg");
            }
        }
        else if ($('#select-option').val() == '2' && $('#select-question-type').val() == '3') {
            $("#HindiQuestion").hide();
            $(".textareas").hide();
            $("#no-of-options").show();
            $(".tabl").show();

            $("#imgUpload").show();
            $("#textboxesEh").hide();
            $(".tabl tbody").empty();
            for (var i = 1; i <= 4; i++) {
                Append(i, 2, "noimg", "onlyImg");
            }

        }

    });
    $("#select-lang").change(function () {
        if ($("#select-lang").val() == 2) {
            $(".QuesHi").hide();
            $(".hFont").hide();
            $(".QuesEn").show();
        }
        else if ($("#select-lang").val() == 3) {
            $(".QuesHi").show();
            $(".hFont").show();
            $(".QuesEn").hide();
        }
        else if ($("#select-lang").val() == 1) {
            $(".QuesHi").show();
            $(".hFont").show();
            $(".QuesEn").show();
        }
    });
    var i = 5;

    $("#select-nooptions").change(function (e) {
        var a = $("#select-nooptions").val();
        var table = $(".tabl tbody");
        table.empty();
        for (var op = 1; op <= a; op++) {



            e.preventDefault();

            if ($('#select-option').val() === "1" && $('#select-question-type').val() == '1') {
                Append(i, 1, "noimg", "no-onlyImg");
                i++;
            }
            else if ($('#select-option').val() === "2" && $('#select-question-type').val() == '1') {
                Append(i, 2, "noimg", "no-onlyImg");
                i++;
            }
            else if ($('#select-question-type').val() === "2" && $('#select-option').val() === "1") {

                Append(i, 1, "img", "no-onlyImg");
                i++;
            }
            else if ($('#select-question-type').val() === "2" && $('#select-option').val() === "2") {

                Append(i, 2, "img", "no-onlyImg");
                i++;
            }
            else if ($('#select-question-type').val() === "3" && $('#select-option').val() === "1") {
                Append(i, 1, "noimg", "onlyImg");
                i++;
            }
            else if ($('#select-question-type').val() === "3" && $('#select-option').val() === "2") {

                Append(i, 2, "noimg", "onlyImg");
                i++;
            }
        }
    });

    $("#subjects").change(function () {

        //var valueSubjects = $(this).val();
        //var valueLessons = $("#lessons").val();
        $("#get-lesson").click();
    });
    $("#delete-btn").click(function () {

    });
    $("body").on("click", ".remove-button", function () {
        console.log("Deleted");
        $(this).parents("tr").remove();
    });
});
