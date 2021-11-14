<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FifteenForm.aspx.cs" Inherits="Lab2.FifteenForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Game</title>
    <link href="FifteenStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panel_field" runat="server"> 
            <asp:Label ID="lbl_click" runat="server" Text="You haven't pressed anything yet" />
            <asp:Label ID="lbl_rezult" runat="server" />
            <asp:Button ID="btn_00" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_01" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_02" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_03" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_10" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_11" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_12" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_13" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_20" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_21" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_22" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_23" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_30" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_31" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_32" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
            <asp:Button ID="btn_33" runat="server" AutoPostBack="true" OnClick="btn_Click" CssClass="btn"/>
        </asp:Panel>
    </form>
</body>
</html>
