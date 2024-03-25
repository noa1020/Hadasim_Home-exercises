//edit vaccination logic
async function EditVaccination(item, selectElement, vaccinationDateInput, userVaccinationId, editVaccinationButton) {
    const index = item.vaccinations.findIndex(v => v.userVaccinationId === userVaccinationId);

    selectElement.removeAttribute('readonly');
    vaccinationDateInput.removeAttribute('readonly');
    selectElement.style.border = '1px solid blue';
    vaccinationDateInput.style.border = '1px solid blue';
    selectElement.removeChild(selectElement.firstChild);
    vaccinationsArr.forEach(vaccination => {
        const option = document.createElement('option');
        option.value = vaccination.vaccinationId;
        option.textContent = vaccination.vaccinationName;
        selectElement.appendChild(option);
        if (vaccination.vaccinationId == item.vaccinations[index].vaccinationId)
            option.selected = true;
    });

    editVaccinationButton.textContent = 'Confirm Changes';
    editVaccinationButton.style.backgroundColor = 'green';
    editVaccinationButton.classList.add('confirm-button');
    editVaccinationButton.onclick = () => confirmChangesHandler(vaccinationDateInput, index, item, selectElement, editVaccinationButton);

}
//confirm vaccination changes
async function confirmChangesHandler(vaccinationDateInput, index, item, selectElement, editVaccinationButton) {
    if (vaccinationDateInput.value=='') {
        alert('Please fill in all required fields');
        return;
    }
    item.vaccinations[index].vaccinationId = parseInt(selectElement.value);
    item.vaccinations[index].vaccinationDate = new Date(vaccinationDateInput.value);
    await UpdateUser(item);
}

// Add vaccination logic
async function AddVaccinationDialog(user) {
    if (user.vaccinations?.length == 4) {
        alert("You cannot take more than 4 vaccines");
    }
    else {
        const dialogContainer = document.createElement('div');
        dialogContainer.classList.add('dialog-container');

        const dialogBox = document.createElement('div');
        dialogBox.classList.add('dialog-box');

        const closeButton = document.createElement('button');
        closeButton.classList.add('close-button');
        closeButton.innerHTML = 'X';
        closeButton.classList.add("close-button", "btn", "btn-danger");
        closeButton.addEventListener('click', () => {
            document.body.removeChild(dialogContainer);
        });

        const title = document.createElement('h2');
        title.textContent = 'Add Vaccination';

        const dateLabel = document.createElement('label');
        dateLabel.textContent = 'Vaccination Date: ';
        const dateInput = document.createElement('input');
        dateInput.type = 'date';
        dateInput.classList.add("dialogInput");

        var selectElement = document.createElement("select");
        var selectElementLabel = document.createElement("label");
        selectElementLabel.textContent = "Choose vaccination:";
        selectElement.required = true;
        var defaultOption = document.createElement("option");
        defaultOption.value = "";
        defaultOption.textContent = "Select vaccination...";
        defaultOption.disabled = true;
        defaultOption.selected = true;
        selectElement.appendChild(defaultOption);


        vaccinationsArr.forEach(vaccination => {
            const option = document.createElement('option');
            option.value = vaccination.vaccinationId;
            option.textContent = vaccination.vaccinationName;
            selectElement.appendChild(option);
        });

        const confirmButton = document.createElement('button');
        confirmButton.classList.add('confirm-button');
        confirmButton.textContent = 'Confirm';
        confirmButton.addEventListener('click', async () => {
            const newVaccination = {
                "userVaccinationId": 0,
                "vaccinationDate": dateInput.value,
                "VaccinationId": parseInt(selectElement.value),
                "userId": user.userId
            };
            if (!newVaccination["vaccinationDate"] || !newVaccination["VaccinationId"]) {
                alert('Please fill in all required fields');
                return;
            }
            user.vaccinations.push(newVaccination);
            await UpdateUser(user);
            const dialogContainer = document.getElementById('dialog-container');
            document.body.removeChild(dialogContainer);
        });

        dialogBox.appendChild(closeButton);
        dialogBox.appendChild(title);
        dialogBox.appendChild(dateLabel);
        dialogBox.appendChild(dateInput);
        dialogBox.appendChild(selectElementLabel);
        dialogBox.appendChild(selectElement);
        dialogBox.appendChild(confirmButton);

        dialogContainer.appendChild(dialogBox);

        document.body.appendChild(dialogContainer);
    }
}
//Edit covid19 parameters(recovery and illness dates)
async function EditCovid19(editButton, recoveryDateInput, illnessDateInput,userId) {
    const covid19details = [recoveryDateInput, illnessDateInput]
    covid19details.forEach(input => {
        input.removeAttribute('readonly');
        input.style.border = '1px solid blue';
    });
    editButton.textContent = 'Confirm Changes';
    editButton.style.backgroundColor = 'green';
    editButton.classList.add('confirm-button');
    editButton.removeEventListener('click', EditCovid19);

    editButton.addEventListener('click', async () => {
        const updatedUser = {
            "userId": userId
        }
        covid19details.forEach(input => {
            updatedUser[input.id] = input.value.trim();
        });
        if (updatedUser["recoveryDate"] && !updatedUser["illnessDate"]) {
            alert('Please fill the day with illness');
            return;
        }
        updatedUser["recoveryDate"] == '' ? updatedUser["recoveryDate"] = null : updatedUser["recoveryDate"]=new Date(updatedUser["recoveryDate"]);
        updatedUser["illnessDate"] == '' ? updatedUser["illnessDate"] = null :  updatedUser["illnessDate"]=new Date(updatedUser["illnessDate"]);
        covid19details.forEach(input => {
            input.setAttribute('readonly', true);
            input.style.border = '';
        });

        await UpdateUser(updatedUser);
    });
}

