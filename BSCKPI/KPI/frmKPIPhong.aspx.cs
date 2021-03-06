﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.ChiTieuKPI;
using DaoBSCKPI.DonVi;
using DaoBSCKPI;
using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.KPI
{
    public partial class frmKPIPhong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachNam();
                DanhSachDonVi();

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
                    btnCapNhatMTNam.Visible = true;
                    txtGiaoKPI.Text = "1";
                }
                else
                {
                    btnCapNhatMTNam.Visible = false;
                    txtGiaoKPI.Text = "0";
                }
            }
            else
            {
                btnCapNhatMTNam.Visible = false;
                txtGiaoKPI.Text = "0";
            }            
        }

        private void DanhSachDonVi()
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.IDDonViQuanLy = daPhien.NguoiDung.IDDonVi.Value;
            dMHDV.MHDV.TuNgay = DateTime.Now;
            if (daPhien.VaiTro <= (int)DaoBSCKPI.NguoiDung.daDangNhap.eVaiTro.Quản_lý_Phòng)
            {
                daDonVi dDV = new daDonVi();
                dDV.DV.ID = daPhien.NguoiDung.IDDonVi.Value;
                stoDonVi.DataSource = dDV.DanhSachDuyNhat();
            }
            else
            {
                stoDonVi.DataSource = dMHDV.DanhSach();
                stoDonVi.DataBind();
            }
                
        }

        private void DanhSachNam()
        {
            daThamSo dTS = new daThamSo();
            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();
        }

        private void DanhSachKPIPhong()
        {
            if(slbNam.SelectedItem.Value==null||slbDonVi.SelectedItem.Value==null)
            {
                return;
            }
            daChiTieuKPIPhong dKPIP = new daChiTieuKPIPhong();
            dKPIP.KPIP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKPIP.KPIP.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);//daPhien.NguoiDung.IDDonVi;
            dKPIP.KPIP.IDPhongBan = 0;//daPhien.NguoiDung.IDPhongBan;
            if (slbPhongBan.SelectedItem.Value != null)
            {
                dKPIP.KPIP.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);
                stoKPIPhong.DataSource = dKPIP.DanhSachChoPhong(chkChiChon.Checked);
            }
            else
            {
                dKPIP.KhoiTao();
                stoKPIPhong.DataSource = dKPIP.DanhSach();
            }
            stoKPIPhong.DataBind();
        }
        #endregion

        #region Su Kien
        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            daMoHinhPhongBan dMHPB = new daMoHinhPhongBan();
            dMHPB.MHPB.TuNgay = DateTime.Now;
            dMHPB.MHPB.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            stoPhong.DataSource = dMHPB.DanhSachDDL();
            stoPhong.DataBind();
        }

        protected void dsKPIPhong(object sender, StoreReadDataEventArgs e)
        {
            DanhSachKPIPhong();
        }

        protected void btnCapNhatMTNam_Click(object sender, DirectEventArgs e)
        {
            daChiTieuKPIPhong dKPIP = new daChiTieuKPIPhong();
            dKPIP.KPIP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKPIP.KPIP.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dKPIP.KPIP.IDPhongBan = 0;
            dKPIP.CapNhatMucTieuNam();
            DanhSachKPIPhong();
        }

        [DirectMethod(Namespace = "BangKPIPX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangKPIP)
        {
            if (field=="Chon")
            {
                daChiTieuKPIChoPhong dCP = new daChiTieuKPIChoPhong();
                dCP.KPICP.Nam = int.Parse(slbNam.SelectedItem.Value);
                dCP.KPICP.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
                dCP.KPICP.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);
                dCP.KPICP.IDKPI = id;
                if (Convert.ToBoolean(newvalue))
                {
                    dCP.Them();
                }
                else
                {
                    dCP.Xoa();
                }
                grdKPIP.GetStore().GetById(id).Commit();
                return;
            }
            daChiTieuKPIPhong dKPIP = new daChiTieuKPIPhong();
            dKPIP.KPIP.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKPIP.KPIP.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);// daPhien.NguoiDung.IDDonVi;
            dKPIP.KPIP.IDPhongBan = 0;//daPhien.NguoiDung.IDPhongBan;
            dKPIP.KPIP.IDKPI = id;
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangKPIP.ToString());

            try { dKPIP.KPIP.MucTieuNam = decimal.Parse(node.Property("MucTieuNam").Value.ToString()); } catch { dKPIP.KPIP.MucTieuNam = 0; }

            try { dKPIP.KPIP.MucTieuThang1 = decimal.Parse(node.Property("MucTieuThang1").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang1 = 0; }
            try { dKPIP.KPIP.MucTieuThang2 = decimal.Parse(node.Property("MucTieuThang2").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang2 = 0; }
            try { dKPIP.KPIP.MucTieuThang3 = decimal.Parse(node.Property("MucTieuThang3").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang3 = 0; }
            try { dKPIP.KPIP.MucTieuThang4 = decimal.Parse(node.Property("MucTieuThang4").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang4 = 0; }
            try { dKPIP.KPIP.MucTieuThang5 = decimal.Parse(node.Property("MucTieuThang5").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang5 = 0; }
            try { dKPIP.KPIP.MucTieuThang6 = decimal.Parse(node.Property("MucTieuThang6").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang6 = 0; }
            try { dKPIP.KPIP.MucTieuThang7 = decimal.Parse(node.Property("MucTieuThang7").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang7 = 0; }
            try { dKPIP.KPIP.MucTieuThang8 = decimal.Parse(node.Property("MucTieuThang8").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang8 = 0; }
            try { dKPIP.KPIP.MucTieuThang9 = decimal.Parse(node.Property("MucTieuThang9").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang9 = 0; }
            try { dKPIP.KPIP.MucTieuThang10 = decimal.Parse(node.Property("MucTieuThang10").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang10 = 0; }
            try { dKPIP.KPIP.MucTieuThang11 = decimal.Parse(node.Property("MucTieuThang11").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang11 = 0; }
            try { dKPIP.KPIP.MucTieuThang12 = decimal.Parse(node.Property("MucTieuThang12").Value.ToString()); } catch { dKPIP.KPIP.MucTieuThang12 = 0; }

            dKPIP.ThemSua();
            grdKPIP.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}