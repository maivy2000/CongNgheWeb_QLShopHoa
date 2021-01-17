using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAn_BanHoa.Models
{
    public class Product
    {
        public string sMaHoa { get; set; }
        public string sTenHoa { get; set; }
        public string sMaLoai { get; set; }
        public double dGia { get; set; }
        public string sMoTa { get; set; }
        public string sAnh { get; set; }
        public string sMaChuDe { get; set; }

    }
}