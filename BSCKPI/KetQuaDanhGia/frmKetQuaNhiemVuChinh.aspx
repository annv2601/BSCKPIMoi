<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmKetQuaNhiemVuChinh.aspx.cs" Inherits="BSCKPI.KetQuaDanhGia.frmKetQuaNhiemVuChinh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../resource/css/main.css" />
    <script>
        var beforeCellEditHandler = function (e) {
            if (e.record.data.NhapChiTiet > 0 && e.field == "KetQua") {
                //alert("Co chay");
                App.txtIDNhiemVu.setValue(e.record.data.IDNhiemVu);
                App.wKQChiTiet.show();

                CellEditing1.cancelEdit();
                //txtIDNhiemVu.SetValue(e.record.data.IDNhiemVu);
                //App.wKQChiTiet.Show();
            }            
        }

        var EditKQ = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangKQDGNVX.EditKQ(e.record.data.IDNhiemVu, e.field, e.originalValue, e.value, e.record.data);
            }
        }

        var EditCT = function (editor, e) {
            if (e.value != e.originalValue) {
                if (e.value > e.record.data.GiaTriToiDa && e.record.data.GiaTriToiDa!=0)
                {
                    App.stoKQCTiet.rejectChanges();
                    alert('Giá trị nhập vào quá lớn');                    
                }
                else
                {
                    BangKQDGNVCTietX.EditCT(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
                }
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
        <ext:GridPanel runat="server" ID="grdNV"
            Title="Kết quả Nhiệm vụ trọng tâm" TitleAlign="Center" MinHeight="500">
            <Store>
                <ext:Store runat="server" ID="stoNV" OnReadData="DanhSachKQNVTTam">
                    <Model>
                        <ext:Model runat="server" IDProperty="IDNhiemVu">
                            <Fields>
                                <ext:ModelField Name="IDNhiemVu" />
                                <ext:ModelField Name="IDNhanVien" />
                                <ext:ModelField Name="TenNhanVien" />
                                <ext:ModelField Name="TenCongViec" />
                                <ext:ModelField Name="IDTanSuatDo" />
                                <ext:ModelField Name="TanSuatDo" />
                                <ext:ModelField Name="IDDonViTinh" />
                                <ext:ModelField Name="DonViTinh" />
                                <ext:ModelField Name="MucTieu" />
                                <ext:ModelField Name="IDXuHuongYeuCau" />
                                <ext:ModelField Name="XuHuongYeuCau" />
                                <ext:ModelField Name="Ma" />
                                <ext:ModelField Name="KetQua" />
                                <ext:ModelField Name="Diem" />
                                <ext:ModelField Name="TyLeHoanThanh" />
                                <ext:ModelField Name="TyLeTinh" />
                                <ext:ModelField Name="DienGiai" />
                                <ext:ModelField Name="NhapChiTiet" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:SelectBox runat="server" ID="slbThang" 
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="True">
                            <ListConfig MaxHeight="500">                       
                            </ListConfig>
                            <Listeners>
                                <Select Handler="#{stoNV}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoThang">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="Ten" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                        <ext:SelectBox runat="server" ID="slbNam" QueryMode="Local" TypeAhead="true"
                            EmptyText="Năm ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="true">
                            <Listeners>
                                <Select Handler="#{stoNV}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoNam" AutoDataBind="true">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="Ten" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                        <ext:SelectBox runat="server" ID="slbDonVi" DisplayField="Ten" ValueField="IDDonVi" EmptyText="Chọn đơn vị" MarginSpec="0 0 0 10" Width="200">
                            <Listeners>
                                <Select Handler="#{stoPhong}.reload();#{stoNV}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoDonVi">
                                    <Fields>
                                        <ext:ModelField Name="IDDonVi" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                    <ext:SelectBox runat="server" ID="slbPhongBan" DisplayField="TenPhongBan" ValueField="IDPhongBan" EmptyText="Chọn Phòng ban" MarginSpec="0 0 0 10" Width="200">
                                <Listeners>
                                    <Select Handler="#{stoNV}.reload();" />
                                </Listeners>
                                <Store>
                                    <ext:Store runat="server" ID="stoPhong" OnReadData="DanhSachPhongBan">
                                        <Fields>
                                            <ext:ModelField Name="IDPhongBan" />
                                            <ext:ModelField Name="TenPhongBan" />
                                        </Fields>
                                    </ext:Store>
                                </Store>
                            </ext:SelectBox>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="50" />
                    <ext:Column runat="server" Text="Tên nhân viên" DataIndex="TenNhanVien" Width="140" />
                    <ext:Column runat="server" Text="Mã công việc" DataIndex="Ma" Width="80" Align="Center" />
                    <ext:Column runat="server" Text="Tên công việc" DataIndex="TenCongViec" Width="300" CellWrap="true"/>                    
                    <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" Width="100" Align="Center"/>
                    <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau" Width="80" Align="Center"/>
                    <ext:NumberColumn runat="server" Text="Mục tiêu" DataIndex="MucTieu" Width="100" Align="Right" />
                    <ext:NumberColumn runat="server" Text="Kết quả" DataIndex="KetQua" Width="120" Align="Right">
                        <Editor>
                            <ext:NumberField runat="server" AllowDecimals="true" DecimalPrecision="3" />
                        </Editor>
                    </ext:NumberColumn>
                    <ext:NumberColumn runat="server" Text="Tỷ lệ hoàn thành" DataIndex="TyLeHoanThanh" Width="100" Align="Right" />
                    <ext:NumberColumn runat="server" Text="Điểm" DataIndex="Diem" Width="100" Align="Right" />
                    <ext:Column runat="server" Text="Diễn giải" DataIndex="DienGiai" Width="300" >
                        <Editor>
                            <ext:TextField runat="server" />
                        </Editor>
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel runat="server" Mode="Single">                    
                </ext:CellSelectionModel>
            </SelectionModel>
            <Plugins>
                <ext:CellEditing runat="server" ClicksToEdit="1">
                    <Listeners>
                        <Edit Fn="EditKQ" />
                        <BeforeEdit Handler="return beforeCellEditHandler(e);"></BeforeEdit>
                    </Listeners>
                </ext:CellEditing>
            </Plugins>
        </ext:GridPanel>

        <ext:Store runat="server" ID="stoKQCTiet" OnReadData="DanhSachKQNVCTiet">
            <Model>
                <ext:Model runat="server" IDProperty="STT">
                    <Fields>
                        <ext:ModelField Name="STT" />
                        <ext:ModelField Name="IDNhiemVu" />
                        <ext:ModelField Name="TenCongViec" />
                        <ext:ModelField Name="MucTieu" />
                        <ext:ModelField Name="IDDonViTinh" />
                        <ext:ModelField Name="DonViTinh" />
                        <ext:ModelField Name="IDPhuongThuc" />
                        <ext:ModelField Name="PhuongThuc" />
                        <ext:ModelField Name="KetQua" />
                        <ext:ModelField Name="Diem" />
                        <ext:ModelField Name="GiaTriToiThieu" />
                        <ext:ModelField Name="GiaTriToiDa" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>

        <ext:Hidden runat="server" ID="txtIDNhiemVu" />

        <ext:Window runat="server" ID="wKQChiTiet" Icon="ResultsetFirst" TitleAlign="Center" Title="Kết quả nhiệm vụ trọng tâm chi tiêt"
            Hidden="true" Width="620" Height="300" ButtonAlign="Center">
            <Items>
                <ext:GridPanel runat="server" ID="grdKQCTiet" StoreID="stoKQCTiet">
                    <ColumnModel>
                        <Columns>
                            <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="50" />
                            <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" Width="80" />
                            <ext:NumberColumn runat="server" Text="Mục tiêu" DataIndex="MucTieu" Width="80" Format="###,###,###.##" />
                            <ext:Column runat="server" Text="Quy cách" DataIndex="PhuongThuc" Width="200" />
                            <ext:NumberColumn runat="server" Text="Kết quả" DataIndex="KetQua" Width="100" Format="###,###,###.##">
                                <Editor>
                                    <ext:NumberField runat="server" AllowDecimals="true" DecimalPrecision="3" />
                                </Editor>
                            </ext:NumberColumn>
                            <ext:NumberColumn runat="server" Text="Điểm" DataIndex="Diem" Width="100" Format="###,###,###.##">
                                <Editor>
                                    <ext:NumberField runat="server" AllowDecimals="true" DecimalPrecision="3" />
                                </Editor>
                            </ext:NumberColumn>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:CellSelectionModel runat="server" Mode="Single" />
                    </SelectionModel>
                    <Plugins>
                        <ext:CellEditing runat="server" ClicksToEdit="1">
                            <Listeners>
                                <Edit Fn="EditCT" />
                            </Listeners>
                        </ext:CellEditing>
                    </Plugins>
                </ext:GridPanel>
            </Items>
            <Listeners>
                <Show Handler="#{stoKQCTiet}.reload();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" ID="btnDong" Text="Đóng" Icon="Cross">
                    <Listeners>
                        <Click Handler="#{stoNV}.reload();#{wKQChiTiet}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
