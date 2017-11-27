<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmQuanTriNguoiDung.aspx.cs" Inherits="BSCKPI.NguoiDung.frmQuanTriNguoiDung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="resource/css/main.css" />
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Hidden ID="txtIDNhanVienDangNhap" runat="server" />
        <ext:TabPanel runat="server" Layout="FitLayout" ButtonAlign="Center" Cls="tabs">
            <Items>
                <ext:Panel runat="server" Title="Thông tin đăng nhập" Icon="UserKey" Header="false" Height="380" ButtonAlign="Center">
                    <LayoutConfig>
                                <ext:VBoxLayoutConfig Align="Center" />
                            </LayoutConfig>
                    <Items>
                        <ext:FieldContainer runat="server" MarginSpec="30 0 0 0">
                            <Items>
                                <ext:TextField runat="server" ID="txtEmail" FieldLabel="Email" EmptyText="Địa chỉ Email"  LabelStyle="font-weight:bold;" Width="500" MarginSpec="20 0 0 10"
                                    AllowBlank="false"  MsgTarget="Side"/>
                                <ext:TextField runat="server" ID="txtMatKhau" FieldLabel="Mật khẩu" LabelStyle="font-weight:bold;" Width="500" MarginSpec="20 0 0 10" EmptyText="Mật khẩu đăng nhập chương trình" InputType="Password" 
                                    AllowBlank="false"  MsgTarget="Side">
                                    <Listeners>
                                        <ValidityChange Handler="this.next().validate();" />
                                        <Blur Handler="this.next().validate();" />
                                    </Listeners>
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtMatKhauNhacLai" FieldLabel="Nhắc lại Mật khẩu" LabelStyle="font-weight:bold;" Width="500" MarginSpec="20 0 0 10" EmptyText="Mật khẩu nhắc lại phải giống Mật khẩu"  InputType="Password"
                                    AllowBlank="false"  MsgTarget="Side">
                                    <CustomConfig>
                                        <ext:ConfigItem Name="initialPassField" Value="txtMatKhau" Mode="Value" />
                                    </CustomConfig>
                                </ext:TextField>
                            </Items>
                        </ext:FieldContainer>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="btnCapNhatMatKhau" Text="Cập nhật" Icon="Accept" Width="150">
                            <DirectEvents>
                                <Click OnEvent="btnCapNhatMatKhau_Click"></Click>
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:Panel>
                <ext:Panel runat="server" Title="Nhóm truy nhập" Icon="GroupKey" Header="false" Height="380">
                    <Items>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout">
                            <Items>
                                <ext:GridPanel runat="server" ID="grdNhomTruyNhapDaChon" Header="false" MarginSpec="10 0 0 10" MinHeight="300">
                                    <Store>
                                        <ext:Store runat="server" ID="stoNhomTruyNhapDaChon">
                                            <Fields>
                                                <ext:ModelField Name="IDNhomTruyNhap" />
                                                <ext:ModelField Name="NhomTruyNhap" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:Column runat="server" ID="ntnNhomTruyNhap" Text="Nhóm truy nhập" DataIndex="NhomTruyNhap" Width="350" StyleSpec="font-weight:bold;" />
                                        </Columns>
                                    </ColumnModel>
                                </ext:GridPanel>
                                <ext:FieldContainer runat="server" Layout="VBoxLayout" MarginSpec="10 0 0 50">
                                    <LayoutConfig>
                                        <ext:VBoxLayoutConfig Align="Center" />
                                    </LayoutConfig>
                                    <Items>
                                        <ext:Button runat="server" ID="btnThemNhomTruyNhap" Text="Gán" Icon="GroupAdd" MarginSpec="30 0 0 10" Width="120">

                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnLoaiBoNhomTruyNhap" Text="Loại bỏ" Icon="GroupGo" MarginSpec="50 0 0 10" Width="120">

                                        </ext:Button>
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FieldContainer>
                    </Items>
                </ext:Panel>
                <ext:Panel runat="server" Title="Quyền truy nhập" Icon="KeyGo" Header="false" Height="380">
                    <Items>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="10 0 0 10">
                                    <Items>
                                        <ext:Button runat="server" ID="btnThemChucNang" Text="Gán" Icon="ApplicationAdd" MarginSpec="0 0 0 10" Width="120">

                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnLoaiBoChucNang" Text="Loại bỏ" Icon="ApplicationDelete" MarginSpec="0 0 0 10" Width="120">

                                        </ext:Button>
                                    </Items>
                                </ext:FieldContainer>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout">
                            <Items>
                                <ext:GridPanel runat="server" ID="grdChucNang" Header="false" MarginSpec="0 0 0 10" MinHeight="300">
                                    <Store>
                                        <ext:Store runat="server" ID="stoChucNang">
                                            <Fields>
                                                <ext:ModelField Name="IDChucNang" />
                                                <ext:ModelField Name="ChucNang" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:Column runat="server" ID="qtnChucNang" Text="Module đối tượng" DataIndex="ChucNang" Width="320" StyleSpec="font-weight:bold;" />
                                        </Columns>
                                    </ColumnModel>
                                </ext:GridPanel>

                                <ext:GridPanel runat="server" ID="grdQuyenTruyNhap" Header="false" MarginSpec="0 0 0 30" MinHeight="300">
                                    <Store>
                                        <ext:Store runat="server" ID="stoQuyenTruyNhap">
                                            <Fields>
                                                <ext:ModelField Name="IDQuyenTruyNhap" />
                                                <ext:ModelField Name="Chon" />
                                                <ext:ModelField Name="QuyenTruyNhap" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:CheckColumn runat="server" ID="qtnChon" Text="Chọn" DataIndex="Chon" Editable="true" Width="60" StyleSpec="font-weight:bold;"/>
                                            <ext:Column runat="server" ID="qtnQuyenTruyNhap" Text="Quyền truy nhập" DataIndex="QuyenTruyNhap" Width="300" StyleSpec="font-weight:bold;" />
                                        </Columns>
                                    </ColumnModel>
                                </ext:GridPanel>
                            </Items>
                        </ext:FieldContainer>
                    </Items>
                </ext:Panel>
            </Items>
            
        </ext:TabPanel>
    </form>
</body>
</html>
