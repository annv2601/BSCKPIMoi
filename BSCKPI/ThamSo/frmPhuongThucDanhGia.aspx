<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPhuongThucDanhGia.aspx.cs" Inherits="BSCKPI.ThamSo.frmPhuongThucDanhGia" %>
<%@ Register Src="~/ThamSo/UC/ucPhuongThucDanhGia.ascx" TagName="PT" TagPrefix="UC" %>
<%@ Register Src="~/UC/ucDanhMucBK.ascx" TagName="DM" TagPrefix="UC" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Store runat="server" ID="stoPTDG" OnReadData="DanhSachPTDG">
            <Model>
                <ext:Model runat="server" IDProperty="ID">
                    <Fields>
                        <ext:ModelField Name="STT" />
                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="IDTanSuatDo" />
                        <ext:ModelField Name="TanSuat" />
                        <ext:ModelField Name="IDPhuongThuc" />
                        <ext:ModelField Name="PhuongThuc" />
                        <ext:ModelField Name="TuNgay" />
                        <ext:ModelField Name="DenNgay" />
                        <ext:ModelField Name="ThuTu" />
                        <ext:ModelField Name="GiaTriToiThieu" />
                        <ext:ModelField Name="GiaTriToiDa" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>

        <ext:Menu runat="server" ID="mnuPTDG">
            <Items>
                <ext:MenuItem runat="server" ID="mnuiThongTin" Icon="Information" Text="Thông tin Quy cách">
                    <DirectEvents>
                        <Click OnEvent="mnuiThongTin_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdPTDG}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="mnuiXoa" Icon="Delete" Text="Xóa Quy cách đánh giá">
                    <DirectEvents>
                        <Click OnEvent="mnuiXoa_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdPTDG}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
            </Items>
        </ext:Menu>

        <ext:GridPanel runat="server" ID="grdPTDG" StoreID="stoPTDG" MinHeight="500" ContextMenuID="mnuPTDG">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnThemPTDG" Text="Thêm mới" Icon="Add" Width="150">
                            <DirectEvents>
                                <Click OnEvent="btnThemPTDG_Click" />
                            </DirectEvents>
                        </ext:Button>

                        <ext:Button runat="server" ID="btnThemQuyCach" Text="Thêm mới quy cách" Icon="New" Width="150">
                            <DirectEvents>
                                <Click OnEvent="btnThemQuyCach_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="60" StyleSpec="font-weight: bold;"/>
                    <ext:Column runat="server" Text="Đơn vị tính" DataIndex="TanSuat" Width="100" StyleSpec="font-weight: bold;" Align="Center"/>
                    <ext:Column runat="server" Text="Quy cách" DataIndex="PhuongThuc" Width="250" StyleSpec="font-weight: bold;"/>
                    <ext:DateColumn runat="server" Text="Từ ngày" DataIndex="TuNgay" Width="120" StyleSpec="font-weight: bold;"/>
                    <ext:DateColumn runat="server" Text="Đến ngày" DataIndex="DenNgay" Width="120" StyleSpec="font-weight: bold;"/>
                    <ext:NumberColumn runat="server" Text="Giá trị tối đa" DataIndex="GiaTriToiDa" Width="150" StyleSpec="font-weight: bold;" Align="Right"/>
                    <ext:Column runat="server" Text="STT sắp xếp" DataIndex="ThuTu" Width="" StyleSpec="font-weight: bold;"/>
                    <ext:Column runat="server" Text="" Width="400" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" Mode="Single" />
            </SelectionModel>
        </ext:GridPanel>

        <ext:Window runat="server" ID="wPTDG" Width="340" Height="360" ButtonAlign="Center" Hidden="true"
            Icon="Application" TitleAlign="Center" Title="Quy cách đánh giá">
            <Items>
                <ext:Panel runat="server" Header="false" Layout="FitLayout" Closable="false">
                    <Content>
                        <uc:PT ID="ucPT1" runat="server" Title="" />
                    </Content>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatPTDG" Text="Cập nhật" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatPTDG_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongPTDG" Icon="Cross" Text="Đóng">
                    <Listeners>
                        <Click Handler="#{wPTDG}.hide();#{stoPTDG}.reload();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Window runat="server" ID="wDanhMuc" Width="400" Height="320" ButtonAlign="Center" Hidden="true"
            Icon="Application" TitleAlign="Center" Title="Danh mục Quy cách">
            <Items>
                <ext:Panel runat="server" Header="false" Layout="FitLayout" Closable="false">
                    <Content>
                        <uc:DM ID="ucDM1" runat="server" Title="" />
                    </Content>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatDM" Text="Cập nhật" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatDM_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongDM" Icon="Cross" Text="Đóng">
                    <Listeners>
                        <Click Handler="#{wDanhMuc}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
