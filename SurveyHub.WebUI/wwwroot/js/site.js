﻿async function GetAllSurveys() {
    $.ajax({
        url: "/Home/GetAllSurveys",
        method: "GET",
        success: function (data) {
            var isAdmin = document.getElementById("user-info").getAttribute("is-admin");
            var surveyContext = "";

            for (var i = 0; i < data.surveys.length; i++) {
                surveyContext += `
                    <div class="survey-container" key="${data.surveys[i].id}">
                        <a href="/Account/Profile?userId=${data.surveys[i].creator.id}">
                            <img src="/images/users/${data.surveys[i].creator.imageUrl}" alt="${data.surveys[i].creator.userName}" class="profile-image">
                        </a>
                        <div class="survey-main">
                `;

                if (isAdmin === "is-admin") {
                    surveyContext += `<i class="delete-survey fa fa-trash" onclick="deleteSurvey(${data.surveys[i].id})"></i>`
                }

                surveyContext += `
                        <div class="survey-username">${data.surveys[i].creator.userName}</div>
                        <div class="survey-date">${data.surveys[i].publishTime}</div>
                        <div class="survey-content">
                            <h5>${data.surveys[i].content}</h5>
                            <span class="survey-category category-${data.surveys[i].category}">${data.surveys[i].category}</span>
                            <div class="options-container" id="options-${data.surveys[i].id}"></div>
                        </div>
                    </div>
                </div>`
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

                    var optionVotesCount = 0;
                    for (var k = 0; k < data.responses.length; k++) {
                        if (data.responses[k].optionId === options[j].id) {
                            optionVotesCount++;
                        }
                    }

                    optionsContext += `
                        <div class="form-check">
                            <input class="form-check-input" type="radio" name="survey-radio${data.surveys[i].id}" key="${options[j].id}" onclick="saveResponse(${data.surveys[i].id}, ${options[j].id})" ${isChecked ? 'checked' : ''}>
                            <label class="form-check-label" for="survey-radio${data.surveys[i].id}">${options[j].text}</label>
                            <span class="option-votes-count">(${optionVotesCount} votes)</span>
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
            GetAllSurveys();
            console.log(response);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

async function deleteSurvey(surveyId) {
    $.ajax({
        url: "/Admin/DeleteSurvey",
        method: "GET",
        data: {
            surveyId: surveyId
        },
        success: function (response) {
            GetAllSurveys();
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

    $(document).on("click", ".profile-avatar", function () {
        $('.profile-image input[type="file"]').click();
    });
});