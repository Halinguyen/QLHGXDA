$(document).ready(function () {
    var username;
    var password;
    $(document).on('click', '#btnLogin', function () {
        username = $('#inputEmailAddress').val();
        password = $('#inputPassword').val();
        const data = {
            tendangnhap: $('#inputEmailAddress').val(),
            matkhau: $('#inputPassword').val()
        }
        if (username.length == 0 || password.length == 0) {
            alert('Bạn vui lòng nhập đủ dữ liệu !');
            return false;
        }
        else {
            $.ajax({
                url: location.pathname + '/Dangnhap',
                type: 'POST',
                data: data,
            }).done(function (res) {
                switch (res) {
                    case "True1":
                        window.location.href = "QLKhudexe/Index";
                        break;
                    case "True2":
                        window.location.href = "QLXe/Index";
                        break;
                    case "True3":
                        window.location.href = "QLXeravao/Index";
                        break;
                    case "Sai":
                        alert('Sai tên đăng nhập hoặc mật khẩu :(');
                        break;
                }
            });
        }

    });
});