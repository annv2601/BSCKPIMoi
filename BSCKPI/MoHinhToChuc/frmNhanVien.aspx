﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmNhanVien.aspx.cs" Inherits="BSCKPI.MoHinhToChuc.frmNhanVien" %>
<%@ Register Src="~/MoHinhToChuc/UC/ucNhanVien.ascx" TagName="NV" TagPrefix="UC" %>
<%@ Register Src="~/MoHinhToChuc/UC/ucChuyenDonVi.ascx" TagName="DV" TagPrefix="UC" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../resource/css/DataView.css" rel="stylesheet" />
    <%--<link href="../resource/css/main.css" rel="stylesheet" />--%>
    
    
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="10 0 0 0">
            <Items>
                <ext:SelectBox runat="server" ID="slbThang" 
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" Width="120">
                    <ListConfig MaxHeight="500">                       
                   </ListConfig>
                            <Listeners>
                                <Select Handler="#{stoNhanVien}.reload();" />
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
                        <ext:SelectBox runat="server" ID="slbNam" QueryMode="Local" TypeAhead="true" Width="120"
                            EmptyText="Năm ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="true">
                            <Listeners>
                                <Select Handler="#{stoNhanVien}.reload();" />
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
                <ext:SelectBox runat="server" ID="slbDonVi" DisplayField="Ten" ValueField="IDDonVi" EmptyText="Chọn đơn vị quản lý" MarginSpec="0 0 0 10" Width="300">
                            <Listeners>
                                <Select Handler="#{stoPhong}.reload();#{stoNhanVien}.reload();" />                                
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
                <ext:ComboBox runat="server" ID="slbPhongBan" DisplayField="Ten" ValueField="ID" EmptyText="Chọn Phòng ban, đơn vị dưới" MarginSpec="0 0 0 10" Width="300" QueryMode="Local">
                            <Listeners>
                                <Select Handler="#{stoNhanVien}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoPhong" OnReadData="DanhSachPhongBan">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                <ext:Button runat="server" ID="btnThemMoiNhanVien" Text="Thêm nhân viên" Icon="UserAdd" MarginSpec="0 0 0 30">
                    <DirectEvents>
                        <Click OnEvent="btnThemMoiNhanVien_Click" />
                    </DirectEvents>
                </ext:Button>
            </Items>
        </ext:FieldContainer>

        <ext:Menu runat="server" ID="mnuNhanVien">
            <Items>
                <ext:MenuItem runat="server" ID="mnuitemThongTin" Text="Thông tin Nhân viên" Icon="Information">
                    <DirectEvents>
                        <Click OnEvent="mnuitemThongTin_Click">
                            <ExtraParams>
                                <ext:Parameter
                                    Name="Values"
                                    Value="#{vNhanVien}.getRowsValues({ selectedOnly : true })"
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="mnuitmChuyenDonVi" Text="Chuyển đơn vị làm việc" Icon="TransmitEdit">
                    <DirectEvents>
                        <Click OnEvent="mnuitmChuyenDonVi_Click">
                            <ExtraParams>
                                <ext:Parameter
                                    Name="Values"
                                    Value="#{vNhanVien}.getRowsValues({ selectedOnly : true })"
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="mnuitemNhanVienXoa" Text="Xóa Nhân viên nhập sai" Icon="Delete">
                    <DirectEvents>
                        <Click OnEvent="mnuitemNhanVienXoa_Click">
                            <ExtraParams>
                                <ext:Parameter
                                    Name="Values"
                                    Value="#{vNhanVien}.getRowsValues({ selectedOnly : true })"
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuSeparator />
                <ext:MenuItem runat="server" ID="mnuitmQuanLyTruyNhap" Text="Quản lý truy nhập" Icon="DiskMultiple">
                    <DirectEvents>
                        <Click OnEvent="mnuitmQuanLyTruyNhap_Click">
                            <ExtraParams>
                                <ext:Parameter
                                    Name="Values"
                                    Value="#{vNhanVien}.getRowsValues({ selectedOnly : true })"
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
            </Items>
        </ext:Menu>

        <ext:DataView  runat="server" ID="vNhanVien" ContextMenuID="mnuNhanVien"
                    MultiSelect="false" DeferInitialRefresh="false"
                    OverItemCls="x-view-over"
                    TrackOver="true"
                    Cls="img-chooser-view"
                    ItemSelector="div.thumb-wrap"
                    EmptyText="" MarginSpec="20 0 0 0">
                    <Store>
                        <ext:Store ID="stoNhanVien" runat="server" PageSize="30" OnReadData="DanhSachNhanVien">
                            <Model>
                                <ext:Model runat="server">
                                    <Fields>
                                        <ext:ModelField Name="STT" />
                                        <ext:ModelField Name="IDNhanVien" />
                                        <ext:ModelField Name="HoDem" />
                                        <ext:ModelField Name="Ten" />
                                        <ext:ModelField Name="TenNhanVien" />
                                        <ext:ModelField Name="NgaySinh" />
                                        <ext:ModelField Name="GioiTinh" />
                                        <ext:ModelField Name="DienThoaiDiDong" />
                                        <ext:ModelField Name="Email" />
                                        <ext:ModelField Name="MaNhanVien" />
                                        <ext:ModelField Name="HoatDong" />
                                        <ext:ModelField Name="IDChucVu" />
                                        <ext:ModelField Name="ChucVu" />
                                        <ext:ModelField Name="IDChucDanh" />
                                        <ext:ModelField Name="ChucDanh" />
                                        <ext:ModelField Name="IDPhuTrach" />
                                        <ext:ModelField Name="LinhVucPhuTrach" />
                                        <ext:ModelField Name="urlAnh" />
                                        <ext:ModelField Name="MoTaCongViec" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <Tpl runat="server">
                        <Html>
                            <tpl for=".">
                                <div class="thumb-wrap" id="{STT}">
                                    <div class="thumb"><img src="{urlAnh}" title="{TenNhanVien}"></div>
                                    <strong>{TenNhanVien}</strong>
                                    <span>Mã: {MaNhanVien}</span>
                                </div>
                            </tpl>
                        </html>                   
                    </Tpl>
                <DirectEvents>
                    <ItemDblClick OnEvent="DanhGiaNhanVien_DBClick">
                        <ExtraParams>
                                <ext:Parameter
                                    Name="Values"
                                    Value="#{vNhanVien}.getRowsValues({ selectedOnly : true })"
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        <EventMask ShowMask="true" Msg="Đang thực hiện ....." />
                    </ItemDblClick>
                </DirectEvents>
                </ext:DataView>
        
        <ext:Window runat="server" ID="wNhanVien" Width="780" Height="350" ButtonAlign="Center" Hidden="true"
            Icon="User" TitleAlign="Center">
            <Items>
                <ext:Panel runat="server" Header="false" Layout="FitLayout" Closable="false">
                    <Content>
                        <uc:NV ID="ucNV1" runat="server" Title="" />
                    </Content>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatNhanVien" Text="Cập nhật" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatNhanVien_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongCSNV" Icon="Cross" Text="Đóng">
                    <Listeners>
                        <Click Handler="#{wNhanVien}.hide();#{stoNhanVien}.reload();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Window runat="server" ID="wChuyenDonVi" Width="460" Height="400" ButtonAlign="Center" Hidden="true"
            Icon="TransmitEdit" TitleAlign="Center" Title="Chuyển đơn vị làm việc">
            <Items>
                <ext:Panel runat="server" Header="false" Layout="FitLayout" Closable="false">
                    <Content>
                        <uc:DV ID="ucCDV1" runat="server" Title="" />
                    </Content>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatCDV" Text="Cập nhật" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatCDV_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button2" Icon="Cross" Text="Đóng">
                    <Listeners>
                        <Click Handler="#{wChuyenDonVi}.hide();#{stoNhanVien}.reload();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>

        <ext:Window runat="server" ID="wDuLieuDanhGia" Width="1100" Height="620" ButtonAlign="Center" Hidden="true"
            Icon="Bell" TitleAlign="Center" Title="Nhân viên ......">
            <Items>
                <ext:TabPanel runat="server" Layout="FitLayout" ButtonAlign="Center" Cls="tabs">
                <Items>
                    <ext:Panel runat="server" Title="Công việc chính" Header="false" ID="pCVC" Height="580">
                        <Loader runat="server" Url="" ID="lCVC" Mode="Frame">                            
                        </Loader>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="Mục tiêu phân bổ" Header="false" ID="pMTPB" Height="580">
                        <Loader runat="server" Url="" ID="lMTPB" Mode="Frame">                            
                        </Loader>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="Kết quả đánh giá" Header="false" ID="pKQDG" Height="580">
                        <Loader runat="server" Url="" ID="lKQDG" Mode="Frame">                            
                        </Loader>
                    </ext:Panel>
                </Items>
                </ext:TabPanel>
            </Items>            
        </ext:Window>
    </form>
</body>
</html>
