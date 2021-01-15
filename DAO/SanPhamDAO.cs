using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiThucHanh.DAO
{
    public sealed class SanPhamDAO
    {
        private static SanPhamDAO san_pham;

        public SanPhamDAO()
        {
        }

        public static SanPhamDAO Instance {
            get 
            {
                if (san_pham == null)
                    san_pham = new SanPhamDAO();
                return san_pham;
            }
            set => san_pham = value; 
        }

        public int create_SanPham(sanpham sp)
        {
            db_csharpEntities t = new db_csharpEntities();
            t.sanphams.Add(sp);

            try
            {
                return t.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int update_SanPham(sanpham sp)
        {
            db_csharpEntities t = new db_csharpEntities();
            sanpham sp1 = t.sanphams.Find(sp.masp);
            sp1.tensp = sp.tensp;
            sp1.madm = sp.madm;
            sp1.dongia = sp.dongia;
            try
            {
                return t.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int delete_SanPham(int masp)
        {
            db_csharpEntities t = new db_csharpEntities();
            var sp = t.sanphams.Find(masp);
            t.sanphams.Remove(sp);
            try
            {
                return t.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public List<sanpham> getAll_SanPham()
        {
            db_csharpEntities t = new db_csharpEntities();
            var lst = (from sp in t.sanphams
                       join dm in t.danhmucs on sp.madm equals dm.madm 
                       select new {sp.masp,sp.tensp,sp.dongia,sp.danhmuc}
                       ).ToList();
            List<sanpham> lstsp = new List<sanpham>();
            foreach(var a in lst)
            {
                sanpham sp = new sanpham();
                sp.masp = a.masp;
                sp.tensp = a.tensp;
                sp.dongia = a.dongia;
                sp.danhmuc = a.danhmuc;
                lstsp.Add(sp);
            }
            return lstsp;
        }
    }
}
