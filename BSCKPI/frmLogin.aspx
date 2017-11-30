<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="BSCKPI.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Viewport runat="server">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:FormPanel
                    runat="server"
                    Title="Đăng nhập"
                    Width="480"
                    Frame="true"
                    BodyPadding="13"
                    DefaultAnchor="100%" ButtonAlign="Center">
                    <Items>
                        <ext:TextField
                            runat="server"
                            AllowBlank="false"
                            FieldLabel="Email"
                            Name="user" ID="txtEmail"
                            EmptyText="Nhập địa chỉ Email" />

                        <ext:TextField
                            runat="server"
                            AllowBlank="false"
                            FieldLabel="Mật khẩu"
                            Name="pass" ID="txtMatKhau"
                            EmptyText="Nhập Mật khẩu"
                            InputType="Password" />

                        <ext:Checkbox runat="server" FieldLabel="Nhớ tên đăng nhập" Name="remember" ID="chkNho" LabelWidth="150" Checked="true"/>
                    </Items>
                    <Buttons>                        
                        <ext:Button runat="server" ID="btnDangNhap" Text="Đăng nhập" >
                            <DirectEvents>
                                <Click OnEvent="btnDangNhap_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
