<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucThamSoTinhDiem.ascx.cs" Inherits="BSCKPI.ThamSo.UC.ucThamSoTinhDiem" %>
<ext:Panel ID="Panel1" runat="server" BodyPadding="5" Layout="AnchorLayout">
<LayoutConfig>
    
</LayoutConfig>    
    <Items>
        <ext:Hidden runat="server" ID="txtID" />
        <ext:TextField runat="server" ID="txtTen" FieldLabel="Tên" LabelWidth="70" Width="380"/>
        <ext:SelectBox runat="server" ID="slbXuHuong" DisplayField="Ten" ValueField="ID" FieldLabel="Xu hướng" LabelWidth="70" Width="380">
            <Store>
                <ext:Store runat="server" ID="stoXuHuong">
                    <Fields>
                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="Ten" />
                    </Fields>
                </ext:Store>
            </Store>
        </ext:SelectBox>
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:NumberField runat="server" ID="txtCanDuoi" FieldLabel="Cận dưới" AllowDecimals="true" DecimalPrecision="3" LabelWidth="70" Width="180"/>
                <ext:NumberField runat="server" ID="txtCanTren" FieldLabel="Cận trên" AllowDecimals="true" DecimalPrecision="3" MarginSpec="0 0 0 10" LabelWidth="70" Width="180"/>
            </Items>
        </ext:FieldContainer>
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:NumberField runat="server" ID="txtDiemCanDuoi" FieldLabel="Tối thiểu" AllowDecimals="true" DecimalPrecision="3" LabelWidth="70" Width="180"/>
                <ext:NumberField runat="server" ID="txtDiemCanTren" FieldLabel="Tối đa" AllowDecimals="true" DecimalPrecision="3" MarginSpec="0 0 0 10" LabelWidth="70" Width="180"/>
            </Items>
        </ext:FieldContainer>
        <ext:SelectBox runat="server" ID="slbNhomThamSo" DisplayField="Ten" ValueField="ID" FieldLabel="Nhóm" LabelWidth="70" Width="380">
            <Listeners>
                <Select Handler="#{stoGiaTri}.reload();" />
            </Listeners>
            <Store>
                <ext:Store runat="server" ID="stoNhomTS">
                    <Fields>
                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="Ten" />
                    </Fields>
                </ext:Store>
            </Store>
        </ext:SelectBox>
        <ext:SelectBox runat="server" ID="slbGiaTri" DisplayField="Ten" ValueField="ID" FieldLabel="Giá trị" LabelWidth="70" Width="380">
            <Store>
                <ext:Store runat="server" ID="stoGiaTri" OnReadData="DanhSachGiaTri">
                    <Fields>
                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="Ten" />
                    </Fields>
                </ext:Store>
            </Store>
        </ext:SelectBox>

    </Items>
</ext:Panel>