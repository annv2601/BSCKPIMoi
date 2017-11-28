using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI;
using DaoBSCKPI.DonVi;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.KetQuaDanhGia
{
    public partial class frmKetQuaDanhGiaDonVi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachDonVi();
            }
        }

        #region Rieng
        private void DanhSachDonVi()
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.IDDonViQuanLy = daPhien.NguoiDung.IDDonVi.Value;
            dMHDV.MHDV.TuNgay = DateTime.Now;
            stoDonVi.DataSource = dMHDV.DanhSach();
            stoDonVi.DataBind();
        }

        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();

            stoThang.DataSource = dTS.DanhSachThang();
            stoThang.DataBind();
        }
        #endregion

        #region Su kien
        protected void DanhSachKetQuaDanhGiaDonVi(object sender, StoreReadDataEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null||slbDonVi.SelectedItem.Value==null)
            {
                return;
            }
            daKetQuaDanhGiaDonVi dDV = new daKetQuaDanhGiaDonVi();
            dDV.DGDV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDV.DGDV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dDV.DGDV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dDV.DGDV.IDPhongBan = 0;

            dDV.DGDV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dDV.KhoiTao();

            stoDGDV.DataSource = dDV.DanhSach();
            stoDGDV.DataBind();
        }

        [DirectMethod(Namespace = "BangKQDGDVX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangKPIP)
        {
            daKetQuaDanhGiaDonVi dDV = new daKetQuaDanhGiaDonVi();
            dDV.DGDV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDV.DGDV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dDV.DGDV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dDV.DGDV.IDPhongBan = 0;
            dDV.DGDV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangKPIP.ToString());

            dDV.DGDV.IDKPI = int.Parse(node.Property("IDKPI").Value.ToString());

            try { dDV.DGDV.KetQua = decimal.Parse(node.Property("KetQua").Value.ToString()); } catch { dDV.DGDV.KetQua = 0; }

            dDV.CapNhat();
            grdDGDV.GetStore().GetById(id).Commit();
        }

        protected void btnGanChoNhanVien_CLick(object sender, DirectEventArgs e)
        {
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null || slbDonVi.SelectedItem.Value == null)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Tham số chọn chưa đủ!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnGanChoNhanVien.ClientID
                });
                return;
            }
            daKetQuaDanhGiaDonVi dKQDV = new daKetQuaDanhGiaDonVi();
            dKQDV.DGDV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dKQDV.DGDV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dKQDV.DGDV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dKQDV.DGDV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dKQDV.GanChoNhanVien();
            X.Msg.Alert("", "Gán kết quả đánh giá sang cho nhân viên của " + slbDonVi.SelectedItem.Text + " hoàn thành").Show();
        }
        #endregion
    }
}