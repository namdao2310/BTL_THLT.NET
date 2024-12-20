﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_ban_quanao
{
    public partial class Frm_QlNhacc : Form
    {
        NhaCungCap b = new NhaCungCap();
        public Frm_QlNhacc()
        {
            InitializeComponent();
            LoadMaSanPhamIntoComboBox();
            cb_msp.SelectedIndex = 0;
        }
        void hienthi()
        {
            dataGridView1.DataSource = b.getAllNhaCungCap();
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txt_manhacc.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_manhacc.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_tennhacc.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tennhacc.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_diachi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_diachi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_sdt.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_sdt.Focus();
                return false;
            }
            if (cb_msp.SelectedIndex == 0) 
            {
                MessageBox.Show("Vui lòng chọn Mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_msp.Focus();
                return false;
            }
            return true;
        }
        private bool ValidateSearchInput()
        {
            if (string.IsNullOrWhiteSpace(txt_manhacc.Text) && string.IsNullOrWhiteSpace(txt_tennhacc.Text))
            {
                MessageBox.Show("Vui lòng nhập ít nhất Mã nhà cung cấp hoặc Tên nhà cung cấp để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_manhacc.Focus();
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                b.CreateNhaCungCap(txt_manhacc.Text, txt_tennhacc.Text, txt_diachi.Text, txt_sdt.Text, cb_msp.Text);
                hienthi();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                b.UpdateNhaCungCap(txt_manhacc.Text, txt_tennhacc.Text, txt_diachi.Text, txt_sdt.Text, cb_msp.Text);
                hienthi();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b.DeleteNhaCungCap(txt_manhacc.Text);
            hienthi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void LoadMaSanPhamIntoComboBox()
        {
            try
            {
                var nhaCungCapList = b.GetMaSanPham();
                cb_msp.Items.Clear();
                cb_msp.Items.Insert(0, "-Chọn-");
                foreach (string ncc in nhaCungCapList)
                {
                    cb_msp.Items.Add(ncc);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp vào ComboBox: " + ex.Message);
            }
        }
        private void Frm_QlNhacc_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count >= 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txt_manhacc.Text = row.Cells[0].Value.ToString();
                txt_tennhacc.Text = row.Cells[1].Value.ToString();
                txt_diachi.Text = row.Cells[2].Value.ToString();
                txt_sdt.Text = row.Cells[3].Value.ToString();
                cb_msp.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ValidateSearchInput())
            {
                dataGridView1.DataSource = b.TimKiemNhaCungCap(txt_manhacc.Text);
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_manhacc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
