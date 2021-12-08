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
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Mã Nhà Cung Cấp")]
            public int MaNhaCungCap { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Nhà Cung Cấp")]
            public string TenNhaCungCap { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Địa chỉ")]
            public string DiaChi { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Điện thoại")]
            public string DienThoai { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }
    }
}