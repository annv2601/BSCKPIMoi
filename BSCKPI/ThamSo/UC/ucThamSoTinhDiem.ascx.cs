using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DanhMucBSCKPI;

using Ext.Net;
namespace BSCKPI.ThamSo.UC
{
    public partial class ucThamSoTinhDiem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachChon();
            }
        }

        public int IDThamSo
        {
            get { return int.Parse(txtID.Text); }
            set { txtID.Text = value.ToString(); }
        }

        public string Ten
        {
            get { return txtTen.Text.Trim(); }
            set { txtTen.Text = value; }
        }

        public int IDXuHuong
        {
            get
            {
                return slbXuHuong.SelectedItem.Value == null ? 0 : int.Parse(slbXuHuong.SelectedItem.Value);
            }
            set
            {
                slbXuHuong.SelectedItems.Clear();
                if(value<=0)
                {
                    slbXuHuong.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbXuHuong.SelectedItems.Add(new Ext.Net.ListItem { Value=value.ToString(), Mode = ParameterMode.Raw });
                }
                slbXuHuong.UpdateSelectedItems();
            }
        }

        public decimal CanDuoi
        {
            get { return Convert.ToDecimal(txtCanDuoi.Number); }
            set { txtCanDuoi.Number = Convert.ToDouble(value); }
        }

        public decimal CanTren
        {
            get { return Convert.ToDecimal(txtCanTren.Number); }
            set { txtCanTren.Number = Convert.ToDouble(value); }
        }

        public decimal DiemCanDuoi
        {
            get { return Convert.ToDecimal(txtDiemCanDuoi.Number); }
            set { txtDiemCanDuoi.Number = Convert.ToDouble(value); }
        }

        public decimal DiemCanTren
        {
            get { return Convert.ToDecimal(txtDiemCanTren.Number); }
            set { txtDiemCanTren.Number = Convert.ToDouble(value); }
        }

        public int IDNhomThamSo
        {
            get
            {
                return slbNhomThamSo.SelectedItem.Value == null ? 0 : int.Parse(slbNhomThamSo.SelectedItem.Value);
            }
            set
            {
                slbNhomThamSo.SelectedItems.Clear();
                if (value <= 0)
                {
                    slbNhomThamSo.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbNhomThamSo.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = ParameterMode.Raw });
                }
                slbNhomThamSo.UpdateSelectedItems();
            }
        }

        public int IDGiaTri
        {
            get
            {
                return slbGiaTri.SelectedItem.Value == null ? 0 : int.Parse(slbGiaTri.SelectedItem.Value);
            }
            set
            {
                slbGiaTri.SelectedItems.Clear();
                if (value <= 0)
                {
                    slbGiaTri.SelectedItems.Add(new Ext.Net.ListItem { Text = string.Empty, Mode = ParameterMode.Raw });
                }
                else
                {
                    slbGiaTri.SelectedItems.Add(new Ext.Net.ListItem { Value = value.ToString(), Mode = ParameterMode.Raw });
                }
                slbGiaTri.UpdateSelectedItems();
            }
        }

        public void KhoiTao()
        {
            IDThamSo = 0;
            Ten = "";
            IDXuHuong = 0;
            CanDuoi = 0;
            CanTren = 0;
            DiemCanDuoi = 0;
            DiemCanTren = 0;
            IDNhomThamSo = 0;
            IDGiaTri = 0;
        }

        public void DanhSachChon()
        {
            daDanhMucBK dDM = new daDanhMucBK();
            stoXuHuong.DataSource = dDM.DanhSach((int)daNhomDanhMucBK.eNhom.Xu_Hướng);
            stoXuHuong.DataBind();

            stoNhomTS.DataSource = dDM.DanhSach((int)daNhomDanhMucBK.eNhom.Tham_số_Tính_điểm);
            stoNhomTS.DataBind();
        }

        protected void DanhSachGiaTri(object sender, StoreReadDataEventArgs e)
        {
            daDanhMucBK dDM = new daDanhMucBK();
            stoGiaTri.DataSource = dDM.DanhSach(int.Parse(slbNhomThamSo.SelectedItem.Value));
            stoGiaTri.DataBind();
        }
    }
}