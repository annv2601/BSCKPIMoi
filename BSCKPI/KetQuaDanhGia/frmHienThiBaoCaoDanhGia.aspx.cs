using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI.NhanVien;
using BaoBieuIn.DanhGia;
using DaoBSCKPI.DonVi;
using DaoBSCKPI.DiemXepLoai;
using System.Globalization;
using DaoBSCKPI.KeHoachDanhGia;
using DaoBSCKPI.Database.KeHoachDanhGia;
using DaoBSCKPI;

namespace BSCKPI.KPI
{
    public partial class frmHienThiBaoCaoDanhGia : System.Web.UI.Page
    {
        private crBangDanhGia rptBDG = new crBangDanhGia();
        private crBangDanhGiaNhieu rptDGNhieu = new crBangDanhGiaNhieu();
        private crDanhGiaTongHop rptDGTongHop = new crDanhGiaTongHop();
        private crDanhGiaTongHopDonVi rptDGTongHopDonVi = new crDanhGiaTongHopDonVi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ThangBaoCao"] != null)
            {
                byte _Thang;
                int _Nam;
                Guid _IDNhanVien;
                _Thang = byte.Parse(Request.QueryString["ThangBaoCao"]);
                _Nam = int.Parse(Request.QueryString["NamBaoCao"]);
                _IDNhanVien = Guid.Parse(Request.QueryString["NhanVienBaoCao"]);
                switch (int.Parse(Request.QueryString["BieuBaoCao"]))
                {
                    case 1:
                        BangDanhGia(_Thang, _Nam, _IDNhanVien);
                        break;
                    case 2:
                        BangDanhGiaKeHoach(_Thang,_Nam,int.Parse(Request.QueryString["IDKeHoach"]), int.Parse(Request.QueryString["IDDonVi"]), int.Parse(Request.QueryString["IDPhongBan"]));
                        break;
                    case 9:
                        if (Request.QueryString["IDPhongBanBaoCao"] == null)
                        {
                            BangTongHop(_Thang, _Nam, int.Parse(Request.QueryString["IDDonViBaoCao"]), int.Parse(Request.QueryString["KHBaoCao"]));
                        }
                        else
                        {
                            BangTongHopDonVi(_Thang, _Nam, int.Parse(Request.QueryString["IDDonViBaoCao"]), int.Parse(Request.QueryString["IDPhongBanBaoCao"]), int.Parse(Request.QueryString["KHBaoCao"]));
                        }
                        break;
                }
            }
        }

        #region Danh gia ket qua
        private void BangDanhGia(byte rThang, int rNam, Guid rIDNhanVien)
        {
            daBangDanhGia dBDG = new daBangDanhGia();
            dBDG.Thang = rThang;
            dBDG.Nam = rNam;
            dBDG.IDNhanVien = rIDNhanVien;
            rptBDG.SetDataSource(dBDG.BangIn());

            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.IDNhanVien = rIDNhanVien;
            dTTNV.TTNV.Thang = rThang;
            dTTNV.TTNV.Nam = rNam;
            dTTNV.ThongTin();

            daDonVi dDV = new daDonVi();
            daPhongBan dPB = new daPhongBan();
                        
            if (dTTNV.TTNV.IDPhongBan!=0)
            {
                dPB.PB.ID = dTTNV.TTNV.IDPhongBan.Value;
                dPB.ThongTin();
                rptBDG.SetParameterValue(4, dPB.PB.Ten);
            }
            else
            {
                dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
                dDV.ThongTin();
                rptBDG.SetParameterValue(4, dDV.DV.Ten);
            }

            dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
            dDV.ThongTin();
            rptBDG.SetParameterValue(1, dDV.DV.Ten);
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.IDDonVi = dTTNV.TTNV.IDDonVi.Value;
            dMHDV.MHDV.TuNgay = DateTime.Parse(rThang.ToString()+"/01/"+rNam.ToString());
            dMHDV.ThongTin();
            dDV.DV.ID = dMHDV.MHDV.IDDonViQuanLy;
            dDV.ThongTin();
            rptBDG.SetParameterValue(0, dDV.DV.Ten);

            rptBDG.SetParameterValue(2, "Tháng " + rThang.ToString() + " năm " + rNam.ToString());

            rptBDG.SetParameterValue(3, dTTNV.TTNV.TenNhanVien);
                       
            dTTNV.TimTT();

            rptBDG.SetParameterValue(5, dTTNV.Tim.ChucVu);
            rptBDG.SetParameterValue(6, dTTNV.Tim.ChucDanh);

            daDiemXepLoai dDiem = new daDiemXepLoai();
            dDiem.DXL.Thang = rThang;
            dDiem.DXL.Nam = rNam;
            dDiem.DXL.IDNhanVien = rIDNhanVien;
            if (dDiem.Lay()==null)
            {
                rptBDG.SetParameterValue(7, "");
                rptBDG.SetParameterValue(8, "");
            }
            else
            {
                rptBDG.SetParameterValue(7, dDiem.LayDXL.TongDiemKPI.Value.ToString("N2", CultureInfo.CreateSpecificCulture("vi-VN")));
                rptBDG.SetParameterValue(8, dDiem.LayDXL.Ten.ToUpper());
            }

            rptBDG.SetParameterValue(9, dTTNV.Tim.PhuTrach);

            CrystalReportViewer1.ReportSource = rptBDG;
        }
        #endregion

