<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Monitoreo.aspx.cs" Inherits="Monitoreo_Monitoreo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .metodoI{
          font-size:100px;
        }

        .metodosI{
            font-size:100%;
        }

        a{
            text-decoration: none;
            color:#333;
        }
        .auto-style3 {
            width: 1600px;
            height: 1200px;
        }
    </style> 

    <div class="container-fluid">    
        <section id="estadosAnimo">
            <div class="row">
                <div class="col-md-12">
                    <h2>Selecciona el estado de ánimo</h2>
                    <h4>Selecciona el estado de ánimo que deseas calibrar</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" align="center" style="padding-top: 3rem!important;">
                    <a name="estadoAnimo">
                        <img src="../images/estado_animo1.jpg" style="border-radius: 50%!important;" width="100px" height="100px" class="rounded-circle"/>
                    </a>
                    <div>Estrés</div>
                </div>
                <div class="col-md-6" align="center" style="padding-top: 3rem!important;">
                    <a name ="estadoAnimo">
                        <img src="../images/estado_animo2.jpg" style="border-radius: 50%!important;" width="100px" height="100px" class="rounded-circle"/>
                    </a>
                    <div>Relajación</div>
                    <br />
                </div>
            </div>
        </section>

        <section id="metodosInduccion">
             <div class="row">
                <div class="col-md-12">
                    <h2>Elija el método de inducción</h2>
                    <h4>Selecciona el método de inducción que desea utilizar</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3" id="divPensamiento" name="metodoI" align="center" >
                    <asp:LinkButton ID="pensamiento" runat="server">
                        <div class="col-md-3">
                            <i class="glyphicon glyphicon-cloud" style="font-size:10px; padding-top:70px;"></i>
                        </div>
                        <div class="col-md-3">
                            <i class="glyphicon glyphicon-cloud" style="font-size:30px; padding-top:50px;"></i>
                        </div>
                        <div class="col-md-6">
                            <i class="glyphicon glyphicon-cloud" style="font-size:70px; padding-top:10px;"></i>
                        </div> 
                    </asp:LinkButton>
                </div>
                <div class="col-md-3" name="metodoI" id="divVideo" align="center">
                    <a href="#"><i class="fa fa-file-video-o metodoI" style="font-size:100px;"></i></a>
                </div>
                <div class="col-md-3" name="metodoI" id="divAudio" align="center">
                    <a><i class="fa fa-assistive-listening-systems metodoI"></i></a>
                </div>
                <div class="col-md-3" name="metodoI" id="divImagen" align="center" >
                    <a><i class="fa fa-image metodoI"></i></a>
                </div>
            </div>
            <div class="row">
                <br /> <br />
                <div class="col-md-12" align="center">
                    <button class="btn btn-lg btn-success">Regresar</button>
                </div>
            </div>
        </section>

        <section id="catAudios">
            <div class="row">
                <asp:GridView ID="gvMetAlm" runat="server" AutoGenerateColumns="false" >
                    <Columns>
                        <asp:ButtonField HeaderText="Título/Nombre" DataTextField="title" />
                        <asp:ButtonField HeaderText="Descripcion" DataTextField="descrip" />
                        <asp:TemplateField HeaderText="Sonidos">
                            <ItemTemplate>  
                               <%#Eval("ruta")%>
                            </ItemTemplate>  
                        </asp:TemplateField>  
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-12" align="center">
                    <a class="btn btn-lg btn-success" onclick="metodosI()">Regresar</a>
            </div>
        </section>

        <section id="catVideos">
            <div class="col-md-12" align="center">
                    <a class="btn btn-lg btn-success" onclick="metodosI()">Regresar</a>
            </div>
        </section>

        <section id="catImagenes">
            <div class="col-md-12" align="center">
                    <a class="btn btn-lg btn-success" onclick="metodosI()">Regresar</a>
            </div>
        </section>

        <section id="catPensamientos">
            <div class="col-md-12" align="center">
                    <a class="btn btn-lg btn-success" onclick="metodosI()">Regresar</a>
            </div>
        </section>

        <section id="conexionDiadema">
           <div class="row">
               <div class="col-md-12">
                   <h2>Verifique la conexión de la Diadema</h2>
               </div>
               <div>
                   <a href="#msgConectando" id="conectarD" class="btn" data-toggle="modal" data-backdrop="static" onclick="conectarDiadema()">Conectar</a>
                    <button id ="desconectarD" class="btn">Desconectar</button>  
               </div>
                <div class="col-md-12" align="center">
                    <a class="btn btn-lg btn-success" onclick="metodosI()">Regresar</a>
                </div>
           </div>
        </section>

        <div class="modal fade" id="msgConectando">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title">Realizando la conexión</h2>
                    </div>
                    <div class="modal-body" id="conectando-body">
                         
                    </div>
                    <div class="modal-footer" id="conectando-footer">
                        <div id="conectando-footer-error">
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                            <button type="button" class="btn btn-primary" onclick="conectarDiadema()">Reintentar</button>
                        </div>
                        <div id="conectando-footer-success">
                            <button type="button" class="btn btn-primary" onclick="">Continuar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  
    </div>
         
        <script>
            var seccion1 = $("#estadosAnimo");
            var seccion2 = $("#metodosInduccion");
            var catAudios = $("#catAudios");
            var catImagenes = $("#catImagenes");
            var catVideos = $("#catVideos");
            var catPensamientos = $("#catPensamientos");
            var seccion4 = $("#conexionDiadema");
            $(document).ready(function(){
                //seccion1.hide();
                seccion2.hide();
                catAudios.hide();
                catImagenes.hide();
                catVideos.hide();
                catPensamientos.hide();
                seccion4.hide();

                //Cierra la conexión con la diadema
                $('#desconectarD').click(function (e) {
                    e.preventDefault();
                    desconectarDiadema();
                });

                $('[name=audios_estresantes]').on('pause', function () {
                    //alert('El audio esta en pausa');
                });

                //Detecta cuando el audio termino de reproducirse y cierra la conexión con la diadema
                $('[name=audios_estresantes]').on('ended', function () {
                    desconectarDiadema();   
                });

                //Comienza a guardar las ondas cuando inicia la reproducción del audio
                $('[name=audios_estresantes]').on('play', function () {
                    alert('El audio se esta reproduciendo');
                    $.ajax({
                        type: "POST",
                        url: "../Servicio/ConexionDiadema.svc/GuardarDatos",

                        data: null,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: true,
                        success: function (data) {
                            
                            alert(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            var error = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(error.Message);
                        }
                    });
                });

                $('#divPensamiento').click(function (e) {
                    e.preventDefault();
                    $.ajax({
                        type: "POST",                                              // tipo de request que estamos generando
                        url: 'Monitoreo.aspx/MostrarAudios',                    // URL al que vamos a hacer el pedido
                        data: null,                                                // data es un arreglo JSON que contiene los parámetros que 
                        // van a ser recibidos por la función del servidor
                        contentType: "application/json; charset=utf-8",            // tipo de contenido
                        dataType: "json",                                          // formato de transmición de datos
                        async: true,                                               // si es asincrónico o no
                        success: function (resultado) {                            // función que va a ejecutar si el pedido fue exitoso
                            alert(resultado.toString());
                            var num = resultado.d;
                            alert(num);
                           
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                            var error = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(error.Message);
                        }
                    });
                });
            });

            $('[name=estadoAnimo]').on('click', function () {
                seccion1.hide();
                seccion2.show();
            });

            //Muestra la seleccion de los métodos almacenados
            $('[name=metodoI]').on('click', function () {
                //alert($(this).attr('id'));
                seccion4.show();
                if ($(this).attr('id') == "divPensamiento") {
                    seccion2.hide();
                    catPensamientos.show();
                } else if ($(this).attr('id') == "divVideo") {
                    seccion2.hide();
                    catVideos.show();
                } else if ($(this).attr('id') == "divImagen") {
                    seccion2.hide();
                    catImagenes.show();
                } else if ($(this).attr('id') == "divAudio") {
                    seccion2.hide();
                    catAudios.show();
                }
            });

            function metodosI() {
                catPensamientos.hide();
                catVideos.hide();
                catImagenes.hide();
                catAudios.hide();
                seccion2.show();
            }

            //Función manda llamar al metodo que realiza la conexión con la diadema
            function conectarDiadema() {
                $('#conectando-body').empty();
                $('#conectando-body').append(" <div class='row'><div class='col-md-12' align='center'><i class='fa fa-spinner fa-spin' style= 'font-size:24px;' ></i ></div></div>");
                $('#conectando-footer-success').hide();
                $('#conectando-footer-error').hide();
                $.ajax({
                    type: "POST",
                    url: "../Servicio/ConexionDiadema.svc/ConectarDiadema",
                    data: null,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function (data) {
                        if (data.d == "success") {
                            $('#conectando-body').empty();
                            $('#conectando-body').append("<p>Conexión exitosa</p>");
                            $('#conectando-footer-success').show();
                        } else {
                            $('#conectando-body').empty();
                            $('#conectando-body').append("<p>Conexión fallida, verifique que su dispositivo este encendido</p>");
                            $('#conectando-body').append("<p>Si los errores continuan dar click <a href='#'>aquí</a></p>");
                            $('#conectando-footer-error').show();
                        }

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        alert(error.Message);
                    }
                });
            }

            //Función que manda llamar al método que cierra la conexión con la diadema
            function desconectarDiadema() {
                $.ajax({
                    type: "POST",
                    url: "../Servicio/ConexionDiadema.svc/DesconectarDiadema",
                    data: null,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function (data) {
                        //alert(data.d);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        //alert(error.Message);
                    }
                });
            }
    </script>
        
</asp:Content>



       
        
