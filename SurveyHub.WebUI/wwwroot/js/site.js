async function GetAllSurveys() {
    $.ajax({
        url: "/Home/GetAllSurveys",
        method: "GET",
        success: function(data) {
            var context = "";
            console.log(data);

            for (var i = 0; i < data.length; i++) {
                context += `
                    <div class="post-container">
                        <img src="https://cdn.discordapp.com/attachments/1070777183326437496/1212130350193573968/no-profile.png?ex=65f0b75b&is=65de425b&hm=dc283c1eec61d2f67e20dce222da1edfade26939627f35f4e16e1a6d5289f181&" alt="Profile" class="profile-image">
                        <div class="post-main">
                            <div class="post-username">${data[i].creator.userName}</div>
                            <div class="post-date">${data[i].publishTime}</div>
                            <div class="post-content">
                                <h5>${data[i].content}?</p>

                                <div class="form-check">
                                  <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                                  <label class="form-check-label" for="flexRadioDefault1">radio1</label>
                                </div>
                                <div class="form-check">
                                  <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2">
                                  <label class="form-check-label" for="flexRadioDefault2">radio1 </label>
                                </div>
                            </div>
                        </div>
                    </div>
                `;
            }

            var id = document.getElementById("surveys-container");
            id.innerHTML = context;
        }
    })
}

GetAllSurveys();