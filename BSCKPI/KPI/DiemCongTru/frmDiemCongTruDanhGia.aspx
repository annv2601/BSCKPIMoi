<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDiemCongTruDanhGia.aspx.cs" Inherits="BSCKPI.KPI.DiemCongTru.frmDiemCongTruDanhGia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var edit = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangDCTDGX.Edit(e.record.data.ThuTu, e.field, e.originalValue, e.value, e.record.data);
                e.record.data.TongDiemCong = e.record.data.TongDiemKPI + e.value;
            }
        }

        var beforeCellEditHandler = function (e) {
            if (App.txtNhapDCTDG.getValue() == "0") {
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
                <ext:SelectBox runat="server" ID="slbThang" Width="120"
                            EmptyText="Tháng ...." DisplayField="Ten" ValueField="ID" MarginSpec="0 0 0 10" RenderXType="True" >
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
                    <Listeners>
                          <Select Handler="#{stoDCTDG}.reload();" />
                    </Listeners>
                    <Store>
                        <ext:Store runat="server" ID="stoKHDG">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                            </Fields>
                        </ext:Store>
                    </Store>
                </ext:SelectBox>   
                <ext:Button runat="server" ID="btnTinhDiem" Text="Tính và xếp loại" Icon="CalculatorLink" Width="150" UI="Success" MarginSpec="0 0 0 10">
                    <DirectEvents>
                        <Click OnEvent="btnTinhDiem_Click">
                            <EventMask ShowMask="true" Msg="Đang tính toán....." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnIn" Text="In Tổng hợp" Icon="Printer" Width="150" UI="Success" MarginSpec="0 0 0 10">
                    <DirectEvents>
                        <Click OnEvent="btnIn_Click">
                            <EventMask ShowMask="true" Msg="....." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Items>
        </ext:FieldContainer>
        <ext:FieldContainer runat="server" Layout="HBoxLayout" MarginSpec="10 0 0 0">
            <Items>
                <ext:SelectBox runat="server" ID="slbDonVi" DisplayField="Ten" ValueField="IDDonVi" EmptyText="Chọn đơn vị" MarginSpec="0 0 0 10" Width="300">
                            <Listeners>
                                <Select Handler="#{stoPhong}.reload();#{stoDCTDG}.reload();" />
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
                <ext:SelectBox runat="server" ID="slbPhongBan" DisplayField="TenPhongBan" ValueField="IDPhongBan" EmptyText="Chọn Phòng ban" MarginSpec="0 0 0 10" Width="200">
                                <Listeners>
                                    <Select Handler="#{stoDCTDG}.reload();" />
                                </Listeners>
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
        </ext:FieldContainer>
        <ext:Hidden runat="server" ID="txtNhapDCTDG" />
        <ext:GridPanel runat="server" ID="grdDCTDG" Width="1300" MinHeight="500" Layout="FitLayout" MarginSpec="10 0 0 0">
                            <Store>
                                <ext:Store runat="server" ID="stoDCTDG" OnReadData="DanhSachDCTDG">
                                    <Model>
                                        <ext:Model runat="server" IDProperty="ThuTu">
                                            <Fields>
                                                <ext:ModelField Name="ThuTu" />
                                                <ext:ModelField Name="IDNhanVien" />
                                                <ext:ModelField Name="TenNhanVien" />
                                                <ext:ModelField Name="TongDiemKPI" />                                                
                                                <ext:ModelField Name="Diem" />
                                                <ext:ModelField Name="TongDiemCong" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
            
                            <ColumnModel runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" ID="RowNumbererColumn1" Text="STT" Width="60" Align="Center"/>
                                    <ext:Column runat="server" ID="Column2" Text="Tên nhân viên" DataIndex="TenNhanVien" Width="250"/>
                                   <ext:NumberColumn runat="server" Text="Tổng Điểm KPI" DataIndex="TongDiemKPI" Width="200" Format="###,###,###.##" Align="Right"/>
                                    <ext:NumberColumn runat="server" Text="Điểm cộng, trừ" DataIndex="Diem" Width="200" Format="###,###,###.##" Align="Right">
                                        <Editor>
                                            <ext:NumberField runat="server" AllowDecimals="true" DecimalPrecision="2" />
                                        </Editor>
                                    </ext:NumberColumn>
                                    <ext:NumberColumn runat="server" Text="Tổng Điểm" DataIndex="TongDiemCong" Width="200" Format="###,###,###.##" Align="Right"/>
                                    <ext:Column runat="server" Text="" Width="600" />
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
    </form>
</body>
</html>
