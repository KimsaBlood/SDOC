<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Modificar.aspx.cs" Inherits="Modificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .form-group div input{
              height:30px;
          }.form-group div input, .form-group label{
            margin-top:5px;
            font-size:12px;
            margin-bottom:5px;
        }.btn{
             margin-top:20px;
                font-size:15px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6">
                 <form class="form-horizontal" >
            <h2>Modificar datos</h2>
                     <hr />


                        <div class="form-group">
                            <label class="control-label col-sm-5" for="name">Nombre (s):</label>                
                            <div class="col-sm-7">
                                <asp:TextBox id="name" runat="server" type="text" class="form-control" name="name" required="required"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="lastName">Apellido paterno:</label>                
                            <div class="col-sm-7">
                                <asp:TextBox id="lastName" runat="server" type="text" class="form-control" name="lastName" required="required"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="sureName">Apellido materno:</label>                
                            <div class="col-sm-7">
                                <asp:TextBox id="sureName" runat="server" type="text" class="form-control" name="sureName"  required="required"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="email">Correo electronico:</label>                
                            <div class="col-sm-7">
                                <asp:TextBox id="email" runat="server" TextMode="Email" class="form-control" name="email" required="required" title="El formato debe ser de correo electronico nombre@servidor.dominio" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="userName">Usuario:</label>                
                            <div class="col-sm-7">
                                <asp:Label id="userName" runat="server" type="text" class="form-control" name="userName" required="required"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="userPass">Contraseña:</label>                
                            <div class="col-sm-7">
                                <asp:TextBox id="userPass" runat="server" TextMode="Password" class="form-control" name="userPass" required="required" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" title="La contraseña debe contener 6 caracteres entre los cuales debe haber un numero, una mayuscula y una minuscula"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="userPassConf">Confirmar contraseña:</label>                
                            <div class="col-sm-7">
                                <asp:TextBox id="userPassConf" runat="server" type="Password" class="form-control" name="userPassConf" required="required" title="La contraseña debe contener 6 caracteres entre los cuales debe haber un numero, una mayuscula y una minuscula" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="photo">Foto:</label>                
                            <div class="col-sm-7">
                                <asp:FileUpload id="photo" runat="server" class="" name="photo" style="color:transparent"  />
                            </div>
                        </div>
                        <center><asp:Button CssClass="btn btn-info" style="width:150px;" Text="Modificar" OnClick="Modify_Click" runat="server" /></center>
                        

            </form>
            </div>
            <div class="col-lg-3"></div>
        </div>
    </div>
</asp:Content>

