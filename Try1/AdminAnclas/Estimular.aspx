<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Estimular.aspx.cs" Inherits="AdminAnclas_Estimular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <h2>¿Qué es estimular un ancla?</h2>
                        <p>Para que un ancla funcione correctamente se necesita estar habituado a ella,
                             lo cual se logrará siguiendo una cantidad de instrucciones y repetiendolas cada cierto tiempo
                            para asi mejorar su funcionamiento.
                        </p>
                        <hr />
                        <p>Al dar clic en el siguiente botón se mostrarán tus anclas activas y deberás elegir la que desees estimular</p>
                        <div class="row">
                            <div class="col-md-6" align="center">
                                <asp:Button runat="server" OnClick="Start_Click" CssClass="btn btn-info" Text="Comenzar estimulación (Leer instrucciones)" />
                            </div>
                            <div class="col-md-6" align="center">
                                <asp:Button runat="server" OnClick="Start_Click_Audio" CssClass="btn btn-info" Text="Comenzar estimulación (Escuchar instrucciones)" />
                            </div>
                            
                        </div>
                    </div>
                    <div class="col-lg-1"></div>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
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
                        <asp:ButtonField  commandname="Select" ControlStyle-CssClass="btn btn-info" Text="Elegir" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-2"></div>
        </div>
            </asp:View>

            <asp:View ID="View3" runat="server">
                <hr />
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <h2>Instrucciones</h2>
                        <hr />
                        <p>Las siguientes instrucciones están basadas en la creación de un ancla del libro de introducción a la PNL J. O’Conor</p>
                            <br /><br />
                        <div align="center" id="btnComezarAudio">
                            <asp:Button CssClass="btn btn-info" Text="Comenzar" runat="server" OnClick="Next1_Click" aling="center"/>
                        </div>
                         
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <h2>Instrucciones</h2>
                        <hr />
                        <h3>Piense en el estado de relajación al que desea llegar.</h3>
                        <div align="center">
                            
                        <asp:Button CssClass="btn btn-info" Text="Siguiente" runat="server" OnClick="Next2_Click1" />
                        </div>
                        
                    </div>
                </div>    
            </asp:View>
            <asp:View ID="View5" runat="server">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <h2>Instrucciones</h2>
                        <hr />
                        <h3>Busque una situación en la que haya sentido este estado de relajación, elija el que más sea intenso y claro.
                        De no poder encontrar alguno, piense en alguien que usted conozca o en un personaje ficticio de un libro o 
                        película el cual haya llegado a este estado de relajación.</h3>
                        <br />
                    </div>
                </div>
                <div align="center">
                    <asp:Button CssClass="btn btn-info" Text="Siguiente" runat="server" OnClick="Next3_Click" />
                </div>
                
            </asp:View>
            <asp:View ID="View6" runat="server">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <h2>Instrucciones</h2>
                    <hr />
                    <h3>Asocie la situación con el ancla.<br />
                    Piense en la situación que haya elegido en el paso dos, mientras observa su ancla
                    </h3>

                    <div align="center">
                        <asp:Label runat="server" ID="lblTitle" CssClass="text-center"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblDescrip" CssClass="text-center"></asp:Label>
                        <br />
                        <asp:Literal ID="litFile" runat="server"></asp:Literal>
                        <br />
                        <asp:Button CssClass="btn btn-info" Text="Finalizar" runat="server" OnClick="Finalizar_Click1" />
                    </div>
                </div>
                
                
            </asp:View>

            <asp:View ID="View7" runat="server">
                <div class="row">
                    <div class="col-md-12" align="center">
                        <!--<asp:Button runat="server" OnClick="Next4_Click" Text="Comenzar" ID="btnComenzar"/>-->
                        <br />
                        <button id="btnComenzar" class="btn">Comenzar</button>
                    </div>
                </div>   
            </asp:View>


            <asp:View ID="View8" runat="server">
                <div class="row">
                    <div class ="col-md-12">
                       <audio controls  src='../Files/sounds/estimular_ancla/AnclaDP3.mp3' type='audio/mp3' id="ADP3" style="display: none;"></audio>            
                    </div>
                </div>
                <div align="center">
                    <h2><asp:Label runat="server" ID="lblTitle2" CssClass="text-center"></asp:Label></h2>
                    <h3><asp:Label runat="server" ID="lblDescrip2" CssClass="text-center"></asp:Label></h3>
                    <asp:Literal ID="litFile2" runat="server"></asp:Literal>
                    <br />
                     <asp:Button CssClass="btn btn-info" Text="Finalizar" runat="server" OnClick="Finalizar_Click1" />
                </div>
                
            </asp:View>
          
        </asp:MultiView>
    </div>

    <div class="modal fade" id="estimulacionAnclaAudio">
        <div class="modal-dialog">

        </div>
   </div>

    <section id="Auidio">
        <div class="row">
                    <div class ="col-md-12" align="center">
                        <!--<audio id="ADP1" controls>
                            <source type="audio/mp3" src='../Files/sounds/estimular_ancla/AnclaDP1.mp3'/>
                            <source type="audio/mp3" src='../Files/sounds/estimular_ancla/AnclaDP1.mp3'/>
                        </audio>-->
                        <audio controls  src='../Files/sounds/estimular_ancla/AnclaDP1.mp3' type='audio/mp3' id="ADP1" style="display: none;"></audio>
                        <audio controls  src='../Files/sounds/estimular_ancla/AnclaDP2.mp3' type='audio/mp3' id="ADP2" style="display: none;"></audio>
                        
                        <button id="btnContinuar" class="btn" style="display:none;"> Click para continuar</button>
                    </div>
        </div>
        <div class="" id="ancla">
            <div class="row">
                <div class="col-md-12" align="center">
                    <asp:Button runat="server" ID="btnAncla" OnClick="Next5_Click" CssClass="btn" Text="Click para continuar"/>
                </div>
            </div>
        </div>
    </section>

    <script>
        $(document).ready(function () {
            var cont = 1;
            $("#Auidio").hide();
            $("#ancla").hide();

            
            var audio = document.getElementById("ADP3");
            if(audio != null)
                audio.play();

            $("#ADP1").on('ended', function () {
                //alert("termino");
                $("#btnContinuar").show();
            });

            $("#ADP2").on('ended', function () {
                //alert("termino");
                //$("#btnContinuar").show();
                 $("#ancla").show();
            });

            $("#btnContinuar").click(function (e) {
                e.preventDefault();
                //alert("siguiente");
                $("#btnContinuar").hide();
                cont = 2;
                var nomAudio = "ADP2";
                var num = "ADP" + cont;
                //alert(num);
                var audio = document.getElementById(num);
                audio.play();
            });

            $("#btnComenzar").click(function (e) {
                e.preventDefault();
                $("#Auidio").show();
                 //$("#ADP1").play();
                var audio = document.getElementById("ADP1");
                audio.play();
                $("#btnComenzar").hide();
            });
            
            $("#prueba").click(function () {
                //alert("dio click en prueb");
                $("#ADP1").play();
            });
            $("#ContentPlaceHolder1_btnComenzar").click(function () {
                $("#ADP1").play();
            });

            $("#btnEstAncAu").click(function () {
                $("#estimulacionAnclaAudio").modal();
            });
        });
    </script>
</asp:Content>

