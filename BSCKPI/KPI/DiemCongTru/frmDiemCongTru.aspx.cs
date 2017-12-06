using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.KeHoachDanhGia;
using DaoBSCKPI.DiemCongTru;
using DaoBSCKPI;
using DaoBSCKPI.DonVi;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.KPI.DiemCongTru
{
    public partial class frmDiemCongTru : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachKeHoachDG();
                DanhSachDonVi(DateTime.Now, daPhien.NguoiDung.IDDonVi.Value);

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
                    btnThem.Visible = true;
                    txtNhapDCT.Text = "1";
                }
                else
                {
                    btnThem.Visible = false;
                    txtNhapDCT.Text = "0";
                }
            }
            else
            {
                btnThem.Visible = false;
                txtNhapDCT.Text = "0";
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
            if (daPhien.VaiTro <= (int)DaoBSCKPI.NguoiDung.daDangNhap.eVaiTro.Quản_lý_Phòng)
            {
                daDonVi dDV = new daDonVi();
                dDV.DV.ID = daPhien.NguoiDung.IDDonVi.Value;
                stoDonVi.DataSource = dDV.DanhSachDuyNhat();
            }
            else
            {
                stoDonVi.DataSource = dMHDV.DanhSach();
            }
            stoDonVi.DataBind();
        }

        private void DanhSachKeHoachDG()
        {
            daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
            stoKHDG.DataSource = dKHDG.DanhSach();
            stoKHDG.DataBind();
        }

        private void DanhSachNhanVienDanhGia()
        {
            if (slbKeHoachDG.SelectedItem.Value != null)
            {
                daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
                dKHDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dKHDG.Nam = int.Parse(slbNam.SelectedItem.Value);
                dKHDG.KHDG.ID = int.Parse(slbKeHoachDG.SelectedItem.Value);
                stoNhanVien.DataSource = dKHDG.DanhSachNhanVien();
                stoNhanVien.DataBind();
            }
        }

        private void DanhSachNhanVienDanhGiaDonVi()
        {
            if (slbKeHoachDG.SelectedItem.Value != null)
            {
                daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
                dKHDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dKHDG.Nam = int.Parse(slbNam.SelectedItem.Value);
                dKHDG.KHDG.ID = int.Parse(slbKeHoachDG.SelectedItem.Value);

                int _IDDV, _IDPB;
                _IDDV = int.Parse(slbDonVi.SelectedItem.Value);
                _IDPB = int.Parse(slbPhongBan.SelectedItem.Value);
                if (_IDPB < 0)
                {
                    _IDPB = 0 - _IDPB;
                }
                else
                {
                    _IDDV = _IDPB;
                    _IDPB = 0;
                }

                stoNhanVien.DataSource = dKHDG.DanhSachNhanVienDonVi(_IDDV, _IDPB);
                stoNhanVien.DataBind();
            }
        }
        #endregion

        #region Su kien
        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            slbPhongBan.SelectedItems.Clear();
            slbPhongBan.UpdateSelectedItems();
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = DateTime.Now;
            dMHDV.MHDV.IDDonViQuanLy = int.Parse(slbDonVi.SelectedItem.Value);
            if (daPhien.VaiTro <= (int)DaoBSCKPI.NguoiDung.daDangNhap.eVaiTro.Quản_lý_Phòng)
            {
                daPhongBan dPB = new daPhongBan();
                dPB.PB.ID = daPhien.NguoiDung.IDPhongBan.Value;
                if (dPB.PB.ID != 0)
                {
                    stoPhong.DataSource = dPB.DanhSachDuyNhat();
                }
                else
                {
                    daDonVi dDV = new daDonVi();
                    dDV.DV.ID = daPhien.NguoiDung.IDDonVi.Value;
                    stoPhong.DataSource = dDV.DanhSachDuyNhat();
                }
            }
            else
            {
                stoPhong.DataSource = dMHDV.DanhSachGopVoiPhongBan();
            }
            stoPhong.DataBind();
        }

        protected void DanhSachDCT(object sender, StoreReadDataEventArgs e)
        {
            daDiemCongTru dDCT = new daDiemCongTru();
            dDCT.DCT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDCT.DCT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dDCT.DCT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
            stoDCT.DataSource = dDCT.DanhSach();
            stoDCT.DataBind();
        }

        protected void DanhSachNhanVienTD(object sender, StoreReadDataEventArgs e)
        {
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null)
            {
                return;
            }
            if (slbDonVi.SelectedItem.Value == null && slbPhongBan.SelectedItem.Value == null)
            {
                DanhSachNhanVienDanhGia();
            }
            else
            {
                if (slbDonVi.SelectedItem.Value != null && slbPhongBan.SelectedItem.Value != null)
                {
                    DanhSachNhanVienDanhGiaDonVi();
                }
            }
        }

        protected void btnThem_Click(object sender, DirectEventArgs e)
        {
            if(slbNhanVien.SelectedItem.Value==null)
            {
                X.Msg.Alert("","Phải chọn một nhân viên").Show();
                return;
            }
            if(txtDiem.Number==0)
            {
                X.Msg.Alert("","Điểm phải khác 0").Show();
                return;
            }
            if(txtNoiDung.Text.Trim()=="")
            {
                X.Msg.Alert("","Phải có Lý do được cộng điểm hoặc trừ điểm").Show();
                return;
            }
            daDiemCongTru dDCT = new daDiemCongTru();
            dDCT.DCT.ThuTu = 0;
            dDCT.DCT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDCT.DCT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dDCT.DCT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
            dDCT.DCT.NoiDung = txtNoiDung.Text.Trim();
            dDCT.DCT.Diem = Convert.ToDecimal(txtDiem.Number);
            dDCT.DCT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dDCT.ThemSua();
            stoDCT.Reload();

            txtNoiDung.Text = "";
            txtDiem.Number = 0;
        }

        [DirectMethod(Namespace = "BangDCTX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangPB)
        {
            daDiemCongTru dDCT = new daDiemCongTru();            
            dDCT.DCT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDCT.DCT.Nam = int.Parse(slbNam.SelectedItem.Value);            
            dDCT.DCT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangPB.ToString());
            dDCT.DCT.ThuTu = id;
            dDCT.DCT.IDNhanVien = Guid.Parse(node.Property("IDNhanVien").Value.ToString());
            dDCT.DCT.NoiDung = node.Property("NoiDung").Value.ToString();
            dDCT.DCT.Diem = Convert.ToDecimal(node.Property("Diem").Value.ToString());

            dDCT.ThemSua();
            grdDCT.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}