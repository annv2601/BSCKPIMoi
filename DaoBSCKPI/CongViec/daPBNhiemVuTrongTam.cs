using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoBSCKPI.Database.CongViec;

namespace DaoBSCKPI.CongViec
{
    public class daPBNhiemVuTrongTam
    {
        private linqPBNhiemVuTrongTamDataContext lPBNV = new linqPBNhiemVuTrongTamDataContext();
        private sp_tblcvPhanBoNhiemVuTrongTam_ThongTinResult _PBNV = new sp_tblcvPhanBoNhiemVuTrongTam_ThongTinResult();

        public sp_tblcvPhanBoNhiemVuTrongTam_ThongTinResult PBNV { get => _PBNV; set => _PBNV = value; }

        public sp_tblcvPhanBoNhiemVuTrongTam_ThongTinResult ThongTin()
        {
            try
            {
                PBNV = lPBNV.sp_tblcvPhanBoNhiemVuTrongTam_ThongTin(PBNV.IDNhiemVu).Single();
                return PBNV;
            }
            catch
            {
                return null;
            }
        }

        public void KhoiTaovaBoSung(Guid rIDNVien)
        {
            lPBNV.sp_tblcvPhanBoNhiemVuTrongTam_KhoiTao_NhanVien(PBNV.Thang, PBNV.Nam, rIDNVien, PBNV.NguoiTao);
        }

        public void CapNhat()
        {
            lPBNV.sp_tblcvPhanBoNhiemVuTrongTam_CapNhat(PBNV.Thang, PBNV.Nam, PBNV.IDNhiemVu, PBNV.TrongSo, PBNV.NguoiTao);
        }
    }
}