        #region Tham So
        private void NapThamSoDG(byte rThang, int rNam, Guid rIDNhanVien, string rTenBC)
        {
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.IDNhanVien = rIDNhanVien;
            dTTNV.TTNV.Thang = rThang;
            dTTNV.TTNV.Nam = rNam;
            dTTNV.ThongTin();

            daDonVi dDV = new daDonVi();
            daPhongBan dPB = new daPhongBan();

            if (dTTNV.TTNV.IDPhongBan != 0)
            {
                dPB.PB.ID = dTTNV.TTNV.IDPhongBan.Value;
                dPB.ThongTin();
                rptDGNhieu.SetParameterValue("DonVi", dPB.PB.Ten,rTenBC);
            }
            else
            {
                dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
                dDV.ThongTin();
                rptDGNhieu.SetParameterValue("DonVi", dDV.DV.Ten, rTenBC);
            }

            dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
            dDV.ThongTin();
            rptDGNhieu.SetParameterValue("DVDuoi", dDV.DV.Ten, rTenBC);
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.IDDonVi = dTTNV.TTNV.IDDonVi.Value;
            dMHDV.MHDV.TuNgay = DateTime.Parse(rThang.ToString() + "/01/" + rNam.ToString());
            dMHDV.ThongTin();
            dDV.DV.ID = dMHDV.MHDV.IDDonViQuanLy;
            dDV.ThongTin();
            rptDGNhieu.SetParameterValue("DVTren", dDV.DV.Ten, rTenBC);

            rptDGNhieu.SetParameterValue("ThoiGian", "Tháng " + rThang.ToString() + " năm " + rNam.ToString(), rTenBC);

            rptDGNhieu.SetParameterValue("TenNhanVien", dTTNV.TTNV.TenNhanVien, rTenBC);

            dTTNV.TimTT();

            rptDGNhieu.SetParameterValue("ChucVu", dTTNV.Tim.ChucVu, rTenBC);
            rptDGNhieu.SetParameterValue("ChucDanh", dTTNV.Tim.ChucDanh, rTenBC);

            daDiemXepLoai dDiem = new daDiemXepLoai();
            dDiem.DXL.Thang = rThang;
            dDiem.DXL.Nam = rNam;
            dDiem.DXL.IDNhanVien = rIDNhanVien;
            if (dDiem.Lay() == null)
            {
                rptDGNhieu.SetParameterValue("TongDiem", "", rTenBC);
                rptDGNhieu.SetParameterValue("XepLoai", "", rTenBC);
            }
            else
            {
                rptDGNhieu.SetParameterValue("TongDiem", dDiem.LayDXL.TongDiemKPI.Value.ToString("N2", CultureInfo.CreateSpecificCulture("vi-VN")), rTenBC);
                rptDGNhieu.SetParameterValue("XepLoai", dDiem.LayDXL.Ten.ToUpper(), rTenBC);
            }
            rptDGNhieu.SetParameterValue("LinhVucPhuTrach", dTTNV.Tim.PhuTrach, rTenBC);
        }