// Show Covid-19 details logic
async function ShowCovid19Details(item, itemContainer, covidarrow) {

    if (itemContainer.querySelector('.covid19details')) {
        itemContainer.querySelector('.covid19details').remove();
        covidarrow.textContent = 'covid19 details▼';

    } else {
        covidarrow.textContent = 'close covid19 details▲';
        const Covid19Details = document.createElement('div');
        Covid19Details.classList.add('covid19details');
        const vaccinations = document.createElement('div');
        for (let index = 0; index < item.vaccinations?.length; index++) {
            const vaccinationDetails = item.vaccinations[index];
            if (vaccinationDetails != null) {
                const vaccination = document.createElement('div');
                vaccination.classList.add('vaccination');
                const vaccinationLabel = document.createElement('label');
                vaccinationLabel.textContent = `vaccination ${index + 1}:`;

                const vaccinationDate = document.createElement('div');
                const vaccinationDateInput = document.createElement('input');
                vaccinationDateInput.type = "date";
                const vaccinationDateLabel = document.createElement('label');
                vaccinationDateLabel.textContent = "Vaccination date: ";
                const vaccinationDateValue = new Date(vaccinationDetails.vaccinationDate);
                vaccinationDateValue.setDate(vaccinationDateValue.getDate() + 1);
                vaccinationDateInput.value = vaccinationDateValue.toISOString().substring(0, 10);
                vaccinationDateInput.setAttribute('readonly', true);
                vaccinationDateInput.id = `vaccinationDate${index}`;
                vaccinationDate.append(vaccinationDateLabel, vaccinationDateInput);

                const vaccinationName = document.createElement('div');

                let selectElement = document.createElement("select");
                const selectElementLabel = document.createElement("label");
                selectElementLabel.textContent = "Choose vaccination:";
                selectElement.required = true;
                let selectedVaccination;
                vaccinationsArr.forEach(vacc => {
                    if (vacc.vaccinationId == vaccinationDetails.vaccinationId) {
                        selectedVaccination = vacc;
                    }
                });
                selectElement.setAttribute('readonly', true);
                var defaultOption = document.createElement("option");
                defaultOption.textContent = selectedVaccination.vaccinationName;
                defaultOption.disabled = true;
                defaultOption.selected = true;
                selectElement.appendChild(defaultOption);

                vaccinationName.append(selectElementLabel, selectElement);

                const editVaccinationButton = document.createElement('button');
                editVaccinationButton.textContent = 'Edit vaccination details';
                editVaccinationButton.classList.add('edit-vaccination-button');
                editVaccinationButton.onclick = () => EditVaccination(item, selectElement, vaccinationDateInput, vaccinationDetails.userVaccinationId, editVaccinationButton);

                const deleteButton = document.createElement('button');
                deleteButton.textContent = 'delete vaccination ';
                deleteButton.classList.add('delete-vaccination-button');
                deleteButton.onclick = async () => await DeleteVaccination(vaccinationDetails.userVaccinationId, item);

                vaccination.append(vaccinationLabel, vaccinationDate, vaccinationName, editVaccinationButton, deleteButton);
                vaccinations.append(vaccination);
            }
        }
        const illnessDate = document.createElement('div');

        const illnessDateInput = document.createElement('input');
        illnessDateInput.type = "date";
        illnessDateInput.classList.add('covid19detailsinput');
        const illnessDateLabel = document.createElement('label');
        illnessDateLabel.textContent = "Illness date: ";
        if (item.illnessDate != null) {
        const illnessDateValue = new Date(item.illnessDate);
        illnessDateValue.setDate(illnessDateValue.getDate() + 1);
        illnessDateInput.value = illnessDateValue.toISOString().substring(0, 10);
        }
        illnessDateInput.setAttribute('readonly', true);
        illnessDateInput.id = 'illnessDate';
        illnessDate.append(illnessDateLabel, illnessDateInput);

        const recoveryDate = document.createElement('div');
        const recoveryDateInput = document.createElement('input');
        recoveryDateInput.type = "date";
        recoveryDateInput.classList.add('covid19detailsinput');
        const recoveryDateLabel = document.createElement('label');
        recoveryDateLabel.textContent = "Recovery date: ";

        if (item.recoveryDate != null) {
        const recoveryDateValue = new Date(item.recoveryDate);
        recoveryDateValue.setDate(recoveryDateValue.getDate() + 1);
        recoveryDateInput.value = recoveryDateValue.toISOString().substring(0, 10);
        }
        recoveryDateInput.setAttribute('readonly', true);
        recoveryDateInput.id = 'recoveryDate';
        recoveryDate.append(recoveryDateLabel, recoveryDateInput);

        Covid19Details.append(vaccinations, illnessDate, recoveryDate);
        const editButton = document.createElement('button');
        editButton.textContent = 'Edit covid19 details';
        editButton.classList.add('edit-covid19-button');
        editButton.addEventListener('click', () => EditCovid19(editButton, recoveryDateInput, illnessDateInput,item.userId));

        const addvaccination = document.createElement('button');
        addvaccination.textContent = 'Add vaccination';
        addvaccination.classList.add('add-vaccination');
        addvaccination.addEventListener('click', () => AddVaccinationDialog(item));

        Covid19Details.append(editButton, addvaccination);
        itemContainer.appendChild(Covid19Details);
    }
}

