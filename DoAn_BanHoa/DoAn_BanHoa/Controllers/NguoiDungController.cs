using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_BanHoa.Models;
namespace DoAn_BanHoa.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        QuanLyShopHoaDataContext db = new QuanLyShopHoaDataContext();
        public ActionResult Index()
        {
            return View();
        }
        //Đăng ký, đăng nhập
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string tenDN = f["txtTenDN"];
            string matKhau = f["txtMatKhau"];
            TAIKHOAN taiKhoan = db.TAIKHOANs.SingleOrDefault(tk => tk.TENDN == tenDN && tk.MATKHAU == matKhau);
            //La user nhap tk mk chinh xac
            if (taiKhoan != null && taiKhoan.QUYEN == true)
            {
                //ViewBag.tb = "Đăng nhập tài khoản thành công!";
                Session["kh"] = taiKhoan.HOTEN;
                //return RedirectToAction("Index", "Product");
                Session["taiKhoan"] = taiKhoan;
                return RedirectToAction("SanPhamAdmin", "Product");
            }
            if (taiKhoan != null && taiKhoan.QUYEN == false)
            {
                Session["kh"] = taiKhoan.HOTEN;
                Session["taiKhoan"] = taiKhoan;
                return RedirectToAction("SanPham", "Home");
            }
            //ko dc rong~
            if (tenDN == string.Empty) //Thông tin đăng nhập sai bét.
            {
                ViewData["Loi1"] = "Tên đăng nhập không được bỏ trống!";

            }
            if (matKhau == string.Empty)
            {
                ViewData["Loi2"] = "Mật khẩu không được bỏ trống!";
            }
            if (!String.IsNullOrEmpty(tenDN) || !String.IsNullOrEmpty(matKhau))
            {
                ViewBag.tb = "Sai tên tài khoản hoặc mật khẩu";
            }
            return View();
        }
    
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        //Viet ham dang ky
        [HttpPost]
        public ActionResult DangKy(TAIKHOAN kh, FormCollection f)
        {
            //bool flag = true;
            var hoten = f["txtHoTen"];
            var tendn = f["txtTenDN"];
            var matkhau = f["txtMatKhau"];
            var rematkhau = f["txtReMatKhau"];
            var dienthoai = f["txtDienThoai"];
            var ngaysinh = String.Format("{0:MM/DD/YYYY}", f["txtNgaySinh"]);
            var email = f["txtEmail"];
            var diachi = f["txtDiaChi"];
            //Kiem tra ten dang nhap

            bool ktraTenDN = db.TAIKHOANs.Where(t => t.TENDN == tendn).Count() > 0;
            if (ktraTenDN)
            {
                ViewBag.loi = "Đã tồn tại tên đăng nhập này!";
                //flag = true;
                return View();
            }
            //Kiem tra email co ton tai chua
            bool ktraEmail = db.TAIKHOANs.Where(t => t.EMAIL == email).Count() > 0;
            if (ktraEmail)
            {
                ViewBag.email = "Đã tồn tại tài khoản Email này!";
                //flag = true;
                return View();
            }
            if (hoten == string.Empty)
            {
                ViewData["Loi1"] = "Họ tên không được bỏ trống";
            }
            if (tendn == string.Empty)
            {
                ViewData["Loi2"] = "Tên đăng nhập không được bỏ trống";
            }
            if (matkhau == string.Empty || rematkhau == string.Empty)
            {
                ViewData["Loi3"] = "Vui lòng nhập mật khẩu";
            }
            if (dienthoai == string.Empty)
            {
                ViewData["Loi4"] = "Vui lòng nhập sdt";
            }
            else
            {
                TAIKHOAN newKH = new TAIKHOAN();
                newKH.HOTEN = hoten;
                newKH.TENDN = tendn;
                newKH.MATKHAU = matkhau;
                newKH.SDT = dienthoai;
                if (ngaysinh == null)
                {
                    ViewBag.tb = "Vui lòng nhập ngày sinh";
                    return View();
                }
                else
                {
                    newKH.NGAYSINH = DateTime.Parse(ngaysinh);
                }

                newKH.EMAIL = email;
                newKH.DIACHI = diachi;
                newKH.QUYEN = false;
                db.TAIKHOANs.InsertOnSubmit(newKH);
                db.SubmitChanges();
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        //Test Dang Nhap Ajax
    //    public ActionResult DangNhapAjaxPartial()
    //    {
    //        //TAIKHOAN kh = Session["taiKhoan"] as TAIKHOAN;
    //        return PartialView();
    //    }
    //    [HttpPost]
    //    public ActionResult DangNhapAjax(TAIKHOAN kh)
    //    {
    //        int kq = 1;
    //        try
    //        {
    //            TAIKHOAN taiKhoan = db.TAIKHOANs.SingleOrDefault(tk => tk.TENDN == kh.TENDN && tk.MATKHAU == kh.MATKHAU);
    //            if (taiKhoan != null)
    //            {
    //                Session["taiKhoan"] = taiKhoan;
    //                return Json(kq, JsonRequestBehavior.AllowGet);
    //            }
    //        }
    //        catch
    //        {
    //            kq = 0;
    //        }
    //        return Json(kq, JsonRequestBehavior.AllowGet);
    //    }

    //    public ActionResult DangXuat()
    //    {
    //        Session["taiKhoan"] = null;
    //        int kq = 1;
    //        try
    //        {
    //        }
    //        catch
    //        {
    //            kq = 0;
    //        }
    //        return Json(kq, JsonRequestBehavior.AllowGet);
    //    }
    //    public ActionResult clearTextBox()
    //    {
    //        int kq = 1;
    //        try
    //        {
    //        }
    //        catch
    //        {
    //        }
    //        return Json(kq,JsonRequestBehavior.AllowGet);
    //    }
        

    }
}
