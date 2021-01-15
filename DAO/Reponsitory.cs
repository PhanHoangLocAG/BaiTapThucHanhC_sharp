using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiThucHanh.DAO
{
    public sealed class Reponsitory
    {
        private static DanhMucDAO _danhMuc = DanhMucDAO.Instance;

        private static SanPhamDAO _sanPham = SanPhamDAO.Instance;
        public Reponsitory()
        {
        }

        public static DanhMucDAO DanhMuc { get => _danhMuc; set => _danhMuc = value; }
        public static SanPhamDAO SanPham { get => _sanPham; set => _sanPham = value; }
    }
}
