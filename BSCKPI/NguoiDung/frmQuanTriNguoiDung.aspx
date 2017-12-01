<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmQuanTriNguoiDung.aspx.cs" Inherits="BSCKPI.NguoiDung.frmQuanTriNguoiDung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="resource/css/main.css" />
    <script type="text/javascript">
    var editChonQuyen = function (editor, e) {
        if (e.value !== e.originalValue) {
            BangQuyenTNX.EditQTN(e.record.data.IDQuyenTruyNhap, e.field, e.originalValue, e.value, e.record.data);
        }
    }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" Locale="vi-VN" />
    <form id="form1" runat="server">
        <ext:Hidden ID="txtIDNhanVienDangNhap" runat="server" />
        
        <ext:TabPanel runat="server" Layout="FitLayout" ButtonAlign="Center" Cls="tabs">
            <Items>
                <ext:Panel runat="server" Title="Thông tin đăng nhập" Icon="UserKey" Header="false" Height="380" ButtonAlign="Center">
                    <LayoutConfig>
                                <ext:VBoxLayoutConfig Align="Center" />
                            </LayoutConfig>
                    <Items>
                        <ext:FieldContainer runat="server" MarginSpec="30 0 0 0">
                            <Items>
                                <ext:TextField runat="server" ID="txtEmail" FieldLabel="Email" EmptyText="Địa chỉ Email"  LabelStyle="font-weight:bold;" Width="500" MarginSpec="20 0 0 10"
                                    AllowBlank="false"  MsgTarget="Side"/>
                                <ext:TextField runat="server" ID="txtMatKhau" FieldLabel="Mật khẩu" LabelStyle="font-weight:bold;" Width="500" MarginSpec="20 0 0 10" EmptyText="Mật khẩu đăng nhập chương trình" InputType="Password" 
                                    AllowBlank="false"  MsgTarget="Side">
                                    <Listeners>
                                        <ValidityChange Handler="this.next().validate();" />
                                        <Blur Handler="this.next().validate();" />
                                    </Listeners>
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtMatKhauNhacLai" FieldLabel="Nhắc lại Mật khẩu" LabelStyle="font-weight:bold;" Width="500" MarginSpec="20 0 0 10" EmptyText="Mật khẩu nhắc lại phải giống Mật khẩu"  InputType="Password"
                                    AllowBlank="false"  MsgTarget="Side">
                                    <CustomConfig>
                                        <ext:ConfigItem Name="initialPassField" Value="txtMatKhau" Mode="Value" />
                                    </CustomConfig>
                                </ext:TextField>
                                <ext:SelectBox runat="server" ID="slbVaiTro" FieldLabel="Vai trò" LabelStyle="font-weight:bold;" Width="500" MarginSpec="20 0 0 10"
                                    DisplayField="Ten" ValueField="ID">
                                    <Store>
                                        <ext:Store runat="server" ID="stoVaiTro">
                                            <Fields>
                                                <ext:ModelField Name="ID" />
                                                <ext:ModelField Name="Ten" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                </ext:SelectBox>                                
                            </Items>
                        </ext:FieldContainer>
                    </Items>
                    <Buttons>
                        <ext:Button runat="server" ID="btnCapNhatMatKhau" Text="Cập nhật" Icon="Accept" Width="150">
                            <DirectEvents>
                                <Click OnEvent="btnCapNhatMatKhau_Click"></Click>
                            </DirectEvents>
                        </ext:Button>
                    </Buttons>
                </ext:Panel>
                <ext:Panel runat="server" Title="Nhóm truy nhập" Icon="GroupKey" Header="false" Height="380" Visible="false">
                    <Items>
                        <ext:FieldContainer runat="server" Layout="HBoxLayout">
                            <Items>
                                <ext:GridPanel runat="server" ID="grdNhomTruyNhapDaChon" Header="false" MarginSpec="10 0 0 10" MinHeight="300">
                                    <Store>
                                        <ext:Store runat="server" ID="stoNhomTruyNhapDaChon">
                                            <Fields>
                                                <ext:ModelField Name="IDNhomTruyNhap" />
                                                <ext:ModelField Name="NhomTruyNhap" />
                                            </Fields>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel>
                                        <Columns>
                                            <ext:Column runat="server" ID="ntnNhomTruyNhap" Text="Nhóm truy nhập" DataIndex="NhomTruyNhap" Width="350" StyleSpec="font-weight:bold;" />
                                        </Columns>
                                    </ColumnModel>
                                </ext:GridPanel>
                                <ext:FieldContainer runat="server" Layout="VBoxLayout" MarginSpec="10 0 0 50">
                                    <LayoutConfig>
                                        <ext:VBoxLayoutConfig Align="Center" />
                                    </LayoutConfig>
                                    <Items>
                                        <ext:Button runat="server" ID="btnThemNhomTruyNhap" Text="Gán" Icon="GroupAdd" MarginSpec="30 0 0 10" Width="140">

                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnLoaiBoNhomTruyNhap" Text="Loại bỏ" Icon="GroupGo" MarginSpec="50 0 0 10" Width="140">

                                        </ext:Button>

                                        <ext:Button runat="server" ID="btnThemMoiNhomTruyNhap" Text="Thêm mới" Icon="Add" MarginSpec="50 0 0 10" Width="140">

                                        </ext:Button>
                                    </Items>
                                </ext:FieldContainer>
                            </Items>
                        </ext:FieldContainer>
                    </Items>
                </ext:Panel>
                <ext:Panel runat="server" ID="pnlQTN" Title="Quyền truy nhập" Icon="KeyGo" Header="false" Height="380" Layout="HBoxLayout">                    
                    <LayoutConfig>
                                <ext:HBoxLayoutConfig Align="Stretch" />
                            </LayoutConfig>
                    <Items>
                        <ext:GridPanel runat="server" ID="grdQTNChucNang" Header="false" MarginSpec="0 0 0 10" MinHeight="300" Flex="1" AutoScroll="true">                            
                                    <Store>
                                        <ext:Store runat="server" ID="stoQTNChucNang">
                                                    <Model>
                                                        <ext:Model runat="server">
                                                            <Fields>
                                                                <ext:ModelField Name="IDChucNang" />
                                                                <ext:ModelField Name="ChucNang" />
                                                            </Fields>
                                                        </ext:Model>
                                                    </Model>                                            
                                                </ext:Store>
                                    </Store>   
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button runat="server" ID="btnThemChucNang" Text="Gán" Icon="KeyAdd" MarginSpec="0 0 0 0" Width="100">
                                            <DirectEvents>
                                                <Click OnEvent="btnThemChucNang_Click" />
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnLoaiBoChucNang" Text="Loại bỏ" Icon="KeyDelete" MarginSpec="0 0 0 10" Width="100">
                                            <DirectEvents>
                                                <Click OnEvent="btnLoaiBoChucNang_Click">
                                                    <EventMask ShowMask="true" Msg="......" />
                                                    <ExtraParams>
                                                                <ext:Parameter
                                                                    Name="Values"
                                                                    Value="#{grdQTNChucNang}.getRowsValues({ selectedOnly : true })"
                                                                    Mode="Raw"
                                                                    Encode="true" />
                                                            </ExtraParams>
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                                            <ColumnModel runat="server">
                                                <Columns>
                                                    <ext:Column runat="server" ID="cqtnChucNang" Text="Module đối tượng" DataIndex="ChucNang" Width="300" StyleSpec="font-weight:bold;" Flex="1"/>
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel runat="server" Mode="Single">
                                                    <DirectEvents>
                                                        <Select OnEvent="grdQTNChucNang_Chon">
                                                            <ExtraParams>
                                                                <ext:Parameter
                                                                    Name="Values"
                                                                    Value="#{grdQTNChucNang}.getRowsValues({ selectedOnly : true })"
                                                                    Mode="Raw"
                                                                    Encode="true" />
                                                            </ExtraParams>
                                                        </Select>
                                                    </DirectEvents>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>

                                <ext:GridPanel runat="server" ID="grdQTNQuyen" Header="false" MarginSpec="40 0 0 30" MinHeight="300" Flex="1">
                                                            <Store>
                                                                <ext:Store runat="server" ID="stoQTNQuyen" OnReadData="DanhSachQuuyenCuaChucNang">
                                                                    <Model>
                                                                        <ext:Model runat="server" IDProperty="IDQuyenTruyNhap">
                                                                            <Fields>
                                                                                <ext:ModelField Name="IDQuyenTruyNhap" />
                                                                                <ext:ModelField Name="IDChucNang" />
                                                                                <ext:ModelField Name="Chon" />
                                                                                <ext:ModelField Name="QuyenTruyNhap" />
                                                                            </Fields>
                                                                        </ext:Model>
                                                                    </Model>                                                                    
                                                                </ext:Store>
                                                            </Store>
                                                            <ColumnModel>
                                                                <Columns>
                                                                    <ext:CheckColumn runat="server" ID="cqtnChon" Text="..." DataIndex="Chon" Editable="true" Width="40" StyleSpec="font-weight:bold;" Flex="1"/>
                                                                    <ext:Column runat="server" ID="cqtnQuyenTruyNhap" Text="Quyền truy nhập" DataIndex="QuyenTruyNhap" Width="250" StyleSpec="font-weight:bold;" />
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
                </ext:Panel>
            </Items>            
        </ext:TabPanel>

        <ext:Window runat="server" ID="wDSChucNang" Title="Danh sách Module chức năng" TitleAlign="Center" Hidden="true" Width="300" Height="400" ButtonAlign="Center">
            <Items>
                <ext:GridPanel runat="server" ID="grdDSChucNang" Header="false" Height="310" AutoScroll="true">
                    <Store>
                        <ext:Store runat="server" ID="stoDSChucNang">
                            <Fields>
                                <ext:ModelField Name="ID" />
                                <ext:ModelField Name="Ten" />
                            </Fields>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column runat="server" DataIndex="Ten" Width="250" CellWrap="true" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" Mode="Multi" />
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnGanThamChucNang" Text="Thêm ..." Icon="KeyAdd" Width="100">
                    <DirectEvents>
                        <Click OnEvent="btnGanThamChucNang_Click">
                            <ExtraParams>
                                <ext:Parameter
                                    Name="Values"
                                    Value="#{grdDSChucNang}.getRowsValues({ selectedOnly : true })"
                                    Mode="Raw"
                                    Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongDSChucNang" Text="Đóng" Icon="Cross" Width="100">
                    <Listeners>
                        <Click Handler="#{wDSChucNang}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
