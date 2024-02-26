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
                        <img src="https://cdn.discordapp.com/attachments/1070777183326437496/1204892132142358548/cdm.png?ex=65e8d73e&is=65d6623e&hm=d2a8a3ce1081d0f91413c2fc2026664da6d60d200a64651219cf888aca8629ba&" alt="Profile" class="profile-image">
                        <div class="post-main">
                            <div class="post-username">${data[i].creator.userName}</div>
                            <div class="post-date">${data[i].publishTime}</div>
                            <div class="post-content">
                                <p>survey</p>
                            </div>
                        </div>
                    </div>
                `;
            }

            var id = document.getElementsByClassName("surveys-container");
            id.innerHTML = context;
        }
    })
}

GetAllSurveys();