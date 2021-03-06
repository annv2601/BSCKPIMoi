﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.CongViec;

namespace DaoBSCKPI.CongViec
{
    public class daNhiemVuTrongTam:daThamSo
    {
        private linqNhiemVuTrongTamDataContext lNV = new linqNhiemVuTrongTamDataContext();
        private sp_tblcvNhiemVuTrongTam_ThongTinResult _NVu = new sp_tblcvNhiemVuTrongTam_ThongTinResult();

        public sp_tblcvNhiemVuTrongTam_ThongTinResult NVu { get => _NVu; set => _NVu = value; }

        public sp_tblcvNhiemVuTrongTam_ThongTinResult ThongTin()
        {
            try
            {
                NVu = lNV.sp_tblcvNhiemVuTrongTam_ThongTin(NVu.ID, NVu.Thang, NVu.Nam).Single();
                return NVu;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lNV.sp_tblcvNhiemVuTrongTam_ThemSua(NVu.ID, NVu.Ma, NVu.Thang, NVu.Nam, NVu.IDNhanVien, NVu.TenCongViec, NVu.MucTieu, NVu.IDTanSuatDo,
                NVu.IDDonViTinh, NVu.IDXuHuongYeuCau, NVu.IDTrangThai, NVu.NguoiTao);
        }

        public void ChuyenDanhGiaTiepThangSau()
        {
            lNV.sp_tblcvNhiemVuTrongTam_ChuyenDanhGiaThangSau(NVu.ID, NVu.Thang, NVu.Nam, NVu.NguoiTao);
        }

        public void Xoa()
        {
            lNV.sp_tblcvNhiemVuTrongTam_Xoa(NVu.ID, NVu.Thang, NVu.Nam);
        }

        public DataTable DanhSach()
        {
            List<sp_tblcvNhiemVuTrongTam_DanhSachResult> lst;
            lst = lNV.sp_tblcvNhiemVuTrongTam_DanhSach(Thang, Nam, IDDonVi, IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachTheoNhanVien()
        {
            List<sp_tblcvNhiemVuTrongTam_DanhSach_TheoNhanVienResult> lst;
            lst = lNV.sp_tblcvNhiemVuTrongTam_DanhSach_TheoNhanVien(Thang, Nam, IDNhanVien).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
