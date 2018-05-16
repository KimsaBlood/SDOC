<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Monitoreo.aspx.cs" Inherits="Monitoreo_Monitoreo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
         <form>
              <asp:Button ID="iniciar" runat="server" OnClick="Button1_Click1" Text="Conectar" />
              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Desconectar" />
         </form>
          
            <asp:Literal id="literalList" runat="server" />
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          
        
</asp:Content>
       
        
