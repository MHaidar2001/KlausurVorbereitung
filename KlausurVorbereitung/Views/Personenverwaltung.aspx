<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personenverwaltung.aspx.cs" Inherits="KlausurVorbereitung.Views.Personenverwaltung" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                Vorname <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
           Geburtsdatum <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Einfügen" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Änderung Speichern" OnClick="Button2_Click" /><br />

            <br />
            <br />
           ID eingeben: <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
           <asp:Button ID="Button3" runat="server" Text="Bearbeiten" OnClick="Button3_Click" /><br />
             ID eingeben;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" Text="Löschen" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell>ID</asp:TableCell>
                    <asp:TableCell>Name</asp:TableCell>
                    <asp:TableCell>Vorname</asp:TableCell>
                    <asp:TableCell>Geburtsdatum</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
