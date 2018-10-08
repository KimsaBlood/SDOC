<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Registrar.aspx.cs" Inherits="AdminAnclas_Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <script type="text/javascript" language="javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args) {
            var elem = args.get_postBackElement();
        }

        function EndRequestHandler(sender, args)
        {
            var result = getResult('ContentPlaceHolder1_resultGA');
            if (result == "#msg-1") {
                var modal = $("#msg-1");
                modal.modal();
            } else if (result == "#msg-2") {
                 var modal = $("#msg-2");
                modal.modal();
            } else if (result == "#msg-3") {
                 var modal = $("#msg-3");
                modal.modal();
            }
            $("#divResult").hide(); 
             var result = $("#ContentPlaceHolder1_resultGA").val("");
        }

        function getResult(element) {
            var result = $("#ContentPlaceHolder1_resultGA").val();
            return result;
        }

                /*function BeginRequestHandler(sender, args)
                {
                     var elem = args.get_postBackElement();
                     ActivateAlertDiv('visible', 'AlertDiv', elem.value + ' processing...');
                }
               
                function ActivateAlertDiv(visstring, elem, msg)
                {
                     var adiv = $get(elem);
                     adiv.style.visibility = visstring;
                     adiv.innerHTML = msg;                     
                }*/
    </script>
    <asp:UpdatePanel ID="panelRegistoAnclas" runat="server"> 
         <ContentTemplate>
             <div class="container-fluid">
              <div class="row">
                  <div class="col-md-2"></div>
                    <div class="col-md-10">
                    <h1>¿Qué es un ancla?</h1>
                    <hr />
                    <p> Es todo aquel estímulo que esta asociado y que trae un estado psicológico </p>
                    <p>Como por ejemplo, una canción favorita que al escucharla te hace sentir mejor, una fotografía de tus vacaciones con tus seres queridos que al verla te produce felicidad, un reconocimiento que ganaste y al verlo te hace sentir satisfacción,
                    una frase que al leerla te da motivación.</p>
                    </div>
              </div>
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
                                <asp:FileUpload id="file" runat="server" class="form-control" name="file" visible="false" accept="image/* video/mp4 video/ogg audio/mp3 audio/wav audio/ogg" required="requiered" />
                            </div>
                        </div>
                        <asp:Button runat="server" ID="btnRegistrarF" CssClass="btn btn-info" Text="RegistrarA"  OnClick="Register_Click" Visible="false"/>
                        <asp:Button runat="server" ID="btnRegistrar" CssClass="btn btn-info" Text="Registrar" OnClick="Register_Click"/>
                    </form>
                </div>
                <div class="col-lg-2">
                    <div id="divResult">
                        <asp:TextBox runat="server" ID="resultGA" Text="result"></asp:TextBox>
                    </div>
               </div>
            </div>
        </div>

        <!-- Mensaje Registro éxitoso--->
        <div class="modal fade" id="msg-1">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title">Registro de Ancla</h2>
                    </div>
                    <div class="modal-body" id="registro-body">
                        <p>Se registró el ancla corectamente</p>                           
                    </div>
                    <div class="modal-footer" id="registro-footer">
                        <div id="conectando-footer-error">
                            <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="limpiar()">Continuar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Ancla Registrada anteriormente--->
        <div class="modal fade" id="msg-2">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title">Registro de Ancla</h2>
                    </div>
                    <div class="modal-body" id="msg-2-body">
                        <p>Ancla Registrada anteriormente</p>                           
                    </div>
                    <div class="modal-footer" id="msg-2-footer">
                        <div id="msg-2-footer-error">
                            <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="limpiar()">Continuar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

             <!-- Ancla Registrada anteriormente--->
        <div class="modal fade" id="msg-3">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title">Registro de Ancla</h2>
                    </div>
                    <div class="modal-body" id="msg-3-body">
                        <p>Excede el número de anclas permitidas</p>                           
                    </div>
                    <div class="modal-footer" id="msg-3-footer">
                        <div id="msg-3-footer-error">
                            <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="limpiar()">Continuar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>


         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnRegistrarF"/>
        </Triggers>
    </asp:UpdatePanel>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divResult").hide();
        });

        function limpiar() {
            //alert("funcion limpiar");
            var result = $("#ContentPlaceHolder1_resultGA").val("");
        }
        var result = getResult('ContentPlaceHolder1_resultGA');
        if (result == "msg-1") {
            var modal = $("#msg-1");
            modal.modal();
        } else if (result == "msg-2") {
            var modal = $("#msg-2");
            modal.modal();
        } else if (result == "msg-3") {
            var modal = $("#msg-3");
            modal.modal();
        }
    </script>
</asp:Content>