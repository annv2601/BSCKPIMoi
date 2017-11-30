using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NguoiDung;

namespace DaoBSCKPI.NguoiDung
{
    public class daNguoiDungQuyen
    {
        private linqNguoiDungQuyenDataContext lNDQ = new linqNguoiDungQuyenDataContext();
        private sp_tblHTNguoiDungQuyenTruyNhap_ThongTinResult _NDQ = new sp_tblHTNguoiDungQuyenTruyNhap_ThongTinResult();
        public List<sp_tblHTNguoiDungQuyenTruyNhap_DanhSachResult> lstQuyen=new List<sp_tblHTNguoiDungQuyenTruyNhap_DanhSachResult>();

        public sp_tblHTNguoiDungQuyenTruyNhap_ThongTinResult NDQ { get => _NDQ; set => _NDQ = value; }

        public sp_tblHTNguoiDungQuyenTruyNhap_ThongTinResult ThongTin()
        {
            try
            {
                NDQ = lNDQ.sp_tblHTNguoiDungQuyenTruyNhap_ThongTin(NDQ.IDNhanVien).Single();
                return NDQ;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lNDQ.sp_tblHTNguoiDungQuyenTruyNhap_ThemSua(NDQ.IDNhanVien, NDQ.IDQuyenTruyNhap, NDQ.IDChucNang, NDQ.NguoiTao);
        }

        public void Xoa()
        {
            lNDQ.sp_tblHTNguoiDungQuyenTruyNhap_Xoa(NDQ.IDNhanVien, NDQ.IDQuyenTruyNhap, NDQ.IDChucNang);
        }

        public void XoaChucNang()
        {
            lNDQ.sp_tblHTNguoiDungQuyenTruyNhap_XoaChucNang(NDQ.IDNhanVien, NDQ.IDChucNang);
        }

        public DataTable DanhSach()
        {
            List<sp_tblHTNguoiDungQuyenTruyNhap_DanhSachResult> lst;
            lst = lNDQ.sp_tblHTNguoiDungQuyenTruyNhap_DanhSach(NDQ.IDNhanVien, NDQ.IDQuyenTruyNhap, NDQ.IDChucNang).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public void DanhSachQuyen()
        {
            lstQuyen = lNDQ.sp_tblHTNguoiDungQuyenTruyNhap_DanhSach(NDQ.IDNhanVien, 0, NDQ.IDChucNang).ToList();            
        }

        public DataTable DanhSachChucNang()
        {
            List<sp_tblHTNguoiDungQuyenTruyNhap_DanhSachChucNangResult> lst;
            lst = lNDQ.sp_tblHTNguoiDungQuyenTruyNhap_DanhSachChucNang(NDQ.IDNhanVien).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }

        public DataTable DanhSachChucQuyen()
        {
            List<sp_tblHTNguoiDungQuyenTruyNhap_DanhSachQuyenResult> lst;
            lst = lNDQ.sp_tblHTNguoiDungQuyenTruyNhap_DanhSachQuyen(NDQ.IDNhanVien,NDQ.IDChucNang).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