        private void NapThamSoDGTrong(string rTenBC)
        {
            rptDGNhieu.SetParameterValue("DonVi", "", rTenBC);            
            rptDGNhieu.SetParameterValue("DVDuoi", "", rTenBC);
            rptDGNhieu.SetParameterValue("DVTren", "", rTenBC);
            rptDGNhieu.SetParameterValue("ThoiGian", "", rTenBC);
            rptDGNhieu.SetParameterValue("TenNhanVien", "", rTenBC);
            rptDGNhieu.SetParameterValue("ChucVu", "", rTenBC);
            rptDGNhieu.SetParameterValue("ChucDanh", "", rTenBC);
            rptDGNhieu.SetParameterValue("TongDiem", "", rTenBC);
            rptDGNhieu.SetParameterValue("XepLoai", "", rTenBC);
            rptDGNhieu.SetParameterValue("LinhVucPhuTrach", "", rTenBC);
        }
        #endregion

        #region Nhieu
        private void BangDanhGiaKeHoach(byte _Thang, int _Nam, int _IDKeHoach, int _IDDonVi, int _IDPhongBan)
        {
            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            List<sp_tblBKKeHoachDanhGia_DanhSachNhanVienResult> lst;
            dKH.Thang = _Thang;
            dKH.Nam = _Nam;
            dKH.KHDG.ID = _IDKeHoach;
            if(_IDDonVi==0)
            {
                lst = dKH.lstDanhSachNhanVien();
            }
            else
            {
                lst = dKH.lstDanhSachNhanVienDonVi(_IDDonVi,_IDPhongBan);
            }

            if (lst.Count > 0)
            {
                daBangDanhGia dBDG = new daBangDanhGia();
                dBDG.Thang = _Thang;
                dBDG.Nam = _Nam;
               
                int i = 0;
                string _TenBC;
                while (i < 100 && i < lst.Count)
                {
                    _TenBC = "rptDG" + i.ToString();
                    dBDG.IDNhanVien = lst[i].IDNhanVien.Value;
                    rptDGNhieu.Subreports[_TenBC].SetDataSource(dBDG.BangIn());
                    i = i + 1;
                }
               /* while (i < 100)
                {   
                    _TenBC = "rptDG" + i.ToString();
                    dBDG.IDNhanVien = Guid.Empty;
                    
                    rptDGNhieu.Subreports[_TenBC].SetDataSource(dBDG.BangIn());
                    i = i + 1;
                }*/
                
                //Nap tham so cac bao cao sau
                i = 0;
                while (i < 100 && i < lst.Count)
                {
                    _TenBC = "rptDG" + i.ToString();
                    NapThamSoDG(_Thang, _Nam, lst[i].IDNhanVien.Value, _TenBC);
                    i = i + 1;
                }
                int j = i;
                while (i < 100)
                {
                    _TenBC = "rptDG" + i.ToString();
                    NapThamSoDGTrong(_TenBC);
                    i = i + 1;
                }
                while (j <= 100)
                {
                    rptDGNhieu.ReportDefinition.Sections[j+2].SectionFormat.EnableSuppress = true;
                    j = j + 1;
                }
                //================================
              
                
                //Hien thi bao cao
                CrystalReportViewer1.ReportSource = rptDGNhieu;
            }
        }

