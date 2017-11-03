<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGhepKPIvaThamSo.aspx.cs" Inherits="BSCKPI.ThamSo.frmGhepKPIvaThamSo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        var edit = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangKPIvTSX.Edit(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Store runat="server" ID="stoKPIvTS" OnReadData="DanhSachKPIvTS">
            <Model>
                <ext:Model runat="server" IDProperty="STT">
                    <Fields>
                        <ext:ModelField Name="STT" />
                        <ext:ModelField Name="ID" />
                        <ext:ModelField Name="IDKPI" />
                        <ext:ModelField Name="Ma" />
                        <ext:ModelField Name="TenKPI" />
                        <ext:ModelField Name="TenThamSo" />
                        <ext:ModelField Name="NgayApDung" />
                        <ext:ModelField Name="NgayKetThuc" />
                        <ext:ModelField Name="CanTren" />
                        <ext:ModelField Name="CanDuoi" />
                        <ext:ModelField Name="DiemCanTren" />
                        <ext:ModelField Name="DiemCanDuoi" />
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
        
        <ext:GridPanel runat="server" ID="grdKPIvTS" StoreID="stoKPIvTS" MinHeight="400">      
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnThemGhep" Text="Thêm" Icon="Add">
                            <DirectEvents>
                                <Click OnEvent="btnThemGhep_Click" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel>
                <Columns>
                    <ext:Column runat="server" Text="STT" DataIndex="STT" Width="50" Align="Center" />
                    <ext:Column runat="server" Text="Mã" DataIndex="Ma" Width="70" Align="Center" />
                    <ext:Column runat="server" Text="Tên" DataIndex="TenKPI" Width="350" CellWrap="true"/>
                    <ext:Column runat="server" Text="Tham số" DataIndex="TenThamSo" Width="250">
                        <%--<Editor>
                            <ext:SelectBox runat="server" ID="slbChonTS" StoreID="stoTSTDChon" DisplayField="Ten" ValueField="Ten" />
                        </Editor>--%>
                    </ext:Column>
                    <ext:DateColumn runat="server" Text="Ngày áp dụng" DataIndex="NgayApDung" Width="120" Format="dd/MM/yyyy">
                        <%--<Editor>
                            <ext:DateField runat="server" />
                        </Editor>--%>
                    </ext:DateColumn>
                    <ext:DateColumn runat="server" Text="Ngày kết thúc" DataIndex="NgayKetThuc" Width="120" Format="dd/MM/yyyy">
                        <%--<Editor>
                            <ext:DateField runat="server" />
                        </Editor>--%>
                    </ext:DateColumn>
                    <ext:NumberColumn runat="server" Text="Cận dưới" DataIndex="CanDuoi" Format="###,###,###.###" Width="150" Align="Right"/>
                    <ext:NumberColumn runat="server" Text="Cận trên" DataIndex="CanTren" Format="###.###.###,###" Width="150" Align="Right"/>
                    <ext:Column runat="server" Text="Giá trị quá">
                        <Columns>
                            <ext:NumberColumn runat="server" Text="Tối thiểu" DataIndex="DiemCanDuoi" Format="###.###.###,###" Width="150" Align="Right"/>
                            <ext:NumberColumn runat="server" Text="Tối đa" DataIndex="DiemCanTren" Format="###.###.###,###" Width="150" Align="Right"/>
                        </Columns>
                    </ext:Column>         
                    <ext:Column runat="server" Text="" Width="300"/>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CellSelectionModel runat="server" />
            </SelectionModel>
            <%--<Plugins>
                <ext:CellEditing runat="server" ClicksToEdit="1">
                    <Listeners>
                        <Edit Fn="edit" />
                    </Listeners>
                </ext:CellEditing>
            </Plugins>--%>
        </ext:GridPanel>

        <ext:Window runat="server" ID="wKPIvTS" Width="400" Height="260" ButtonAlign="Center" Hidden="true"
            Icon="Connect" TitleAlign="Center" Title="Ghép tham số cho KPI">
            <Items>
                <ext:Panel runat="server" Header="false" Layout="AnchorLayout" Closable="false">
                    <Items>
                        <ext:ComboBox runat="server" ID="slbKPIChon" DisplayField="Ten" ValueField="ID" FieldLabel="KPI"
                            LabelWidth="80" Width="380" MarginSpec="10 0 0 0" QueryMode="Local">
                            <Store>
                                <ext:Store runat="server" ID="stoKPIChon">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:SelectBox runat="server" ID="slbTSChon" DisplayField="Ten" ValueField="ID" FieldLabel="Tham số"
                            LabelWidth="80" Width="380" MarginSpec="10 0 0 0">
                            <Store>
                                <ext:Store runat="server" ID="stoTSTDChon">
                                    <Fields>
                                        <ext:ModelField Name="ID" />
                                        <ext:ModelField Name="Ten" />
                                    </Fields>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                        <ext:DateField runat="server" ID="txtNgayApDung" Format="dd/MM/yyyy" FieldLabel="Từ ngày" LabelWidth="80" Width="380" MarginSpec="10 0 0 0" />
                        <ext:DateField runat="server" ID="txtNgayKetThuc" Format="dd/MM/yyyy" FieldLabel="Đến ngày" LabelWidth="80" Width="380" MarginSpec="10 0 0 0"/>
                    </Items>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatTSTD" Text="Cập nhật" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatTSvKPI_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongTSTD" Icon="Cross" Text="Đóng">
                    <Listeners>
                        <Click Handler="#{wKPIvTS}.hide();#{stoKPIvTS}.reload();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
