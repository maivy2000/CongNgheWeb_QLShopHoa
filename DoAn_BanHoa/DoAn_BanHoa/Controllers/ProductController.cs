using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_BanHoa.Models;
using PagedList;
namespace DoAn_BanHoa.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        QuanLyShopHoaDataContext db = new QuanLyShopHoaDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            var dsHoa = db.HOAs.ToList();
            return View(dsHoa);
        }
        //Danh sách thành viên.
        public ActionResult ThanhVien()
        {
            var thanhVien = db.TAIKHOANs.Where(t => t.QUYEN == false).ToList();
            if (thanhVien.Count() == 0)
            {
                return RedirectToAction("ThanhVienRong", "Product");
            }
            ViewBag.tv = thanhVien.Count();
            return View(thanhVien);
        }
        public ActionResult ThanhVienRong()
        {
            return View();
        }
        public ActionResult DSThanhVien()
        {
            return PartialView();
        }
        public ActionResult XoaKhachHang(int maKH)
        {
            var kh = db.TAIKHOANs.SingleOrDefault(t => t.MAKH == maKH);
            if (kh == null)
            {
                return View();
            }
            db.TAIKHOANs.DeleteOnSubmit(kh);
            db.SubmitChanges();
            return RedirectToAction("ThanhVien", "Product");
        }
        [HttpGet]
        public ActionResult SuaKhachHang(int maKH)
        {
            TAIKHOAN ma = db.TAIKHOANs.SingleOrDefault(t => t.MAKH ==maKH);
            return View(ma);
        }
        [HttpPost]
        public ActionResult SuaKhachHang(TAIKHOAN kh,int maKH, FormCollection f)
        {
            string matKhau = f["txtMatKhau"];
            TAIKHOAN kh1 = db.TAIKHOANs.SingleOrDefault(sp => sp.MAKH == maKH);
            //bool checkTenDN = db.TAIKHOANs.Where(t => t.TENDN == kh.TENDN).Count() > 0;
            //if (checkTenDN)
            //{
            //    ViewBag.tb = "Đã tồn tại tên đăng nhập này. Sửa không thành công!";
            //    return View();
            //}
                kh1.HOTEN = kh.HOTEN;
                kh1.TENDN = kh.TENDN;
                kh1.MATKHAU = matKhau;
                db.SubmitChanges();
           
            return RedirectToAction("ThanhVien", "Product");
        }
        //
        private static bool checkMa(int ma)
        {
            using (QuanLyShopHoaDataContext db = new QuanLyShopHoaDataContext())
            {
                bool kTraMaHoa = db.HOAs.Where(s => ma == Convert.ToInt32(s.MAHOA.Substring(2))).Count() > 0;
                if (kTraMaHoa)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool checkLoaiHoa(string ma)
        {
            using (QuanLyShopHoaDataContext db = new QuanLyShopHoaDataContext())
            {
                bool kTraMaLoai = db.LOAIHOAs.Where(s => ma == s.MALOAI.Substring(2)).Count() > 0;
                if (kTraMaLoai)
                {
                    return false;
                }
            }
            return true;

        }
        [HttpGet]
        public ActionResult ThemSanPham()
        {
            ViewBag.loaiHoa = new SelectList(db.LOAIHOAs.ToList(), "MALOAI", "TENLOAI");
            ViewBag.chuDe = new SelectList(db.CHUDEs.ToList(), "MACHUDE", "TENCHUDE");
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham(HOA hoa, HttpPostedFileBase fup)
        {
            //Làm stt Hoa tự động tăng
            int countHoa = 1;
            while (!checkMa(countHoa))
            {
                countHoa += 1;
            }
            string ma = "";
            if (countHoa >= 100)
            {
                ma = "MH" + countHoa;
            }
            else if (countHoa >= 10)
            {
                ma = "MH0" + countHoa;
            }
            else
            {
                ma = "MH00" + countHoa;
            }
            //
            if (fup == null)
            {
                return View();
            }
            else
            {
                hoa.MAHOA = ma;
                hoa.ANH = fup.FileName;
                fup.SaveAs(Server.MapPath("~/Content/AlbumHoa/" + fup.FileName));
                db.HOAs.InsertOnSubmit(hoa);
                db.SubmitChanges();
            }

            return RedirectToAction("SanPhamAdmin", "Product");
        }

        //Sửa sản phẩm
        [HttpGet]
        public ActionResult SuaSanPham(string maHoa)
        {
            HOA spHoa = db.HOAs.SingleOrDefault(sp => sp.MAHOA == maHoa);
            ViewBag.chuDe = new SelectList(db.CHUDEs.ToList(), "MACHUDE", "TENCHUDE");
            ViewBag.loaiHoa = new SelectList(db.LOAIHOAs.ToList(), "MALOAI", "TENLOAI");
            return View(spHoa);
        }
        [HttpPost]
        public ActionResult SuaSanPham(HOA hoa, HttpPostedFileBase fup, string maHoa)
        {
            HOA spHoa = db.HOAs.SingleOrDefault(sp => sp.MAHOA == maHoa);

            if (fup == null)
            {
                return View();
            }
            else
            {
                spHoa.TENHOA = hoa.TENHOA;
                spHoa.GIA = Convert.ToDecimal(hoa.GIA);
                spHoa.MOTA = hoa.MOTA;
                spHoa.MACHUDE = hoa.MACHUDE;
                spHoa.MALOAI = hoa.MALOAI;
                hoa.ANH = fup.FileName;
                fup.SaveAs(Server.MapPath("~/Content/AlbumHoa/" + fup.FileName));
                db.SubmitChanges();
            }
            return RedirectToAction("SanPhamAdmin", "Product");
        }
        //Danh sach san pham
        //public ActionResult SanPhamAdmin()
        //{
        //    var listHoa = db.HOAs.ToList();
        //    ViewBag.sp = "DANH SÁCH TẤT CẢ SẢN PHẨM";
        //    return View(listHoa);
        //}
        public ActionResult SanPhamAdmin(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.sp = "DANH SÁCH TẤT CẢ SẢN PHẨM";
            var listHoa = db.HOAs.OrderBy(sp => sp.TENHOA).ToPagedList(pageNumber, pageSize);
            return View(listHoa);
        }
        public ActionResult SanPhamPartial()
        {
            return PartialView();
        }
        //Xóa sản phẩm

        public ActionResult XoaSanPham(string maHoa)
        {
            var hoa = db.HOAs.SingleOrDefault(sp => sp.MAHOA == maHoa);
            if (hoa == null)
            {
                return View();
            }
            db.HOAs.DeleteOnSubmit(hoa);
            db.SubmitChanges();
            return RedirectToAction("SanPhamAdmin", "Product");
        }
        public ActionResult HTTheoLoaiHoa(string maLoai)
        {
            List<HOA> dsHoa = db.HOAs.Where(t => t.MALOAI == maLoai).ToList();
            //HOA spHoa = db.HOAs.Single(t => t.MALOAI == maLoai);
            return View("Index", dsHoa);
        }
        public ActionResult DSMenu_LoaiHoa()
        {
            List<LOAIHOA> loaiHoa = db.LOAIHOAs.ToList();
            return PartialView(loaiHoa);
        }
        //XEM DANH SÁCH HÓA ĐƠN
        //public ActionResult DSDonHang()
        //{
        //    var listHD = db.DONHANGs.ToList();
        //    ViewBag.tenkh = (db.TAIKHOANs.Where(t =>t.MAKH == mcd).FirstOrDefault()).TENCHUDE
        //    return View();
        //}


    }
}
