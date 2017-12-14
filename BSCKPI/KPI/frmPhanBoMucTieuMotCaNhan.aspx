<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPhanBoMucTieuMotCaNhan.aspx.cs" Inherits="BSCKPI.KPI.frmPhanBoMucTieuMotCaNhan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .x-grid-body .x-grid-cell-Cost {
            background-color : #f1f2f4;
        }

        .x-grid-row-summary .x-grid-cell-Cost .x-grid-cell-inner{
            background-color : #e1e2e4;
        }

        .task .x-grid-cell-inner {
            padding-left: 15px;
        }

        .x-grid-row-summary .x-grid-cell-inner {
            font-weight: bold;
            font-size: 16px;
            background-color : #f1f2f4;
        }
    </style>
    <script type="text/javascript">
        var editNV = function (editor, e)
        {
            if (e.value !== e.originalValue)
            {
                BangPBMTNVX.EditNV(e.record.data.ThuTu, e.field, e.originalValue, e.value, e.record.data);
            }
        }
        
        var editCT = function (editor, e) {
            if (e.value !== e.originalValue) {
                BangPBMTCTX.EditCT(e.record.data.STT, e.field, e.originalValue, e.value, e.record.data);
            }
        }
        var getSum = function (grid, index) {
            var dataIndex = grid.getColumnModel().getDataIndex(index),
                sum = 0;

            grid.getStore().each(function (record) {
                sum += record.get(dataIndex);
            });

            return sum;
        };

        var beforeCellEditHandler = function (e) {
            if (App.txtNhap.getValue() == "0") {
                CellEditing1.cancelEdit();
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Hidden runat="server" ID="txtIDNhanVien" />
        <ext:Hidden runat="server" ID="txtThang" />
        <ext:Hidden runat="server" ID="txtNam" />
        <ext:Hidden runat="server" ID="txtNhap" />
        <ext:GridPanel runat="server" ID="grdPBChiTieu" Width="1300" MinHeight="500" Layout="FitLayout" Header="false">
                            <Store>
                                <ext:Store runat="server" ID="stoPhanBoCT" OnReadData="DanhSachPBMTNV" GroupField="TenNhom" GroupDir="Default">
                                    <Model>
                                        <ext:Model runat="server" IDProperty="STT">
                                            <Fields>
                                                <ext:ModelField Name="STT" />
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="Ma" />
                                                <ext:ModelField Name="Ten" />
                                                <ext:ModelField Name="TenNhom" />
                                                <ext:ModelField Name="XuHuong" />
                                                <ext:ModelField Name="DonViTinh" />
                                                <ext:ModelField Name="TanSuatDo" />
                                                <ext:ModelField Name="MucTieu" />
                                                <ext:ModelField Name="TrongSo" />
                                                <ext:ModelField Name="TrongSoNhom" />
                                                <ext:ModelField Name="LoaiChiTieu" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
            
                            <ColumnModel runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn runat="server" ID="RowNumbererColumn1" Text="STT" Width="60" Align="Center"/>
                                    <ext:Column runat="server" ID="Column1" Text="Mã" DataIndex="Ma" Width="70"/>
                                    <ext:SummaryColumn
                                        runat="server"
                                        Text="Tên KPI"
                                        DataIndex="Ten"
                                        Hideable="false"
                                        SummaryType="Count"
                                        Width="200">
                                        <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +')' : '(1)');" />
                                    </ext:SummaryColumn>
                                    
                                    <%--<ext:Column runat="server" ID="Column2" Text="Tên KPI" DataIndex="Ten" Width="200"/>--%>
                                    <ext:Column runat="server" ID="Column3" Text="Đơn vị tính" DataIndex="DonViTinh"  Align="Center"/>
                                    <%--<ext:Column runat="server" ID="Column4" Text="Tần suất đo" DataIndex="TanSuatDo"  Align="Center"/>
                                    <ext:Column runat="server" ID="Column5" Text="Xu hướng yêu cầu" DataIndex="XuHuong" Width="130" Align="Center"/>--%>
                                    <ext:NumberColumn runat="server" ID="cTrongSoNhom" Text="Trọng số nhóm" DataIndex="TrongSoNhom" Format="000%"  Align="Center" Width="120"/>
                                    <ext:NumberColumn runat="server" ID="NumberColumn1" Text="Trọng số" DataIndex ="TrongSo" SummaryType="Sum" Width="150" Align="Right">
                                    <Renderer Handler="return Ext.util.Format.number(value,'0,000.0')+'%';"></Renderer>
                                    <SummaryRenderer  Handler="return Ext.util.Format.number(value,'0,000.0')+'%';"></SummaryRenderer >
                                        <Editor>
                                            <ext:NumberField ID="NumberField2" runat="server" AllowDecimals="true" DecimalPrecision="2" />
                                        </Editor>
                                    </ext:NumberColumn>
                                    <ext:NumberColumn runat="server" ID="NumberColumn2" Text="Mục tiêu" DataIndex ="MucTieu" Width="200" Align="Right">
                                    <SummaryRenderer  Handler="return Ext.util.Format.number(value,'000,000,000.00');"></SummaryRenderer >
                                        <%--<Editor>
                                            <ext:NumberField ID="NumberField3" runat="server" AllowDecimals="true" DecimalPrecision="2" />
                                        </Editor>--%>
                                    </ext:NumberColumn>
                                    <ext:Column runat="server" Width="100" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CellSelectionModel runat="server" Mode="Single">                    
                                </ext:CellSelectionModel>
                            </SelectionModel>
                            <Plugins>                
                                <ext:CellEditing runat="server" ClicksToEdit="1">
                                    <Listeners>
                                        <BeforeEdit Handler="return beforeCellEditHandler(e);"></BeforeEdit>
                                        <Edit Fn="editCT" />
                                    </Listeners>
                                </ext:CellEditing>
                            </Plugins>
                            <Features>
                                
                                <ext:GroupingSummary
                                ID="Group1"
                                runat="server"                    
                                GroupHeaderTplString="{name}"
                                HideGroupedHeader="true"
                                EnableGroupingMenu="false" />
                            </Features>
                        </ext:GridPanel>
    </form>
</body>
</html>
