using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiThucHanh.DAO
{
    public sealed class DanhMucDAO
    {
        private static DanhMucDAO danh_muc;

        private DanhMucDAO()
        {
        }

        public static DanhMucDAO Instance { 
            get 
            {
                if (danh_muc == null)
                    danh_muc = new DanhMucDAO();
                return danh_muc;
            }
            set => danh_muc = value;
        }

        public int create_DanhMuc(string madm ,string tendm )
        {
            db_csharpEntities t = new db_csharpEntities();
            danhmuc dm = new danhmuc();
            dm.madm = madm;
            dm.tendm = tendm;
            dm.trangthai = true;
            t.danhmucs.Add(dm);
            try
            {
                return t.SaveChanges();
                
            }
            catch (Exception ex)
            {
                return -1;
            }
           
        }

        public int update_DanhMuc(string madm, string tendm)
        {
            db_csharpEntities t = new db_csharpEntities();
            danhmuc dm = t.danhmucs.Find(madm);
            dm.tendm = tendm;
            try
            {
                return t.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public int delete_DanhMuc(string madm)
        {
            db_csharpEntities t = new db_csharpEntities();
            danhmuc dm = t.danhmucs.Find(madm);
            dm.trangthai = false;
            try
            {
                return t.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public List<danhmuc> getAllCategory()
        {
            db_csharpEntities t = new db_csharpEntities();
            var lst = t.danhmucs.Where(d => d.trangthai == true).ToList();
            return lst;
        }
    }

      
}
