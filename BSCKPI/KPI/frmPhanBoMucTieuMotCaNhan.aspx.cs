using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.PhanBoMucTieu;
using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI.CongViec;

using BSCKPI.UIHelper;
using Ext.Net;
namespace BSCKPI.KPI
{
    public partial class frmPhanBoMucTieuMotCaNhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                txtThang.Text = Request.QueryString["T"];
                txtNam.Text = Request.QueryString["N"];
                txtIDNhanVien.Text = Request.QueryString["L"];
                stoPhanBoCT.Reload();

                txtNhap.Text = "1";
            }
        }

        #region Thuoc tinh
        private byte Thang
        {
            get { return byte.Parse(txtThang.Text); }
            set { txtThang.Text = value.ToString(); }
        }

        private int Nam
        {
            get { return int.Parse(txtNam.Text); }
            set { txtNam.Text = value.ToString(); }
        }

        private Guid IDNhanVien
        {
            get { return Guid.Parse(txtIDNhanVien.Text); }
            set { txtIDNhanVien.Text = value.ToString(); }
        }
        #endregion

        #region Su kien

        protected void DanhSachPBMTNV(object sender, StoreReadDataEventArgs e)
        {
            daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
            dPBMT.MT.Thang = Thang;
            dPBMT.MT.Nam = Nam;
            dPBMT.MT.IDNhanVien = IDNhanVien;
            dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            dPBMT.KhoiTaoTheoNhanVien();

            daBangDanhGia dBDG = new daBangDanhGia();
            dBDG.Thang = Convert.ToByte(dPBMT.MT.Thang.Value);
            dBDG.Nam = dPBMT.MT.Nam.Value;
            dBDG.IDNhanVien = dPBMT.MT.IDNhanVien.Value;

            stoPhanBoCT.DataSource = dBDG.BangPhanBoNhap();//dPBMT.DanhSach();
            stoPhanBoCT.DataBind();
        }

        [DirectMethod(Namespace = "BangPBMTCTX")]
        public void EditCT(int id, string field, string oldvalue, string newvalue, object BangPB)
        {

            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangPB.ToString());

            switch (node.Property("LoaiChiTieu").Value.ToString())
            {
                case "1":
                    daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
                    dPBMT.MT.Thang = Thang;
                    dPBMT.MT.Nam = Nam;
                    dPBMT.MT.IDNhanVien = IDNhanVien;
                    dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.Value.ToString();
                    dPBMT.MT.IDKPI = int.Parse(node.Property("ID").Value.ToString());
                    try
                    {
                        dPBMT.MT.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());
                    }
                    catch { dPBMT.MT.TrongSo = 0; }
                    try
                    {
                        dPBMT.MT.MucTieu = decimal.Parse(node.Property("MucTieu").Value.ToString());
                    }
                    catch { dPBMT.MT.MucTieu = 0; }

                    dPBMT.ThemSua();
                    break;
                case "2":
                    daPBNhiemVuTrongTam dPBNV = new daPBNhiemVuTrongTam();
                    dPBNV.PBNV.Thang = Thang;
                    dPBNV.PBNV.Nam = Nam;
                    dPBNV.PBNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.Value.ToString();
                    dPBNV.PBNV.IDNhiemVu = int.Parse(node.Property("ID").Value.ToString());
                    try
                    {
                        dPBNV.PBNV.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());
                    }
                    catch { dPBNV.PBNV.TrongSo = 0; }
                    dPBNV.CapNhat();
                    break;
            }

            grdPBChiTieu.GetStore().GetById(id).Commit();
        }
        #endregion
    }
}