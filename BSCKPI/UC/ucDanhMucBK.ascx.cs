using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DanhMucBSCKPI;

using Ext.Net;
namespace BSCKPI.UC
{
    public partial class ucDanhMucBK : System.Web.UI.UserControl
    {
        #region Thuoc tinh
        public int IDDanhMuc
        {
            get { return Convert.ToInt32(txtID.Text); }
            set { txtID.Text = value.ToString(); }
        }

        public string Ma
        {
            get { return txtMa.Text.Trim(); }
            set { txtMa.Text = value; }
        }

        public string TenTat
        {
            get { return txtTenTat.Text.Trim(); }
            set { txtTenTat.Text = value.ToString(); }
        }

        public string Ten
        {
            get { return txtTen.Text.Trim(); }
            set { txtTen.Text = value; }
        }

        public string GhiChu
        {
            get { return txtGhiChu.Text.Trim(); }
            set { txtGhiChu.Text = value; }
        }

        public int IDNhom
        {
            get { return int.Parse(slbNhom.SelectedItem.Value); }
            set
            {
                slbNhom.SelectedItems.Clear();
                if(value<=0)
                {
                    slbNhom.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbNhom.SelectedItems.Add(new Ext.Net.ListItem { Value=value.ToString(), Mode = ParameterMode.Raw });
                }
                slbNhom.UpdateSelectedItems();
            }
        }

        public decimal STTsx
        {
            get { return Convert.ToDecimal(txtThuTu.Number); }
            set { txtThuTu.Number = Convert.ToDouble(value); }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachNhom();
            }
        }

        #region Chuc nang
        private void DanhSachNhom()
        {
            daNhomDanhMucBK dNhom = new daNhomDanhMucBK();
            stoNhom.DataSource = dNhom.DanhSach();
            stoNhom.DataBind();
        }

        public void ThaoTacNhom(Boolean rMoDong)
        {
            slbNhom.Disable(rMoDong);
        }

        public void KhoiTao()
        {
            IDDanhMuc = 0;
            IDNhom = 0;
            Ma = "";
            TenTat = "";
            Ten = "";
            STTsx = 1;
            GhiChu = "";
        }
        #endregion
    }
}