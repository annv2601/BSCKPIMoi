<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDiemCongTru.aspx.cs" Inherits="BSCKPI.KPI.DiemCongTru.frmDiemCongTru" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var edit = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangDCTX.Edit(e.record.data.ThuTu, e.field, e.originalValue, e.value, e.record.data);
            }
        }        

        var beforeCellEditHandler = function (e) {
            if (App.txtNhapDCT.getValue() == "0") {
                CellEditing1.cancelEdit();
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN"/>
    <form id="form1" runat="server">
        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="10 0 0 0">
            <Items>
                <ext:SelectBox runat="server" ID="slbThang" 
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="True" Width="120">                           
                    <ListConfig MaxHeight="500" />
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
                <ext:SelectBox runat="server" ID="slbKeHoachDG" EmptyText="Kế hoạch đánh giá ..."
                    DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" Width="350" >
                    <%--<Listeners>
                          <Select Handler="#{stoNhanVien}.reload();" />
                    </Listeners>--%>
                    <Store>
                        <ext:Store runat="server" ID="stoKHDG">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>
                <ext:SelectBox runat="server" ID="slbDonVi" DisplayField="Ten" ValueField="IDDonVi" EmptyText="Chọn đơn vị" MarginSpec="0 0 0 10" Width="200">
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
               <ext:ComboBox runat="server" ID="slbPhongBan" DisplayField="Ten" ValueField="ID" EmptyText="Chọn Phòng ban" MarginSpec="0 0 0 10" Width="200">
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
            </Items>
        </ext:FieldContainer>
        <ext:Hidden runat="server" ID="txtNhapDCT" />
        <ext:GridPanel runat="server" ID="grdDCT" Width="1300" MinHeight="460" Layout="FitLayout" MarginSpec="10 0 0 0">
                            <Store>
                                <ext:Store runat="server" ID="stoDCT" OnReadData="DanhSachDCT">
                                    <Model>
                                        <ext:Model runat="server" IDProperty="ThuTu">
                                            <Fields>
                                                <ext:ModelField Name="ThuTu" />
                                                <ext:ModelField Name="Thang" />
                                                <ext:ModelField Name="Nam" />
                                                <ext:ModelField Name="IDNhanVien" />
                                                <ext:ModelField Name="TenNhanVien" />
                                                <ext:ModelField Name="NoiDung" />                                                
                                                <ext:ModelField Name="Diem" />
                                                <ext:ModelField Name="NgayTao" />
                                                <ext:ModelField Name="NgaySua" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
            
                            <ColumnModel runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" ID="RowNumbererColumn1" Text="STT" Width="60" Align="Center"/>
                                    <ext:Column runat="server" ID="Column2" Text="Tên KPI" DataIndex="TenNhanVien" Width="160"/>
                                    <ext:Column runat="server" Text="Nội dung" DataIndex="NoiDung" Width="500" CellWrap="true">
                                        <Editor>
                                            <ext:TextField runat="server" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:NumberColumn runat="server" Text="Điểm" DataIndex="Diem" Width="200" Format="###,###,###.##">
                                        <Editor>
                                            <ext:NumberField runat="server" AllowDecimals="true" DecimalPrecision="2" />
                                        </Editor>
                                    </ext:NumberColumn>
                                    <ext:Column runat="server" Text="" Width="400" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel runat="server" >                    
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>                
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <BeforeEdit Handler="return beforeCellEditHandler(e);"></BeforeEdit>
                                        <Edit Fn="edit" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                        </ext:GridPanel>
        <ext:FieldContainer runat="server" MarginSpec="10 0 0 0">
            <Items>
                <ext:FieldContainer runat="server" Layout="HBoxLayout">
                    <Items>
                        <ext:SelectBox runat="server" ID="slbNhanVien" QueryMode="Local" FieldLabel="Nhân viên"
                                    DisplayField="TenNhanVien" ValueField="IDNhanVien" LabelStyle="font-weight:bold;" Width="350">
                                    <Listeners>
                                        <Select Handler="#{stoDCT}.reload();" />
                                    </Listeners>
                                    <Store>
                                        <ext:Store runat="server" ID="stoNhanVien" OnReadData="DanhSachNhanVienTD">
                                            <Fields>
                                                <ext:ModelField Name="TenNhanVien" />
                                                <ext:ModelField Name="IDNhanVien" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                </ext:SelectBox>
                        <ext:NumberField ID="txtDiem" runat="server" FieldLabel="Điểm" Width="200" LabelWidth="60" LabelStyle="font-weight:bold;" MarginSpec="0 0 0 150"/>
                        <ext:Button runat="server" ID="btnThem" Text="Cập nhật" Icon="Accept" MarginSpec="0 0 0 50" Width="150">
                            <DirectEvents>
                                <Click OnEvent="btnThem_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:FieldContainer>
                <ext:TextArea runat="server" ID="txtNoiDung" FieldLabel="Nội dung" Width="900" LabelStyle="font-weight:bold;"/>
            </Items>
        </ext:FieldContainer>
    </form>
</body>
</html>
