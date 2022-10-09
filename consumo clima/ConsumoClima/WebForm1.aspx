<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ConsumoClima.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DL_City" runat="server">
                <asp:ListItem>select</asp:ListItem>
                <asp:ListItem Value="2">iabgue</asp:ListItem>
                <asp:ListItem Value="3">bogta</asp:ListItem>
      
    </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:Label ID="lblciudad" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbldireccion" runat="server" Text=""></asp:Label>
              <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>

</html>
