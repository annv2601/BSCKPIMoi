<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmNhiemVuChinhCaNhan.aspx.cs" Inherits="BSCKPI.KPI.frmNhiemVuChinhCaNhan" %>
<%@ Register src="~/UC/ucNhiemVuTrongTam.ascx" tagname="NV" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
        <ext:Hidden runat="server" ID="txtIDNhanVien" />
        <ext:Hidden runat="server" ID="txtThang" />
        <ext:Hidden runat="server" ID="txtNam" />
        <ext:GridPanel runat="server" ID="grdNV" Header="false"
            Title="Nhiệm vụ trọng tâm" TitleAlign="Center" MinHeight="500">
            <Store>
                <ext:Store runat="server" ID="stoNV" OnReadData="DanhSachNVTTam">
                    <Model>
                        <ext:Model runat="server">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="IDNhanVien" />
                                <ext:ModelField Name="TenNhanVien" />
                                <ext:ModelField Name="TenCongViec" />
                                <ext:ModelField Name="IDTanSuatDo" />
                                <ext:ModelField Name="TanSuatDo" />
                                <ext:ModelField Name="IDDonViTinh" />
                                <ext:ModelField Name="DonViTinh" />
                                <ext:ModelField Name="MucTieu" />
                                <ext:ModelField Name="IDTrangThai" />
                                <ext:ModelField Name="TrangThai" />
                                <ext:ModelField Name="IDXuHuongYeuCau" />
                                <ext:ModelField Name="XuHuongYeuCau" />
                                <ext:ModelField Name="Ma" />
                                <ext:ModelField Name="DanhGiaTiepThangSau" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnThemCVC" Text="Thêm mới" Icon="Add">
                            <DirectEvents>
                                <Click OnEvent="btnThemCVC_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="60" StyleSpec="font-weight:bold;"/>
                    <ext:Column runat="server" Text="Mã công việc" DataIndex="Ma" Width="120" Align="Center" StyleSpec="font-weight:bold;"/>
                    <ext:Column runat="server" Text="Tên công việc" DataIndex="TenCongViec" Width="500" CellWrap="true" StyleSpec="font-weight:bold;"/>
                    <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" Width="120" Align="Center" StyleSpec="font-weight:bold;"/>
                    <%--<ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo" Width="120" Align="Center"/>                    
                    <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau" Width="120" Align="Center"/>--%>
                    <ext:NumberColumn runat="server" Text="Mục tiêu" DataIndex="MucTieu" Width="150" Align="Right" StyleSpec="font-weight:bold;"/>
<%--                <ext:CheckColumn runat="server" Text="Chuyển đánh giá tiếp tháng sau" DataIndex="DanhGiaTiepThangSau" Editable="true" />
                    <ext:Column runat="server" Text="Trạng thái" DataIndex="TrangThai" Width="120" />--%>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel runat="server" >
                </ext:CellSelectionModel>
            </SelectionModel>
        </ext:GridPanel>

        <ext:Window runat="server" ID="wCVC" Hidden="true" ButtonAlign="Center" Width="900">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Header="false" Border="false" Layout="FitLayout">
                     <Content>
                           <uc1:NV ID="ucNV1" runat="server" Title="" />
                     </Content>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button ID="btnCapNhatNV" runat="server" Text="Cập nhật" Icon="Accept" Width="150" Height="50" MarginSpec="50 0 0 0">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatNV_Click" />
                        </DirectEvents>
                    </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
