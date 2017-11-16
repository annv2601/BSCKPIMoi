using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.CongViec;

namespace DaoBSCKPI.CongViec
{
    public class daKQNhiemVuTrongTamChiTiet
    {
        private linqKQNhiemVuTrongTamChiTietDataContext lKQCT = new linqKQNhiemVuTrongTamChiTietDataContext();
        private sp_tblcvKetQuaNhiemVuTrongTamChiTiet_ThongTinResult _KQCT = new sp_tblcvKetQuaNhiemVuTrongTamChiTiet_ThongTinResult();

        public sp_tblcvKetQuaNhiemVuTrongTamChiTiet_ThongTinResult KQCT { get => _KQCT; set => _KQCT = value; }

        public sp_tblcvKetQuaNhiemVuTrongTamChiTiet_ThongTinResult ThonTin()
        {
            try
            {
                KQCT = lKQCT.sp_tblcvKetQuaNhiemVuTrongTamChiTiet_ThongTin(KQCT.Thang, KQCT.Nam, KQCT.IDNhiemVu, KQCT.IDPhuongThuc).Single();
                return KQCT;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lKQCT.sp_tblcvKetQuaNhiemVuTrongTamChiTiet_ThemSua(KQCT.Thang, KQCT.Nam, KQCT.IDNhiemVu, KQCT.IDPhuongThuc, KQCT.KetQua, KQCT.Diem, KQCT.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblcvKetQuaNhiemVuTrongTamChiTiet_DanhSachResult> lst;
            lst = lKQCT.sp_tblcvKetQuaNhiemVuTrongTamChiTiet_DanhSach(KQCT.Thang, KQCT.Nam, KQCT.IDNhiemVu).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

    }
}
