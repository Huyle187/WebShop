using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    [MetadataTypeAttribute(typeof(NhaCungCapMetadata))]
    public partial class NhaCungCap
    {
        internal sealed class NhaCungCapMetadata
        {
            [Display(Name = "Mã Nhà Cung Cấp")]
            public int MaNhaCungCap { get; set; }

            [Display(Name = "Nhà Cung Cấp")]
            public string TenNhaCungCap { get; set; }

            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }

            [Display(Name = "Điện thoại")]
            public string DienThoai { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }
        }
    }
}