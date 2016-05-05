<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
</head>
<body>
<form id="form1" runat="server">
<div><img src="http://localhost:52255/img/title.png"/></div>
<div><b>Convert Webpage with image and table to pdf</b></div><br />
<div>
<asp:GridView ID="gvDetails" AutoGenerateColumns="false" CellPadding="5" runat="server" Width="559px">
<Columns>
<asp:BoundField HeaderText="UserId" DataField="UserId" />
<asp:BoundField HeaderText="UserName" DataField="UserName" />
<asp:BoundField HeaderText="Education" DataField="Education" />
<asp:BoundField HeaderText="Location" DataField="Location" />
</Columns>
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>
</div>
<asp:Button ID="btnPDF" runat="server" Text="Export to PDF" OnClick="btnPDF_Click"/>
</form>
</body>
</html>