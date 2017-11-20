using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.ChiTieuKPI;

namespace DaoBSCKPI.ChiTieuKPI
{
    public class daChiTieuKPIChoPhong
    {
        private linqChiTieuKPIChoPhongDataContext lCP = new linqChiTieuKPIChoPhongDataContext();
        private sp_tblBKChiTieuKPIChoPhong_ThongTinResult _KPICP = new sp_tblBKChiTieuKPIChoPhong_ThongTinResult();

        public sp_tblBKChiTieuKPIChoPhong_ThongTinResult KPICP { get => _KPICP; set => _KPICP = value; }

        public sp_tblBKChiTieuKPIChoPhong_ThongTinResult ThongTin()
        {
            try
            {
                KPICP = lCP.sp_tblBKChiTieuKPIChoPhong_ThongTin(KPICP.Thang, KPICP.Nam, KPICP.IDDonVi, KPICP.IDPhongBan, KPICP.IDKPI).Single();
                return KPICP;
            }
            catch
            {
                return null;
            }
        }

        public void Them()
        {
            lCP.sp_tblBKChiTieuKPIChoPhong_Them(KPICP.Ma, KPICP.Thang, KPICP.Nam, KPICP.IDDonVi, KPICP.IDPhongBan, KPICP.IDKPI, KPICP.NguoiTao);
        }

        public void Xoa()
        {
            lCP.sp_tblBKChiTieuKPIChoPhong_Xoa(KPICP.Thang, KPICP.Nam, KPICP.IDDonVi, KPICP.IDPhongBan, KPICP.IDKPI);
        }
    }
}
