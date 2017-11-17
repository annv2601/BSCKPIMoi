using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.DanhMucBSCKPI;

using Ext.Net;
namespace BSCKPI.ThamSo.UC
{
    public partial class ucPhuongThucDanhGia : System.Web.UI.UserControl
    {
        #region Thuoc tinh
        public int IDPTDG
        {
            get { return Convert.ToInt32(txtID.Text); }
            set { txtID.Text = value.ToString(); }
        }

        public int IDTanSuatDo
        {
            get
            {
                return cboDonViTinh.SelectedItem.Value == null ? 0 : int.Parse(cboDonViTinh.SelectedItem.Value);
            }
            set
            {
                cboDonViTinh.SelectedItems.Clear();
                if (value <= 0)
                {
                    cboDonViTinh.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    cboDonViTinh.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = ParameterMode.Raw });
                }
                cboDonViTinh.UpdateSelectedItems();
            }
        }

        public int IDPhuongThuc
        {
            get
            {
                return cboPhuongThuc.SelectedItem.Value == null ? 0 : int.Parse(cboPhuongThuc.SelectedItem.Value);
            }
            set
            {
                cboPhuongThuc.SelectedItems.Clear();
                if (value <= 0)
                {
                    cboPhuongThuc.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    cboPhuongThuc.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = ParameterMode.Raw });
                }
                cboPhuongThuc.UpdateSelectedItems();
            }
        }

        public DateTime TuNgay
        {
            get {return txtTuNgay.SelectedDate; }
            set { txtTuNgay.SelectedDate = value; }
        }

        public DateTime DenNgay
        {
            get { return txtDenNgay.SelectedDate; }
            set { txtDenNgay.SelectedDate = value; }
        }

        public decimal GiaTriToiDa
        {
            get { return Convert.ToDecimal(txtGiaTriToiDa.Number); }
            set { txtGiaTriToiDa.Number = Convert.ToDouble(value); }
        }

        public decimal GiaTriToiThieu
        {
            get {
                try
                {
                    return Convert.ToDecimal(txtGiaTriToiThieu.Number);
                }
                catch
                {
                    return 0;
                }
            }
            set { txtGiaTriToiThieu.Number = Convert.ToDouble(value); }
        }

        public decimal ThuTu
        {
            get { return Convert.ToDecimal(txtThuTu.Number); }
            set { txtThuTu.Number = Convert.ToDouble(value); }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Đơn_Vị_Tính);
                DanhSachDanhMuc((int)daNhomDanhMucBK.eNhom.Phương_Thức);
            }
        }

        #region Chuc nang
        private void DanhSachDanhMuc(int rNhomDM)
        {
            daDanhMucBK dDM = new daDanhMucBK();
            DataTable dt = dDM.DanhSach(rNhomDM);
            switch (rNhomDM)
            {
                case (int)daNhomDanhMucBK.eNhom.Phương_Thức:
                    stoPhuongThhuc.DataSource = dt;
                    stoPhuongThhuc.DataBind();
                    break;
                case (int)daNhomDanhMucBK.eNhom.Đơn_Vị_Tính:
                    stoDonViTinh.DataSource = dt;
                    stoDonViTinh.DataBind();
                    break;
            }
        }

        public void DanhSachPhuongThuc()
        {
            daDanhMucBK dDM = new daDanhMucBK();
            stoPhuongThhuc.DataSource = dDM.DanhSach((int)daNhomDanhMucBK.eNhom.Phương_Thức);
            stoPhuongThhuc.DataBind();
        }

        public void KhoiTao()
        {
            IDPTDG = 0;
            IDTanSuatDo = 0;
            IDPhuongThuc = 0;
            GiaTriToiDa = 0;
            GiaTriToiThieu = 0;
            ThuTu = 1;
            DateTime _Ngay = DateTime.Now;
            TuNgay = DateTime.Parse(_Ngay.Month.ToString()+"/01/"+_Ngay.Year.ToString());
            DenNgay = DateTime.Parse("12/31/" + (_Ngay.Year+1).ToString());
        }
        #endregion

        #region Su kien
        
        #endregion
    }
}