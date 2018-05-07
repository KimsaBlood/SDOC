<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Modificar.aspx.cs" Inherits="AdminAnclas_Modificar" %>

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
                        <asp:ButtonField  commandname="Select" ControlStyle-CssClass="btn btn-info" Text="Modificar" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-2"></div>
        </div>
      </asp:View>
            <asp:View ID="Datos" runat="server">
                <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <form class="form-horizontal" >
                    <h2>Modificar mi ancla</h2>
                    <hr />
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="title">Título/Nombre del ancla:</label>                
                        <div class="col-sm-7">
                            <asp:TextBox id="title" runat="server" type="text" class="form-control" name="title" required="required"/>
                        </div>
                     </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5" for="desc">Descripción:</label>                
                        <div class="col-sm-7">
                            <asp:TextBox id="desc" runat="server" type="text" class="form-control" name="desc" required="required"/>
                        </div>
                     </div>
                    
                    <br />
                    <div class="form-group">
                            <asp:Label runat="server" id="lblFile" class="control-label col-sm-5" for="file" Visible="false">Archivo:</asp:Label>                
                            <div class="col-sm-7">
                                <asp:FileUpload id="file" runat="server" class="form-control" name="file" visible="false" />
                            </div>
                        </div>
                    <asp:Button runat="server" CssClass="btn btn-info" Text="Modifcar" OnClick="Modify_Click" />
                    <div class="form-group">
                        <label class="control-label col-sm-5 hidden" for="tipo">Tipo:</label>                
                        <div class="col-sm-7">
                            <asp:TextBox id="tipo" runat="server" type="text" class="form-control hidden" name="tipo" required="required"/>
                        </div>
                     </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5 hidden" for="id">Id:</label>                
                        <div class="col-sm-7">
                            <asp:TextBox id="id" runat="server" type="text" class="form-control hidden" name="id" required="required"/>
                        </div>
                     </div>
                    <div class="form-group">
                        <label class="control-label col-sm-5 hidden" for="path">Path:</label>                
                        <div class="col-sm-7">
                            <asp:TextBox id="path" runat="server" type="text" class="form-control hidden" name="path" required="required"/>
                        </div>
                     </div>
                </form>
            </div>
            <div class="col-lg-2"></div>
        </div>
            </asp:View>
            </asp:MultiView>
    </div>
</asp:Content>

