using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI.ThamSoTinhDiem;
using DaoBSCKPI.DanhMucBSCKPI;

using BSCKPI.UIHelper;
using Ext.Net;
namespace BSCKPI.ThamSo
{
    public partial class frmPhuongThucDanhGia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                stoPTDG.Reload();
                CheckQuyen(int.Parse(Request.QueryString["CN"]));
            }
        }

        #region Rieng
        #endregion

        #region Su kien
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
                    btnThemPTDG.Visible = true;
                    btnThemQuyCach.Visible = true;
                }
                else
                {
                    btnThemPTDG.Visible = false;
                    btnThemQuyCach.Visible = false;
                }
            }
            else
            {
                btnThemPTDG.Visible = false;
                btnThemQuyCach.Visible = false;
            }

            //Quyen Sua
            bool _Quyen = false;
            int i;
            for(i=0; i<dNDQ.lstQuyen.Count;i++)
            {
                if(dNDQ.lstQuyen[i].IDQuyenTruyNhap== (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Sửa)
                {
                    _Quyen = true;
                    break;
                }
            }
            mnuiThongTin.Visible = _Quyen;

            _Quyen = false;
            for (i = 0; i < dNDQ.lstQuyen.Count; i++)
            {
                if (dNDQ.lstQuyen[i].IDQuyenTruyNhap == (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Xóa)
                {
                    _Quyen = true;
                    break;
                }
            }
            mnuiXoa.Visible = _Quyen;

            if(dNDQ.lstQuyen[0].IDQuyenTruyNhap== (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Tất_Cả)
            {
                mnuiThongTin.Visible = true;
                mnuiXoa.Visible = true;
            }

        }

        protected void DanhSachPTDG(object sender, StoreReadDataEventArgs e)
        {
            daPhuongThucDanhGiaKetQuaNVTT dPT = new daPhuongThucDanhGiaKetQuaNVTT();
            stoPTDG.DataSource = dPT.DanhSach();
            stoPTDG.DataBind();
        }

        protected void mnuiThongTin_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    ucPT1.IDPTDG = int.Parse(row["ID"].ToString());
                    ucPT1.IDTanSuatDo = int.Parse(row["IDTanSuatDo"].ToString());
                    ucPT1.IDPhuongThuc = int.Parse(row["IDPhuongThuc"].ToString());
                    ucPT1.TuNgay = DateTime.Parse(row["TuNgay"].ToString());
                    ucPT1.DenNgay = DateTime.Parse(row["DenNgay"].ToString());
                    ucPT1.GiaTriToiThieu = decimal.Parse(row["GiaTriToiThieu"].ToString());
                    ucPT1.GiaTriToiDa = decimal.Parse(row["GiaTriToiDa"].ToString());
                    ucPT1.ThuTu = int.Parse(row["ThuTu"].ToString());
                }
                catch
                {
                    ucPT1.IDPTDG = 0;
                }
            }

            if (ucPT1.IDPTDG == 0)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn 1 quy cách đánh giá trước khi chỉnh sửa!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                wPTDG.Show();
            }
        }

        protected void mnuiXoa_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            daPhuongThucDanhGiaKetQuaNVTT dPT = new daPhuongThucDanhGiaKetQuaNVTT();
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    dPT.PT.ID = int.Parse(row["ID"].ToString());
                    dPT.PT.IDPhuongThuc = int.Parse(row["IDPhuongThuc"].ToString());
                }
                catch
                {
                    dPT.PT.ID = 0;
                }
            }

            if (dPT.PT.ID == 0)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn 1 quy cách đánh giá trước khi Xóa!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                if (dPT.KiemTraXoa())
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Thông báo",
                        Message = "Quy cách này đã được nhập liệu. Không thể xóa quy cách này được!",
                        Buttons = MessageBox.Button.OK,
                        Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                    });
                }
                else
                {
                    dPT.Xoa();
                    stoPTDG.Reload();
                }
            }
        }

        protected void btnThemPTDG_Click(object sender, DirectEventArgs e)
        {
            ucPT1.KhoiTao();
            ucPT1.DanhSachPhuongThuc();
            wPTDG.Show();
        }

        protected void btnCapNhatPTDG_Click(object sender, DirectEventArgs e)
        {
            daPhuongThucDanhGiaKetQuaNVTT dPT = new daPhuongThucDanhGiaKetQuaNVTT();
            dPT.PT.ID = ucPT1.IDPTDG;
            dPT.PT.IDTanSuatDo = ucPT1.IDTanSuatDo;
            dPT.PT.IDPhuongThuc = ucPT1.IDPhuongThuc;
            dPT.PT.TuNgay = ucPT1.TuNgay;
            dPT.PT.DenNgay = ucPT1.DenNgay;
            dPT.PT.GiaTriToiThieu = ucPT1.GiaTriToiThieu;
            dPT.PT.GiaTriToiDa = ucPT1.GiaTriToiDa;
            dPT.PT.ThuTu = ucPT1.ThuTu;

            dPT.ThemSua();
            ucPT1.KhoiTao();
        }

        protected void btnThemQuyCach_Click(object sender, DirectEventArgs e)
        {
            ucDM1.KhoiTao();
            ucDM1.ThaoTacNhom(true);
            ucDM1.IDNhom = (int)daNhomDanhMucBK.eNhom.Phương_Thức;
            wDanhMuc.Show();
        }

        protected void btnCapNhatDM_Click(object sender, DirectEventArgs e)
        {
            daDanhMucBK dDMBK = new daDanhMucBK();
            dDMBK.DMB.ID = ucDM1.IDDanhMuc;
            dDMBK.DMB.Ma = ucDM1.Ma;
            dDMBK.DMB.TenTat = ucDM1.TenTat;
            dDMBK.DMB.Ten = ucDM1.Ten;
            dDMBK.DMB.GhiChu = ucDM1.GhiChu;
            dDMBK.DMB.STTsx = ucDM1.STTsx;
            dDMBK.DMB.Nhom = ucDM1.IDNhom;
            dDMBK.DMB.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            dDMBK.ThemSua();
            ucDM1.KhoiTao();
            
        }
        #endregion
    }
}