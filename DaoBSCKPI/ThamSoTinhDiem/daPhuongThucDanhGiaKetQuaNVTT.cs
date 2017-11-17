using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ThamSoTinhDiem;

namespace DaoBSCKPI.ThamSoTinhDiem
{
    public class daPhuongThucDanhGiaKetQuaNVTT
    {
        private linqPhuongThucDanhGiaKetQuaDataContext lPT = new linqPhuongThucDanhGiaKetQuaDataContext();
        private sp_tblcvPhuongThucDanhGiaKetQua_ThongTinResult _PT = new sp_tblcvPhuongThucDanhGiaKetQua_ThongTinResult();

        public sp_tblcvPhuongThucDanhGiaKetQua_ThongTinResult PT { get => _PT; set => _PT = value; }

        public sp_tblcvPhuongThucDanhGiaKetQua_ThongTinResult ThongTin()
        {
            try
            {
                PT = lPT.sp_tblcvPhuongThucDanhGiaKetQua_ThongTin(PT.ID).Single();
                return PT;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lPT.sp_tblcvPhuongThucDanhGiaKetQua_ThemSua(PT.ID, PT.IDTanSuatDo, PT.IDPhuongThuc, PT.TuNgay, PT.DenNgay, PT.GiaTriToiThieu, PT.GiaTriToiDa, PT.ThuTu, PT.NguoiTao);
        }

        public Boolean KiemTraXoa()
        {
            return lPT.sp_tblcvPhuongThucDanhGiaKetQua_KiemTraXoa(PT.IDPhuongThuc).Single().CoGiaTri.Value;
        }

        public void Xoa()
        {
            lPT.sp_tblcvPhuongThucDanhGiaKetQua_Xoa(PT.ID);
        }

        public DataTable DanhSach()
        {
            List<sp_tblcvPhuongThucDanhGiaKetQua_DanhSachResult> lst;
            lst = lPT.sp_tblcvPhuongThucDanhGiaKetQua_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
