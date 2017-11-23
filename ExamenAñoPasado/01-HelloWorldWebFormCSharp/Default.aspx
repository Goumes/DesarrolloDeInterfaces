<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblnombre" Text="Nombre: " runat="server"/>
        <asp:Textbox ID="Nombre" runat="server"/>
        <br />

       
        <asp:Button ID="Enviar" name="boton1" text="Enviar" runat="server" OnClick="Enviar_Click"/><br/><br/>

         <asp:label name="lblresultado" ID="labelresultado" Text="" runat="server" /> 
         <br />
         <asp:Label name="lblfelicidad" ID="lblfelicidad" Text=""   runat="server" /><br />

         <asp:button  name="respuesta" ID="si" Text="Si" Visible="false" runat="server"  OnClick="respuesta_Click"/><br />
         <asp:button  name="respuesta" ID="no" Text="No" Visible="false" runat="server" OnClick="respuesta_Click"/><br />
         <asp:Label name="lblrespuesta" ID="lblrespuesta" Text=""   runat="server" />
        <asp:Calendar ID="calendario" runat="server"></asp:Calendar>
        
    </div>
    </form>
</body>
</html>
