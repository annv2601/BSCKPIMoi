﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmNhiemVuChinh.aspx.cs" Inherits="BSCKPI.KPI.frmNhiemVuChinh" %>
<%@ Register src="~/UC/ucNhiemVuTrongTam.ascx" tagname="NV" tagprefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../resource/css/main.css" />
    <script type="text/javascript">
        var editC = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangNVTTX.EditC(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
        <ext:Hidden runat="server" ID="txtIDNV" />
        <ext:Menu runat="server" ID="mnuNVTT">
            <Items>
                <ext:MenuItem runat="server" ID="mnuitmXoa" Text="Xóa Công việc được phân công" Icon="Delete">
                    <DirectEvents>
                        <Click OnEvent="mnuitmXoa_Click">
                            <ExtraParams>
                                <ext:Parameter
                                    Name="Values"
                                    Value="#{grdNV}.getRowsValues({ selectedOnly : true })"
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>                    
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Hidden runat="server" ID="txtNhapNVC" />
        <ext:GridPanel runat="server" ID="grdNV" ContextMenuID="mnuNVTT"
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
                        <ext:SelectBox runat="server" ID="slbThang" Width="120"
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="True">
                            <ListConfig MaxHeight="500" />
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
                        <ext:SelectBox runat="server" ID="slbNam" QueryMode="Local" TypeAhead="true" Width="120"
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
                        <ext:SelectBox runat="server" ID="slbDonVi" DisplayField="Ten" ValueField="IDDonVi" EmptyText="Chọn đơn vị" MarginSpec="0 0 0 10" Width="300">
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
                    <ext:ComboBox runat="server" ID="slbPhongBan" DisplayField="Ten" ValueField="ID" EmptyText="Chọn Phòng ban, đơn vị dưới" MarginSpec="0 0 0 10" Width="300" QueryMode="Local">
                                <Listeners>
                                    <Select Handler="#{stoNV}.reload();" />
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
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn runat="server" Text="STT" Align="Center" Width="60" />
                    <ext:Column runat="server" Text="Tên nhân viên" DataIndex="TenNhanVien" Width="200" />
                    <ext:Column runat="server" Text="Mã công việc" DataIndex="Ma" Width="80" Align="Center" />
                    <ext:Column runat="server" Text="Tên công việc" DataIndex="TenCongViec" Width="400" CellWrap="true"/>
                    <ext:Column runat="server" Text="Tần suất đo" DataIndex="TanSuatDo" Width="120" Align="Center"/>
                    <ext:Column runat="server" Text="Đơn vị tính" DataIndex="DonViTinh" Width="120" Align="Center"/>
                    <ext:Column runat="server" Text="Xu hướng" DataIndex="XuHuongYeuCau" Width="120" Align="Center"/>
                    <ext:NumberColumn runat="server" Text="Mục tiêu" DataIndex="MucTieu" Width="150" Align="Right" />
                    <ext:CheckColumn runat="server" Text="Chuyển đánh giá tiếp tháng sau" DataIndex="DanhGiaTiepThangSau" Editable="true" />
                    <ext:Column runat="server" Text="Trạng thái" DataIndex="TrangThai" Width="120" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel runat="server" >
                    <DirectEvents>
                        <Select OnEvent="grdNV_Select">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{grdNV}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Select>
                    </DirectEvents>
                </ext:CellSelectionModel>
            </SelectionModel>
            <Plugins>
                <ext:FilterHeader runat="server" OnCreateFilterableField="OnCreateFilterableField" />
                <ext:CellEditing runat="server" ClicksToEdit="1">
                    <Listeners>
                        <Edit Fn="editC"></Edit>
                    </Listeners>
                </ext:CellEditing>
            </Plugins>
        </ext:GridPanel>

        <ext:FieldContainer runat="server" Layout="HBoxLayout" ID="fdcNhapLieu" >
         <Items>
            <ext:Panel ID="Panel1" runat="server" Header="false" Border="false" Layout="FitLayout">
                 <Content>
                       <uc1:NV ID="ucNV1" runat="server" Title="" />
                 </Content>
            </ext:Panel>
             <ext:FieldContainer runat="server" Layout="VBoxLayout" >
                <Items>
                    <ext:Button ID="btnCapNhatNV" runat="server" Text="Cập nhật" Icon="Accept" Width="150" Height="50" MarginSpec="50 0 0 0">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatNV_Click" />
                        </DirectEvents>
                    </ext:Button>
                </Items>
            </ext:FieldContainer>
         </Items>
     </ext:FieldContainer>
    </form>
</body>
</html>
