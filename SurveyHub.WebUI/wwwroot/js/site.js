async function GetAllSurveys() {
    $.ajax({
        url: "/Home/GetAllSurveys",
        method: "GET",
        success: function (data) {
            var surveyContext = "";

            for (var i = 0; i < data.surveys.length; i++) {
                surveyContext += `
                    <div class="survey-container">
                        <img src="https://cdn.discordapp.com/attachments/1070777183326437496/1212130350193573968/no-profile.png?ex=65f0b75b&is=65de425b&hm=dc283c1eec61d2f67e20dce222da1edfade26939627f35f4e16e1a6d5289f181&" alt="Profile" class="profile-image">
                        <div class="survey-main">
                            <div class="survey-username">${data.surveys[i].creator.userName}</div>
                            <div class="survey-date">${data.surveys[i].publishTime}</div>
                            <div class="survey-content">
                                <h5>${data.surveys[i].content}</h5>
                                <div class="options-container" id="options-${data.surveys[i].id}"></div>
                            </div>
                        </div>
                    </div>
                `;
            }

            var id = document.getElementById("surveys-container");
            id.innerHTML = surveyContext;

            for (var i = 0; i < data.options.length; i++) {
                var optionsContext = "";
                var options = data.options.filter(option => option.surveyId === data.surveys[i].id);

                for (var j = 0; j < options.length; j++) {
                    var isChecked = false;
                    for (var k = 0; k < data.userResponses.length; k++) {
                        if (data.userResponses[k].optionId === options[j].id) {
                            isChecked = true;
                            break;
                        }
                    }

                    optionsContext += `
                        <div class="form-check">
                            <input class="form-check-input" type="radio" name="survey-radio${data.surveys[i].id}" key="${options[j].id}" onclick="saveResponse(${data.surveys[i].id}, ${options[j].id})" ${isChecked ? 'checked' : ''}>
                            <label class="form-check-label" for="survey-radio${data.surveys[i].id}">${options[j].text}</label>
                        </div>
                    `;
                }

                var surveyOptionsContainer = document.getElementById(`options-${data.surveys[i].id}`);
                surveyOptionsContainer.innerHTML = optionsContext;
            }
        }
    })
}

async function saveResponse(surveyId, optionId) {
    $.ajax({
        url: "/Home/SaveResponse",
        method: "POST",
        data: {
            surveyId: surveyId,
            optionId: optionId
        },
        success: function (response) {
            console.log(response);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

$(document).ready(function () {
    GetAllSurveys();

    $(".add-option-button").click(function () {
        var newOptionInput = '<div class="option-input"><input type="text" name="options[]" placeholder="enter option" required><button type="button" class="remove-option-button">-</button></div>';
        $("#add-survey-options-container").append(newOptionInput);
    });

    $(document).on("click", ".remove-option-button", function () {
        $(this).closest(".option-input").remove();
    });

    $("#add-survey-form").submit(function (event) {
        event.preventDefault();

        var formData = $(this).serialize();

        $.ajax({
            url: "/Home/AddSurvey",
            method: "POST",
            data: formData,
            success: function (response) {
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    });
});