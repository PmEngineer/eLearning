$(document).ready(function () {
    $("#update-btn").click(function () {
        var SubjectId = $("#subjects").val();
        var LessonId = $("#lessons").val();
        var QuestionType = $("#select-question-type").val();
        var Language = $("#select-lang").val();
        var AnswerType = $("#select-option").val();
        var NoOfOption = $("#select-nooptions").val();
        //var EQuestion = $("#EnglishQ").text();
        //var HQuestion = $("#HindiQ").text();
        var Id = $("#question_Id").val();
        var question_CreatedDate = $("#question_CreatedDate").val();
        var question_CreatedBy = $("#question_CreatedBy").val();
        var item = [];
        var IsCorrect = false;
        var RESULT = true;
        if (Language == "1") {
            var HQuestion = CKEDITOR.instances['HindiQ'].getData();
            var HQuestionSolution = CKEDITOR.instances['HindiSolution'].getData();
            var EQuestion = CKEDITOR.instances['EnglishQ'].getData();
            var EQuestionSolution = CKEDITOR.instances['EnglishSolution'].getData();
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
                    for (var i = 0; i < NoOfOption; i++) {
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
                            IsCorrect: IsCorrect,
                            Id: $("#optionId" + i).val()
                        }
                        item.push(obj);
                    }
                }
            }

            else if (AnswerType == 2) {
                for (var i = 0; i < NoOfOption; i++) {
                    if ($('#checkbox' + i).is(":checked")) {
                        IsCorrect = true;
                    }
                    else {
                        IsCorrect = false;
                    }
                    var obj = {
                        Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + i].getData(),
                        Option_Text_Eng: CKEDITOR.instances['txtInstructions' + i].getData(),
                        IsCorrect: IsCorrect,
                        Id: $("#optionId" + i).val()
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
                    HQuesSolution: HQuestionSolution,
                    EQuesSolution: EQuestionSolution,
                    QuestionType: QuestionType,
                    Language: Language,
                    AnswerType: AnswerType,
                    NoOfOption: NoOfOption,
                    EQuestion: EQuestion,
                    HQuestion: HQuestion,
                    Id: Id,
                    CreatedOn: question_CreatedDate,
                    CreatedBy: question_CreatedBy,
                    options: item
                }
                $.ajax({
                    type: "POST",
                    url: "/Master/UpdateQuestion",
                    data: questions,
                    dataType: "json",
                    /* contentType: 'application/json; charset=utf-8',*/
                    success: function (data) {

                        window.location.replace("/EditQuestion/" + Id);


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
        if (Language == "2") {
            var EQuestion = CKEDITOR.instances['EnglishQ'].getData();
            var EQuestionSolution = CKEDITOR.instances['EnglishSolution'].getData();
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
                    for (var i = 0; i < NoOfOption; i++) {
                        var rval = $("input[name='selectedRow']:checked").val();

                        if (i == rval) {
                            IsCorrect = true;
                        }
                        else {
                            IsCorrect = false;
                        }
                        var obj = {
                            Option_Text_Eng: CKEDITOR.instances['txtInstructions' + i].getData(),
                            IsCorrect: IsCorrect,
                            Id: $("#optionId" + i).val()
                        }
                        item.push(obj);
                    }
                }
            }

            else if (AnswerType == 2) {
                for (var i = 0; i < NoOfOption; i++) {
                    if ($('#checkbox' + i).is(":checked")) {
                        IsCorrect = true;
                    }
                    else {
                        IsCorrect = false;
                    }
                    var obj = {
                        Option_Text_Eng: CKEDITOR.instances['txtInstructions' + i].getData(),
                        IsCorrect: IsCorrect,
                        Id: $("#optionId" + i).val()
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
             debugger;

            if (RESULT) {
                var questions
                    = {
                    SubjectId: SubjectId,
                    LessonId: LessonId,
                    EQuesSolution: EQuestionSolution,
                    QuestionType: QuestionType,
                    Language: Language,
                    AnswerType: AnswerType,
                    NoOfOption: NoOfOption,
                    EQuestion: EQuestion,
                    Id: Id,
                    CreatedOn: question_CreatedDate,
                    CreatedBy: question_CreatedBy,
                    options: item
                }
                $.ajax({
                    type: "POST",
                    url: "/Master/UpdateQuestion",
                    data: questions,
                    dataType: "json",
                    /* contentType: 'application/json; charset=utf-8',*/
                    success: function (data) {

                        window.location.replace("/EditQuestion/" + Id);


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
        if (Language == "3") {
            var HQuestion = CKEDITOR.instances['HindiQ'].getData();
            var HQuestionSolution = CKEDITOR.instances['HindiSolution'].getData();
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
                    for (var i = 0; i < NoOfOption; i++) {
                        var rval = $("input[name='selectedRow']:checked").val();

                        if (i == rval) {
                            IsCorrect = true;
                        }
                        else {
                            IsCorrect = false;
                        }
                        var obj = {
                            Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + i].getData(),
                            IsCorrect: IsCorrect,
                            Id: $("#optionId" + i).val()
                        }
                        item.push(obj);
                    }
                }
            }

            else if (AnswerType == 2) {
                for (var i = 0; i < NoOfOption; i++) {
                    if ($('#checkbox' + i).is(":checked")) {
                        IsCorrect = true;
                    }
                    else {
                        IsCorrect = false;
                    }
                    var obj = {
                        Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + i].getData(),
                        IsCorrect: IsCorrect,
                        Id: $("#optionId" + i).val()
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
            debugger;

            if (RESULT) {
                var questions
                    = {
                    SubjectId: SubjectId,
                    LessonId: LessonId,
                    HQuesSolution: HQuestionSolution,
                    QuestionType: QuestionType,
                    Language: Language,
                    AnswerType: AnswerType,
                    NoOfOption: NoOfOption,
                    HQuestion: HQuestion,
                    Id: Id,
                    CreatedOn: question_CreatedDate,
                    CreatedBy: question_CreatedBy,
                    options: item
                }
                $.ajax({
                    type: "POST",
                    url: "/Master/UpdateQuestion",
                    data: questions,
                    dataType: "json",
                    /* contentType: 'application/json; charset=utf-8',*/
                    success: function (data) {

                        window.location.replace("/EditQuestion/" + Id);


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
        localStorage.setItem("LocateKey", "1");
    });
});
var questionEdit = function (quesid) {
    var s = $('#subjects').val();
    // alert(s);
    $.ajax({
        type: "get",
        url: "/Master/GetQuestionById?Id=" + quesid,
        success: function (data) {



            console.log(data);

            var eQuestion = data.eQuestion;
            var eQuesSolution = data.eQuesSolution;

            var hQuestion = data.hQuestion;
            var hQuesSolution = data.hQuesSolution;

            CKEDITOR.instances['HindiQ'].setData(hQuestion);
            CKEDITOR.instances['HindiSolution'].setData(hQuesSolution);

            CKEDITOR.instances['EnglishQ'].setData(eQuestion);
            CKEDITOR.instances['EnglishSolution'].setData(eQuesSolution);

            var questionType = data.questionType;
            var answerType = data.answerType;
            var subjectId = data.subjectId;

            var noopoptions = data.noOfOption;
            var lessonId = data.lessonId.Name;
            var language = data.language;
            var isActive = data.isActive;
            var id = data.id;
            var Option_Text_Eng = data.Option_Text_Eng;
            var Option_Text_Hindi = data.Option_Text_Hindi;
            //$("#subjects").val(subjectId);
            //$("#select-nooptions").val(noopoptions);
            //$("#select-option").val(answerType);
            if (language == 2) {
                $(".QuesHi").hide();
                $(".hFont").hide();
                $(".QuesEn").show();
            }
            else if (language == 3) {
                $(".QuesHi").show();
                $(".hFont").show();
                $(".QuesEn").hide();
            }
            else if (language == 1) {
                $(".QuesHi").show();
                $(".hFont").show();
                $(".QuesEn").show();
            }
            // alert(subjectId);
            $.each(data.options, function (i, value) {
                var option_Text_Eng = value.option_Text_Eng;
                var isCorrect = value.isCorrect
                var questionId = value.questionId;
                var optionId = value.id;
                if (language == "1") {
                    var option_Text_Hindi = value.option_Text_Hindi;
                    var option_Text_Eng = value.option_Text_Eng;

                    AppendBoth(i, answerType, "noimg", "no-onlyImg", option_Text_Hindi, option_Text_Eng, isCorrect, optionId);
                }
                else if (language == "2") {
                    var option_Text_Eng = value.option_Text_Eng;

                    AppendEnglish(i, answerType, "noimg", "no-onlyImg", option_Text_Eng, isCorrect, optionId);
                }
                else if (language == "3") {
                    var option_Text_Hindi = value.option_Text_Hindi;
                    AppendHindi(i, answerType, "noimg", "no-onlyImg", option_Text_Hindi, isCorrect, optionId);
                }
            });

        },
        error: function () {
            alert("Error occured!!")
        }
    });
}
function AppendBoth(i, type, img, onlyImg, option_Text_Hindi, option_Text_Eng, iscorrect, optionId) {
    var checked = "";
    if (iscorrect) {
        checked = "checked";
    }
    var table = $(".tabl");
    var row = $("<tr></tr>");
    if (type == 1 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td class="QuesHi"><textarea  id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" ' + checked + ' name="selectedRow" value="' + i + '"  type="radio"/></td><td style="display:none;"><button  class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" ' + checked + ' type="checkbox" value="' + i + '" id="checkbox' + i + '"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 1 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea  class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" ' + checked + ' name="selectedRow" value="' + i + '" type="radio"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" ' + checked + ' type="checkbox"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
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
    CKEDITOR.replace('hitxtInstructions' + i, { language: 'hi' });
    CKEDITOR.instances['txtInstructions' + i].setData(option_Text_Eng);
    CKEDITOR.instances['hitxtInstructions' + i].setData(option_Text_Hindi);

}
function AppendEnglish(i, type, img, onlyImg, option_Text_Eng, iscorrect, optionId) {
    var checked = "";
    if (iscorrect) {
        checked = "checked";
    }
    var table = $(".tabl");
    var row = $("<tr></tr>");
    if (type == 1 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td><input class="w-50 rc" ' + checked + ' name="selectedRow" value="' + i + '"  type="radio"/></td><td style="display:none;"><button  class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td><input class="w-50 rc" ' + checked + ' type="checkbox" value="' + i + '" id="checkbox' + i + '"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 1 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea  class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td><input class="w-50 rc" ' + checked + ' name="selectedRow" value="' + i + '" type="radio"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td><input class="w-50 rc" ' + checked + ' type="checkbox"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
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

    CKEDITOR.replace('txtInstructions' + i, {
        language: 'en',
        filebrowserImageUploadUrl: '/Editor/Upload',
        filebrowserUploadMethod: "form",
        filebrowserImageBrowseLinkUrl: "/Editor/FileBrowse/"
});
    CKEDITOR.instances['txtInstructions' + i].setData(option_Text_Eng);

}
function AppendHindi(i, type, img, onlyImg, option_Text_Hindi, iscorrect, optionId) {
    var checked = "";
    if (iscorrect) {
        checked = "checked";
    }
    var table = $(".tabl");
    var row = $("<tr></tr>");
    if (type == 1 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesHi"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea  id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" ' + checked + ' name="selectedRow" value="' + i + '"  type="radio"/></td><td style="display:none;"><button  class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesHi"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" ' + checked + ' type="checkbox" value="' + i + '" id="checkbox' + i + '"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 1 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesHi"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td><input class="w-50 rc" ' + checked + ' name="selectedRow" value="' + i + '" type="radio"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesHi"><input type="hidden" id="optionId' + i + '" value="' + optionId + '"/><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td><input class="w-50 rc" ' + checked + ' type="checkbox"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
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

    CKEDITOR.replace('hitxtInstructions' + i, {
        language: 'hi',
        filebrowserImageUploadUrl: '/Editor/Upload',
        filebrowserUploadMethod: "form",
        filebrowserImageBrowseLinkUrl: "/Editor/FileBrowse/"
});
    CKEDITOR.instances['hitxtInstructions' + i].setData(option_Text_Hindi);

}
