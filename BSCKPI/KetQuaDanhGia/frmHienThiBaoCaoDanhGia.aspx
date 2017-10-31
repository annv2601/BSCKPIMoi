﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHienThiBaoCaoDanhGia.aspx.cs" Inherits="BSCKPI.KPI.frmHienThiBaoCaoDanhGia" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src='<%=ResolveUrl("~/crystalreportviewers13/js/crviewer/crv.js")%>'type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" 
                HasCrystalLogo="False" HasDrilldownTabs="False" HasDrillUpButton="False" HasSearchButton="False" 
                HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" PrintMode="ActiveX" ToolPanelView="None" DisplayStatusbar="False" />
        </div>
    </form>
</body>
</html>
