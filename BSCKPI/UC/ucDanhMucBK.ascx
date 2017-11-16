<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDanhMucBK.ascx.cs" Inherits="BSCKPI.UC.ucDanhMucBK" %>
<ext:Panel 
    ID="Panel1" 
    runat="server" 
    BodyPadding="5"
    Layout="AnchorLayout">
    <Items>
        <ext:Hidden runat="server" ID="txtID" />
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:TextField runat="server" ID="txtMa" FieldLabel="Mã" Width="150" LabelWidth="50" MarginSpec="0 0 0 5" />
                <ext:TextField runat="server" ID="txtTenTat" FieldLabel="Tên tắt" Width="200" LabelWidth="50" MarginSpec="0 0 0 30" />
            </Items>
        </ext:FieldContainer>
        <ext:TextField runat="server" ID="txtTen" FieldLabel="Tên" Width="380" LabelWidth="50" MarginSpec="10 0 0 5" />
        <ext:TextArea runat="server" ID="txtGhiChu" FieldLabel="Ghi chú" Width="380" LabelWidth="50" MarginSpec="10 0 0 5" />
        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="10 0 0 0">
            <Items>
                <ext:SelectBox runat="server" ID="slbNhom" FieldLabel="Nhóm" DisplayField="Ten" ValueField="ID"
                    LabelWidth="50" MarginSpec="0 0 0 5" Width="240">
                    <Store>
                        <ext:Store runat="server" ID="stoNhom">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>
                <ext:NumberField runat="server" ID="txtThuTu" FieldLabel="Thứ tự" MarginSpec="0 0 0 10" Width="130" LabelWidth="60" MinValue="1" AllowDecimals="true" DecimalPrecision="1"/>
            </Items>
        </ext:FieldContainer>
    </Items>
</ext:Panel>