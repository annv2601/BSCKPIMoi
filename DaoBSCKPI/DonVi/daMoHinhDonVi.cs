using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DonVi;

namespace DaoBSCKPI.DonVi
{
    public class daMoHinhDonVi
    {
        private linqMoHinhDonViDataContext lmhdv = new linqMoHinhDonViDataContext();
        private sp_tblMoHinhDonVi_ThongTinResult _MHDV = new sp_tblMoHinhDonVi_ThongTinResult();
        private List<sp_tblDonVi_ThongTinResult> lstMHDV = new List<sp_tblDonVi_ThongTinResult>();

        public sp_tblMoHinhDonVi_ThongTinResult MHDV { get => _MHDV; set => _MHDV = value; }

        public sp_tblMoHinhDonVi_ThongTinResult ThongTin()
        {
            try
            {
                MHDV = lmhdv.sp_tblMoHinhDonVi_ThongTin(MHDV.IDDonVi, MHDV.TuNgay).Single();
                return MHDV;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lmhdv.sp_tblMoHinhDonVi_ThemSua(MHDV.IDDonVi, MHDV.IDDonViQuanLy, MHDV.STTsx, MHDV.TuNgay, MHDV.DenNgay, MHDV.GhiChu, MHDV.NguoiTao);
        }

        public void SuaDenNgay()
        {
            lmhdv.sp_tblMoHinhDonVi_SuaDenNgay(MHDV.IDDonVi, MHDV.DenNgay);
        }

        public DataTable DanhSach()
        {
            List<sp_tblMoHinhDonVi_DanhSachResult> lst;
            lst = lmhdv.sp_tblMoHinhDonVi_DanhSach(MHDV.IDDonViQuanLy, MHDV.TuNgay,true).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public List<sp_tblMoHinhDonVi_DanhSachResult> lstPhanCap(int rIDDVQL, DateTime rNgay)
        {
            List<sp_tblMoHinhDonVi_DanhSachResult> lstCon;
            lstCon = lmhdv.sp_tblMoHinhDonVi_DanhSach(rIDDVQL, rNgay,false).ToList();
            return lstCon;
        }
        
        private void lstChon(int rIDDVQL, DateTime rNgay, int rMuc, string rTenTat)
        {
            List<sp_tblMoHinhDonVi_DanhSachResult> lstCon;
            lstCon = lmhdv.sp_tblMoHinhDonVi_DanhSach(rIDDVQL, rNgay, false).ToList();
            daDonVi dDV = new daDonVi();
            dDV.DV.ID = rIDDVQL;
            dDV.ThongTin();
            string _Dau="";
            switch(rMuc)
            {
                case 0:
                    _Dau = "";
                    break;
                case 1:
                    _Dau = "--";
                    break;
                case 2:
                    _Dau = "----";
                    break;
                case 3:
                    _Dau = "------";
                    break;
                case 4:
                    _Dau = "--------";
                    break;
                case 5:
                    _Dau = "----------";
                    break;
                case 6:
                    _Dau = "------------";
                    break;
            }
            rTenTat = rTenTat == "" ? "" : (rTenTat + "/ ");
            dDV.DV.Ten = _Dau + " "+rTenTat + dDV.DV.Ten + " : " + dDV.DV.ID.ToString();
            if (lstCon.Count==0)
            {   
                lstMHDV.Add(dDV.DV);                
            }
            else
            {
                lstMHDV.Add(dDV.DV);
                foreach (sp_tblMoHinhDonVi_DanhSachResult pt in lstCon)
                {
                    lstChon(pt.IDDonVi, rNgay,rMuc+1,dDV.DV.TenTat);
                }
            }
        }

        public DataTable DanhSachMHDV(int rIDDVQL, DateTime rNgay)
        {
            lstChon(rIDDVQL, rNgay,0,"");
            return daDatatableVaList.ToDataTable(lstMHDV);
        }

        public DataTable DanhSachGopVoiPhongBan()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Ten", typeof(string));

            linqMoHinhPhongBanDataContext lPB = new linqMoHinhPhongBanDataContext();
            List<sp_tblMoHinhPhongBan_DanhSachResult> lstPB;
            lstPB = lPB.sp_tblMoHinhPhongBan_DanhSach(MHDV.IDDonViQuanLy, MHDV.TuNgay).ToList();
            foreach(sp_tblMoHinhPhongBan_DanhSachResult ptP in lstPB)
            {
                dt.Rows.Add(0 - ptP.IDPhongBan, ptP.TenPhongBan);
            }

            List<sp_tblMoHinhDonVi_DanhSachResult> lst;
            lst = lmhdv.sp_tblMoHinhDonVi_DanhSach(MHDV.IDDonViQuanLy, MHDV.TuNgay, false).ToList();
            foreach(sp_tblMoHinhDonVi_DanhSachResult ptD in lst)
            {
                dt.Rows.Add(ptD.IDDonVi, ptD.Ten);
            }

            return dt;
        }
    }
}
