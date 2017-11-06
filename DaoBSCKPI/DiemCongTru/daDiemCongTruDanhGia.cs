using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DiemCongTru;

namespace DaoBSCKPI.DiemCongTru
{
    public class daDiemCongTruDanhGia
    {
        private lineDiemCongTruDanhGiaDataContext lDCTDG = new lineDiemCongTruDanhGiaDataContext();
        private sp_tblBKDiemCongTruDanhGia_ThongTinResult _DCTDG = new sp_tblBKDiemCongTruDanhGia_ThongTinResult();

        public sp_tblBKDiemCongTruDanhGia_ThongTinResult DCTDG { get => _DCTDG; set => _DCTDG = value; }

        public sp_tblBKDiemCongTruDanhGia_ThongTinResult ThongTin()
        {
            try
            {
                DCTDG = lDCTDG.sp_tblBKDiemCongTruDanhGia_ThongTin(DCTDG.Thang, DCTDG.Nam, DCTDG.IDNhanVien).Single();
                return DCTDG;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lDCTDG.sp_tblBKDiemCongTruDanhGia_ThemSua(DCTDG.Thang, DCTDG.Nam, DCTDG.IDNhanVien, DCTDG.Diem, DCTDG.NguoiTao);
        }

        public DataTable DanhSach(int rIDKeHoach)
        {
            List<sp_tblBKDiemCongTruDanhGia_DanhSach_KeHoachResult> lst;
            lst = lDCTDG.sp_tblBKDiemCongTruDanhGia_DanhSach_KeHoach(DCTDG.Thang, DCTDG.Nam, rIDKeHoach).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
