using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            load_ListView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        

        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            View.SanPham sanpham = new View.SanPham();
            sanpham.Show();
        }

        private void btnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            View.DanhMuc danhmuc = new View.DanhMuc();
            danhmuc.Show();
        }

        public void load_ListView()
        {
            
            lstSanPham.FullRowSelect = true;
            lstSanPham.GridLines = true;
            lstSanPham.Items.Clear();
            List<sanpham> sp = new List<sanpham>();
            sp = DAO.Reponsitory.SanPham.getAll_SanPham();
            int i = 0;
            foreach (var a in sp)
            {
                i++;
                ListViewItem Item = new ListViewItem();
                Item.Text = i + "";
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.tensp });
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.dongia + "" });
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.danhmuc + "" });
                Item.Tag = a;
                lstSanPham.Items.Add(Item);
            }
        }


        public void load_ListView(List<sanpham> list)
        {

            lstSanPham.FullRowSelect = true;
            lstSanPham.GridLines = true;
            lstSanPham.Items.Clear();
            
            int i = 0;
            foreach (var a in list)
            {
                i++;
                ListViewItem Item = new ListViewItem();
                Item.Text = i + "";
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.tensp });
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.dongia + "" });
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = a.danhmuc + "" });
                Item.Tag = a;
                lstSanPham.Items.Add(Item);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tìm kiếm");
                return;
            }
            else
            {
                if (rdoMa.Checked)
                {
                    try
                    {
                        int a = int.Parse(txtTimKiem.Text);
                        List<sanpham> lst = DAO.SanPhamDAO.Instance.get_SanPham_Ma(a);
                        if (lst.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm nào");
                            return;
                        }
                        else
                        {
                            load_ListView(lst);
                            MessageBox.Show("Tìm thấy " + lst.Count + " sản phẩm");
                        }


                    }catch(Exception ex)
                    {
                        MessageBox.Show("Mã sản phẩm phải là một con số");
                    }



                }
                else if(rdoTen.Checked)
                {
                    List<sanpham> lst = DAO.SanPhamDAO.Instance.get_SanPham_Ten(txtTimKiem.Text);
                    if (lst.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm nào");
                        return;
                    }
                    else
                    {
                        load_ListView(lst);
                        MessageBox.Show("Tìm thấy "+lst.Count+" sản phẩm");
                    }
                }
                else if (rdoDanhMuc.Checked)
                {
                    List<sanpham> lst = DAO.SanPhamDAO.Instance.get_SanPham_DanhMuc(txtTimKiem.Text);
                    if (lst.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm nào");
                        return;
                    }
                    else
                    {
                        load_ListView(lst);
                        MessageBox.Show("Tìm thấy " + lst.Count + " sản phẩm");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn loại tìm kiếm");
                    return;
                }
            }
        }
    }
}