//Add vaccinatio logic
async function addVaccinationForm() {
    var vaccinationFields = document.getElementById("vaccinationFields");
    // Check if maximum vaccinations reached
    if (vaccinationFields.children.length >= 4) {
        alert("Maximum vaccinations reached (4).");
        return;
    }

    var vaccinationDiv = document.createElement("div");
    vaccinationDiv.classList.add("vaccination-field");
    var vaccinationDateLabel = document.createElement("label");
    vaccinationDateLabel.textContent = "Vaccination Date:";
    var vaccinationDateInput = document.createElement("input");
    vaccinationDateInput.type = "date";
    vaccinationDateInput.classList.add("form-control");
    vaccinationDateInput.required = true;

    var selectElement = document.createElement("select");
    var selectElementLabel = document.createElement("label");
    selectElementLabel.textContent = "Choose vaccination:";
    selectElement.required = true;
    var defaultOption = document.createElement("option");
    defaultOption.value = "";
    defaultOption.textContent = "Select vaccination...";
    defaultOption.disabled = true;
    defaultOption.selected = true;
    selectElement.appendChild(defaultOption);


    vaccinationsArr.forEach(vaccination => {
        const option = document.createElement('option');
        option.value = vaccination.vaccinationId;
        option.textContent = vaccination.vaccinationName;
        selectElement.appendChild(option);
    });
    // Add close button
    var closeButton = document.createElement("button");
    closeButton.textContent = "X";
    closeButton.classList.add("close-button", "btn", "btn-danger");
    closeButton.onclick = () => {
        vaccinationDiv.remove();
    };

    vaccinationDiv.appendChild(vaccinationDateLabel);
    vaccinationDiv.appendChild(vaccinationDateInput);
    vaccinationDiv.appendChild(document.createElement("br"));
    vaccinationDiv.appendChild(selectElementLabel);
    vaccinationDiv.appendChild(document.createElement("br"));
    vaccinationDiv.appendChild(selectElement);
    vaccinationDiv.appendChild(document.createElement("br"));
    vaccinationDiv.appendChild(closeButton);

    vaccinationFields.appendChild(vaccinationDiv);
}
//Display vaccination logic
async function DeleteVaccination(userVaccinationId, item) {
    const index = item.vaccinations.findIndex(v => v.userVaccinationId == userVaccinationId);
    item.vaccinations.splice(index, 1);
    await UpdateUser(item);
}