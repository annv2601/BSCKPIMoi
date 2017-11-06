using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.KeHoachDanhGia;
using DaoBSCKPI.DiemCongTru;
using DaoBSCKPI;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.KPI.DiemCongTru
{
    public partial class frmDiemCongTru : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachKeHoachDG();
            }
        }

        #region Rieng
        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoThang.DataSource = dTS.DanhSachThang();
            stoThang.DataBind();

            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();
        }

        private void DanhSachKeHoachDG()
        {
            daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
            stoKHDG.DataSource = dKHDG.DanhSach();
            stoKHDG.DataBind();
        }

        private void DanhSachNhanVienDanhGia()
        {
            if (slbKeHoachDG.SelectedItem.Value != null)
            {
                daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
                dKHDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dKHDG.Nam = int.Parse(slbNam.SelectedItem.Value);
                dKHDG.KHDG.ID = int.Parse(slbKeHoachDG.SelectedItem.Value);
                stoNhanVien.DataSource = dKHDG.DanhSachNhanVien();
                stoNhanVien.DataBind();
            }
        }
        #endregion

        #region Su kien
        protected void DanhSachDCT(object sender, StoreReadDataEventArgs e)
        {
            daDiemCongTru dDCT = new daDiemCongTru();
            dDCT.DCT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDCT.DCT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dDCT.DCT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
            stoDCT.DataSource = dDCT.DanhSach();
            stoDCT.DataBind();
        }

        protected void DanhSachNhanVienTD(object sender, StoreReadDataEventArgs e)
        {
            DanhSachNhanVienDanhGia();
        }

        protected void btnThem_Click(object sender, DirectEventArgs e)
        {
            if(slbNhanVien.SelectedItem.Value==null)
            {
                X.Msg.Alert("","Phải chọn một nhân viên").Show();
                return;
            }
            if(txtDiem.Number==0)
            {
                X.Msg.Alert("","Điểm phải khác 0").Show();
                return;
            }
            if(txtNoiDung.Text.Trim()=="")
            {
                X.Msg.Alert("","Phải có Lý do được cộng điểm hoặc trừ điểm").Show();
                return;
            }
            daDiemCongTru dDCT = new daDiemCongTru();
            dDCT.DCT.ThuTu = 0;
            dDCT.DCT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDCT.DCT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dDCT.DCT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
            dDCT.DCT.NoiDung = txtNoiDung.Text.Trim();
            dDCT.DCT.Diem = Convert.ToDecimal(txtDiem.Number);
            dDCT.DCT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dDCT.ThemSua();
            stoDCT.Reload();

            txtNoiDung.Text = "";
            txtDiem.Number = 0;
        }

        [DirectMethod(Namespace = "BangDCTX")]
        public void Edit(int id, string field, string oldvalue, string newvalue, object BangPB)
        {
            daDiemCongTru dDCT = new daDiemCongTru();            
            dDCT.DCT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dDCT.DCT.Nam = int.Parse(slbNam.SelectedItem.Value);            
            dDCT.DCT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangPB.ToString());
            dDCT.DCT.ThuTu = id;
            dDCT.DCT.IDNhanVien = Guid.Parse(node.Property("IDNhanVien").Value.ToString());
            dDCT.DCT.NoiDung = node.Property("NoiDung").Value.ToString();
            dDCT.DCT.Diem = Convert.ToDecimal(node.Property("Diem").Value.ToString());

            dDCT.ThemSua();
            grdDCT.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}