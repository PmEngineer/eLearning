$(document).ready(function () {
    console.log("ready!");
   // PermanantState();
    State();
    ZRO();
   
   /* Category();*/
});

//function PermanantState() {
//    var city = "";

//    $('#myselect1').empty();
//    var stateID = $('#myselect').val();

//    $.ajax({
//        type: "GET",
//        url: "/Student/GetCityById?stateId=" + stateID,


//        dataType: "json",
//        success: function (result) {
//            console.log(result);
//            city = city + '<option value="0">Select District</option>'
//            for (i = 0; i < result.length; i++) {
//                city = city + '<option value="' + result[i].id + '">' + result[i].name + '</option>'
//            }

//            $('#myselect1').append(city);

//        }


//    });
//}
function ZRO() {
    var zroID = $('#zroId').val();
    var ARO = "";

    $('#AROID').empty();
    $.ajax({
        type: "GET",
        url: "/Student/GetAROById?ZROID=" + zroID,

        //data: catID,
        //contextType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            for (i = 0; i < result.length; i++) {
                ARO = ARO + '<option value="' + result[i].id + '">' + result[i].name + '</option>'
            }
            $('#AROID').append(ARO);

        }


    });
}
    //function Category() {
    //    var caste="";
    //$('#studentDetail_CasteID').empty();
    //var catID = $('#studentDetail_CategoryID').val();
    //var rID = $('#studentDetail_ReligionID').val();




    //$.ajax({
    //    type: "GET",
    //url: "/Student/GetCasteById?catId=" + catID + "&RegId=" + rID,

    ////data: catID,
    ////contextType: "application/json; charset=utf-8",
    //dataType: "json",
    //success: function (result) {
    //    console.log(result);
    //for(i=0;i<result.length;i++){
    //    caste = caste + '<option value="' + result[i].id + '">' + result[i].name + '</option>'
    //}
    //$('#studentDetail_CasteID').append(caste);
    //        }


    //    });
    //}
function removeStdEducation(id) {

    var res = id.charAt(id.length - 1);

    $('#stdEducationForm' + res + '').remove();


}
function IsSamePermanentAddress() {
   
    let IsSamePermanantAddress = $('#studentDetail_studentAddress_IsSameAsPermanent').is(':checked');
   

    var HouseNo = $('#studentDetail_studentAddress_HouseNo').val();
    var StateID = $('#studentDetail_studentAddress_StateId').val();
    
    var PostOffice = $('#studentDetail_studentAddress_PostOffice').val();
    var District = $('#studentDetail_studentAddress_DistrictId').val();
    
    var Village = $('#studentDetail_studentAddress_Village').val();
    var PoliceStation = $('#studentDetail_studentAddress_PoliceStation').val();
    var Tehsil = $('#studentDetail_studentAddress_Tehsil').val();
    var MobileNo = $('#studentDetail_studentAddress_MobileNo').val();
    var GaurdianMobileNo = $('#studentDetail_studentAddress_GaurdianMobileNo').val();
    var Pincode = $('#studentDetail_studentAddress_Pincode').val();
    var FullAddress = $('#studentDetail_studentAddress_FullAddress').val();
    if (IsSamePermanantAddress == true) {
        $('#PermanantHouseNo').val(HouseNo);
        //  $('#PermanantStateId').val(StateID);
        $("#myselect option[value=" + StateID + "]").prop("selected", true);
        $("#myselect1 option[value=" + District + "]").prop("selected", true);
        //$("#myselect option[value=" + StateID + "]").attr('selected', 'selected');
       // $("#myselect1 option[value=" + District + "]").attr('selected', 'selected');
        $('#PermanantPostOffice').val(PostOffice);

        $('#PermanantVillage').val(Village);
        $('#PermanantPoliceStation').val(PoliceStation);
        $('#PermanantTehsil').val(Tehsil);
        $('#PermanantMobileNo').val(MobileNo);
        $('#PermanantGaurdianMobileNo').val(GaurdianMobileNo);
        $('#PermanantPincode').val(Pincode);
    }
    else {
        $('#PermanantHouseNo').val("");
        $('#myselect').val(0);
        //$('#myselect1').val("Select District");
        $('#myselect1').val(0);
        //$('#PermanantStateId').val("");
        //$('#PermanantDistrictId').val("");
        $('#PermanantPostOffice').val("");

        $('#PermanantVillage').val("");
        $('#PermanantPoliceStation').val("");
        $('#PermanantTehsil').val("");
        $('#PermanantMobileNo').val("");
        $('#PermanantGaurdianMobileNo').val("");
        $('#PermanantPincode').val("");
    }

}
function State() {
    var city = "";
    $('#studentDetail_studentAddress_DistrictId').empty();
   // $('#myselect1').empty();
    var stateID = $('#studentDetail_studentAddress_StateId').val();

    $.ajax({
        type: "GET",
        url: "/Student/GetCityById?stateId=" + stateID,


        dataType: "json",
        success: function (result) {
            console.log(result);
            city = city + '<option value="0">Select District</option>'
            for (i = 0; i < result.length; i++) {
                city = city + '<option value="' + result[i].id + '">' + result[i].name + '</option>'
            }
            $('#studentDetail_studentAddress_DistrictId').append(city);
           // $('#myselect1').append(city);

        }


    });
}