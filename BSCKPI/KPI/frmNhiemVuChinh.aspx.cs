﻿using System;
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
namespace BSCKPI.KPI
{
    public partial class frmNhiemVuChinh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachDonVi(DateTime.Now, daPhien.NguoiDung.IDDonVi.Value);
                ucNV1.KhoiTao();
            }
        }

        #region Rieng
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

            ucNV1.DanhSachNhanVien(dTTNV.DanhSach());
        }

        private void DanhSachDonVi(DateTime rNgay, int rIDDVQL)
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = rNgay;
            dMHDV.MHDV.IDDonViQuanLy = rIDDVQL;
            stoDonVi.DataSource = dMHDV.DanhSach();
            stoDonVi.DataBind();
        }

        private void DanhSachNhiemVuChinh(int rIDDonVi, int rIDphongBan)
        {
            daNhiemVuTrongTam dNVu = new daNhiemVuTrongTam();
            dNVu.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dNVu.Nam = int.Parse(slbNam.SelectedItem.Value);
            dNVu.IDDonVi = rIDDonVi;
            dNVu.IDPhongBan = rIDphongBan;

            stoNV.DataSource = dNVu.DanhSach();
            stoNV.DataBind();

            grdNV.Title = "Nhiệm vụ trọng tâm " + dNVu.Thang.ToString() + "/" + dNVu.Nam.ToString();
        }
        #endregion

        #region SuKien
        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            daMoHinhPhongBan dMHPB = new daMoHinhPhongBan();
            dMHPB.MHPB.TuNgay = DateTime.Now;
            dMHPB.MHPB.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            stoPhong.DataSource = dMHPB.DanhSachDDL();
            stoPhong.DataBind();
        }

        protected void DanhSachNVTTam(object sender, StoreReadDataEventArgs e)
        {
            if (slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null || slbDonVi.SelectedItem.Value==null || slbPhongBan.SelectedItem.Value==null)
            {
                return;
            }

            int _IDDV,_IDPB;
            _IDDV = int.Parse(slbDonVi.SelectedItem.Value);
            _IDPB = int.Parse(slbPhongBan.SelectedItem.Value);
            DanhSachNhanVienNhap(_IDDV,_IDPB);
            DanhSachNhiemVuChinh(_IDDV, _IDPB);
        }

        protected void btnCapNhatNV_Click(object sender, DirectEventArgs e)
        {
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn Tháng và Năm!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
                return;
            }
            daNhiemVuTrongTam dNVu = new daNhiemVuTrongTam();
            dNVu.NVu.ID = ucNV1.IDNVChinh;
            dNVu.NVu.IDNhanVien = ucNV1.IDNhanVien;
            dNVu.NVu.TenCongViec = ucNV1.TenCongViec;
            dNVu.NVu.MucTieu = ucNV1.MucTieu;
            dNVu.NVu.IDDonViTinh = ucNV1.DonViTinh;
            dNVu.NVu.IDTanSuatDo = ucNV1.TanSuatDo;
            dNVu.NVu.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dNVu.NVu.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dNVu.NVu.Nam = int.Parse(slbNam.SelectedItem.Value);
            dNVu.NVu.IDXuHuongYeuCau = ucNV1.XuHuongYeuCau;
            dNVu.NVu.Ma = ucNV1.Ma;
            if (dNVu.NVu.ID==0)
            {
                dNVu.NVu.IDTrangThai = (int)daTrangThai.eTrangThai.Nhập;
            }
            else
            {
                dNVu.NVu.IDTrangThai = (int)daTrangThai.eTrangThai.Sửa;
            }
            if(dNVu.NVu.TenCongViec=="")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Tên công việc khổng thể là trống !",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
                });
                return;
            }
            dNVu.ThemSua();
            stoNV.Reload();
            ucNV1.KhoiTao();
        }

        protected void grdNV_Select(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            daNhiemVuTrongTam dNVu = new daNhiemVuTrongTam();
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    dNVu.NVu.ID = int.Parse(row["ID"]);
                }
                catch
                {
                    dNVu.NVu.ID = 0;
                }
            }
            if (dNVu.NVu.ID != 0)
            {
                dNVu.NVu.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dNVu.NVu.Nam = int.Parse(slbNam.SelectedItem.Value);
                dNVu.ThongTin();
                ucNV1.IDNVChinh = dNVu.NVu.ID;
                ucNV1.IDNhanVien = dNVu.NVu.IDNhanVien.Value;
                ucNV1.TenCongViec = dNVu.NVu.TenCongViec;
                ucNV1.MucTieu = dNVu.NVu.MucTieu.Value;
                ucNV1.TanSuatDo = dNVu.NVu.IDTanSuatDo.Value;
                ucNV1.DonViTinh = dNVu.NVu.IDDonViTinh.Value;
                ucNV1.TrangThai = dNVu.NVu.IDTrangThai.Value;
                ucNV1.XuHuongYeuCau = dNVu.NVu.IDXuHuongYeuCau.Value;
                ucNV1.Ma = dNVu.NVu.Ma;
            }
        }
        #endregion
    }
}