using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.ThamSoTinhDiem;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.ThamSo
{
    public partial class frmThamSoTinhDiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                stoTSTD.Reload();

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
                    btnThemTSTD.Visible = true;
                }
                else
                {
                    btnThemTSTD.Visible = false;
                }
            }
            else
            {
                btnThemTSTD.Visible = false;
            }
        }
        
        #endregion

        #region Su kien
        protected void btnThemTSTD_Click(object sender, DirectEventArgs e)
        {
            ucTSTD1.KhoiTao();
            wThamSoTD.Show();
        }

        protected void btnCapNhatTSTD_Click(object sender, DirectEventArgs e)
        {
            daThamSoTinhDiem dTS = new daThamSoTinhDiem();
            dTS.TSTD.ID = ucTSTD1.IDThamSo;
            dTS.TSTD.Ten = ucTSTD1.Ten;
            dTS.TSTD.IDXuHuongYeuCau = ucTSTD1.IDXuHuong;
            dTS.TSTD.CanDuoi = ucTSTD1.CanDuoi;
            dTS.TSTD.CanTren = ucTSTD1.CanTren;
            dTS.TSTD.DiemCanDuoi = ucTSTD1.DiemCanDuoi;
            dTS.TSTD.DiemCanTren = ucTSTD1.DiemCanTren;
            dTS.TSTD.IDNhomThamSo = ucTSTD1.IDNhomThamSo;
            dTS.TSTD.IDGiaTri = ucTSTD1.IDGiaTri;
            dTS.TSTD.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            if(dTS.TSTD.Ten=="")
            {
                X.Msg.Alert("", "Tên tham số không được để trống").Show();
                return;
            }
            if (dTS.TSTD.IDNhomThamSo==0)
            {
                X.Msg.Alert("", "Phải thuộc vào nhóm tham số nào").Show();
                return;
            }

            dTS.ThemSua();
            ucTSTD1.KhoiTao();
            stoTSTD.Reload();

        }

        protected void DanhSachThamSoTinhDiem(object sender, StoreReadDataEventArgs e)
        {
            daThamSoTinhDiem dTS = new daThamSoTinhDiem();
            stoTSTD.DataSource = dTS.DanhSach();
            stoTSTD.DataBind();
        }
        #endregion
    }
}