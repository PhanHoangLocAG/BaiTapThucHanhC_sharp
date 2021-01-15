using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh.View
{
    public partial class DanhMuc : Form
    {
        private string madm = "";
        public DanhMuc()
        {
            InitializeComponent();
            load_DanhMuc();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lstDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public void load_DanhMuc()
        {
            lstDanhMuc.FullRowSelect = true;
            lstDanhMuc.GridLines =  true;
            lstDanhMuc.Items.Clear();
            var list = DAO.Reponsitory.DanhMuc.getAllCategory();
            if(list != null)
            {
                int i = 0;
                foreach(var a in list)
                {
                    i++;
                    ListViewItem Item = new ListViewItem();
                    Item.Text = i+"";
                    Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.madm });
                    Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.tendm });
                    Item.Tag = a;
                    lstDanhMuc.Items.Add(Item);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string madm = txtMaDanhMuc.Text;
            string tendm = txtTenDanhMuc.Text;
            if(madm == "" || madm.Length >5)
            {
                MessageBox.Show("Mã danh mục không được bỏ trống và không được lớn hơn 5 kí tự");
                return;
            }
            if (tendm == "" || tendm.Length > 50)
            {
                MessageBox.Show("Tên danh mục không được bỏ trống và không được lớn hơn 50 kí tự");
                return;
            }
            

            int check = DAO.Reponsitory.DanhMuc.create_DanhMuc(madm, tendm);

            if(check != -1)
            {
                load_DanhMuc();
                MessageBox.Show("Thêm thành công một danh mục mới ");
            }
            else
            {
                MessageBox.Show("Thêm thất bại ");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.madm.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần xóa từ danh sách");
            }
            else
            {
                int check = DAO.Reponsitory.DanhMuc.delete_DanhMuc(this.madm);
                if (check != -1)
                {
                    load_DanhMuc();
                    this.madm = "";
                    MessageBox.Show("Xóa thành công ");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại ");
                }
            }
        }

        private void lstDanhMuc_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            danhmuc t = (danhmuc)e.Item.Tag;
            txtMaDanhMuc.Text = t.madm;
            txtTenDanhMuc.Text = t.tendm;
            this.madm = t.madm;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (this.madm.Equals(""))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần xóa từ danh sách");
            }
            else if (this.madm != txtMaDanhMuc.Text)
            {
                MessageBox.Show("Không được đổi tên mã danh mục");
            }
            else
            {
                int check = DAO.Reponsitory.DanhMuc.update_DanhMuc(this.madm, txtTenDanhMuc.Text);
                if (check != -1)
                {
                    load_DanhMuc();
                    this.madm = "";
                    MessageBox.Show("Sửa thành công ");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại ");
                }
            }
        }
    }
}
