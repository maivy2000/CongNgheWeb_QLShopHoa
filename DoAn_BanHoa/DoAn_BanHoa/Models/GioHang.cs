using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_BanHoa.Models
{
    public class GioHang
    {
        QuanLyShopHoaDataContext db = new QuanLyShopHoaDataContext();
        public string sMaHoa { get; set; }
        public string sTenHoa { get; set; }
        public string sAnhHoa { get; set; }
        public int iSoLuong { get; set; }
        public double dDonGia { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Khoi tao gio hang
        public GioHang(string MaHoa)
        {
            sMaHoa = MaHoa;
            HOA hoa = db.HOAs.SingleOrDefault(t => t.MAHOA == MaHoa);
            sTenHoa = hoa.TENHOA;
            sAnhHoa = hoa.ANH;
            iSoLuong = 1;
            dDonGia = double.Parse(hoa.GIA.ToString());
        }

    }
}