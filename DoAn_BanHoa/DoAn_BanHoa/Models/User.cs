using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn_BanHoa.Models
{
    public class User
    {
        //Họ và tên khách
        [Required(ErrorMessage = "Họ và tên không được để trống!")]
        public string Name { get; set; }
        //Tên đăng nhập
        //[Required()]
        public string tenDN { get; set; }
        //Mật khẩu bao gồm nhập lại mật khẩu.
        //[Required()]
        public string matKhau { get; set; }
        //số đt
        //[Required()]
        public string SDT { get; set; }
        //Ngày sinh
        public string ngaySinh { get; set; }
        //Email
        //[Required()]
        public string Email { get; set; }
        //Địa chỉ
        //[Required()]
        public string diaChi { get; set; }

    }
}