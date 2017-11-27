<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGanQuyenChoChucNang.ascx.cs" Inherits="BSCKPI.NguoiDung.UC.ucGanQuyenChoChucNang" %>
<script>
    
</script>
<ext:Panel runat="server">
    <Items>
        <ext:Hidden runat="server" ID="txtIDNhanVienQuyenTN" />
        <ext:Hidden runat="server" ID="txtIDNhomQuyenTN" />
        <ext:FieldContainer runat="server" Layout="HBoxLayout">
            <Items>
                <ext:GridPanel runat="server" ID="grdChucNang" Header="false" MarginSpec="0 0 0 10" MinHeight="300">
                                    <Store>
                                        <ext:Store runat="server" ID="stoChucNang">
                                            <Fields>
                                                <ext:ModelField Name="IDChucNang" />
                                                <ext:ModelField Name="ChucNang" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:Column runat="server" ID="qtnChucNang" Text="Module đối tượng" DataIndex="ChucNang" Width="320" StyleSpec="font-weight:bold;" />
                                        </Columns>
                                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server">
                            <Listeners>
                                <Select Handler="#{stoQuyenTruyNhap}.reload();" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                </ext:GridPanel>
                <ext:GridPanel runat="server" ID="grdQuyenTruyNhap" Header="false" MarginSpec="0 0 0 30" MinHeight="300">
                                    <Store>
                                        <ext:Store runat="server" ID="stoQuyenTruyNhap" OnReadData="DanhSachQuuyenCuaChucNang">
                                            <Fields>
                                                <ext:ModelField Name="IDQuyenTruyNhap" />
                                                <ext:ModelField Name="Chon" />
                                                <ext:ModelField Name="QuyenTruyNhap" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:CheckColumn runat="server" ID="qtnChon" Text="Chọn" DataIndex="Chon" Editable="true" Width="60" StyleSpec="font-weight:bold;"/>
                                            <ext:Column runat="server" ID="qtnQuyenTruyNhap" Text="Quyền truy nhập" DataIndex="QuyenTruyNhap" Width="300" StyleSpec="font-weight:bold;" />
                                        </Columns>
                                    </ColumnModel>
                    <SelectionModel>
                        <ext:CellSelectionModel runat="server" />
                    </SelectionModel>
                    <Plugins>
                        <ext:CellEditing runat="server" ClicksToEdit="1">
                            <Listeners>
                                <Edit Fn="editChonQuyen" />
                            </Listeners>
                        </ext:CellEditing>
                    </Plugins>
                </ext:GridPanel>

            </Items>
        </ext:FieldContainer>
        

                                
    </Items>
</ext:Panel>