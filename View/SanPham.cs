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
        private int masp = -1 ;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(this.masp == -1)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm muốn xóa");
            }
            else
            {
                int check = DAO.SanPhamDAO.Instance.delete_SanPham(this.masp);

                if(check != -1)
                {
                    this.masp = -1;
                    load_ListSanPham();
                    MessageBox.Show("Xóa thành công một sản phẩm");

                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void lstSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstSanPham_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            sanpham t = (sanpham)e.Item.Tag;
            this.masp = t.masp;
            txtDonGia.Text = t.dongia + "";
            txtTen.Text = t.tensp;
            for(int i = 0; i < cboDanhMuc.Items.Count ; i++)
            {
                danhmuc a = (danhmuc)cboDanhMuc.Items[i];
                if (a.madm.Equals(t.danhmuc.madm))
                {
                    cboDanhMuc.SelectedIndex = i;
                    return;
                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.masp == -1)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần sửa");
                return;
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không được bỏ trống");
            }
            else if (txtDonGia.Text == "")
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

                if (cboDanhMuc.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn chưa chọn danh mục");
                }
                else
                {
                    
                        danhmuc dm = (danhmuc)cboDanhMuc.SelectedItem;
                        sanpham sp = new sanpham();
                        sp.masp = this.masp;
                        sp.tensp = txtTen.Text;
                        sp.dongia = decimal.Parse(txtDonGia.Text);
                        sp.madm = dm.madm;
                        int check = DAO.Reponsitory.SanPham.update_SanPham(sp);
                        if (check != -1)
                        {
                            load_ListSanPham();
                            this.masp = -1;
                            MessageBox.Show("Sửa thành công một sản phẩm");
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại");
                        }
                    
                    
                }
            }
        }
    }
}
