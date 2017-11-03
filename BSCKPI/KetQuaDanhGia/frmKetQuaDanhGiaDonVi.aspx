<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmKetQuaDanhGiaDonVi.aspx.cs" Inherits="BSCKPI.KetQuaDanhGia.frmKetQuaDanhGiaDonVi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        var edit = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangKQDGDVX.Edit(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);

                var grid = App.grdDGDV;
                var pos = grid.getSelectionModel().getCurrentPosition();
                grid.editingPlugin.startEdit(pos.row + 1, pos.column);
            }
        }
    </script>
   
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Store runat="server" ID="stoDGDV" OnReadData="DanhSachKetQuaDanhGiaDonVi">
            <Model>
                <ext:Model runat="server" IDProperty="STT">
                    <Fields>
                        <ext:ModelField Name="STT" />
                        <ext:ModelField Name="IDKPI" />
                        <ext:ModelField Name="Ten" />
                        <ext:ModelField Name="Ma" />
                        <ext:ModelField Name="DonViTinh" />
                        <ext:ModelField Name="TanSuatDo" />
                        <ext:ModelField Name="XuHuongYeuCau" />
                        <ext:ModelField Name="MucTieu" />
                        <ext:ModelField Name="KetQua" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        <ext:GridPanel runat="server" ID="grdDGDV" MinHeight="400" StoreID="stoDGDV">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:SelectBox runat="server" ID="slbThang" DisplayField="Ten" ValueField="ID"
                            EmptyText="Chọn Tháng ..." MarginSpec="0 0 0 10">
                            <Listeners>
                                <Select Handler="#{stoDGDV}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoThang">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                        <ext:SelectBox runat="server" ID="slbNam" DisplayField="Ten" ValueField="ID"
                            EmptyText="Chọn năm ..." MarginSpec="0 0 0 10">
                            <Listeners>
                                <Select Handler="#{stoDGDV}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoNam">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                        <ext:SelectBox runat="server" ID="slbDonVi" DisplayField="Ten" ValueField="IDDonVi" EmptyText="Chọn đơn vị" MarginSpec="0 0 0 10" Width="200">
                            <Listeners>
                                <Select Handler="#{stoDGDV}.reload();" />
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
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:Column runat="server" ID="STT" Text="STT" DataIndex="STT" Align="Center" Width="50" StyleSpec="font-weight:bold;" />
                    <ext:Column runat="server" ID="Column4" Text="Mã" DataIndex="Ma" Align="Center" Width="70" StyleSpec="font-weight:bold;" />
                    <ext:Column runat="server" ID="Ten" Text="Tên" DataIndex="Ten" Width="300" CellWrap="true" StyleSpec="font-weight:bold;" />
                    <ext:Column runat="server" ID="Column1" Text="Đơn vị tính" DataIndex="DonViTinh" Align="Center" StyleSpec="font-weight:bold;"/>
                    <ext:Column runat="server" ID="Column2" Text="Tần suất" DataIndex="TanSuatDo" Align="Center" StyleSpec="font-weight:bold;"/>
                    <ext:Column runat="server" ID="Column3" Text="Xu hướng" DataIndex="XuHuongYeuCau" Align="Center" StyleSpec="font-weight:bold;"/>
                    <ext:NumberColumn runat="server" Text="Mục tiêu" DataIndex="MucTieu" Format="###.###.###,##" Align="Right" Width="200" StyleSpec="font-weight:bold;"/>
                    <ext:NumberColumn runat="server" Text="Kết quả" DataIndex="KetQua" Format="###.###.###,##" Align="Right" Width="200" StyleSpec="font-weight:bold;">
                        <Editor>
                            <ext:NumberField ID="txtKetQua" runat="server" AllowDecimals="true" DecimalPrecision="2" />
                        </Editor>
                    </ext:NumberColumn>
                    <ext:Column runat="server" ID="Column5" Text="" Align="Center" Width="300"/>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel runat="server" />
            </SelectionModel>
            <Plugins>
                <ext:CellEditing runat="server" ClicksToEdit="1">
                    <Listeners>
                        <Edit Fn="edit" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>
        </ext:GridPanel>
    </form>
</body>
</html>
