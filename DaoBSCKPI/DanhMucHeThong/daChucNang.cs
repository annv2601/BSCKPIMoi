using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.DanhMucMoHinh;

namespace DaoBSCKPI.DanhMucHeThong
{
    public class daChucNang
    {
        public enum eNhomCN
        {
            BSC=1,
            KPI=2,
            Công_Việc_Cá_Nhân=3,
            Mô_Hình=4,
            Báo_cáo=9
        }

        private linqChucNangDataContext lCN = new linqChucNangDataContext();
        private sp_tblChucNang_ThongTinResult _CN = new sp_tblChucNang_ThongTinResult();

        public sp_tblChucNang_ThongTinResult CN { get => _CN; set => _CN = value; }
        public List<sp_tblChucNang_DanhSach_NhanVienResult> LstChucNang { get => _lstChucNang; set => _lstChucNang = value; }

        private List<sp_tblChucNang_DanhSach_NhanVienResult> _lstChucNang = new List<sp_tblChucNang_DanhSach_NhanVienResult>();

        public sp_tblChucNang_ThongTinResult ThongTin()
        {
            try
            {
                CN = lCN.sp_tblChucNang_ThongTin(CN.ID).Single();
                return CN;
            }
            catch
            {
                return null;
            }
        }

        public DataTable DanhSach()
        {
            List<sp_tblChucNang_DanhSachResult> lst;
            lst = lCN.sp_tblChucNang_DanhSach(CN.Nhom).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public List<sp_tblChucNang_DanhSach_NhanVienResult> lstDanhSach(Guid rIDNV)
        {
            LstChucNang = lCN.sp_tblChucNang_DanhSach_NhanVien(CN.Nhom,rIDNV).ToList();
            return LstChucNang;
        }


    }
}
