using QuanLyBanHang.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Forms
{
    public partial class frmHangSanXuat : Form
    {
        //khai báo biến toàn cục
        QLBHDbContext context = new QLBHDbContext(); //Khởi tạo biến ngữ cảnh CSDL
        bool xulyThem = false;                  // kiểm tra có nhấn vào nút thêm hay không
        int id;                                 //lấy mã hãng sản xuất dùng cho sửa, xóa
        public frmHangSanXuat()
        {
            InitializeComponent();
        }
        //các sự kiện
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTeHangSanXuat.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmHangSanXuat_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

            List<HangSanXuat> hsx = new List<HangSanXuat>();
            hsx = context.HangSanXuat.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = hsx;

            txtTeHangSanXuat.DataBindings.Clear();
            txtTeHangSanXuat.DataBindings.Add("Text", bindingSource, "TenHangSanXuat", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xulyThem = true;
            BatTatChucNang(true);
            txtTeHangSanXuat.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeHangSanXuat.Text))
                MessageBox.Show("vui lòng nhập tên hãng sản xuất?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xulyThem)
                {
                    //xử lý thêm
                    HangSanXuat hsx = new HangSanXuat();
                    hsx.TenHangSanXuat = txtTeHangSanXuat.Text;
                    context.HangSanXuat.Add(hsx);

                    context.SaveChanges();
                    MessageBox.Show("Thêm hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //xử lý sửa
                    HangSanXuat hsx = context.HangSanXuat.Find(id);
                    if (hsx != null)
                    {
                        hsx.TenHangSanXuat = txtTeHangSanXuat.Text;
                        context.HangSanXuat.Update(hsx);

                        context.SaveChanges();
                        MessageBox.Show("Cập nhật tên hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                frmHangSanXuat_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xac nhận xóa loại sản phẩm?", "Xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                HangSanXuat hsx = context.HangSanXuat.Find(id);
                if (hsx != null)
                {
                    context.HangSanXuat.Remove(hsx);
                }
                context.SaveChanges();

                frmHangSanXuat_Load(sender, e);

            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmHangSanXuat_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}

