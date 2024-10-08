function QuesAppend(i, QuesEng, QuesHin, QuesId,ESolution,HSolution) {

    var table = $(".tabl");
    var row = $("<tr></tr>");
    row.append("<td style='display:none;'><input id='input" + i + "' value='" + QuesId + "' type='hidden'/></td><td class='QuesEn' >" + i + " English Question<textarea class='' id='EnglishQ" + i + "'></textarea></td><td class='QuesEn'>" + i + "English Solution<textarea class='' id='ESolution" + i + "'></textarea> </td><td class='QuesHi'>" + i + " Hindi Question<textarea class='' id='HindiQ" + i + "'></textarea></td><td class='QuesHi'>" + i + " Hindi Solution<textarea class='' id='HSolution" + i + "'></textarea></td>");
    table.append(row);
    CKEDITOR.replace('EnglishQ' + i, { language: 'en' });
    CKEDITOR.replace('ESolution' + i, { language: 'en' });
    CKEDITOR.replace('HindiQ' + (i), { language: 'hi' });
    CKEDITOR.replace('HSolution' + (i), { language: 'hi' });
    CKEDITOR.instances['EnglishQ' + i].setData(QuesEng);
    CKEDITOR.instances['ESolution' + i].setData(ESolution);
    CKEDITOR.instances['HindiQ' + i].setData(QuesHin);
    CKEDITOR.instances['HSolution' + i].setData(HSolution);
}

function Append(i, type, img, onlyImg, checkval, Engvalue, hindival,OptionId,Checked) {

    var table = $(".tabl");
    var row = $("<tr></tr>");
    if (type == 1 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td style="display:none;"><input id="optionsinput' + i + '" value="' + OptionId + '"/></td><td class="QuesEn" ><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td class="QuesHi"><textarea  id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" ' + Checked +' id="radio' + i + '"  name="selectedRow' + checkval + '" value="' + checkval + '"  type="radio"/></td><td style="display:none;"><button  class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td style="display:none;"><input id="optionsinput' + i + '" value="' + OptionId +'"/></td><td class="QuesEn"><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" type="checkbox" value="' + i + '" id="checkbox' + i + '"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 1 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td style="display:none;"><input id="optionsinput' + i + '" value="' + OptionId +'"/></td><td class="QuesEn"><textarea  class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class=" w-50 rc" name="selectedRow" value="' + i + '" type="radio"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td style="display:none;"><input id="optionsinput' + i + '" value="' + OptionId +'"/></td><td class="QuesEn"><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" type="checkbox"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);

    }
    else if (type == 1 && img == 'noimg' && onlyImg == "onlyImg") {
        row.append('<td style="display:none;"><input id="optionsinput' + i + '" value="' + OptionId +'"/></td><td><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td><input class="w-50 rc" name="selectedRow" value="' + i + '" type="radio"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger"></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == 'noimg' && onlyImg == "onlyImg") {
        row.append('<td style="display:none;"><input id="optionsinput' + i + '" value="' + OptionId +'"/></td><td><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td><input class="w-50 rc"  type="checkbox"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger"></button></td>');
        table.append(row);
    }

    CKEDITOR.replace('txtInstructions' + i, { language: 'en' });
    CKEDITOR.replace('hitxtInstructions' + (i), { language: 'hi' });
    CKEDITOR.instances['txtInstructions' + i].setData(Engvalue);
    CKEDITOR.instances['hitxtInstructions' + (i)].setData(hindival);
}



$(document).ready(function () {

    $("#save-btn").click(function () {

        var inputhidden = $("#ParaQuestionId").val();
        var SubjectId = $("#subjects").val();
        var LessonId = $("#lessons").val();
        var QuestionType = $("#select-question-type").val();
        var Language = $("#select-lang").val();
        var AnswerType = $("#select-option").val();
        var NoofQuestion = $("#select-noofquestions").val();
        var NoOfOption = 4;
        var CreatedBy =  $("#createdby").val();
        //var EQuestion = $("#EnglishQ").text();
        //var HQuestion = $("#HindiQ").text();


        var opitem = [];
        var Quesitem = [];

        var IsCorrect = false;
        var RESULT = true;
        var cou = 1;
        for (var j = 1; j <= NoofQuestion; j++) {


            for (var i = 1; i <= 4; i++) {
                if ($("#radio" + cou).prop("checked")) {
                    IsCorrect = true;
                }
                else {
                    IsCorrect = false;
                } 
                var obj = {
                    Id: $("#optionsinput" + cou).val(),
                    Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + cou].getData(),
                    Option_Text_Eng: CKEDITOR.instances['txtInstructions' + cou].getData(),
                    IsCorrect: IsCorrect
                }
                opitem.push(obj);
                cou++;
            }
            var quesId = $("#input" +j).val();
            var EnglishQ = CKEDITOR.instances['EnglishQ' + j].getData();
            var ESolution = CKEDITOR.instances['ESolution' + j].getData();
            var HindiQ = CKEDITOR.instances['HindiQ' + j].getData();
            var HSolution = CKEDITOR.instances['HSolution' + j].getData();
            var questions =
            {
                Id: quesId,
                SubjectId: SubjectId,
                LessonId: LessonId,
                QuestionType: QuestionType,
                Language: Language,
                AnswerType: AnswerType,
                NoOfOption: NoOfOption,
                EQuestion: EnglishQ,
                HQuestion: HindiQ,
                EQuesSolution: ESolution,
                HQuesSolution: HSolution,
                options: opitem
            }
            opitem = [];
            Quesitem.push(questions);


        }



        var ParaEnglishQ = CKEDITOR.instances['ParaEnglishQ'].getData();
        var ParaHindiQ = CKEDITOR.instances['ParaHindiQ'].getData();
        var ParagraphQuesInfo = {
            Id: inputhidden,
            EngQuestion: ParaEnglishQ,
            HindiQuestion: ParaHindiQ,
            paragraphQuesInfos: Quesitem,
            CreatedBy: CreatedBy
        }

        console.log(ParagraphQuesInfo);
        $.ajax({
            type: "POST",
            url: "/Master/UpdateParagraphQuestion",
            data: ParagraphQuesInfo,
            dataType: "json",
            success: function (data) {
                window.location.replace("/EditParagraphQuestion/" + inputhidden);
             
                //    for (var i = 1; i <= NoOfOption; i++) {

                //        CKEDITOR.instances['hitxtInstructions' + i].setData("");
                //        CKEDITOR.instances['txtInstructions' + i].setData("");


                //    }

                //    CKEDITOR.instances['HindiQ'].setData("");
                //    CKEDITOR.instances['EnglishQ'].setData("");
            },
            error: function () {
                alert("Error occured!!")
            }
        });
        localStorage.setItem("LocateKe", "2");

    });
});