        private void BangDanhGiaKeHoach_Luu(byte _Thang, int _Nam, int _IDKeHoach)
        {
            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            List<sp_tblBKKeHoachDanhGia_DanhSachNhanVienResult> lst;
            dKH.Thang = _Thang;
            dKH.Nam = _Nam;
            dKH.KHDG.ID = _IDKeHoach;
            lst = dKH.lstDanhSachNhanVien();
            if (lst.Count>0)
            {
                daBangDanhGia dBDG = new daBangDanhGia();
                dBDG.Thang = _Thang;
                dBDG.Nam = _Nam;
                dBDG.IDNhanVien = lst[0].IDNhanVien.Value;
                rptDGNhieu.Subreports["rptDG"].SetDataSource(dBDG.BangIn());

                int i = 1;
                string _TenBC;
                while (i<100 && i<lst.Count)
                {
                    _TenBC = "rptDG" + i.ToString();
                    dBDG.IDNhanVien = lst[i].IDNhanVien.Value;
                    rptDGNhieu.Subreports[_TenBC].SetDataSource(dBDG.BangIn());
                    i = i + 1;
                }
                while(i<100)
                {
                    _TenBC = "rptDG" + i.ToString();
                    dBDG.IDNhanVien = Guid.Empty;
                    rptDGNhieu.Subreports[_TenBC].SetDataSource(dBDG.BangIn());
                    i = i + 1;
                }

                //nAP THAM SO BAO CAO DAU
                daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                dTTNV.TTNV.IDNhanVien = lst[0].IDNhanVien.Value;
                dTTNV.TTNV.Thang = _Thang;
                dTTNV.TTNV.Nam = _Nam;
                dTTNV.ThongTin();

                daDonVi dDV = new daDonVi();
                daPhongBan dPB = new daPhongBan();

                _TenBC = "rptDG";
                if (dTTNV.TTNV.IDPhongBan != 0)
                {
                    dPB.PB.ID = dTTNV.TTNV.IDPhongBan.Value;
                    dPB.ThongTin();
                    rptDGNhieu.SetParameterValue("DonVi", dPB.PB.Ten, _TenBC);
                }
                else
                {
                    dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
                    dDV.ThongTin();
                    rptDGNhieu.SetParameterValue("DonVi", dDV.DV.Ten, _TenBC);
                }

                dDV.DV.ID = dTTNV.TTNV.IDDonVi.Value;
                dDV.ThongTin();
                rptDGNhieu.SetParameterValue("DVDuoi", dDV.DV.Ten, _TenBC);
                daMoHinhDonVi dMHDV = new daMoHinhDonVi();
                dMHDV.MHDV.IDDonVi = dTTNV.TTNV.IDDonVi.Value;
                dMHDV.MHDV.TuNgay = DateTime.Parse(_Thang.ToString() + "/01/" + _Nam.ToString());
                dMHDV.ThongTin();
                dDV.DV.ID = dMHDV.MHDV.IDDonViQuanLy;
                dDV.ThongTin();
                rptDGNhieu.SetParameterValue("DVTren", dDV.DV.Ten, _TenBC);

                rptDGNhieu.SetParameterValue("ThoiGian", "Tháng " + _Thang.ToString() + " năm " + _Nam.ToString(), _TenBC);

                rptDGNhieu.SetParameterValue("TenNhanVien", dTTNV.TTNV.TenNhanVien, _TenBC);

                dTTNV.TimTT();

                rptDGNhieu.SetParameterValue("ChucVu", dTTNV.Tim.ChucVu, _TenBC);
                rptDGNhieu.SetParameterValue("ChucDanh", dTTNV.Tim.ChucDanh, _TenBC);

                daDiemXepLoai dDiem = new daDiemXepLoai();
                dDiem.DXL.Thang = _Thang;
                dDiem.DXL.Nam = _Nam;
                dDiem.DXL.IDNhanVien = lst[0].IDNhanVien;
                if (dDiem.Lay() == null)
                {
                    rptDGNhieu.SetParameterValue("TongDiem", "", _TenBC);
                    rptDGNhieu.SetParameterValue("XepLoai", "", _TenBC);
                }
                else
                {
                    rptDGNhieu.SetParameterValue("TongDiem", dDiem.LayDXL.TongDiemKPI.Value.ToString("N2", CultureInfo.CreateSpecificCulture("vi-VN")), _TenBC);
                    rptDGNhieu.SetParameterValue("XepLoai", dDiem.LayDXL.Ten.ToUpper(), _TenBC);
                }
                //========================

                //Nap tham so cac bao cao sau
                i = 1;
                while (i < 100 && i < lst.Count)
                {
                    _TenBC = "rptDG" + i.ToString();
                    NapThamSoDG(_Thang, _Nam, lst[i].IDNhanVien.Value, _TenBC);
                    i = i + 1;
                }
                while (i < 100)
                {
                    _TenBC = "rptDG" + i.ToString();
                    NapThamSoDGTrong(_TenBC);
                    i = i + 1;
                }
                //================================

                //Hien thi bao cao
                CrystalReportViewer1.ReportSource = rptDGNhieu;
            }
        }
        #endregion

