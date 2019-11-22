function toggleActiveSideMenuElemet() {
    let selectedItemSideMenu = document.cookie.match(/selectedItemSideMenu=(.*?)$/);
    $('#' + selectedItemSideMenu[1].toString()).children('a').addClass("active");
}

$(document).ready(() => {
    try {
        toggleActiveSideMenuElemet();
    } catch{
    }
});

$('.sideMenuItem>a').click(function (e) {
    $.ajax({
            type: "GET",
            cache: false,
            async: false,
        url: '/home/index',
            data: 'genreName=' + this.parentElement.id,
            success: function (data) {
                if (data != "") {
                    $("body").html(data);
                }
            }
         });
});

$('.pictureFile-input').on('change', function (e) {
    e.preventDefault();
    //var element = document.getElementsByClassName('pictureFile-input')[0];
    var element = $(this)[0];
    var id = element.id;
    var files = element.files;

    if (files.length > 0) {
        if (window.FormData !== undefined) {

            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append("file" + i, files[i]);
                $('.PosterFilePAth')[0].value = id + '.' + files[i].name.toString().substr(files[i].name.length - 3, 3);
            }
            console.log($('.PosterFilePAth2'));

            $.ajax({
                type: "POST",
                url: "/Home/Upload?Id="+this.id,
                contentType: false,
                processData: false,
                data: data,
                success: function (result) {
                    alert(result);
                },
                error: function (xhr, status, p3) {
                    alert(xhr.responseText);
                }
            });
        } else {
            alert("Браузер не поддерживает загрузку файлов HTML5!");
        }
    }
});



