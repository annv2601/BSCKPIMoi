<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChuyenDonVi.ascx.cs" Inherits="BSCKPI.MoHinhToChuc.UC.ucChuyenDonVi" %>

<ext:Panel ID="Panel1" runat="server" 
    BodyPadding="5" Layout="AnchorLayout">
    <Items>
        <ext:Hidden runat="server" ID="txtIDNhanVien" />
        <ext:Label runat="server" ID="lblTenNhanVien" MarginSpec="20 0 0 30" Width="220" StyleSpec="font-size:24px; font-weight:bold;"/>
        <ext:Label runat="server" ID="lblNgaySinh" MarginSpec="20 0 0 50" Width="120" StyleSpec="font-size:20px"/>
        <ext:FieldSet runat="server" Title="Đơn vị cũ" Layout="VBoxLayout" MarginSpec="20 0 0 0" Height="120">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center"></ext:VBoxLayoutConfig>
            </LayoutConfig>
            <Items>
                <ext:Label runat="server" ID="lblDonViCu" StyleSpec="font-size:20px; font-weight:bold;"/>
                <ext:Label runat="server" ID="lblPhongBanCu" MarginSpec="20 0 0 0" StyleSpec="font-size:20px; font-weight:bold;"/>
            </Items>
        </ext:FieldSet>
        <ext:FieldSet runat="server" Title="Đơn vị mới">
            <Items>
                <ext:ComboBox runat="server" ID="slbDonViCDV" DisplayField="Ten" ValueField="ID" EmptyText="Chọn đơn vị" MarginSpec="10 0 0 10" Width="400" QueryMode="Local">
                            <Listeners>
                                <Select Handler="#{stoPhongCDV}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoDonVi">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                <ext:SelectBox runat="server" ID="slbPhongBanCDV" DisplayField="TenPhongBan" ValueField="IDPhongBan"
                    EmptyText="Chọn Phòng ban" MarginSpec="20 0 0 10" Width="400">                                
                                <Store>
                                    <ext:Store runat="server" ID="stoPhongCDV" OnReadData="DanhSachPhongBanCDV">
                                        <Fields>
                                            <ext:ModelField Name="IDPhongBan" />
                                            <ext:ModelField Name="TenPhongBan" />
                                        </Fields>
                                    </ext:Store>
                                </Store>
                            </ext:SelectBox>
            </Items>
        </ext:FieldSet>
    </Items>
</ext:Panel>