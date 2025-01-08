
const notyf = new Notyf({ duration: 2000, position: { x: 'right', y: 'bottom' } });

function calculateDuration() {
    var startdateInput = document.getElementById("startdate").value;
    var enddateInput = document.getElementById("enddate").value;

    if (startdateInput && enddateInput && enddateInput > startdateInput) {
        var startDate = new Date(startdateInput);
        var endDate = new Date(enddateInput);
        var duration = Math.abs(endDate - startDate);
        var durationInDays = Math.floor(duration / (1000 * 60 * 60 * 24));
        document.getElementById("duration").value = durationInDays;

    } else if (!enddateInput) {
        notyf.error('Please Select End Date...');
    } else {
        notyf.error('Invalid Date..');
    }
}

function calculateValidity() {
    var startdateInput = document.getElementById("startdate").value;
    var enddateInput = document.getElementById("enddate").value;

    if (startdateInput && enddateInput && enddateInput > startdateInput) {
        var startDate = new Date(startdateInput);
        var endDate = new Date(enddateInput);
        var duration = Math.abs(endDate - startDate);
        var durationInDays = Math.floor(duration / (1000 * 60 * 60 * 24));
        document.getElementById("validity").value = durationInDays;

    } else if (!enddateInput) {
        notyf.error('Please Select End Date...');
    } else {
        notyf.error('Invalid Date..');
    }
}
