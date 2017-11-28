using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DiemXepLoai;

namespace DaoBSCKPI.DiemXepLoai
{
    public class daDiemXepLoai
    {
        private linqDiemXepLoaiDataContext lD = new linqDiemXepLoaiDataContext();
        private sp_tblBKDiemXepLoai_ThongTinResult _DXL = new sp_tblBKDiemXepLoai_ThongTinResult();

        private sp_tblBKDiemXepLoai_LayResult _LayDXL = new sp_tblBKDiemXepLoai_LayResult();

        public sp_tblBKDiemXepLoai_ThongTinResult DXL { get => _DXL; set => _DXL = value; }
        public sp_tblBKDiemXepLoai_LayResult LayDXL { get => _LayDXL; set => _LayDXL = value; }

        public sp_tblBKDiemXepLoai_ThongTinResult ThongTin()
        {
            try
            {
                DXL = lD.sp_tblBKDiemXepLoai_ThongTin(DXL.Thang, DXL.Nam, DXL.IDNhanVien).Single();
                return DXL;
            }
            catch
            {
                return null;
            }
        }

        public sp_tblBKDiemXepLoai_LayResult Lay()
        {
            try
            {
                LayDXL = lD.sp_tblBKDiemXepLoai_Lay(DXL.Thang, DXL.Nam, DXL.IDNhanVien).Single();
                return LayDXL;
            }
            catch
            {
                return null;
            }
        }
        
        public DataTable BaoCaoTatCa()
        {
            List<sp_tblBKDiemXepLoai_BaoCao_TatCaResult> lst;
            lst = lD.sp_tblBKDiemXepLoai_BaoCao_TatCa(DXL.Thang, DXL.Nam).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable BaoCaoKeHoach(int rIDKH)
        {
            List<sp_tblBKDiemXepLoai_BaoCao_TatCaResult> lst;
            lst = lD.sp_tblBKDiemXepLoai_BaoCao_KeHoach(DXL.Thang, DXL.Nam,rIDKH).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable BaoCaoDonVi(int rIDDonVi, int rIDPhongBan)
        {
            List<sp_tblBKDiemXepLoai_BaoCao_DonViResult> lst;
            lst = lD.sp_tblBKDiemXepLoai_BaoCao_DonVi(DXL.Thang, DXL.Nam, rIDDonVi,rIDPhongBan).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