        #region Tong hop
        private void BangTongHop(byte rThang, int rNam, int rIDDonVi, int rIDKH)
        {
            daDiemXepLoai dXL = new daDiemXepLoai();
            dXL.DXL.Thang = rThang;
            dXL.DXL.Nam = rNam;
            rptDGTongHop.SetDataSource(dXL.BaoCaoKeHoach(rIDKH));

            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            daDonVi dDV = new daDonVi();
            dMHDV.MHDV.IDDonVi = rIDDonVi;
            dMHDV.MHDV.TuNgay = DateTime.Parse(rThang.ToString() + "/01/" + rNam.ToString());
            dMHDV.ThongTin();

            dDV.DV.ID = dMHDV.MHDV.IDDonViQuanLy;
            dDV.ThongTin();
            rptDGTongHop.SetParameterValue(0, dDV.DV.Ten.ToUpper());
            dDV.DV.ID = rIDDonVi;
            dDV.ThongTin();
            rptDGTongHop.SetParameterValue(1, dDV.DV.Ten.ToUpper());

            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            dKH.KHDG.ID = rIDKH;
            dKH.ThongTin();
            rptDGTongHop.SetParameterValue(2,dKH.KHDG.TieuDe1.ToUpper());
            rptDGTongHop.SetParameterValue(3, dKH.KHDG.TieuDe2);
            rptDGTongHop.SetParameterValue(4, dKH.KHDG.TieuDe3);
            rptDGTongHop.SetParameterValue(5, "Kỳ đánh giá: " + "Tháng " + rThang.ToString() + "/" + rNam.ToString());

            CrystalReportViewer1.ReportSource = rptDGTongHop;
        }

        private void BangTongHopDonVi(byte rThang, int rNam, int rIDDonVi, int rIDPhongBan, int rIDKH)
        {
            daDiemXepLoai dXL = new daDiemXepLoai();
            dXL.DXL.Thang = rThang;
            dXL.DXL.Nam = rNam;
            rptDGTongHopDonVi.SetDataSource(dXL.BaoCaoDonVi(rIDDonVi,rIDPhongBan));

            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            daDonVi dDV = new daDonVi();
            daPhongBan dPB = new daPhongBan();

            if(rIDPhongBan!=0)
            {
                dDV.DV.ID = rIDDonVi;
                dDV.ThongTin();
                rptDGTongHopDonVi.SetParameterValue(0, dDV.DV.Ten.ToUpper());

                dPB.PB.ID = rIDPhongBan;
                dPB.ThongTin();
                rptDGTongHopDonVi.SetParameterValue(1, dPB.PB.Ten);
            }
            else
            {
                dMHDV.MHDV.IDDonVi = rIDDonVi;
                dMHDV.MHDV.TuNgay = DateTime.Parse(rThang.ToString() + "/01/" + rNam.ToString());
                dMHDV.ThongTin();

                dDV.DV.ID = dMHDV.MHDV.IDDonViQuanLy;
                dDV.ThongTin();
                rptDGTongHopDonVi.SetParameterValue(0, dDV.DV.Ten.ToUpper());
                dDV.DV.ID = rIDDonVi;
                dDV.ThongTin();
                rptDGTongHopDonVi.SetParameterValue(1, dDV.DV.Ten.ToUpper());
            }
            

            daKeHoachDanhGia dKH = new daKeHoachDanhGia();
            dKH.KHDG.ID = rIDKH;
            dKH.ThongTin();
            rptDGTongHopDonVi.SetParameterValue(2, dKH.KHDG.TieuDe1.ToUpper());
            rptDGTongHopDonVi.SetParameterValue(3, dKH.KHDG.TieuDe2);
            rptDGTongHopDonVi.SetParameterValue(4, dKH.KHDG.TieuDe3);
            rptDGTongHopDonVi.SetParameterValue(5, "Kỳ đánh giá: " + "Tháng " + rThang.ToString() + "/" + rNam.ToString());

            CrystalReportViewer1.ReportSource = rptDGTongHopDonVi;
        }
        #endregion
    }
}