using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.KetQuaDanhGia;

namespace DaoBSCKPI.KetQuaDanhGia
{
    public class daKetQuaDanhGiaDonVi
    {
        private linqKetQuaDanhGiaDonViDataContext lDGV = new linqKetQuaDanhGiaDonViDataContext();
        private sp_tblBKKetQuaDanhGiaDonVi_ThongTinResult _DGDV = new sp_tblBKKetQuaDanhGiaDonVi_ThongTinResult();

        public sp_tblBKKetQuaDanhGiaDonVi_ThongTinResult DGDV { get => _DGDV; set => _DGDV = value; }

        public sp_tblBKKetQuaDanhGiaDonVi_ThongTinResult ThongTin()
        {
            try
            {
                DGDV = lDGV.sp_tblBKKetQuaDanhGiaDonVi_ThongTin(DGDV.Thang, DGDV.Nam, DGDV.IDDonVi, DGDV.IDPhongBan, DGDV.IDKPI).Single();
                return DGDV;
            }
            catch
            {
                return null;
            }
        }

        public void CapNhat()
        {
            lDGV.sp_tblBKKetQuaDanhGiaDonVi_CapNhat(DGDV.Thang, DGDV.Nam, DGDV.IDDonVi, DGDV.IDPhongBan, DGDV.IDKPI, DGDV.KetQua, DGDV.NguoiTao);
        }

        public void GanChoNhanVien()
        {
            lDGV.sp_tblBKKetQuaDanhGiaDonVi_GanChoNhanVien(DGDV.Thang, DGDV.Nam, DGDV.IDDonVi, DGDV.NguoiTao);
        }

        public void KhoiTao()
        {
            lDGV.sp_tblBKKetQuaDanhGiaDonVi_KhoiTao(DGDV.Thang, DGDV.Nam, DGDV.IDDonVi, DGDV.IDPhongBan, DGDV.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKKetQuaDanhGiaDonVi_DanhSachResult> lst;
            lst = lDGV.sp_tblBKKetQuaDanhGiaDonVi_DanhSach(DGDV.Thang, DGDV.Nam, DGDV.IDDonVi, DGDV.IDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
