<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhuongThucDanhGia.ascx.cs" Inherits="BSCKPI.ThamSo.UC.ucPhuongThucDanhGia" %>

<ext:Panel 
    ID="Panel1" 
    runat="server" 
    BodyPadding="5"
    Layout="AnchorLayout">
    <Items>
        <ext:Hidden runat="server" ID="txtID" />
        <ext:ComboBox ID="cboDonViTinh"
                            runat="server"
                            FieldLabel="Đơn vị tính"
                            DisplayField="Ten"
                            ValueField="ID"
                            Width="310" QueryMode="Local"
                            TypeAhead="true" MarginSpec="10 0 0 5">
                            <Store>
                                <ext:Store runat="server" ID="stoDonViTinh" AutoDataBind="true">
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
                        </ext:ComboBox>
        <ext:ComboBox ID="cboPhuongThuc"
                            runat="server"
                            FieldLabel="Quy cách"
                            DisplayField="Ten"
                            ValueField="ID"
                            Width="310" QueryMode="Local"
                            TypeAhead="true" MarginSpec="10 0 0 5">
                            <Store>
                                <ext:Store runat="server" ID="stoPhuongThhuc" AutoDataBind="true">
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
                        </ext:ComboBox>
        <ext:DateField runat="server" ID="txtTuNgay" FieldLabel="Từ ngày" Format="dd/MM/yyyy" MarginSpec="10 0 0 5"/>
        <ext:DateField runat="server" ID="txtDenNgay" FieldLabel="Đến ngày" Format="dd/MM/yyyy" MarginSpec="10 0 0 5"/>
        <ext:NumberField runat="server" ID="txtThuTu" FieldLabel="Thứ tự" MarginSpec="10 0 0 5" Width="310" MinValue="1" AllowDecimals="true" DecimalPrecision="1"/>
    </Items>
</ext:Panel>

