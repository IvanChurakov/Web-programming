<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panel_field" runat="server"> 
            <asp:Label ID="lbl_rezult" runat="server" Text="I love C#" />
            <asp:Button ID="btn_00" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="btn_01" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="btn_02" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="btn_10" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="btn_11" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="btn_12" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="btn_20" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="btn_21" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="btn_22" runat="server" AutoPostBack="true" OnClick="btn_Click" />
            <asp:Button ID="Button1" runat="server" AutoPostBack="true" OnClick="Restart" Text="Restart"/>
        </asp:Panel>
    </form>
</body>
</html>
