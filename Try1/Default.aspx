<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

<!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script><script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.css">
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.0/jquery-confirm.min.js"></script>
<style>
    .jconfirm.jconfirm-material .jconfirm-box{
        border-top-style:solid;
        border-top-color:#5bc0de;
        border-top-width:10px;
}
    body{
        background:url("images/fondo1.jpg");
            background:  url("images/fondo1.jpg");
background-size:     cover;                      /* <------ */
    background-repeat:   no-repeat;
    background-position: center center; 
    background-attachment: fixed;
    }.panel{
         margin-top:30%;
             opacity:.9;
     }
</style>
</head>
<body>
    <form  id="form2" runat="server">
        <div class="container-fluid">
            <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-3 col-xs-1"></div>
            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-10">
                <div class="panel panel-info">
                    <div class="panel-heading">Inicio de sesión</div>
                        <div class="panel-body">
                            <form>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Nombre de usuario" required="required"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtPsw" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña" required="required"></asp:TextBox>
                                </div>
                                <br />
                                <asp:Button ID="btnLogin" runat="server" style="width:120px;" CssClass="btn btn-info btnLogin pull-left" OnClick="btnLogin_Click1" Text="Iniciar sesión"/>
                                
                                
                                    <asp:LinkButton ID="btnRegis" runat="server" style="width:120px;" CssClass="btn btn-success pull-right" OnClick="btnRegis_Click1" Text="Registrarse"/>
                                
                                          

                                   
                            </form>
                        </div> 
                    <form>
                    <div class="panel-footer pForgotten text-center"><asp:LinkButton runat="server" OnClick="btnForgot_Click1">¿Olvido su contraseña o tiene problemas para ingresar?</asp:LinkButton></div>
                </form>
                        </div>
            </div>
        <div class="col-lg-4 col-md-4 col-sm-3 col-xs-1"></div> 
    </div>
        </div>
        </form>
</body>
</html>
