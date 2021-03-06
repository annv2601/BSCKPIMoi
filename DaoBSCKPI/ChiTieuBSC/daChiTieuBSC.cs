﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ChiTieuBSC;

namespace DaoBSCKPI.ChiTieuBSC
{
    public class daChiTieuBSC
    {
        private linqChiTieuBSCDataContext lBSC = new linqChiTieuBSCDataContext();
        private sp_tblBKChiTieuBSC_ThongTinResult _BSC = new sp_tblBKChiTieuBSC_ThongTinResult();

        public sp_tblBKChiTieuBSC_ThongTinResult BSC { get => _BSC; set => _BSC = value; }

        public List<sp_tblBKChiTieuBSC_DanhSachResult> lstBSC = new List<sp_tblBKChiTieuBSC_DanhSachResult>();

        public sp_tblBKChiTieuBSC_ThongTinResult ThongTin()
        {
            try
            {
                BSC = lBSC.sp_tblBKChiTieuBSC_ThongTin(BSC.ID).Single();
                return BSC;
            }
            catch
            {
                return null;
            }
        }
        
        public void ThemSua()
        {
            lBSC.sp_tblBKChiTieuBSC_ThemSua(BSC.ID, BSC.Ma, BSC.STT, BSC.Ten, BSC.TrongSo, BSC.MucTieu, BSC.IDDonViTinh, BSC.IDChiTieuTren, BSC.Muc, BSC.IDTanSuatDo,
                BSC.IDXuHuongYeuCau, BSC.STTsx, BSC.InDam, BSC.InNghieng);
        }

        public bool CapNhatTrongSo()
        {
            return lBSC.sp_tblBKChiTieuBSC_CapNhatTrongSo(BSC.ID, BSC.TrongSo).Single().KetQuaSuaTS.Value;
        }

        public decimal LayTongTrongSo()
        {
            return lBSC.sp_tblBKChiTieuBSC_LayTongTrongSo(BSC.IDChiTieuTren).Single().TongTrongSo;
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKChiTieuBSC_DanhSachResult> lst;
            lst = lBSC.sp_tblBKChiTieuBSC_DanhSach(BSC.IDChiTieuTren).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public List<sp_tblBKChiTieuBSC_DanhSachResult> lstDanhSach()
        {
            lstBSC = lBSC.sp_tblBKChiTieuBSC_DanhSach(BSC.IDChiTieuTren).ToList();
            return lstBSC;
        }
        
        

        public void DongBoChiTieu(int rNam)
        {
            lBSC.sp_DongBo_ChiTieu(rNam);
        }
    }
}
