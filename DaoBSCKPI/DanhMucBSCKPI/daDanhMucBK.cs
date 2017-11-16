using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DanhMucBK;

namespace DaoBSCKPI.DanhMucBSCKPI
{
    public class daDanhMucBK
    {
        private linqDanhMucBKDataContext lDM = new linqDanhMucBKDataContext();
        private sp_tblBKDanhMuc_ThongTinResult _DMB = new sp_tblBKDanhMuc_ThongTinResult();

        private sp_tblBKDanhMuc_TimResult _DMTim = new sp_tblBKDanhMuc_TimResult();
        public sp_tblBKDanhMuc_TimResult DMTim { get => _DMTim; set => _DMTim = value; }
        public sp_tblBKDanhMuc_ThongTinResult DMB { get => _DMB; set => _DMB = value; }

        public DataTable DanhSach(int rNhom)
        {
            List<sp_tblBKDanhMuc_DanhSachResult> lst;
            lst = lDM.sp_tblBKDanhMuc_DanhSach(rNhom).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public sp_tblBKDanhMuc_TimResult Tim()
        {
            try
            {
                DMTim = lDM.sp_tblBKDanhMuc_Tim(DMTim.Ten).Single();
                return DMTim;
            }
            catch
            {
                return null;
            }
        }

        public sp_tblBKDanhMuc_ThongTinResult ThongTin()
        {
            try
            {
                DMB = lDM.sp_tblBKDanhMuc_ThongTin(DMB.ID).Single();
                return DMB;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lDM.sp_tblBKDanhMuc_ThemSua(DMB.ID, DMB.Ma, DMB.Ten, DMB.TenTat, DMB.GhiChu, DMB.STTsx, DMB.Nhom, DMB.NguoiTao);
        }
    }
}
