<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationForm.aspx.cs" Inherits="Lab2.ValidationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fifteen</title>
    <link href="ValidationStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panel_field" runat="server">
            <asp:Label ID="lbl_title" Text="Registration Form" runat="server" />
            <asp:TextBox ID="txt_username" Text="UserName" runat="server" CssClass="Elements"></asp:TextBox>
            <asp:TextBox ID="txt_age" Text="Age" runat="server" CssClass="Elements"></asp:TextBox>
            <asp:TextBox ID="txt_telephone" Text="Telephone" runat="server" CssClass="Elements"></asp:TextBox>
            <asp:TextBox ID="txt_email" Text="Email" runat="server" CssClass="Elements"></asp:TextBox>
            <asp:TextBox ID="txt_password" Text="Password" runat="server" CssClass="Elements"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfv_username" 
                runat="server" 
                ControlToValidate="txt_username" 
                InitialValue="UserName" 
                ErrorMessage="Name is required">
            </asp:RequiredFieldValidator>
            <asp:CompareValidator 
                ID="cv_age" 
                runat="server" 
                ControlToValidate="txt_age" 
                type="Integer"
                operator="GreaterThanEqual"
                ValueToCompare="18"
                InitialValue="Age" 
                ErrorMessage="Get out of here son">
            </asp:CompareValidator>
            <asp:RangeValidator
                ID="rv_telephone" 
                runat="server" 
                ControlToValidate="txt_telephone" 
                MaximumValue="99999999"
                MinimumValue="10000000" 
                InitialValue="Telephone" 
                ErrorMessage="I smell lies and this is from you">
            </asp:RangeValidator>
            <asp:RegularExpressionValidator
                ID="rev_email" 
                runat="server" 
                ControlToValidate="txt_email" 
                ValidationExpression="\S+@\S+\.\S+\w+"
                InitialValue="Email" 
                ErrorMessage="sorry but you're wrong again">
            </asp:RegularExpressionValidator>
            <asp:CustomValidator 
                ID="cv_password" 
                runat="server" 
                ControlToValidate="txt_password" 
                InitialValue="Password" 
                ErrorMessage="Password must be 8 numbers"
                OnServerValidate="cv_password_SValidate">
            </asp:CustomValidator>
            <asp:Button ID="btn_submit" Text="Submit" runat="server" AutoPostBack="true" OnClick="btn_Click" />
        </asp:Panel>
    </form>
</body>
</html>
