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
        <ext:TabPanel runat="server" Layout="FitLayout" ButtonAlign="Center" Cls="tabs">
            <Items>
                <ext:Panel runat="server" Title="Thông tin đăng nhập" Icon="UserKey" Header="false" Height="420">
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
                </ext:Panel>
                <ext:Panel runat="server" Title="Nhóm truy nhập" Icon="GroupKey" Header="false" Height="420">
                </ext:Panel>
                <ext:Panel runat="server" Title="Quyền truy nhập" Icon="KeyGo" Header="false" Height="420">
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Cập nhật" Icon="Accept" Width="150">

                </ext:Button>
            </Buttons>
        </ext:TabPanel>
        <%--<ext:Panel runat="server" Layout="FitLayout">
            <DockedItems>
                <ext:TabStrip runat="server">
                    <Items>
                        <ext:Tab Text="Thông tin đăng nhập" Icon="UserKey">
                            
                        </ext:Tab>
                        <ext:Tab Text="Nhóm truy nhập" Icon="GroupKey"/>
                        <ext:Tab Text="Quyền truy nhập" Icon="KeyGo"/>
                    </Items>
                </ext:TabStrip>
            </DockedItems>
        </ext:Panel>--%>
    </form>
</body>
</html>
