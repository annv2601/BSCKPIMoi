using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.DonVi;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI;
using DaoBSCKPI.NguoiDung;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.MoHinhToChuc
{
    public partial class frmNhanVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                daPhien.KiemTraXacThuc();

                DanhSachThangNam();
                DanhSachDonVi(DateTime.Now,daPhien.NguoiDung.IDDonVi.Value);
                //DanhSachDonViPhanCap(DateTime.Now, daPhien.NguoiDung.IDDonVi.Value);

                CheckQuyen(int.Parse(Request.QueryString["CN"]));

                //dat san
                DateTime _ngay = DateTime.Now;
                if (_ngay.Day < 15)
                {
                    _ngay = _ngay.AddMonths(-1);
                }
                daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                slbDonVi.SelectedItem.Value = daPhien.NguoiDung.IDDonVi.Value.ToString();
                stoPhong.Reload();
                if (daPhien.NguoiDung.IDPhongBan.Value > 0)
                {
                    slbPhongBan.SelectedItem.Value = (0 - daPhien.NguoiDung.IDPhongBan.Value).ToString();
                }
                else
                {
                    slbPhongBan.SelectedItem.Value = daPhien.NguoiDung.IDDonVi.Value.ToString();
                }
                slbPhongBan.UpdateSelectedItems();

                slbThang.SelectedItem.Value = _ngay.Month.ToString();
                slbNam.SelectedItem.Value = _ngay.Year.ToString();

                dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
                dTTNV.TTNV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
                dTTNV.TTNV.IDPhongBan = daPhien.NguoiDung.IDPhongBan.Value;
                dTTNV.TTNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

                dTTNV.KhoiTao(); //Kiem tra neu chua co thi khoi tao luon

                stoNhanVien.DataSource = dTTNV.DanhSach();
                stoNhanVien.DataBind();
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
                if (dNDQ.lstQuyen[0].IDQuyenTruyNhap.Value >= (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Nhập && dNDQ.lstQuyen[0].IDQuyenTruyNhap.Value != (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Gán_Truy_nhập)
                {
                    btnThemMoiNhanVien.Visible = true;
                }
                else
                {
                    btnThemMoiNhanVien.Visible = false;
                }
            }
            else
            {
                btnThemMoiNhanVien.Visible = false;
            }

            //Quyen Sua
            bool _Quyen = false;
            int i;
            for (i = 0; i < dNDQ.lstQuyen.Count; i++)
            {
                if (dNDQ.lstQuyen[i].IDQuyenTruyNhap == (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Sửa)
                {
                    _Quyen = true;
                    break;
                }
            }
            mnuitemThongTin.Visible = _Quyen;
            mnuitmChuyenDonVi.Visible = _Quyen;

            _Quyen = false;
            for (i = 0; i < dNDQ.lstQuyen.Count; i++)
            {
                if (dNDQ.lstQuyen[i].IDQuyenTruyNhap == (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Xóa)
                {
                    _Quyen = true;
                    break;
                }
            }
            mnuitemNhanVienXoa.Visible = _Quyen;

            _Quyen = false;
            for (i = 0; i < dNDQ.lstQuyen.Count; i++)
            {
                if (dNDQ.lstQuyen[i].IDQuyenTruyNhap == (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Gán_Truy_nhập)
                {
                    _Quyen = true;
                    break;
                }
            }
            mnuitmQuanLyTruyNhap.Visible = _Quyen;

            if (dNDQ.lstQuyen[0].IDQuyenTruyNhap == (int)DaoBSCKPI.NguoiDung.daQuyenTruyNhap.eQuyen.Tất_Cả)
            {
                mnuitemNhanVienXoa.Visible = true;
                mnuitmChuyenDonVi.Visible = true;
                mnuitemThongTin.Visible = true;
                mnuitmQuanLyTruyNhap.Visible = true;
            }

        }

        private Guid IDNhanVienTruyNhap
        {
            get { return Session["IDNhanVienTruyNhapQLy"]==null?Guid.Empty:(Guid)Session["IDNhanVienTruyNhapQLy"]; }
            set { Session["IDNhanVienTruyNhapQLy"] = value; }
        }

        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoThang.DataSource = dTS.DanhSachThang();
            stoThang.DataBind();

            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();            
        }

        private void DanhSachDonVi(DateTime rNgay,int rIDDVQL)
        {
            DataTable dt;
            if (daPhien.VaiTro<=(int)daDangNhap.eVaiTro.Quản_lý_Phòng)
            {
                daDonVi dDV = new daDonVi();
                dDV.DV.ID = daPhien.NguoiDung.IDDonVi.Value;
                dt = dDV.DanhSachDuyNhat();

                stoDonVi.DataSource = dt;
                stoDonVi.DataBind();

                DataTable dt2 = dt;
                ucCDV1.DanhSachGanDonVi(dt2);
            }
            else
            {
                daMoHinhDonVi dMHDV = new daMoHinhDonVi();
                dMHDV.MHDV.TuNgay = rNgay;
                dMHDV.MHDV.IDDonViQuanLy = rIDDVQL;
                dt = dMHDV.DanhSach();
                //dt.Columns["IDDonVi"].ColumnName = "ID";
                //dt.Rows.Add(999999, "--- Hiện cả đơn vị dưới ---", 0, 9999, DateTime.Now, DateTime.Now, "", DateTime.Now, "");

                stoDonVi.DataSource = dt;
                stoDonVi.DataBind();

                DataTable dt2 = dt;
                ucCDV1.DanhSachGanDonVi(dt2);
            }
        }

        private void DanhSachDonViPhanCap(DateTime rNgay, int rIDDVQL)
        {
            daMoHinhDonVi dMH = new daMoHinhDonVi();
            DataTable dt = dMH.DanhSachMHDV(rIDDVQL, rNgay);
            DataTable dt2 = dt;
            stoDonVi.DataSource = dt;
            stoDonVi.DataBind();

            ucCDV1.DanhSachGanDonVi(dt2);
        }

        private Ext.Net.Window TaoCuaSo(string rTieuDe, string Url)
        {
            Ext.Net.Window _CSo = new Ext.Net.Window();
            ComponentLoader _Loader = new ComponentLoader();
            _Loader.Url = Url; //daPhien.LayDiaChiURL(Url);
            _Loader.Mode = LoadMode.Frame;
            _Loader.LoadMask.ShowMask = true;
            _Loader.LoadMask.Msg = "Đang xử lý .....";

            _CSo.ID = "wQLTruyNhap";
            _CSo.Title = rTieuDe;
            _CSo.TitleAlign = TitleAlign.Center;
            _CSo.AutoRender = true;
            _CSo.Maximizable = false;
            _CSo.Icon = Icon.DiskMultiple;
            _CSo.Width = 640;
            _CSo.Height = 480;
            _CSo.Loader = _Loader;

            return _CSo;
        }
        #endregion

        #region Su Kien Danh Sach
        protected void DanhSachNhanVien(object sender, StoreReadDataEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null||slbDonVi.SelectedItem.Value==null||slbPhongBan.SelectedItem.Value==null)
            {
                return;
            }
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTTNV.TTNV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dTTNV.TTNV.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);
            if(dTTNV.TTNV.IDPhongBan<0)
            {
                dTTNV.TTNV.IDPhongBan = 0 - dTTNV.TTNV.IDPhongBan;
            }
            else
            {
                dTTNV.TTNV.IDDonVi = int.Parse(slbPhongBan.SelectedItem.Value);
                dTTNV.TTNV.IDPhongBan = 0;
            }
            dTTNV.TTNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            dTTNV.KhoiTao(); //Kiem tra neu chua co thi khoi tao luon

            stoNhanVien.DataSource = dTTNV.DanhSach();
            stoNhanVien.DataBind();
        }

        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            if (slbDonVi.SelectedItem.Value== "999999")
            {
                DanhSachDonViPhanCap(DateTime.Now, daPhien.NguoiDung.IDDonVi.Value);
                slbDonVi.SelectedItems.Clear();
                slbDonVi.UpdateSelectedItems();

                slbPhongBan.SelectedItems.Clear();
                slbPhongBan.UpdateSelectedItems();
                return;
            }
            slbPhongBan.SelectedItems.Clear();
            slbPhongBan.UpdateSelectedItems();
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = DateTime.Now;
            dMHDV.MHDV.IDDonViQuanLy = int.Parse(slbDonVi.SelectedItem.Value);
            if (daPhien.VaiTro <= (int)daDangNhap.eVaiTro.Quản_lý_Phòng)
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
        #endregion

        #region Su kien Nut bam
        protected void btnThemMoiNhanVien_Click(object sender, DirectEventArgs e)
        {
            if(slbThang.SelectedItem.Value==null||slbNam.SelectedItem.Value==null||slbDonVi.SelectedItem.Value==null||slbPhongBan.SelectedItem.Value==null)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị Đơn vị và phòng ban trước",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnThemMoiNhanVien.ClientID,
                    Fn = new JFunction { Fn = "showResult" }
                });
                return;
            }
            ucNV1.KhoiTao();
            wNhanVien.Title = "Thêm nhân viên mới";
            wNhanVien.Show();
        }

        protected void btnCapNhatNhanVien_Click(object sender, DirectEventArgs e)
        {
            daNhanVien dNV = new daNhanVien();
            daThongTinNhanVien dTNV = new daThongTinNhanVien();

            dNV.NV.IDNhanVien = ucNV1.IDNhanVien;
            dNV.NV.HoDem = ucNV1.HoDem;
            dNV.NV.Ten = ucNV1.Ten;
            dNV.NV.TenNhanVien = ucNV1.TenNhanVien;
            if(ucNV1.NgaySinh>DateTime.Now.AddYears(-18))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Nhân viên này chưa đủ tuổi lao động",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatNhanVien.ClientID
                });
                return;
            }
            dNV.NV.NgaySinh = ucNV1.NgaySinh;
            dNV.NV.GioiTinh = ucNV1.GioiTinh;
            dNV.NV.DienThoaiDiDong = ucNV1.DienThoaiDiDong;
            try
            {
                var mail = new System.Net.Mail.MailAddress(ucNV1.Email);
            }
            catch
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Địa chỉ Email không đúng",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatNhanVien.ClientID
                });
                return;
            }
            dNV.NV.Email = ucNV1.Email;
            dNV.NV.MaNhanVien = ucNV1.MaNhanVien;
            dNV.NV.HoatDong = true;
            dNV.NV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            if(dNV.NV.HoDem=="" || dNV.NV.Ten==""||dNV.NV.Email=="")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải nhập đủ thông tin",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING"),
                    AnimEl = this.btnCapNhatNhanVien.ClientID
                });

                return;
            }
            dTNV.TTNV.IDNhanVien = dNV.ThemSua();
            dTNV.TTNV.IDChucDanh = ucNV1.IDChucDanh;
            dTNV.TTNV.IDChucVu = ucNV1.IDChucVu;
            dTNV.TTNV.IDPhuTrach = ucNV1.IDPhuTrach;
            dTNV.TTNV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dTNV.TTNV.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);
            dTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTNV.TTNV.TenNhanVien = dNV.NV.TenNhanVien;
            dTNV.TTNV.MoTaCongViec = ucNV1.MoTaCongViec;
            dTNV.TTNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            if (dTNV.TTNV.IDPhongBan < 0)
            {
                dTNV.TTNV.IDPhongBan = 0 - dTNV.TTNV.IDPhongBan;
            }
            else
            {
                dTNV.TTNV.IDDonVi = int.Parse(slbPhongBan.SelectedItem.Value);
                dTNV.TTNV.IDPhongBan = 0;
            }
            dTNV.ThemSua();

            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Hoàn thành",
                Message = "Đã cập nhật thông tin nhân viên "+dNV.NV.TenNhanVien+" thành công",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "INFO"),
                AnimEl = this.btnCapNhatNhanVien.ClientID
            });

            ucNV1.KhoiTao();
        }

        protected void btnCapNhatCDV_Click(object sender, DirectEventArgs e)
        {
            daThongTinNhanVien dTTNV = new daThongTinNhanVien();
            dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTTNV.TTNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();
            dTTNV.TTNV.IDNhanVien = ucCDV1.IDNhanVien;
            dTTNV.TTNV.IDDonVi = ucCDV1.IDDonViMoi;
            dTTNV.TTNV.IDPhongBan = ucCDV1.IDPhongBanMoi;
            dTTNV.ChuyenDonVi();
            stoNhanVien.Reload();
            ucCDV1.KhoiTao();
            wChuyenDonVi.Hide();
            X.Msg.Alert("","Đã chuyển đơn vị làm việc cho lao động xong!").Show();
        }
        #endregion

        #region Su kien menu
        protected void mnuitemThongTin_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            ucNV1.IDNhanVien = Guid.Empty;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    ucNV1.IDNhanVien = Guid.Parse(row["IDNhanVien"].ToString());
                    ucNV1.HoDem = row["HoDem"].ToString();
                    ucNV1.Ten = row["Ten"].ToString();
                    ucNV1.Email = row["Email"].ToString();
                    ucNV1.DienThoaiDiDong = row["DienThoaiDiDong"].ToString();
                    ucNV1.NgaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                    ucNV1.GioiTinh =bool.Parse(row["GioiTinh"].ToString());
                    ucNV1.IDChucDanh =int.Parse(row["IDChucDanh"].ToString());
                    ucNV1.IDChucVu =int.Parse(row["IDChucVu"].ToString());
                    ucNV1.IDPhuTrach = int.Parse(row["IDPhuTrach"].ToString());
                    ucNV1.MoTaCongViec = row["MoTaCongViec"].ToString();
                    ucNV1.MaNhanVien = row["MaNhanVien"].ToString();
                }
                catch
                {
                    ucNV1.IDNhanVien = Guid.Empty;
                }
            }
            if(ucNV1.IDNhanVien==Guid.Empty)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải chọn một nhân viên trước khi xem hoặc sửa",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                wNhanVien.Show();
            }
        }

        protected void mnuitemNhanVienXoa_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            string _TenNV = "";
            ucNV1.IDNhanVien = Guid.Empty;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    ucNV1.IDNhanVien = Guid.Parse(row["IDNhanVien"].ToString());
                    _TenNV = row["TenNhanVien"].ToString();
                }
                catch
                {
                    ucNV1.IDNhanVien = Guid.Empty;
                }
            }
            if (ucNV1.IDNhanVien == Guid.Empty)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải chọn một nhân viên trước khi xóa",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                X.MessageBox.Confirm("Xóa nhân viên", "Anh chị có chắc chắn muốn XÓA nhân viên "+_TenNV+" này không?", new MessageBoxButtonsConfig
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
            daThongTinNhanVien dTNV = new daThongTinNhanVien();
            dTNV.TTNV.IDDonVi = int.Parse(slbDonVi.SelectedItem.Value);
            dTNV.TTNV.IDPhongBan = int.Parse(slbPhongBan.SelectedItem.Value);
            if (dTNV.TTNV.IDPhongBan<0)
            {
                dTNV.TTNV.IDPhongBan = 0 - dTNV.TTNV.IDPhongBan;
            }
            else
            {
                dTNV.TTNV.IDDonVi = dTNV.TTNV.IDPhongBan;
                dTNV.TTNV.IDPhongBan = 0;
            }
            dTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
            dTNV.TTNV.IDNhanVien = ucNV1.IDNhanVien;
            dTNV.Xoa();
            stoNhanVien.Reload();
            ucNV1.IDNhanVien = Guid.Empty;

            X.Msg.Show(new MessageBoxConfig
            {
                Title = "Hoàn thành",
                Message = "Đã XÓA nhân viên thành công",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "ERROR")
            });
        }

        [DirectMethod]
        public void DoNo()
        {
            ucNV1.IDNhanVien = Guid.Empty;
        }

        protected void mnuitmChuyenDonVi_Click(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            ucNV1.IDNhanVien = Guid.Empty;
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    ucCDV1.IDNhanVien = Guid.Parse(row["IDNhanVien"].ToString());
                    ucCDV1.TenNhanVien = row["TenNhanVien"].ToString();
                    ucCDV1.NgaySinh = DateTime.Parse(row["NgaySinh"].ToString()).ToString("dd/MM/yyyy");                    
                }
                catch
                {
                    ucCDV1.IDNhanVien = Guid.Empty;
                }
            }
            if (ucCDV1.IDNhanVien == Guid.Empty)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải chọn một nhân viên trước khi Chuyển đơn vị làm việc",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                dTTNV.TTNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dTTNV.TTNV.Nam = int.Parse(slbNam.SelectedItem.Value);
                dTTNV.TTNV.IDNhanVien = ucCDV1.IDNhanVien;
                dTTNV.ThongTinTen();
                ucCDV1.DonViCu = dTTNV.TTNVTen.DonVi;
                ucCDV1.PhongBanCu = dTTNV.TTNVTen.PhongBan;
                wChuyenDonVi.Show();
            }
        }

        protected void mnuitmQuanLyTruyNhap_Click(object sender, DirectEventArgs e)
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
                    IDNhanVienTruyNhap = Guid.Parse(row["IDNhanVien"].ToString());                    
                }
                catch
                {
                    IDNhanVienTruyNhap = Guid.Empty;
                }
            }
            if (IDNhanVienTruyNhap == Guid.Empty)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải chọn một nhân viên trước khi cập nhật quyền truy nhập!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                Ext.Net.Window csTruyNhap;
                csTruyNhap = TaoCuaSo("Quản lý truy nhập", daPhien.LayDiaChiURL("/NguoiDung/frmQuanTriNguoiDung.aspx?IDNhanVienTruyNhap="+IDNhanVienTruyNhap.ToString()));
                this.form1.Controls.Add(csTruyNhap);
                csTruyNhap.Render();
            }
        }
        #endregion

        #region Chon de danh gia luon
        protected void DanhGiaNhanVien_DBClick(object sender, DirectEventArgs e)
        {
            string json = e.ExtraParams["Values"];
            if (json == "")
            {
                return;
            }
            Dictionary<string, string>[] companies = JSON.Deserialize<Dictionary<string, string>[]>(json);
            string _IDNVCDG = "";
            foreach (Dictionary<string, string> row in companies)
            {
                try
                {
                    _IDNVCDG = row["IDNhanVien"].ToString();
                    wDuLieuDanhGia.Title ="Nhân viên: " + row["TenNhanVien"].ToString(); ;
                }
                catch
                {
                    _IDNVCDG = "";
                }
            }
            if (_IDNVCDG == "")
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị phải chọn một nhân viên trước khi Đánh giá",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });
            }
            else
            {
                pCVC.Loader.Url = "/KPI/frmNhiemVuChinhCaNhan.aspx?T=" + slbThang.SelectedItem.Value + "&N=" + slbNam.SelectedItem.Value + "&L=" + _IDNVCDG;
                pCVC.LoadContent();

                pMTPB.Loader.Url = "/KPI/frmPhanBoMucTieuMotCaNhan.aspx?T=" + slbThang.SelectedItem.Value + "&N=" + slbNam.SelectedItem.Value + "&L=" + _IDNVCDG;
                pMTPB.LoadContent();

                pKQDG.Loader.Url = "/KetQuaDanhGia/frmBangCaNhan.aspx?T=" + slbThang.SelectedItem.Value + "&N=" + slbNam.SelectedItem.Value + "&NhanVien=" + _IDNVCDG;
                pKQDG.LoadContent();

                wDuLieuDanhGia.Show();
            }
        }
        #endregion
    }
}