using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NguoiDung;

namespace DaoBSCKPI.NguoiDung
{
    public class daDangNhap
    {
        public enum eVaiTro
        {
            Thao_Tác=1,
            Quản_lý_Phòng=2,
            Quản_lý_Trung_tâm_Huyện=3,
            Quản_lý_Tỉnh_Thành=4,
            Quản_lý_TCTy=5
        }

        private linqDangNhapDataContext lDN = new linqDangNhapDataContext();
        private sp_tblHTDangNhap_ThongTinResult _ND = new sp_tblHTDangNhap_ThongTinResult();

        public sp_tblHTDangNhap_ThongTinResult ND { get => _ND; set => _ND = value; }

        public sp_tblHTDangNhap_ThongTinResult ThongTin()
        {
            try
            {
                ND = lDN.sp_tblHTDangNhap_ThongTin(ND.IDNhanVien).Single();
                return ND;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lDN.sp_tblHTDangNhap_ThemSua(ND.IDNhanVien, ND.Email, ND.MatKhau, ND.IDVaiTro, ND.NguoiTao);
        }

        public string DangNhap()
        {
            return lDN.sp_tblHTDangNhap_DangNhap(ND.Email, ND.MatKhau).Single().KetQuaDangNhap;
        }

        public DataTable DanhSachVaiTro()
        {
            List<sp_tblHTVaiTro_DanhSachResult> lst;
            lst = lDN.sp_tblHTVaiTro_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
