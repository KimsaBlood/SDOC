<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forgot.aspx.cs" Inherits="Forgot" %>

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
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/all.css" integrity="sha384-+d0P83n9kaQMCwj8F4RJB66tzIwOKmrdb46+porD/OvrJ+37WqIM7UoBtwHO6Nlg" crossorigin="anonymous">
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
         margin-top:50%;
             opacity:.9;
     }
</style>
</head>
<body>
        <div class="container-fluid">
            <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-3 col-xs-1"></div>
            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-10">
                <div class="panel panel-info">
                    <div class="panel-heading">Recuperar contraseña</div>
                        <div class="panel-body">
                            <p>Ingresa el correo asociado a tu cuenta y se te enviará un email de recuperación</p>
                            <form id="form2" runat="server">                    
                                <div class="input-group">
                                    
                                    <span class="input-group-addon"><i class="fa fa-envelope" aria-hidden="true"></i></span>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"  placeholder="Correo electronico"></asp:TextBox>
                                </div> 
                                <br />
                                <center><asp:Button CssClass="btn btn-info" runat="server" OnClick="Send_Click" Text="Enviar" /></center>
                            </form>
                        </div>  
                </div>
            </div>
        <div class="col-lg-4 col-md-4 col-sm-3 col-xs-1"></div> 
    </div>
        </div>
</body>
</html>
