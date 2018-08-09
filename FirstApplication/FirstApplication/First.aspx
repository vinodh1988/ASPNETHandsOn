<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="First.aspx.cs" Inherits="FirstApplication.First" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #GridView1 th ,#GridView1 td{
          width: 175px;
          height: 28px;
          padding: 4px;
          font-size: 20px;
          font-family: 'Agency FB';
          background-color: darkolivegreen;
          color: lightgoldenrodyellow;
        }
        #GridView1 td {
          background-color: lightgreen;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <th>Department Name
                </th>
                <td>
                    
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please fill the name" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name Length  4 to 30 Charectars(only alphabhets) First letter caps" ValidationExpression="^[A-Z][a-zA-Z\s]{4,}$" ControlToValidate="TextBox1"></asp:RegularExpressionValidator>
                </td>
              
            </tr>
            <tr>
                <th>Group</th>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                 <td>
                    
                  </td>
            </tr>
             <tr>
                <th>Support Documents
                </th>
                <td>
                    
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                   
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Add  the file" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Upload file in Doc or Docx Format" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="File Size cannot be more than 300 KB" ControlToValidate="FileUpload1" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </td>
              
            </tr>
            
            <tr>
                <td colspan="2" style="text-align:center">

                    <asp:Button ID="Button2" runat="server" Text="Store Department" OnClick="Button2_Click" />

                    <br />
                    <br />

                </td>
            </tr>
        </table>
        
        <div>
        
            <asp:Label ID="Label2" runat="server" BackColor="Yellow" BorderColor="#FFFF66" ForeColor="#009900" Text="Label"></asp:Label>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Second.aspx">Move to Another page</asp:HyperLink>
            <br />
        
            <br />
            Data in the division </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
            <asp:Button ID="Button1" runat="server" BackColor="#CCFF66" BorderStyle="None" BorderWidth="0px" Text="Perform Event" OnClick="Button1_Click" />
        
        <asp:GridView ID="GridView1" runat="server" Width="728px">
        </asp:GridView>
    </form>
  
</body>
</html>
