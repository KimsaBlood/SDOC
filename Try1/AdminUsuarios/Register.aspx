<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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
            background: -prefix-linear-gradient(180deg, rgba(220,220,220,0), white),url("../images/fondo3.jpg");
            background: linear-gradient(0, rgba(200,200,200,0), rgba(250,250,250,1)), url("../images/fondo3.jpg");
background-size:     cover;                      /* <------ */
    background-repeat:   no-repeat;
    background-position: center center; 
    background-attachment: fixed;
        }
        .form-group div input, .form-group label{
            margin-top:5px;
            font-size:12px;
            margin-bottom:5px;
        }.panel{
             margin-top:20%;
             opacity:.9;
             
         }.form-group div input{
              height:30px;
          }.panel-heading{
               font-size:20px;
           }.btn{
                font-size:15px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <form class="form-horizontal" >
            
            <div class="form-group">
                <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4" style="text-align:right">
                    <div class="panel panel-info">
                        <div class="panel-heading" style="text-align:center">Registrarse</div>
                        <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="name">Nombre (s):</label>                
                            <div class="col-sm-7">
                                <asp:TextBox id="name" runat="server" type="text" class="form-control" name="name" required="required" />
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
                                <asp:TextBox id="userName" runat="server" type="text" class="form-control" name="userName" required="required" pattern=".{6,}" title="El nombre de usuario debe contener mas de 6 caracteres"/>
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
                                <asp:FileUpload id="photo" runat="server" class="" name="photo" style="color:transparent" accept="image/*" pattern=".+(\.gif|\.jpg|\.png)" title="El archivo debe tener extensión gif, jpg o png" />
                            </div>
                        </div>
                        <center><asp:Button CssClass="btn btn-info" style="width:150px;" Text="Enviar" OnClick="Regis_Click" runat="server" /></center>
                        </div>
                     

                    </div>
                </div>
                <div class="col-lg-4"></div>
                    </div>
            </div>
            </form>
        </div>
    </form>
</body>
</html>
