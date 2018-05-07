<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Registrar.aspx.cs" Inherits="AdminAnclas_Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-8">
                <form class="form-horizontal" >
                    <h2>Registrar nueva ancla</h2>
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
                        <label class="control-label col-sm-5" for="tipo">Tipo de ancla:</label>                
                        <div class="col-sm-7">
                            <asp:DropDownList runat="server" ID="tipo" CssClass="form-control" name="tipo" AutoPostBack="true" OnSelectedIndexChanged="tipo_SelectedIndexChanged">

                            </asp:DropDownList>
                        </div>
                     </div>
                    <div class="form-group">
                            <asp:Label runat="server" id="lblFile" class="control-label col-sm-5" for="file" Visible="false">Archivo:</asp:Label>                
                            <div class="col-sm-7">
                                <asp:FileUpload id="file" runat="server" class="form-control" name="file" visible="false" />
                            </div>
                        </div>
                    <asp:Button runat="server" CssClass="btn btn-info" Text="Registrar" OnClick="Register_Click" />
                </form>
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>

