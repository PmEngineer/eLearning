
    const notyf = new Notyf({duration: 2000, position: {x: 'right', y: 'bottom' } });

    document.getElementById("addSubjectButton").addEventListener("click", function () {
        var subjectId = document.getElementById("subjectSelect").value;
    var subjectName = document.getElementById("subjectSelect").options[document.getElementById("subjectSelect").selectedIndex].text;
    var facultyId = document.getElementById("facultySelect").value;
    var facultyName = document.getElementById("facultySelect").options[document.getElementById("facultySelect").selectedIndex].text;
    var startTime = document.getElementById("startTime").value;
    var endTime = document.getElementById("endTime").value;

    if (subjectId && facultyId && startTime && endTime) {
            var table = document.getElementById("subjectsTable").getElementsByTagName('tbody')[0];
    var newRow = table.insertRow();

    newRow.insertCell(0).innerText = subjectName;
    newRow.insertCell(1).innerText = facultyName;
    newRow.insertCell(2).innerText = startTime;
    newRow.insertCell(3).innerText = endTime;

    var deleteCell = newRow.insertCell(4);
    var deleteButton = document.createElement("button");
    deleteButton.innerHTML = '<i class="fas fa-trash"></i>';
    deleteButton.classList.add("btn", "btn-danger", "btn-sm");
    deleteButton.onclick = function () {
        table.deleteRow(newRow.rowIndex - 1);
    notyf.success('Subject removed successfully.');
            };
    deleteCell.appendChild(deleteButton);

    document.getElementById("subjectSelect").selectedIndex = 0;
    document.getElementById("facultySelect").selectedIndex = 0;
    document.getElementById("startTime").value = "";
    document.getElementById("endTime").value = "";

   
    notyf.success('Subject added successfully.');
        } else {
        //alert("Please fill in all fields before adding.");
    
    notyf.error('Please fill in all fields before adding.');
        }
    });
