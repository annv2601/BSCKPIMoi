using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI.CongViec;
using DaoBSCKPI.Khac;
using DaoBSCKPI.DonVi;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.KetQuaDanhGia
{
    public partial class frmKetQuaNhiemVuChinh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
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
                    txtNhapKQNVC.Text = "1";
                }
                else
                {
                    txtNhapKQNVC.Text = "0";
                }
            }
            else
            {
                txtNhapKQNVC.Text = "0";
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

        private void DanhSachNhanVienNhap(int rIDDonVi, int rIDphongBan)
        {
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTTNV.TTNV.IDDonVi = rIDDonVi;
            dTTNV.TTNV.IDPhongBan = rIDphongBan;
            
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

        private void DanhSachNhiemVuChinh(int rIDDonVi, int rIDphongBan)
        {
            daKQNhiemVuTrongTam dKQNVu = new daKQNhiemVuTrongTam();
            daThamSo dTS = new daThamSo();
            dTS.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTS.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTS.IDDonVi = rIDDonVi;
            dTS.IDPhongBan = rIDphongBan;
            dTS.IDNguoiDung = daPhien.NguoiDung.IDNhanVien.ToString();

            dKQNVu.KhoiTao(dTS);
            dKQNVu.BoSung(dTS);

            stoNV.DataSource = dKQNVu.DanhSach(dTS);
            stoNV.DataBind();
            
        }
        #endregion

        #region SuKien
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

        protected void DanhSachKQNVTTam(object sender, StoreReadDataEventArgs e)
        {
            if (slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null || slbDonVi.SelectedItem.Value==null || slbPhongBan.SelectedItem.Value==null)
            {
                return;
            }

            int _IDDV,_IDPB;
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
            DanhSachNhiemVuChinh(_IDDV, _IDPB);
        }
        
        protected void DanhSachKQNVCTiet(object sender, StoreReadDataEventArgs e)
        {
            daKQNhiemVuTrongTamChiTiet dKQCT = new daKQNhiemVuTrongTamChiTiet();            
            dKQCT.KQCT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dKQCT.KQCT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKQCT.KQCT.IDNhiemVu = int.Parse(txtIDNhiemVu.Value.ToString());
            
            stoKQCTiet.DataSource = dKQCT.DanhSach();
            stoKQCTiet.DataBind();

            daNhiemVuTrongTam dNV = new daNhiemVuTrongTam();
            dNV.NVu.ID = dKQCT.KQCT.IDNhiemVu.Value;
            dNV.NVu.Thang = dKQCT.KQCT.Thang;
            dNV.NVu.Nam = dKQCT.KQCT.Nam;
            if (dNV.ThongTin()!=null)
            {
                wKQChiTiet.Title = dNV.NVu.TenCongViec;
            }
        }


        [DirectMethod(Namespace = "BangKQDGNVX")]
        public void EditKQ(int id, string field, string oldvalue, string newvalue, object BangKQ)
        {
            daKQNhiemVuTrongTam dKQ = new daKQNhiemVuTrongTam();
            dKQ.KQNV.Thang= byte.Parse(slbThang.SelectedItem.Value);
            dKQ.KQNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKQ.KQNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dKQ.KQNV.IDNhiemVu = id;

            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangKQ.ToString());

            try
            {
                dKQ.KQNV.KetQua = decimal.Parse(node.Property("KetQua").Value.ToString());
            }
            catch
            {
                dKQ.KQNV.KetQua = 0;
            }
            try
            {
                dKQ.KQNV.Diem = decimal.Parse(node.Property("Diem").Value.ToString());
            }
            catch
            {
                dKQ.KQNV.Diem = 0;
            }
            dKQ.KQNV.DienGiai = node.Property("DienGiai").Value.ToString();

            dKQ.CapNhat();

            grdNV.GetStore().GetById(id).Commit();
        }

        [DirectMethod(Namespace = "BangKQDGNVCTietX")]
        public void EditCT(int id, string field, string oldvalue, string newvalue, object BangKQ)
        {
            daKQNhiemVuTrongTamChiTiet dKQ = new daKQNhiemVuTrongTamChiTiet();
            dKQ.KQCT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dKQ.KQCT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKQ.KQCT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangKQ.ToString());
            dKQ.KQCT.IDNhiemVu = int.Parse(txtIDNhiemVu.Value.ToString());
            dKQ.KQCT.IDPhuongThuc = int.Parse(node.Property("IDPhuongThuc").Value.ToString());
            try
            {
                dKQ.KQCT.KetQua = decimal.Parse(node.Property("KetQua").Value.ToString());
            }
            catch
            {
                dKQ.KQCT.KetQua = 0;
            }
            try
            {
                dKQ.KQCT.Diem = decimal.Parse(node.Property("Diem").Value.ToString());
            }
            catch
            {
                dKQ.KQCT.Diem = 0;
            }

            dKQ.ThemSua();

            grdKQCTiet.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}