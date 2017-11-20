<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChuyenDonVi.ascx.cs" Inherits="BSCKPI.MoHinhToChuc.UC.ucChuyenDonVi" %>
<ext:Panel ID="Panel1" runat="server" 
    BodyPadding="5" Layout="AnchorLayout">
    <Items>
        <ext:Hidden runat="server" ID="txtIDNhanVien" />
        <ext:Label runat="server" ID="lblTenNhanVien" MarginSpec="10 0 0 10"/>
        <ext:Label runat="server" ID="lblNgaySinh" MarginSpec="10 0 0 10"/>
        <ext:FieldSet runat="server" Title="Đơn vị cũ">
            <Items>
                <ext:Label runat="server" ID="lblDonViCu" MarginSpec="10 0 0 10"/>
                <ext:Label runat="server" ID="lblPhongBanCu" MarginSpec="10 0 0 10"/>
            </Items>
        </ext:FieldSet>
        <ext:FieldSet runat="server" Title="Đơn vị mới">
            <Items>
                <ext:SelectBox runat="server" ID="slbDonVi" DisplayField="Ten" ValueField="IDDonVi" FieldLabel="Đơn vị"
                    EmptyText="Chọn đơn vị" MarginSpec="10 0 0 10" Width="300">
                            <Listeners>
                                <Select Handler="#{stoPhong}.reload();" />
                            </Listeners>
                            <Store>
                                <ext:Store runat="server" ID="stoDonVi" OnReadData="DanhSachDonVi">
                                    <Fields>
                                        <ext:ModelField Name="IDDonVi" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                <ext:SelectBox runat="server" ID="slbPhongBan" DisplayField="TenPhongBan" ValueField="IDPhongBan" FieldLabel="Phòng ban"
                    EmptyText="Chọn Phòng ban" MarginSpec="10 0 0 10" Width="300">                                
                                <Store>
                                    <ext:Store runat="server" ID="stoPhong" OnReadData="DanhSachPhongBan">
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