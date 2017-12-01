﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DanhMucHeThong;
using DaoBSCKPI.Database.DanhMucMoHinh;
using DaoBSCKPI.NhanVien;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                /*daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                dTTNV.TTNV.IDDonVi = 2;
                dTTNV.TTNV.IDPhongBan = 2;
                dTTNV.TTNV.IDNhanVien = Guid.Parse("F2A8A332-84F8-4EB3-B223-03A785D3A337");
                daPhien.NguoiDung = dTTNV.TTNV;*/

                if (Session["PhienLamViecBSC"] == null)
                {
                    Response.Redirect("frmLogin.aspx");
                    return;
                }

                DanhSachChucNang();

            }
        }

        #region Rieng
        private void DanhSachChucNang()
        {
            MenuPanel mp=new MenuPanel();
            Ext.Net.Menu mn = new Ext.Net.Menu();
            Ext.Net.MenuItem mni = new Ext.Net.MenuItem();
            daChucNang dCN = new daChucNang();
            Guid _IDNV = daPhien.NguoiDung.IDNhanVien.Value;

            //Mo hinh
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.Mô_Hình;
            dCN.lstDanhSach(_IDNV);
            if (dCN.LstChucNang.Count > 0)
            {
                mp.Title = "Mô hình Tổ chức";
                mp.SelectedTextCls = "bold-highlight";
                mp.Cls = "my-item";
                mn.ID = "mnuMHTC";
                foreach (sp_tblChucNang_DanhSach_NhanVienResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiMHTC" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Cls = "my-item";
                    mni.Icon = Icon.ArrowRight;
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCN" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURLChucNang(pt.ID,pt.dcUrl) + "','" + pt.TieuDe + "');";
                    mp.Menu.Add(mni);
                }
                pnlChucNang.Add(mp);
            }

            //BSC
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.BSC;
            dCN.lstDanhSach(_IDNV);
            if (dCN.LstChucNang.Count>0)
            {
                mp = new MenuPanel();
                mp.Title = "BSC";
                mp.SelectedTextCls = "bold-highlight";
                mp.Cls = "my-item";
                mn.ID = "mnuBSC";
                foreach(sp_tblChucNang_DanhSach_NhanVienResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiBSC" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Cls = "my-item";
                    mni.Icon = Icon.ArrowRight;
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCN" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURLChucNang(pt.ID,pt.dcUrl) + "','" + pt.TieuDe + "');";
                    mp.Menu.Add(mni);
                }                
                pnlChucNang.Add(mp);
            }

            //KPI
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.KPI;
            dCN.lstDanhSach(_IDNV);
            if (dCN.LstChucNang.Count > 0)
            {
                mp = new MenuPanel();
                mp.Title = "KPI";
                mp.SelectedTextCls = "bold-highlight";
                mn.ID = "mnuKPI";
                foreach (sp_tblChucNang_DanhSach_NhanVienResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiKPI" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Icon = Icon.ArrowRight;
                    mni.Cls = "my-item";
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCNKPI" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURLChucNang(pt.ID,pt.dcUrl) + "','" + pt.TieuDe + "');";
                    mp.Menu.Add(mni);
                }
                pnlChucNang.Add(mp);
            }

            //Cong viec ca nhan
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.Công_Việc_Cá_Nhân;
            dCN.lstDanhSach(_IDNV);
            if (dCN.LstChucNang.Count > 0)
            {
                mp = new MenuPanel();
                mp.Title = "Công việc thường xuyên";
                mp.SelectedTextCls = "bold-highlight";
                mn.ID = "mnuCVTX";
                foreach (sp_tblChucNang_DanhSach_NhanVienResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiCVTX" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Icon = Icon.ArrowRight;
                    mni.Cls = "my-item";
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCNKPI" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURLChucNang(pt.ID,pt.dcUrl) + "','" + pt.TieuDe + "');";
                    mp.Menu.Add(mni);
                }
                pnlChucNang.Add(mp);
            }

            //Bao cao
            dCN.CN.Nhom = (int)daChucNang.eNhomCN.Báo_cáo;
            dCN.lstDanhSach(_IDNV);
            if (dCN.LstChucNang.Count > 0)
            {
                mp = new MenuPanel();
                mp.Title = "Báo cáo";
                mp.SelectedTextCls = "bold-highlight";
                mn.ID = "mnuBaoCao";
                foreach (sp_tblChucNang_DanhSach_NhanVienResult pt in dCN.LstChucNang)
                {
                    mni = new Ext.Net.MenuItem();
                    mni.ID = "mnuiBaoCao" + pt.ID.ToString();
                    mni.Text = pt.Ten;
                    mni.Icon = Icon.ArrowRight;
                    mni.Cls = "my-item";
                    mni.Listeners.Click.Handler = "addTabCN(#{TabPanelChinh},'idTabCN" + pt.ID.ToString() + "','" + daPhien.LayDiaChiURLChucNang(pt.ID,pt.dcUrl) + "','" + pt.TieuDe + "');";                    
                    mp.Menu.Add(mni);
                }
                pnlChucNang.Add(mp);
            }

            //Dang nhap

        }
        #endregion

        #region Su kien
        protected void btnLogin_Click(object sender, DirectEventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }
        #endregion
    }
}