var questionEdit = function (quesid) {
   
    $.ajax({
        type: "get",
        url: "/Master/GetParagraphQuestionById?Id=" + quesid,
        success: function (data) {

            var eQuestion = data.engQuestion;

            var hQuestion = data.hindiQuestion;
            CKEDITOR.replace('ParaEnglishQ', { language: 'en' });
            CKEDITOR.replace('ParaHindiQ',
                {
                    language: 'hi'
                });
            CKEDITOR.instances['ParaHindiQ'].setData(hQuestion);
            CKEDITOR.instances['ParaEnglishQ'].setData(eQuestion);
            var paragraphQuesInfoList = data.paragraphQuesInfos;
            var question = paragraphQuesInfoList[0];
            console.log(question);
            console.log(paragraphQuesInfoList.length);
            $("#subjects").val(question.subjectId);
            $("#lessons").val(question.lessonId);
           // $("#select-noofquestions").val(paragraphQuesInfoList.length);
            //$("#select-noofquestions").val(paragraphQuesInfoList.length);
            $("#select-noofquestions").val(paragraphQuesInfoList.length).trigger('change.select2');
            $("#select-question-type").val(question.questionType);
            $("#select-option").val(question.answerType);
            $("#select-lang").val(question.language).trigger('change.select2');
           // $("#select-lang").val(question.language);
            $("#createdby").val(data.createdBy);
            var i = 1, count = 1;
            paragraphQuesInfoList.forEach(x => {
                var optiondata = x.options;
                console.log(x);

                QuesAppend(i, x.eQuestion, x.hQuestion, x.id, x.eQuesSolution, x.hQuesSolution)

                optiondata.forEach(y => {
                    var checked = "";
                    if (y.isCorrect) {
                        checked = "checked";
                    }
                    Append(count, 1, "noimg", "no-onlyImg", i, y.option_Text_Eng, y.option_Text_Hindi, y.id, checked);
                    count++;
                });
                i++;

            });


            if (question.language=="2") {
                $(".QuesHi").hide();
                $(".hFont").hide();
                $(".QuesEn").show();
            }
            else if (question.language == "3") {
                $(".QuesHi").show();
                $(".hFont").show();
                $(".QuesEn").hide();
            }
        }

    });

}