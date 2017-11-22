using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NguoiDung;

namespace DaoBSCKPI.NguoiDung
{
    public class daNguoiDungNhom
    {
        private linqNguoiDungNhomDataContext lNDN = new linqNguoiDungNhomDataContext();
        private sp_tblHTNguoiDungNhomTruyNhap_ThongTinResult _NDN = new sp_tblHTNguoiDungNhomTruyNhap_ThongTinResult();

        public sp_tblHTNguoiDungNhomTruyNhap_ThongTinResult NDN { get => _NDN; set => _NDN = value; }

        public sp_tblHTNguoiDungNhomTruyNhap_ThongTinResult ThongTin()
        {
            try
            {
                NDN = lNDN.sp_tblHTNguoiDungNhomTruyNhap_ThongTin(NDN.IDNhanVien).Single();
                return NDN;
            }
            catch
            {
                return null;
            }
        }

        public void ThemSua()
        {
            lNDN.sp_tblHTNguoiDungNhomTruyNhap_ThemSua(NDN.IDNhanVien, NDN.IDNhomTruyNhap, NDN.NguoiTao);
        }

        public void Xoa()
        {
            lNDN.sp_tblHTNguoiDungNhomTruyNhap_Xoa(NDN.IDNhanVien, NDN.IDNhomTruyNhap);
        }

        public DataTable DanhSach()
        {
            List<sp_tblHTNguoiDungNhomTruyNhap_DanhSachResult> lst;
            lst = lNDN.sp_tblHTNguoiDungNhomTruyNhap_DanhSach(NDN.IDNhanVien).ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
