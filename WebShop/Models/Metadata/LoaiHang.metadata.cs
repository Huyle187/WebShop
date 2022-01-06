using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    [MetadataTypeAttribute(typeof(LoaiHangMetadata))]
    public partial class LoaiHang
    {
        internal sealed class LoaiHangMetadata
        {
            [Display(Name = "Mã Loại Hàng")]
            public int MaLoaiHang { get; set; }

            [Display(Name = "Tên Loại Hàng")]
            public string TenLoaiHang { get; set; }
        }
    }
}