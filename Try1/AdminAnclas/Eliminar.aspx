<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Eliminar.aspx.cs" Inherits="AdminAnclas_Eliminar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
  <asp:View ID="View1" runat="server">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <h2>Anclas activas</h2>
                <hr />
                <asp:GridView ID="gvAnclas" CssClass="table-hover table" OnSelectedIndexChanged="gvAnclas_SelectedIndexChanged" AutoGenerateColumns="false" runat="server" Width="100%">
                    <Columns>
                        <asp:ButtonField  DataTextField="idAncla" ControlStyle-CssClass="hidden" />
                        <asp:ButtonField HeaderText="Título/Nombre" DataTextField="title" />
                        <asp:ButtonField HeaderText="Descripcion" DataTextField="descrip" />
                        <asp:ButtonField HeaderText="Tipo de Ancla" DataTextField="tipoAncla"/>
                        <asp:ButtonField DataTextField="idTipoAncla" ControlStyle-CssClass="hidden" />
                        <asp:ButtonField DataTextField="rutaFile2" ControlStyle-CssClass="hidden" />
                        <asp:TemplateField HeaderText="Archivo" Visible="false">  
                            <ItemTemplate>  
                               <<%#Eval("rutaFile")%>>  
                            </ItemTemplate>  
                        </asp:TemplateField>
                        <asp:ButtonField  commandname="Select" ControlStyle-CssClass="btn btn-info" Text="Eliminar" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-2"></div>
        </div>
      </asp:View>
            
            </asp:MultiView>
    </div>
</asp:Content>

