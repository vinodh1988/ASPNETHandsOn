<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoToday.aspx.cs" Inherits="FirstApplication.DemoToday" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Parameter Value"></asp:Label>

            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>

        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Process Request" />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Second.aspx">
            Go to Page 2</asp:HyperLink>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
    </form>
    
</body>
</html>
