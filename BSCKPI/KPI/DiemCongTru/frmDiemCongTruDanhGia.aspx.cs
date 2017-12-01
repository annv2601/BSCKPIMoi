using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.KeHoachDanhGia;
using DaoBSCKPI.DiemCongTru;
using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI;
using DaoBSCKPI.DonVi;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.KPI.DiemCongTru
{
    public partial class frmDiemCongTruDanhGia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachDonVi(DateTime.Now, daPhien.NguoiDung.IDDonVi.Value);
                DanhSachKeHoachDG();

                CheckQuyen(int.Parse(Request.QueryString["CN"]));
            }
        }

        #region Rieng
        private void CheckQuyen(int rIDCN)
        {
            DaoBSCKPI.NguoiDung.daNguoiDungQuyen dNDQ = new DaoBSCKPI.NguoiDung.daNguoiDungQuyen();
            dNDQ.NDQ.IDNhanVien = daPhien.NguoiDung.IDNhanVien;
            dNDQ.NDQ.IDChucNang = rIDCN;
            dNDQ.DanhSachQuyen();
            if (dNDQ.lstQuyen.Count > 0)
            {
                if (dNDQ.lstQuyen[0].IDQuyenTruyNhap.Value >= (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Nhập)
                {
                    txtNhapDCTDG.Text = "1";
                }
                else
                {
                    txtNhapDCTDG.Text = "0";
                }
            }
            else
            {
                txtNhapDCTDG.Text = "0";
            }
            
            if (dNDQ.lstQuyen[0].IDQuyenTruyNhap >= (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Duyệt)
            {
                btnTinhDiem.Visible = true;
            }
            else
            {
                btnTinhDiem.Visible = false;
            }

        }

        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoThang.DataSource = dTS.DanhSachThang();
            stoThang.DataBind();

            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();
        }

        private void DanhSachDonVi(DateTime rNgay, int rIDDVQL)
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = rNgay;
            dMHDV.MHDV.IDDonViQuanLy = rIDDVQL;
            stoDonVi.DataSource = dMHDV.DanhSach();
            stoDonVi.DataBind();
        }

        private void DanhSachKeHoachDG()
        {
            daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
            stoKHDG.DataSource = dKHDG.DanhSach();
            stoKHDG.DataBind();
        }

        private Ext.Net.Window CuaSoChucNang(string rTieuDe, string Url)
        {
            Ext.Net.Window _CSo = new Ext.Net.Window();
            ComponentLoader _Loader = new ComponentLoader();
            _Loader.Url = Url;
            _Loader.Mode = LoadMode.Frame;
            _Loader.LoadMask.ShowMask = true;
            _Loader.LoadMask.Msg = "Đang xử lý .....";

            _CSo.ID = "IDcsBaoCaoTH";
            _CSo.Title = rTieuDe;
            _CSo.TitleAlign = TitleAlign.Center;
            _CSo.AutoRender = true;
            _CSo.Maximizable = false;
            _CSo.Icon = Icon.Printer;
            _CSo.Width = 900;
            _CSo.Height = 500;
            _CSo.Loader = _Loader;

            return _CSo;
        }
        #endregion

        #region Su kien
        protected void DanhSachDCTDG(object sender, StoreReadDataEventArgs e)
        {
            daDiemCongTruDanhGia dDCT = new daDiemCongTruDanhGia();
            dDCT.DCTDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDCT.DCTDG.Nam = int.Parse(slbNam.SelectedItem.Value);

            if (slbDonVi.SelectedItem.Value != null)
            {
                if (slbPhongBan.SelectedItem.Value != null)
                {
                    stoDCTDG.DataSource = dDCT.DanhSachDonVi(int.Parse(slbDonVi.SelectedItem.Value), int.Parse(slbPhongBan.SelectedItem.Value));
                }
                else
                {
                    return;
                }
            }
            else
            {
                stoDCTDG.DataSource = dDCT.DanhSach(int.Parse(slbKeHoachDG.SelectedItem.Value));
            }
            stoDCTDG.DataBind();
        }

        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            daMoHinhPhongBan dMHPB = new daMoHinhPhongBan();
            dMHPB.MHPB.TuNgay = DateTime.Now;
            dMHPB.MHPB.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            stoPhong.DataSource = dMHPB.DanhSachDDL();
            stoPhong.DataBind();
        }

        [DirectMethod(Namespace = "BangDCTDGX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangPB)
        {
            daDiemCongTruDanhGia dDCT = new daDiemCongTruDanhGia();
            dDCT.DCTDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDCT.DCTDG.Nam = int.Parse(slbNam.SelectedItem.Value);
            dDCT.DCTDG.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangPB.ToString());            
            dDCT.DCTDG.IDNhanVien = Guid.Parse(node.Property("IDNhanVien").Value.ToString());            
            dDCT.DCTDG.Diem = Convert.ToDecimal(node.Property("Diem").Value.ToString());

            dDCT.ThemSua();
            grdDCTDG.GetStore().GetById(id).Commit();
        }

        protected void btnTinhDiem_Click(object sender, DirectEventArgs e)
        {
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null || slbKeHoachDG.SelectedItem.Value == null)
            {
                X.Msg.Alert("", "Chưa chọn đủ tham số tính toán").Show();
                return;
            }
            daKetQuaDanhGia dKQ = new daKetQuaDanhGia();
            dKQ.KQ.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dKQ.KQ.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKQ.KQ.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dKQ.TinhDiemKeHoach(int.Parse(slbKeHoachDG.SelectedItem.Value));
            X.Msg.Alert("", "Đã hoàn thành tính toán").Show();
        }

        protected void btnIn_Click(object sender, DirectEventArgs e)
        {
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null || slbKeHoachDG.SelectedItem.Value==null)
            {
                X.Msg.Alert("", "Chưa chọn đủ tham số để in").Show();
                return;
            }

            Ext.Net.Window CSo = new Ext.Net.Window();
            /*string _TD1,_TD2,_TD3;
            _TD1 = "tổng hợp kết quả đánh giá kpi tháng của cbcnv các đơn vị chức năng bđhn";
            _TD2 = "(Kèm theo Quyết định số              /QĐ-BĐHN ngày              /2017 của BĐHN";
            _TD3 = "Đối tượng: CBCNV các đơn vị chức năng Bưu điện TP Hà Nội";*/
            if (slbDonVi.SelectedItem.Value == null || slbPhongBan.SelectedItem.Value == null)
            {
                CSo = CuaSoChucNang("Bảng đánh giá Tổng hợp", "/KetQuaDanhGia/frmHienThiBaoCaoDanhGia.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&BieuBaoCao=9&&KHBaoCao=" + slbKeHoachDG.SelectedItem.Value + "&&IDDonViBaoCao=" + daPhien.NguoiDung.IDDonVi.ToString() + "&&NhanVienBaoCao=" + Guid.Empty.ToString());
            }
            else
            {
                CSo = CuaSoChucNang("Bảng đánh giá Tổng hợp", "/KetQuaDanhGia/frmHienThiBaoCaoDanhGia.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&BieuBaoCao=9&&KHBaoCao=" + slbKeHoachDG.SelectedItem.Value + "&&IDDonViBaoCao=" + slbDonVi.SelectedItem.Value + "&&IDPhongBanBaoCao=" + slbPhongBan.SelectedItem.Value + "&&NhanVienBaoCao=" + Guid.Empty.ToString());
            }
            this.Form.Controls.Add(CSo);
            CSo.Render();
            CSo.Show();
        }
        #endregion
    }
}