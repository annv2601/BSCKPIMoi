<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmThamSoTinhDiem.aspx.cs" Inherits="BSCKPI.ThamSo.frmThamSoTinhDiem" %>
<%@ Register Src="~/ThamSo/UC/ucThamSoTinhDiem.ascx" TagName="TD" TagPrefix="UC" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">    
        <ext:Store runat="server" ID="stoTSTD" OnReadData="DanhSachThamSoTinhDiem">
            <Model>
                <ext:Model runat="server" IDProperty="ID">
                    <Fields>
                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="Ten" />
                        <ext:ModelField Name="IDXuHuongYeuCau" />
                        <ext:ModelField Name="XuHuongYeuCau" />
                        <ext:ModelField Name="CanDuoi" />
                        <ext:ModelField Name="CanTren" />
                        <ext:ModelField Name="DiemCanDuoi" />
                        <ext:ModelField Name="DiemCanTren" />
                        <ext:ModelField Name="IDNhomThamSo" />
                        <ext:ModelField Name="NhomThamSo" />
                        <ext:ModelField Name="IDGiaTri" />
                        <ext:ModelField Name="Giatri" />
                        <ext:ModelField Name="NgayTao" />
                        <ext:ModelField Name="NgaySua" />
                        <ext:ModelField Name="NguoiTao" />
                        <ext:ModelField Name="NguoiSua" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:GridPanel runat="server" ID="grdTSTD" StoreID="stoTSTD" MinHeight="400">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnThemTSTD" Text="Thêm Tham số" Icon="Add" Width="150">
                            <DirectEvents>
                                <Click OnEvent="btnThemTSTD_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="50" />
                    <ext:Column runat="server" Text="Tên" DataIndex="Ten" Width="250"/>
                    <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau" />
                    <ext:NumberColumn runat="server" Text="Cận dưới" DataIndex="CanDuoi" Format="###.###.###,###" Width="150" Align="Right"/>
                    <ext:NumberColumn runat="server" Text="Cận trên" DataIndex="CanTren" Format="###.###.###,###" Width="150" Align="Right"/>
                    <ext:Column runat="server" Text="Giá trị quá">
                        <Columns>
                            <ext:NumberColumn runat="server" Text="Tối thiểu" DataIndex="DiemCanDuoi" Format="###.###.###,###" Width="150" Align="Right"/>
                            <ext:NumberColumn runat="server" Text="Tối đa" DataIndex="DiemCanTren" Format="###.###.###,###" Width="150" Align="Right"/>
                        </Columns>
                    </ext:Column>                    
                    <ext:Column runat="server" Text="Nhóm" DataIndex="NhomThamSo" Width="150"/>
                    <ext:Column runat="server" Text="Giá trị đạt" DataIndex="Giatri" Width="120" />
                    <ext:Column runat="server" Text="" Width="300"/>
                </Columns>
            </ColumnModel>
        </ext:GridPanel>
        <ext:Window runat="server" ID="wThamSoTD" Width="400" Height="350" ButtonAlign="Center" Hidden="true"
            Icon="FlagBy" TitleAlign="Center" Title="Tham số tính điểm">
            <Items>
                <ext:Panel runat="server" Header="false" Layout="FitLayout" Closable="false">
                    <Content>
                        <uc:TD ID="ucTSTD1" runat="server" Title="" />
                    </Content>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatTSTD" Text="Cập nhật" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatTSTD_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongTSTD" Icon="Cross" Text="Đóng">
                    <Listeners>
                        <Click Handler="#{wThamSoTD}.hide();#{stoTSTD}.reload();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
