using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ThamSoTinhDiem;

namespace DaoBSCKPI.ThamSoTinhDiem
{
    public class daThamSoTinhDiem
    {
        private linqTSTinhDiemDataContext lTSTD = new linqTSTinhDiemDataContext();
        private sp_tblBKThamSoTinhDiem_ThongTinResult _TSTD = new sp_tblBKThamSoTinhDiem_ThongTinResult();
        private sp_tblBKThamSoTinhDiem_TimResult _TSTDTim = new sp_tblBKThamSoTinhDiem_TimResult();

        public sp_tblBKThamSoTinhDiem_ThongTinResult TSTD { get => _TSTD; set => _TSTD = value; }
        public sp_tblBKThamSoTinhDiem_TimResult TSTDTim { get => _TSTDTim; set => _TSTDTim = value; }

        public sp_tblBKThamSoTinhDiem_ThongTinResult ThongTin()
        {
            try
            {
                TSTD = lTSTD.sp_tblBKThamSoTinhDiem_ThongTin(TSTD.ID).Single();
                return TSTD;
            }
            catch
            {
                return null;
            }
        }

        public sp_tblBKThamSoTinhDiem_TimResult Tim()
        {
            try
            {
                TSTDTim = lTSTD.sp_tblBKThamSoTinhDiem_Tim(TSTD.Ten).Single();
                return TSTDTim;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lTSTD.sp_tblBKThamSoTinhDiem_ThemSua(TSTD.ID, TSTD.Ten, TSTD.IDXuHuongYeuCau, TSTD.CanDuoi, TSTD.CanTren, TSTD.DiemCanDuoi, TSTD.DiemCanTren,
                TSTD.IDNhomThamSo, TSTD.IDGiaTri, TSTD.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKThamSoTinhDiem_DanhSachResult> lst;
            lst = lTSTD.sp_tblBKThamSoTinhDiem_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
