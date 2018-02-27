<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="E_Cafe.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>E-Cafe</title>
    <script src="jquery-3.3.1.min.js"></script>
    <style>
        #header_page {
            width:100%;
            height:40px;
        }

        #title {
            width:100%;
            text-align:center;
            background-color:chartreuse;
        }
        #admin_button_div {
            width:100%;
            float:right;
        }

        #Admin_Button {
            float:right;
        }

        .panelBox{
            margin-top:10px;
            padding-bottom:10px;
            align-content:center;
            height:auto;
        }

        .textBox {
            display:inline;
            margin-right:20px;
            margin-left:20px;
        }

        .label {
            display:inline;
            margin-right:20px;
            margin-left:20px;
        }

        #deliver_div,#pickup_div {
            float:left;
            width:50%;
            height:150px;
        }

        .first{
            padding:8px;
        }

    </style>
</head>
<body>
    <header id="header_page">
        <h1 id="title">24/7 E-Cafe</h1>
        <div id="admin_button_div">
            <button name="Admin_Button" id="Admin_Button" >Admin</button>
        </div>
    </header>
    
   <form id="form1" runat="server" method="post">
        <div>
            <div id="pickup_div">
                <!--<input type="checkbox" id="pickup_checkbox"/>-->
                <asp:CheckBox ID="PickupCheckBox" runat="server" OnCheckedChanged="Pickup_CheckedChanged" AutoPostBack="true"/>
                <label class="first">Pickup:</label>
                <div class="first">
                    <Label class="first">Name</Label>
                    <!--<input type="text" id="Text4" runat="server"/>-->
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <div class="first">
                    <Label class="first">Contact</Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                   <!-- <input type="text" id="Text5" runat="server"/>-->
                </div>
                <div class="first">
                <Label>Time</Label>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                    <!--<input type="datetime" id="Text6" runat="server"/>-->
                </div>
            </div>
            <div id="deliver_div">
                <!--<input type="checkbox" id="deliver_checkbox"/>-->
                <asp:CheckBox ID="DeliverCheckBox" runat="server" OnCheckedChanged="Deliver_CheckedChanged" AutoPostBack="true"/>
                <label class="first">Deliver:</label>
                <div class="first">
                    <Label class="first">Name</Label>
                    <!--<input id="Text1" type="text" runat="server"/>-->
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
                <div class="first">
                    <Label class="first">Contact</Label>
                    <!--<input id="Text2" type="text" runat="server" />-->
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    
                </div>
                <div class="first">
                    <Label class="first">Address</Label>
                    <!--<input id="Text3" type="text" runat="server"/>-->
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

    <div id="menu" style="float:left;">
        <asp:Panel ID="Panel1" runat="server" Height="200px" CssClass="panelBox">
        </asp:Panel>
    </div>
    <div id="checkout" style="width:100%; float:left">
        <!--<button id="checkout_button">Checkout</button>-->
        <asp:Button type="submit" id="checkout_button1" Text="Checkout" runat="server" OnClick="checkout_button1_Click"/>
    </div>
    </form>
    <script>
         $(document).ready(function () {
         $('.number').keyup(function () {
                        this.value = this.value.replace(/[^0-9\.]/g, '');
              });
         });
    </script>
</body>
</html>
