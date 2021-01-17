function DangNhap() {
    var tenDN = $("#TenDN").val();
    var matKhau = $("#MK").val();
    var error = $("#error");
    //Bao loi khi ng dung chua nhap du lieu
    if (tenDN == "") {
        error.text("Tên đăng nhập không được để trống")
        return false;
    }
    if (matKhau == "") {
        error.text("Mật khẩu không được để trống!");
        return false;
    }
    var data = {
        TENDN : tenDN,
        MATKHAU : matKhau,
    };
    $.ajax({
        url: "/NguoiDung/DangNhapAjax/",
        data: JSON.stringify(data),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == 1) {
                $('#iclose').trigger('click');
                location.reload();
            }
            else {
                error.html("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function DangXuat() {
    $.ajax({
        url: "/NguoiDung/DangXuat/",
        data: JSON.stringify(),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == 1)
                location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    
    });
}
function clearTextBox() {
    $.ajax({
        url: "/NguoiDung/clearTextBox/",
        data: JSON.stringify(),
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $("#TenDN").text = "";
            $("#matKhau").text = "";
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}