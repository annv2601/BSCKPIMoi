using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DonVi;
using DaoBSCKPI.Database.DonVi;
using System.Data;
using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.MoHinhToChuc.UC
{
    public partial class ucChuyenDonVi : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachDonVi(daPhien.NguoiDung.IDDonVi.Value, DateTime.Now);
            }
        }

        #region Thuoc tinh
        public Guid IDNhanVien
        {
            get { return Guid.Parse(txtIDNhanVien.Text); }
            set { txtIDNhanVien.Text = value.ToString(); }
        }

        public string TenNhanVien
        {
            set { lblTenNhanVien.Text = value; }
        }

        public string NgaySinh
        {
            set { lblNgaySinh.Text = value; }
        }

        public string DonViCu
        {
            set { lblDonViCu.Text = value; }
        }

        public string PhongBanCu
        {
            set { lblPhongBanCu.Text = value; }
        }

        public int IDDonViMoi
        {
            get { return int.Parse(slbDonViCDV.SelectedItem.Value); }
        }

        public int IDPhongBanMoi
        {
            get { return int.Parse(slbPhongBanCDV.SelectedItem.Value); }
        }
        #endregion

        #region Chuc nang
        protected void DanhSachPhongBanCDV(object sender, StoreReadDataEventArgs e)
        {
            daMoHinhPhongBan dMHPB = new daMoHinhPhongBan();
            dMHPB.MHPB.TuNgay = DateTime.Now;
            dMHPB.MHPB.IDDonVi = int.Parse(slbDonViCDV.SelectedItem.Value);
            stoPhongCDV.DataSource = dMHPB.DanhSachDDL();
            stoPhongCDV.DataBind();
        }
        
        private void DanhSachDonVi(int IDDVQL, DateTime Ngay)
        {
            daMoHinhDonVi dMH = new daMoHinhDonVi();
            DataTable dt= dMH.DanhSachMHDV(IDDVQL, Ngay);
            stoDonVi.DataSource = dt;
            stoDonVi.DataBind();
        }

        public void DanhSachGanDonVi(DataTable dt)
        {
            stoDonVi.DataSource = dt;
            stoDonVi.DataBind();
        }

        public void KhoiTao()
        {
            slbDonViCDV.SelectedItems.Clear();
            slbDonViCDV.UpdateSelectedItems();

            slbPhongBanCDV.SelectedItems.Clear();
            slbPhongBanCDV.UpdateSelectedItems();
        }
        #endregion
    }
}