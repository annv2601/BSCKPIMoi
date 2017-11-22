using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NguoiDung;

namespace DaoBSCKPI.NguoiDung
{
    public class daNhomTruyNhap
    {
        private linqNhomTruyNhapDataContext lNTN = new linqNhomTruyNhapDataContext();
        private sp_tblHTNhomTruyNhap_ThongTinResult _NTN = new sp_tblHTNhomTruyNhap_ThongTinResult();

        public sp_tblHTNhomTruyNhap_ThongTinResult NTN { get => _NTN; set => _NTN = value; }

        public sp_tblHTNhomTruyNhap_ThongTinResult ThongTin()
        {
            try
            {
                NTN = lNTN.sp_tblHTNhomTruyNhap_ThongTin(NTN.ID).Single();
                return NTN;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lNTN.sp_tblHTNhomTruyNhap_ThemSua(NTN.ID, NTN.Ten, NTN.GhiChu, NTN.NguoiTao, NTN.STTsx);
        }

        public void Xoa()
        {
            lNTN.sp_tblHTNhomTruyNhap_Xoa(NTN.ID);
        }

        public DataTable DanhSach()
        {
            List<sp_tblHTNhomTruyNhap_DanhSachResult> lst;
            lst = lNTN.sp_tblHTNhomTruyNhap_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
