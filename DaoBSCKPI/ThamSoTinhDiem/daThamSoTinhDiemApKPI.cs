using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ThamSoTinhDiem;

namespace DaoBSCKPI.ThamSoTinhDiem
{
    public class daThamSoTinhDiemApKPI
    {
        private linqTSTinhDiemApKPIDataContext lTDKPI = new linqTSTinhDiemApKPIDataContext();
        private sp_tblBKThamSoTinhDiemApChoKPI_ThongTinResult _TDKPI = new sp_tblBKThamSoTinhDiemApChoKPI_ThongTinResult();
        private sp_tblBKThamSoTinhDiemApChoKPI_TimResult _TDKPITim = new sp_tblBKThamSoTinhDiemApChoKPI_TimResult();

        public sp_tblBKThamSoTinhDiemApChoKPI_ThongTinResult TDKPI { get => _TDKPI; set => _TDKPI = value; }
        public sp_tblBKThamSoTinhDiemApChoKPI_TimResult TDKPITim { get => _TDKPITim; set => _TDKPITim = value; }

        public sp_tblBKThamSoTinhDiemApChoKPI_ThongTinResult ThongTin()
        {
            try
            {
                TDKPI = lTDKPI.sp_tblBKThamSoTinhDiemApChoKPI_ThongTin(TDKPI.ID).Single();
                return TDKPI;
            }
            catch
            {
                return null;
            }
        }

        public sp_tblBKThamSoTinhDiemApChoKPI_TimResult Tim()
        {
            try
            {
                TDKPITim = lTDKPI.sp_tblBKThamSoTinhDiemApChoKPI_Tim(TDKPI.IDKPI, TDKPI.NgayApDung).Single();
                return TDKPITim;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lTDKPI.sp_tblBKThamSoTinhDiemApChoKPI_ThemSua(TDKPI.ID, TDKPI.IDKPI, TDKPI.IDThamSo, TDKPI.NgayApDung, TDKPI.NgayKetThuc, TDKPI.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKThamSoTinhDiemApChoKPI_DanhSachResult> lst;
            lst = lTDKPI.sp_tblBKThamSoTinhDiemApChoKPI_DanhSach(TDKPI.IDThamSo).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
