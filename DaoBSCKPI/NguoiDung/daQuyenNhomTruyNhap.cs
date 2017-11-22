using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NguoiDung;

namespace DaoBSCKPI.NguoiDung
{
    public class daQuyenNhomTruyNhap
    {
        private linqQuyenNhomTruyNhapDataContext lQNTN = new linqQuyenNhomTruyNhapDataContext();
        private sp_tblHTQuyenNhomTruyNhap_LayQuyenResult _QNTN = new sp_tblHTQuyenNhomTruyNhap_LayQuyenResult();

        public sp_tblHTQuyenNhomTruyNhap_LayQuyenResult QNTN { get => _QNTN; set => _QNTN = value; }

        public void ThemSua()
        {
            lQNTN.sp_tblHTQuyenNhomTruyNhap_ThemSua(QNTN.IDNhomTruyNhap, QNTN.IDQuyenTruyNhap, QNTN.IDChucNang, QNTN.NguoiTao);
        }

        public void Xoa()
        {
            lQNTN.sp_tblHTQuyenNhomTruyNhap_Xoa(QNTN.IDNhomTruyNhap, QNTN.IDQuyenTruyNhap, QNTN.IDChucNang);
        }

        public DataTable DanhSach()
        {
            List<sp_tblHTQuyenNhomTruyNhap_DanhSachResult> lst;
            lst = lQNTN.sp_tblHTQuyenNhomTruyNhap_DanhSach(QNTN.IDNhomTruyNhap).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
