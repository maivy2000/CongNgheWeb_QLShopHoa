using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_BanHoa.Models;
using PagedList;
namespace DoAn_BanHoa.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QuanLyShopHoaDataContext db = new QuanLyShopHoaDataContext();
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult SanPham()
        //{
        //    var listHoa = db.HOAs.ToList();
        //    ViewBag.sp = "DANH SÁCH TẤT CẢ SẢN PHẨM";
        //    return View(listHoa);
        //}

        public ActionResult SanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.sp = "DANH SÁCH TẤT CẢ SẢN PHẨM";
            var listHoa = db.HOAs.OrderBy(sp => sp.TENHOA).ToPagedList(pageNumber, pageSize);
            return View(listHoa);
        }

        //Viết cho giỏ hàng còn trống
        public ActionResult GioHangRong()
        {
            return View();
        }
        public ActionResult DSMenu_LoaiHoa()
        {
            List<LOAIHOA> loaiHoa = db.LOAIHOAs.ToList();
            return PartialView(loaiHoa);
        }
        //Sort theo danh sach cac loai hoa
        //
        public ActionResult HTTheoLoaiHoa(string lh)
        {
            List<HOA> htHoa = db.HOAs.Where(s => s.MALOAI == lh).ToList();
            ViewBag.loaiHoa = (db.LOAIHOAs.Where(q => q.MALOAI == lh).FirstOrDefault()).TENLOAI;
            return View( htHoa);

        }
        // lam thanh menu ben trai theo chu de hoa
        public ActionResult DSMenu_ChuDe()
        {
            List<CHUDE> chuDe = db.CHUDEs.ToList();
            return PartialView(chuDe);
        }
        //Sort theo danh sach chu de 
        public ActionResult HTTheoChuDe(string mcd)
        {
            List<HOA> htCD = db.HOAs.Where(s => s.MACHUDE == mcd).ToList();
            ViewBag.chuDe = (db.CHUDEs.Where(t =>t.MACHUDE == mcd).FirstOrDefault()).TENCHUDE;
            return View(htCD);
        }
        public ActionResult ChiTiet(string mh)
        {
            HOA hoa = db.HOAs.SingleOrDefault(t => t.MAHOA == mh.ToString());
            //Dành cho slides active
            var hoaSlide1 = db.HOAs.OrderByDescending(t => t.MALOAI).Take(6).ToList();
            ViewBag.slide1 = hoaSlide1;
            //Danh cho slide 2
            var hoaSlide2 = db.HOAs.OrderBy(t => t.TENHOA).Take(6).ToList();
            ViewBag.slide2 = hoaSlide2;
            //Dành cho slide 3
            var hoaSlide3 = db.HOAs.OrderBy(t => t.MACHUDE).Take(6).ToList();
            ViewBag.slide3 = hoaSlide3;
            return View(hoa);
        }
        //Viet ham dropdow cac loai hoa.
        public ActionResult DSDrop_LoaiHoa()
        {
            List<LOAIHOA> dropLoaiHoa = db.LOAIHOAs.ToList();
            return PartialView(dropLoaiHoa);
        }
        public ActionResult DSDrop_ChuDeHoa()
        {
            List<CHUDE> dropChuDe = db.CHUDEs.ToList();
            return PartialView(dropChuDe);
        }
        //Viet ham tim kiem san pham theo ten hoa
        //[HttpGet]
        //public ActionResult Search(string tenHoa)
        //{
        //    var listHoa = db.HOAs.ToList();
        //    //List<HOA> listHoa = db.HOAs.Where(t => t.TENHOA == tenHoa).ToList();
        //    return View(listHoa);
        //}
        [HttpPost]
        public ActionResult Search(FormCollection c)
        {
            string search = c["txtTimKiem"];
            List<HOA> listHoa = db.HOAs.Where(s => s.TENHOA.Contains(search)).ToList();
            if (listHoa.Count() == 0)
            {
                return RedirectToAction("TimKiemRong", "Home");
            }
            ViewBag.tb = "DANH SÁCH SẢN PHẨM TÌM ĐƯỢC";

            return View(listHoa);
        }
        //Viet trang tim kiem rong 
        public ActionResult TimKiemRong()
        {
            return View();
        }

    }
}
