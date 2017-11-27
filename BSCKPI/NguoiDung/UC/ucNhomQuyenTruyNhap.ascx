<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNhomQuyenTruyNhap.ascx.cs" Inherits="BSCKPI.NguoiDung.UC.ucNhomQuyenTruyNhap" %>
<ext:Panel runat="server">
    <Items>
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:FieldContainer runat="server" Layout="VBoxLayout">
                    <Items>
                        <ext:Hidden ID="txtIDNhom" runat="server" />
                        <ext:TextField runat="server" ID="txtTen" FieldLabel="Tên nhóm" Width="260" MarginSpec="10 0 0 10"/>
                        <ext:TextArea runat="server" ID="txtGhiChuNhom" FieldLabel="Ghi chú" Width="260" MarginSpec="10 0 0 10"/>
                        <ext:NumberField runat="server" ID="txtThuTuNhom" FieldLabel="STT" MarginSpec="10 0 0 10"/>
                    </Items>
                </ext:FieldContainer>
            </Items>
        </ext:FieldContainer>
    </Items>
</ext:Panel>