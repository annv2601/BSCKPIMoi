using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.ThamSoTinhDiem;
using DaoBSCKPI.ChiTieuKPI;
using BSCKPI.UIHelper;
using Ext.Net;
namespace BSCKPI.ThamSo
{
    public partial class frmGhepKPIvaThamSo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachTSChon();
                DanhSachKPIChon();
                DanhSachKPIvTS();

                CheckQuyen(int.Parse(Request.QueryString["CN"]));
            }
        }

        #region Rieng
        private void CheckQuyen(int rIDCN)
        {
            DaoBSCKPI.NguoiDung.daNguoiDungQuyen dNDQ = new DaoBSCKPI.NguoiDung.daNguoiDungQuyen();
            dNDQ.NDQ.IDNhanVien = daPhien.NguoiDung.IDNhanVien;
            dNDQ.NDQ.IDChucNang = rIDCN;
            dNDQ.DanhSachQuyen();
            if (dNDQ.lstQuyen.Count > 0)
            {
                if (dNDQ.lstQuyen[0].IDQuyenTruyNhap.Value >= (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Nhập)
                {
                    btnThemGhep.Visible = true;
                }
                else
                {
                    btnThemGhep.Visible = false;
                }
            }
            else
            {
                btnThemGhep.Visible = false;
            }
        }

        private void DanhSachTSChon()
        {
            daThamSoTinhDiem dTS = new daThamSoTinhDiem();
            stoTSTDChon.DataSource = dTS.DanhSach();
            stoTSTDChon.DataBind();
        }

        private void DanhSachKPIvTS()
        {
            daThamSoTinhDiemApKPI dKT = new daThamSoTinhDiemApKPI();
            dKT.TDKPI.IDThamSo = 0;
            stoKPIvTS.DataSource = dKT.DanhSach();
            stoKPIvTS.DataBind();
        }

        private void DanhSachKPIChon()
        {
            daChiTieuKPI dKPI = new daChiTieuKPI();
            dKPI.KPI.IDDonVi = 0;
            stoKPIChon.DataSource = dKPI.DanhSach();
            stoKPIChon.DataBind();
        }
        private void KhoiTao()
        {
            txtNgayApDung.Value = string.Empty;
            txtNgayKetThuc.Value = string.Empty;
            slbTSChon.SelectedItems.Clear();
            slbTSChon.UpdateSelectedItems();

        }
        #endregion

        #region Su Kien
        protected void DanhSachKPIvTS(object sender, StoreReadDataEventArgs e)
        {
            DanhSachKPIvTS();
        }

        [DirectMethod(Namespace = "BangKPIvTSX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangKPIP)
        {
            
        }

        protected void btnThemGhep_Click(object sender, DirectEventArgs e)
        {
            KhoiTao();
            wKPIvTS.Show();
        }

        protected void btnCapNhatTSvKPI_Click(object sender, DirectEventArgs e)
        {
            if(slbKPIChon.SelectedItem.Value==null||slbTSChon.SelectedItem.Value==null)
            {
                X.Msg.Alert("","Chỉ tiêu KPI và Tham số phải được chọn").Show();
                return;
            }
            
            daThamSoTinhDiemApKPI dKT = new daThamSoTinhDiemApKPI();
            dKT.TDKPI.ID = 0;
            dKT.TDKPI.IDThamSo = int.Parse(slbTSChon.SelectedItem.Value);
            dKT.TDKPI.IDKPI = int.Parse(slbKPIChon.SelectedItem.Value);
            try
            {
                dKT.TDKPI.NgayApDung = txtNgayApDung.SelectedDate;
                dKT.TDKPI.NgayKetThuc = txtNgayKetThuc.SelectedDate;
            }
            catch
            {
                X.Msg.Alert("", "Đề nghị nhập đầy đủ ngày").Show();
                return;
            }
            dKT.TDKPI.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dKT.ThemSua();
            KhoiTao();
        }
        #endregion
    }
}