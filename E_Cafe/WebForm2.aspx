<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="E_Cafe.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .bill_detail{
            margin-top:20px;
            margin-bottom:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%; height:50px;">
        <div>
            <asp:Label Text="Name: " runat="server"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </div>
        <div>
            <asp:Label Text="Contact Number: " runat="server"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        </div>
        <div>
            <asp:Label ID="Label4" Text="Address or Time Of Pickup: " runat="server"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

        </div>
       
    </div>
        <asp:Table ID="Table1" runat="server" border="1" CssClass="bill_detail">
        </asp:Table>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm Order" />
        
    </form>
</body>
</html>
