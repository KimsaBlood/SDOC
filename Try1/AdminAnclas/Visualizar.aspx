<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Visualizar.aspx.cs" Inherits="AdminAnclas_Visualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <h2>Anclas activas</h2>
                <hr />
                <asp:GridView ID="gvAnclas" CssClass="table-hover table" AutoGenerateColumns="false" runat="server" Width="100%">
                    <Columns>
                        <asp:ButtonField HeaderText="idAncla" DataTextField="idAncla" Visible="false" />
                        <asp:ButtonField HeaderText="Título/Nombre" DataTextField="title" />
                        <asp:ButtonField HeaderText="Descripcion" DataTextField="descrip" />
                        <asp:ButtonField HeaderText="Tipo de Ancla" DataTextField="tipoAncla" />
                        <asp:TemplateField HeaderText="Archivo">  
                        <ItemTemplate>  
                               <<%#Eval("rutaFile")%>>
                            
                        </ItemTemplate>  
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>

