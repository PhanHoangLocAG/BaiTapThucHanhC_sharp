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
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
            load_CboDanhMuc();
            load_ListSanPham();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void load_CboDanhMuc()
        {
           List<danhmuc> lst = DAO.Reponsitory.DanhMuc.getAllCategory();
           foreach(var a in lst)
           {
                cboDanhMuc.Items.Add(a);
           }
        }

        public void load_ListSanPham()
        {
            lstSanPham.FullRowSelect = true;
            lstSanPham.GridLines = true;
            lstSanPham.Items.Clear();
            List<sanpham> sp = new List<sanpham>();
            sp = DAO.Reponsitory.SanPham.getAll_SanPham();
            int i = 0;
            foreach (var a in sp)
            {   i++;
                ListViewItem Item = new ListViewItem();
                Item.Text = i + "";
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.tensp });
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.dongia + "" });
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.danhmuc+ "" });
                Item.Tag = a;
                lstSanPham.Items.Add(Item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTen.Text== "")
            {
                MessageBox.Show("Tên sản phẩm không được bỏ trống");
            }
            else if (txtDonGia.Text=="")
            {
                MessageBox.Show("Đơn giá không được bỏ trống");

            }
            else
            {
                try
                {
                    decimal dongia = decimal.Parse(txtDonGia.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đơn giá không hợp lệ");
                    return;
                }

                if(cboDanhMuc.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn chưa chọn danh mục");
                }
                else
                {
                    danhmuc dm = (danhmuc)cboDanhMuc.SelectedItem;
                    sanpham sp = new sanpham();
                    sp.tensp = txtTen.Text;
                    sp.dongia = decimal.Parse(txtDonGia.Text);
                    sp.madm = dm.madm;
                    int check = DAO.Reponsitory.SanPham.create_SanPham(sp);
                    if(check != -1)
                    {
                        load_ListSanPham();
                        
                        MessageBox.Show("Thêm thành công một sản phẩm");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }

        }
    }
}
