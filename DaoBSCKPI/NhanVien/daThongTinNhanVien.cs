﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NhanVien;

namespace DaoBSCKPI.NhanVien
{
    public class daThongTinNhanVien
    {
        private linqThongTinNhanVienDataContext lTT = new linqThongTinNhanVienDataContext();
        private sp_tblThongTinNhanVien_ThongTinResult _TTNV = new sp_tblThongTinNhanVien_ThongTinResult();
        private sp_tblThongTinNhanVien_TimResult _Tim = new sp_tblThongTinNhanVien_TimResult();
        private sp_tblThongTinNhanVien_ThongTinTenResult _TTNVTen = new sp_tblThongTinNhanVien_ThongTinTenResult();

        public sp_tblThongTinNhanVien_ThongTinResult TTNV { get => _TTNV; set => _TTNV = value; }
        public sp_tblThongTinNhanVien_TimResult Tim { get => _Tim; set => _Tim = value; }
        public sp_tblThongTinNhanVien_ThongTinTenResult TTNVTen { get => _TTNVTen; set => _TTNVTen = value; }

        public sp_tblThongTinNhanVien_ThongTinResult ThongTin()
        {
            try
            {
                TTNV = lTT.sp_tblThongTinNhanVien_ThongTin(TTNV.Thang, TTNV.Nam, TTNV.IDNhanVien).Single();
                return TTNV;
            }
            catch
            {
                return null;
            }
        }

        public sp_tblThongTinNhanVien_ThongTinResult TimEmail(string rEmail)
        {
            try
            {
                sp_tblThongTinNhanVien_ThongTinResult pt=new sp_tblThongTinNhanVien_ThongTinResult();
                sp_tblThongTinNhanVien_ThongTinEmailResult ptE;
                ptE = lTT.sp_tblThongTinNhanVien_ThongTinEmail(TTNV.Thang, TTNV.Nam, rEmail).Single();
                pt.IDNhanVien = ptE.IDNhanVien;
                pt.IDDonVi = ptE.IDDonVi;
                pt.IDPhongBan = ptE.IDPhongBan;
                pt.IDChucVu = ptE.IDChucVu;
                pt.IDChucDanh = ptE.IDChucDanh;
                pt.IDPhuTrach = ptE.IDPhuTrach;
                
                return pt;
            }
            catch
            {
                return null;
            }
        }

        public sp_tblThongTinNhanVien_ThongTinTenResult ThongTinTen()
        {
            try
            {
                TTNVTen = lTT.sp_tblThongTinNhanVien_ThongTinTen(TTNV.Thang, TTNV.Nam, TTNV.IDNhanVien).Single();
                return TTNVTen;
            }
            catch
            {
                return null;
            }
        }

        public sp_tblThongTinNhanVien_TimResult TimTT()
        {
            try
            {
                Tim = lTT.sp_tblThongTinNhanVien_Tim(TTNV.Thang,TTNV.Nam,TTNV.IDNhanVien).Single();
                return Tim;
            }
            catch
            {
                return null;
            }
        }

        public void Xoa()
        {
            lTT.sp_tblThongTinNhanVien_Xoa(TTNV.Thang, TTNV.Nam, TTNV.IDNhanVien, TTNV.IDDonVi, TTNV.IDPhongBan);
        }

        public void ThemSua()
        {
            lTT.sp_tblThongTinNhanVien_ThemSua(TTNV.Thang, TTNV.Nam, TTNV.IDNhanVien, TTNV.TenNhanVien, TTNV.IDDonVi, TTNV.IDPhongBan, TTNV.IDChucVu,
                TTNV.IDChucDanh, TTNV.IDPhuTrach, TTNV.MoTaCongViec, TTNV.NguoiTao);
        }

        public void ChuyenDonVi()
        {
            lTT.sp_tblThongTinNhanVien_ChuyenDonVi(TTNV.IDNhanVien, TTNV.Thang, TTNV.Nam, TTNV.IDDonVi, TTNV.IDPhongBan, TTNV.NguoiSua);
        }

        public void KhoiTao()
        {
            lTT.sp_tblThongTinNhanVien_KhoiTao(TTNV.Thang, TTNV.Nam, TTNV.IDDonVi, TTNV.IDPhongBan, TTNV.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblThongTinNhanVien_DanhSach_DonViResult> lst;
            lst = lTT.sp_tblThongTinNhanVien_DanhSach_DonVi(TTNV.Thang, TTNV.Nam, TTNV.IDDonVi, TTNV.IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachLanhDao()
        {
            List<sp_tblThongTinNhanVien_DanhSach_LanhDaoDonViResult> lst;
            lst = lTT.sp_tblThongTinNhanVien_DanhSach_LanhDaoDonVi(TTNV.Thang, TTNV.Nam, TTNV.IDDonVi, TTNV.IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public List<sp_tblThongTinNhanVien_DanhSach_DonViResult> lstDanhSach()
        {
            List<sp_tblThongTinNhanVien_DanhSach_DonViResult> lst;
            lst = lTT.sp_tblThongTinNhanVien_DanhSach_DonVi(TTNV.Thang, TTNV.Nam, TTNV.IDDonVi, TTNV.IDPhongBan).ToList();
            return lst;
        }
    }
}
