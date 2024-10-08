function submitform() {
    var i = document.getElementById("myform");
    $("#myform").submit();
    console.log("Submitted");
}

function QuesAppend(i) {

    var table = $(".tabl");
    var row = $("<tr></tr>");
    row.append("<td class='QuesEn' style='font-weight: bold;font-size:22px;'> Question " + i + " in English <textarea class='' id='EnglishQ" + i + "'></textarea></td><td class='SolutionEn' style='font-weight: bold;font-size:22px;'> Solution " + i + " in English<textarea class='' id='EnglishSolution" + i + "'></textarea></td><td class='QuesHi'>" + i + " Hindi Question<textarea class='' id='HindiQ" + i + "'></textarea></td><td class='SolutionHi'> Solution " + i + " in Hindi<textarea class='' id='HindiSolution" + i + "'></textarea></td>");
    table.append(row);
    CKEDITOR.replace('EnglishQ' + i, { language: 'en' });
    CKEDITOR.replace('EnglishSolution' + i, { language: 'en' }); 
    CKEDITOR.replace('HindiQ' + (i), { language: 'hi' });
    CKEDITOR.replace('HindiSolution' + (i), { language: 'hi' });
}

function Append(i, type, img, onlyImg, checkval, nooption) {

    var table = $(".tabl");
    var row = $("<tr></tr>");
    if (type == 1 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn" style="font-weight:bold;font-size:18px;" > Option ' + nooption + ' in English (Question'+" "+ '' +  checkval + ') <textarea class="QuesEn"  id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td class="QuesHi"><textarea  id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc " style="margin-top:150px" id="radio' + i + '"  name="selectedRow' + checkval + '" value="' + checkval + '"  type="radio"/></td><td style="display:none;"><button  class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 2 && img == "noimg" && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn" style="font-weight:bold"><textarea class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class="w-50 rc" type="checkbox" value="' + i + '" id="checkbox' + i + '"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
        table.append(row);
    }
    else if (type == 1 && img == 'img' && onlyImg == "no-onlyImg") {
        row.append('<td class="QuesEn" style="font-weight:bold"><textarea  class="QuesEn" id="txtInstructions' + i + '" name="EQuestion"></textarea><div class="mb-3"> <label for="formFile" class="form-label">Upload Image</label><input class="form-control" type="file" id="formFile"></div></td><td class="QuesHi"><textarea id="hitxtInstructions' + i + '" class="hFont"  name="HQuestion"></textarea></td><td><input class=" w-50 rc" name="selectedRow" value="' + i + '" type="radio"/></td><td style="display:none;"><button class="remove-button border border-0 fa fa-trash-o fs-4 text-danger" ></button></td>');
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


    $("#select-noofquestions").val("5");
    $("#select-lang").val("2");
   
    var cou = 1;
    for (var i = 1; i <= 5; i++) {
        QuesAppend(i);
        for (var j = 1; j <= 4; j++) {


            Append(cou, 1, "noimg", "no-onlyImg", i,j)
            cou++;
        }
    }

    $(".QuesHi").hide();
    $(".hFont").hide();
    $(".QuesEn").show();
    $(".SolutionEn").show();
    $(".SolutionHi").hide();

    $("#save-btn").click(function () {
      

        var SubjectId = $("#subjects").val();
        var LessonId = $("#lessons").val();
        var QuestionType = $("#select-question-type").val();
        var Language = $("#select-lang").val();
        var AnswerType = $("#select-option").val();
        var NoofQuestion = $("#select-noofquestions").val();
        var NoOfOption = 4;
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
                    Option_Text_Hindi: CKEDITOR.instances['hitxtInstructions' + cou].getData(),
                    Option_Text_Eng: CKEDITOR.instances['txtInstructions' + cou].getData(),
                    IsCorrect: IsCorrect
                }
                opitem.push(obj);
                cou++;
            }
            var EnglishQ = CKEDITOR.instances['EnglishQ'+j].getData();
            var EnglishSolution = CKEDITOR.instances['EnglishSolution'+j].getData();
           
            var HindiQ = CKEDITOR.instances['HindiQ'+j].getData();
            var HindiSolution = CKEDITOR.instances['HindiSolution'+j].getData();
            var questions=
            {
                SubjectId: SubjectId,
                LessonId: LessonId,
                QuestionType: QuestionType,
                Language: Language,
                AnswerType: AnswerType,
                NoOfOption: NoOfOption,
                EQuestion: EnglishQ,
                EQuesSolution: EnglishSolution,
                HQuestion: HindiQ,
                HQuesSolution: HindiSolution,              
                options: opitem
            }
            opitem = [];
            Quesitem.push(questions);
            

        }



        var ParaEnglishQ = CKEDITOR.instances['ParaEnglishQ'].getData();
        var ParaHindiQ = CKEDITOR.instances['ParaHindiQ'].getData();
        var ParagraphQuesInfo = {
            EngQuestion: ParaEnglishQ,
            HindiQuestion: ParaHindiQ,
            paragraphQuesInfos: Quesitem
        }
    
        console.log(ParagraphQuesInfo);
      
        $.ajax({
            type: "POST",
            url: "/Master/SaveParagraphQuestion",
            data: ParagraphQuesInfo,
            dataType: "json",
            success: function (data) {
                $(".tabl tbody").empty();

            //    for (var i = 1; i <= NoOfOption; i++) {

            //        CKEDITOR.instances['hitxtInstructions' + i].setData("");
            //        CKEDITOR.instances['txtInstructions' + i].setData("");


            //    }

              //  CKEDITOR.instances['HindiQ'].setData("");
            //   CKEDITOR.instances['EnglishQ'].setData("");
                window.location.replace("/DailyParagraphQuestion");
            },
            error: function () {
                alert("Error occured!!")
            }
        });
    });
    //CKEDITOR.replace('EnglishQ', { language: 'en' });
    //CKEDITOR.replace('HindiQ',
    //    {
    //        language: 'hi'
    //    });
    CKEDITOR.replace('ParaHindiQ',
        {
            language: 'hi'
        });
    CKEDITOR.replace('ParaEnglishQ', { language: 'en' });

    //$("#no-of-questions").change();
    //$("#no-of-questions").val(4);
    //for (var i = 1; i <= 4; i++) {
    //    Append(i, 1, "noimg", "no-onlyImg");
    //}
    $("#imgUpload").hide();

   
    $("#select-lang").change(function () {
        if ($("#select-lang").val() == 2) {
            $(".QuesHi").hide();
            $(".SolutionHi").hide();
            $(".hFont").hide();
            $(".QuesEn").show();
            $(".SolutionEn").show();
          

        }
        else if ($("#select-lang").val() == 3) {
            $(".QuesHi").show();
            $(".hFont").show();
            $(".QuesEn").hide();
            $(".SolutionEn").hide();
            $(".SolutionHi").show();
        }
        else if ($("#select-lang").val() == 1) {
            $(".QuesHi").show();
            $(".hFont").show();
            $(".QuesEn").show();
            $(".SolutionEn").hide();
            $(".SolutionHi").hide();

        }
    });
    var i = 5;
    $("#select-noofquestions").change(function (e) {
        var noquest = $("#select-noofquestions").val();
        var cou = 1;
        for (var i = 1; i <= noquest; i++) {
            QuesAppend(i);
            for (var j = 1; j <= 4; j++) {


                Append(cou, 1, "noimg", "no-onlyImg",i)
                cou++;
            }
        }
    });
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


});
