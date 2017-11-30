<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmChuaLogin.aspx.cs" Inherits="BSCKPI.frmChuaLogin" %>

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
            <ext:Panel runat="server" ButtonAlign="Center" Header="false" Layout="FitLayout" Width="540" Height="100">
                <Items>
                    <ext:Label runat="server" Text="Hệ thống chưa xác nhận được bạn. Đề nghị đăng nhập ngay" 
                        StyleSpec="font-size: 18px; font-weight: bold;text-align: center;" Height="50px"/>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnDangNhap" Text="Đăng nhập" Icon="Key" MarginSpec="30 0 0 0" UI="Primary">
                        <DirectEvents>
                            <Click OnEvent="btnDangNhap_Click" />
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
