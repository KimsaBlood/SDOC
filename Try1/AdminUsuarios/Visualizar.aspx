<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Visualizar.aspx.cs" Inherits="Visualizar" %>

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
            }.imgPhoto{
                 max-width:200px;
                 max-height:200px;
                 margin-top:100px;
             }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-lg-3">
                <asp:Image id="userPhoto" runat="server" CssClass="img-thumbnail imgPhoto" ImageUrl="../" />
            </div>
            <div class="col-lg-5">
                 <form class="form-horizontal" >
            <h2>Mis datos</h2>
                     <hr />
                        
                        <div class="form-group">
                            <label class="control-label col-sm-5" for="name">Nombre:</label>
                            <div class="col-sm-7">
                              <p class="form-control-static"><asp:Label id="name" runat="server" type="text" class="" name="name" required="required"/></p>
                            </div>
                          </div>
                         <div class="form-group">
                            <label class="control-label col-sm-5" for="name">Apellido paterno:</label>
                            <div class="col-sm-7">
                              <p class="form-control-static"><asp:Label id="lastName" runat="server" type="text" class="" name="lastName" required="required"/></p>
                            </div>
                          </div>
                <div class="form-group">
                            <label class="control-label col-sm-5" for="name">Apellido materno:</label>
                            <div class="col-sm-7">
                              <p class="form-control-static"><asp:Label id="sureName" runat="server" type="text" class="" name="sureName"  required="required"/></p>
                            </div>
                          </div>
                <div class="form-group">
                            <label class="control-label col-sm-5" for="name">Correo:</label>
                            <div class="col-sm-7">
                              <p class="form-control-static"><asp:Label id="email" runat="server" TextMode="Email" class="" name="email" required="required" /></p>
                            </div>
                          </div>
                <div class="form-group">
                            <label class="control-label col-sm-5" for="name">Usuario:</label>
                            <div class="col-sm-7">
                              <p class="form-control-static"><asp:Label id="userName" runat="server" type="text" class="" name="userName" required="required"/></p>
                            </div>
                          </div> 
                         
                        
                        

            </form>
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>
