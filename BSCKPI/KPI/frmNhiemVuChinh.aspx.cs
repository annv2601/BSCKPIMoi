using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DaoBSCKPI;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI.CongViec;
using DaoBSCKPI.Khac;
using DaoBSCKPI.DonVi;

using Ext.Net;
using BSCKPI.UIHelper;
namespace BSCKPI.KPI
{
    public partial class frmNhiemVuChinh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachDonVi(DateTime.Now, daPhien.NguoiDung.IDDonVi.Value);
                ucNV1.KhoiTao();

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
                    btnCapNhatNV.Visible = true;
                    txtNhapNVC.Text = "1";
                }
                else
                {
                    btnCapNhatNV.Visible = false;
                    txtNhapNVC.Text = "0";
                }
            }
            else
            {
                btnCapNhatNV.Visible = false;
                txtNhapNVC.Text = "0";
            }

            //Quyen Xoa
            bool _Quyen = false;
            int i;
            for (i = 0; i < dNDQ.lstQuyen.Count; i++)
            {
                if (dNDQ.lstQuyen[i].IDQuyenTruyNhap == (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Duyệt)
                {
                    _Quyen = true;
                    break;
                }
            }
            mnuitmXoa.Visible = _Quyen;

            if (dNDQ.lstQuyen[0].IDQuyenTruyNhap == (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Tất_Cả)
            {
                mnuitmXoa.Visible = true;
            }

        }

        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoThang.DataSource = dTS.DanhSachThang();
            stoThang.DataBind();

            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();
        }

        private void DanhSachNhanVienNhap(int rIDDonVi, int rIDphongBan)
        {
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTTNV.TTNV.IDDonVi = rIDDonVi;
            dTTNV.TTNV.IDPhongBan = rIDphongBan;

            ucNV1.DanhSachNhanVien(dTTNV.DanhSach());
        }

        private void DanhSachDonVi(DateTime rNgay, int rIDDVQL)
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = rNgay;
            dMHDV.MHDV.IDDonViQuanLy = rIDDVQL;
            if (daPhien.VaiTro <= (int)DaoBSCKPI.NguoiDung.daDangNhap.eVaiTro.Quản_lý_Phòng)
            {
                daDonVi dDV = new daDonVi();
                dDV.DV.ID = daPhien.NguoiDung.IDDonVi.Value;
                stoDonVi.DataSource = dDV.DanhSachDuyNhat();
            }
            else
            {
                stoDonVi.DataSource = dMHDV.DanhSach();
            }
            stoDonVi.DataBind();
        }

        private void DanhSachNhiemVuChinh(int rIDDonVi, int rIDphongBan)
        {
            daNhiemVuTrongTam dNVu = new daNhiemVuTrongTam();
            dNVu.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dNVu.Nam = int.Parse(slbNam.SelectedItem.Value);
            dNVu.IDDonVi = rIDDonVi;
            dNVu.IDPhongBan = rIDphongBan;

            stoNV.DataSource = dNVu.DanhSach();
            stoNV.DataBind();

            grdNV.Title = "Nhiệm vụ trọng tâm " + dNVu.Thang.ToString() + "/" + dNVu.Nam.ToString();
        }
        #endregion

        #region SuKien
        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            slbPhongBan.SelectedItems.Clear();
            slbPhongBan.UpdateSelectedItems();
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = DateTime.Now;
            dMHDV.MHDV.IDDonViQuanLy = int.Parse(slbDonVi.SelectedItem.Value);
            if (daPhien.VaiTro <= (int)DaoBSCKPI.NguoiDung.daDangNhap.eVaiTro.Quản_lý_Phòng)
            {
                daPhongBan dPB = new daPhongBan();
                dPB.PB.ID = daPhien.NguoiDung.IDPhongBan.Value;
                if (dPB.PB.ID != 0)
                {
                    stoPhong.DataSource = dPB.DanhSachDuyNhat();
                }
                else
                {
                    daDonVi dDV = new daDonVi();
                    dDV.DV.ID = daPhien.NguoiDung.IDDonVi.Value;
                    stoPhong.DataSource = dDV.DanhSachDuyNhat();
                }
            }
            else
            {
                stoPhong.DataSource = dMHDV.DanhSachGopVoiPhongBan();
            }
            stoPhong.DataBind();
        }

        protected void DanhSachNVTTam(object sender, StoreReadDataEventArgs e)
        {
            if (slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null || slbDonVi.SelectedItem.Value==null || slbPhongBan.SelectedItem.Value==null)
            {
                return;
            }

            int _IDDV,_IDPB;
            _IDDV = int.Parse(slbDonVi.SelectedItem.Value);
            _IDPB = int.Parse(slbPhongBan.SelectedItem.Value);
            if (_IDPB < 0)
            {
                _IDPB = 0 - _IDPB;
            }
            else
            {
                _IDDV = _IDPB;
                _IDPB = 0;
            }
            DanhSachNhanVienNhap(_IDDV,_IDPB);
            DanhSachNhiemVuChinh(_IDDV, _IDPB);
        }

        protected void btnCapNhatNV_Click(object sender, DirectEventArgs e)
        {
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn Tháng và Năm!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
                return;
            }
            daNhiemVuTrongTam dNVu = new daNhiemVuTrongTam();
            dNVu.NVu.ID = ucNV1.IDNVChinh;
            dNVu.NVu.IDNhanVien = ucNV1.IDNhanVien;
            dNVu.NVu.TenCongViec = ucNV1.TenCongViec;
            dNVu.NVu.MucTieu = ucNV1.MucTieu;
            dNVu.NVu.IDDonViTinh = ucNV1.DonViTinh;
            dNVu.NVu.IDTanSuatDo = ucNV1.TanSuatDo;
            dNVu.NVu.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dNVu.NVu.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dNVu.NVu.Nam = int.Parse(slbNam.SelectedItem.Value);
            dNVu.NVu.IDXuHuongYeuCau = ucNV1.XuHuongYeuCau;
            dNVu.NVu.Ma = ucNV1.Ma;
            if (dNVu.NVu.ID==0)
            {
                dNVu.NVu.IDTrangThai = (int)daTrangThai.eTrangThai.Nhập;
            }
            else
            {
                dNVu.NVu.IDTrangThai = (int)daTrangThai.eTrangThai.Sửa;
            }
            if(dNVu.NVu.TenCongViec=="")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Tên công việc khổng thể là trống !",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
                });
                return;
            }
            dNVu.ThemSua();
            stoNV.Reload();
            ucNV1.KhoiTao();
        }

        protected void grdNV_Select(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            daNhiemVuTrongTam dNVu = new daNhiemVuTrongTam();
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    dNVu.NVu.ID = int.Parse(row["ID"]);
                }
                catch
                {
                    dNVu.NVu.ID = 0;
                }
            }
            if (dNVu.NVu.ID != 0)
            {
                dNVu.NVu.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dNVu.NVu.Nam = int.Parse(slbNam.SelectedItem.Value);
                dNVu.ThongTin();
                ucNV1.IDNVChinh = dNVu.NVu.ID;
                ucNV1.IDNhanVien = dNVu.NVu.IDNhanVien.Value;
                ucNV1.TenCongViec = dNVu.NVu.TenCongViec;
                ucNV1.MucTieu = dNVu.NVu.MucTieu.Value;
                ucNV1.TanSuatDo = dNVu.NVu.IDTanSuatDo.Value;
                ucNV1.DonViTinh = dNVu.NVu.IDDonViTinh.Value;
                ucNV1.TrangThai = dNVu.NVu.IDTrangThai.Value;
                ucNV1.XuHuongYeuCau = dNVu.NVu.IDXuHuongYeuCau.Value;
                ucNV1.Ma = dNVu.NVu.Ma;
            }
        }


        protected void mnuitmXoa_Click(object sender, DirectEventArgs e)
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
                    txtIDNV.Text = row["ID"].ToString();
                }
                catch
                {
                    txtIDNV.Text = "0";
                }
            }
            if (txtIDNV.Text=="0")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải chọn một công việc trước khi xóa",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                X.MessageBox.Confirm("Xóa Công việc", "Anh chị có chắc chắn muốn XÓA Công việc này không?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoYes()",
                        Text = "Đồng ý Xóa"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "App.direct.DoNo()",
                        Text = "Hủy bỏ"
                    }
                }).Show();
            }
        }

        [DirectMethod]
        public void DoYes()
        {
            daNhiemVuTrongTam dNV = new daNhiemVuTrongTam();
            dNV.NVu.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dNV.NVu.Nam = int.Parse(slbNam.SelectedItem.Value);
            dNV.NVu.ID = int.Parse(txtIDNV.Text);
            dNV.Xoa();
            stoNV.Reload();
            txtIDNV.Text = "0";

            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Hoàn thành",
                Message = "Đã XÓA công việc thành công",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
            });
        }

        [DirectMethod]
        public void DoNo()
        {
            txtIDNV.Text = "0";
        }
        #endregion
    }
}