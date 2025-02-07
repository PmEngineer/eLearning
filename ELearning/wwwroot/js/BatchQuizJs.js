$(document).ready(function () {
    $('#addOption').on('click', function () {
        let EngOption = $('#Eoption').val();
        let HindiOption = $('#Hoption').val();
        let IsTrue = $("#isTrue").is(':checked');



        if (EngOption && HindiOption) {

            let newRow = `<tr>
                                <td>${EngOption}</td>
                                <td>${HindiOption}</td>
                                <td><input type="checkbox" class="is-correct" ${IsTrue ? 'checked' : ''}></td>>
                            <td><button class="btn btn-danger delete-button"><i class="fas fa-trash"></i></button></td>
                        </tr>`;

            $('#optionsTable tbody').append(newRow);


            $('#Eoption').val('');
            $('#Hoption').val('');
            $('#isTrue').prop('checked', false);
        } else {
            alert("Please fill all fields.");
        }
    });

    $('#optionsTable').on('click', '.delete-button', function () {
        $(this).closest('tr').remove();
    });
});
