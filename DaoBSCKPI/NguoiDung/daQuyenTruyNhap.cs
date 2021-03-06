﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DaoBSCKPI.Database.NguoiDung;

namespace DaoBSCKPI.NguoiDung
{
    public class daQuyenTruyNhap
    {
        public enum eQuyen
        {
            Xem=1,
            Nhập=2,
            Sửa=3,
            Gán_Truy_nhập=9,
            Xóa=4,
            Gửi=5,
            Duyệt=6,
            Khóa=7,
            Tất_Cả=8
        }

        private linqQuyenTruyNhapDataContext lQTN = new linqQuyenTruyNhapDataContext();
        private sp_tblHTQuyenTruyNhap_ThongTinResult _QTN = new sp_tblHTQuyenTruyNhap_ThongTinResult();

        public sp_tblHTQuyenTruyNhap_ThongTinResult QTN { get => _QTN; set => _QTN = value; }

        public sp_tblHTQuyenTruyNhap_ThongTinResult ThongTin()
        {
            try
            {
                QTN = lQTN.sp_tblHTQuyenTruyNhap_ThongTin(QTN.ID).Single();
                return QTN;
            }
            catch
            {
                return null;
            }
        }

        public DataTable DanhSach()
        {
            List<sp_tblHTQuyenTruyNhap_DanhSachResult> lst;
            lst = lQTN.sp_tblHTQuyenTruyNhap_DanhSach().ToList();
            return daDatatableVaList.ToDataTable(lst);
        }
    }
}
