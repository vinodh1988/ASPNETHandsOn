<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Second.aspx.cs" Inherits="FirstApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .box{
            background-color: lightcoral;
            color: darkblue;
            height: 60px;
            padding: 10px;
            margin: 10px;
        }
        .num {
          border-radius: 10px;
          padding: 5px;
          background-color: yellowgreen;
          color: darkred;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            View State
            <asp:Label ID="Label1" runat="server" Text="" CssClass="num"></asp:Label>
        </div>
        <div class="box">
            Session State <asp:Label ID="Label2" runat="server" Text="" CssClass="num"></asp:Label> 
        </div>
        <div class="box">
            Application State <asp:Label ID="Label3" runat="server" Text="" CssClass="num"></asp:Label>
        </div>
    </form>
</body>
</html>
