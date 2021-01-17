using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_BanHoa.Models;
namespace DoAn_BanHoa.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QuanLyShopHoaDataContext db = new QuanLyShopHoaDataContext();
        public ActionResult Index()
        {
            return View();
        }
        //Lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Neu lstGioHang chua ton tai thi khoi tao
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(string maHoa, string strURL)
        {
            //Lay ra gio hang
            List<GioHang> lstGioHang = LayGioHang();
            //Kiem tra xem hoa nay da ton tai trong gio hang hay chua?
            GioHang spHoa = lstGioHang.Find(s => s.sMaHoa == maHoa);
            if (spHoa == null)
            {
                spHoa = new GioHang(maHoa);
                lstGioHang.Add(spHoa);
                return Redirect(strURL);
            }
            else //Nguoc lai da co san pham nay trong gio hang, thi minh tang so luong len.
            {
                spHoa.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Tỉnh tổng số lượng trong giỏ hàng
        private int TongSoLuong()
        {
            int tongSL = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tongSL = lstGioHang.Sum(sp => sp.iSoLuong);
            }
            return tongSL;
        }
        //Tính tổng thành tiền
        private double TongThanhTien()
        {
            double tongTT = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tongTT = lstGioHang.Sum(sp => sp.dThanhTien);
            }
            return tongTT;
        }
        //Sau đó xây dựng trang giỏ hàng, sử dụng ViewBag để lưu thông tin tính tổng số lượng.
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("SanPham", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }
        //Thêm cột delete cho phép xóa 1 sản phẩm trong giỏ hàng.
        public ActionResult XoaGioHang(string MaSP)
        {
            //Lay gio hang
            List<GioHang> lstGioHang = LayGioHang();
            //Kiem tra xem hoa can xoa co trong gio hang hay ko?
            GioHang sp = lstGioHang.Single(t => t.sMaHoa == MaSP);
            if (sp != null)
            {
                lstGioHang.RemoveAll(s => s.sMaHoa == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }

            //Neu gio hang rong
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("GioHangRong", "Home"); // return index1 thong bao gio hang rong/
            }
            //Neu con san pham thi return lai gio hang.
            
            return RedirectToAction("GioHang", "GioHang");
        }
        //Update giỏ hàng => La update lai gio hang khi user chinh sua so luong.
        public ActionResult CapNhatGioHang(string MaSP, FormCollection f)
        {
            //Lay Gio Hang
            List<GioHang> lstGioHang = LayGioHang();
            //Kiem tra hoa cap nhat co trong gio hang hay ko?
            GioHang sp = lstGioHang.Single(s => s.sMaHoa == MaSP);
            if (sp != null) //la co san pham trong gio hang, ta update
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        //Xóa hết sản phẩm ở giỏ hàng
        public ActionResult DeleteAllSP()
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("GioHangRong", "Home");//Tro lai trang chu Hoa, hoac idea them la xuat ra thong bao + btn quay ve trang chu.
        }
        //Viết chức năng thanh toán
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["taiKhoan"] == null || Session["taiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Lay gio hang tu session
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lstGioHang);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            DONHANG ddh = new DONHANG();
            TAIKHOAN kh = (TAIKHOAN)Session["taiKhoan"];
            List<GioHang> gh = LayGioHang();
            ddh.MAKH = kh.MAKH;
            ddh.NGAYDAT = DateTime.Now;
            
            var NgayGiao = String.Format("{0:dd/mm/yyyy}", f["Ngaygiao"]);
            //if (ddh.NGAYGIAO == null)
            //{
            //    ViewBag.loi = "Vui lòng nhập ngày giao hàng!";
            //    return View();
            //}
                ddh.NGAYGIAO = DateTime.Parse(NgayGiao);
                ddh.DATHANHTOAN = "Chưa Thanh Toán";
                ddh.TINHTRANGGIAOHANG = "0";
                db.DONHANGs.InsertOnSubmit(ddh);
                db.SubmitChanges();
                //Thêm chi tiết đơn hàng
                foreach (var item in gh)
                {
                    CTDONHANG ctdh = new CTDONHANG();
                    ctdh.MADONHANG = ddh.MADONHANG;
                    ctdh.MAHOA = item.sMaHoa;
                    ctdh.SOLUONG = item.iSoLuong;
                    ctdh.DONGIA = (decimal)item.dDonGia;

                    db.CTDONHANGs.InsertOnSubmit(ctdh);
                }
                db.SubmitChanges();
                Session["GioHang"] = null;
            

            return RedirectToAction("XacNhanDonHang", "GioHang");

        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }


    }
}
