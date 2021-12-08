using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Library to design metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    [MetadataTypeAttribute(typeof(SanPhamMetadata))]
    public partial class SanPham
    {
        internal sealed class SanPhamMetadata
        {
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Mã Hàng")]
            public int MaHang { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Tên Hàng")]
            public string TenHang { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Mã Nhà Cung Cấp")]
            public Nullable<int> MaNhaCungCap { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Mã Loại Hàng")]
            public Nullable<int> MaLoaiHang { get; set; }

            [Display(Name = "Giá Bán")]
            public Nullable<decimal> GiaBan { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Mã Hàng")]
            public string MoTa { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Hình Ảnh")]
            public string HinhAnh { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Ngày Cập Nhật")]
            public Nullable<System.DateTime> NgayCapNhat { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập dữ liệu.")]
            [Display(Name = "Số Lượng Tồn")]
            public Nullable<int> SoLuongTon { get; set; }
        }
    }
}