using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DiemCongTru;

namespace DaoBSCKPI.DiemCongTru
{
    public class daDiemCongTru
    {
        private lineDiemCongTruDataContext lDCT = new lineDiemCongTruDataContext();
        private sp_tblBKDiemCongTru_ThongTinResult _DCT = new sp_tblBKDiemCongTru_ThongTinResult();

        public sp_tblBKDiemCongTru_ThongTinResult DCT { get => _DCT; set => _DCT = value; }

        public sp_tblBKDiemCongTru_ThongTinResult ThongTin()
        {
            try
            {
                DCT = lDCT.sp_tblBKDiemCongTru_ThongTin(DCT.Thang, DCT.Nam, DCT.IDNhanVien, DCT.ThuTu).Single();
                return DCT;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lDCT.sp_tblBKDiemCongTru_ThemSua(DCT.Thang, DCT.Nam, DCT.IDNhanVien, DCT.ThuTu, DCT.NoiDung, DCT.Diem, DCT.NguoiTao);
        }

        public DataTable DanhSach()
        {
            List<sp_tblBKDiemCongTru_DanhSachResult> lst;
            lst = lDCT.sp_tblBKDiemCongTru_DanhSach(DCT.Thang, DCT.Nam, DCT.IDNhanVien).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

    }
}
