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
                        <asp:Button runat="server" OnClick="Start_Click" CssClass="btn btn-info" Text="Comenzar estimulación" />
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
                        <asp:ButtonField  commandname="Select" ControlStyle-CssClass="btn btn-info" Text="Eleigir" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-lg-2"></div>
        </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <h2>Instrucciones</h2>
                <hr />
                <p>Las siguientes instrucciones están basadas en la creación de un ancla del libro de introducción a la PNL J. O’Conor</p>
                <br />
                <h3>Piense en el estado de relajación al que desea llegar.</h3>
                <br />
                <asp:Button CssClass="btn btn-info" Text="Siguiente" runat="server" OnClick="Next1_Click" />
            </asp:View>
            <asp:View ID="View4" runat="server">
                <h2>Instrucciones</h2>
                <hr />
                <br />
                <h3>Busque una situación en la que haya sentido este estado de relajación, elija el que más sea intenso y claro.
                    De no poder encontrar alguno, piense en alguien que usted conozca o en un personaje ficticio de un libro o 
                    película el cual haya llegado a este estado de relajación.</h3>
                <br />
                <asp:Button CssClass="btn btn-info" Text="Siguiente" runat="server" OnClick="Next2_Click1" />
            </asp:View>
            <asp:View ID="View5" runat="server">
                <h2>Instrucciones</h2>
                <hr />
                <br />
                <h3>Asocie la situación con el ancla.<br />
                Piense en la situación que haya elegido en el paso dos, mientras observa su ancla
                </h3>
                <asp:Label runat="server" ID="lblTitle" CssClass="text-center"></asp:Label>
                <br />
                <asp:Label runat="server" ID="lblDescrip" CssClass="text-center"></asp:Label>
                <br />
                <asp:Literal ID="litFile" runat="server"></asp:Literal>
                <br />
                <asp:Button CssClass="btn btn-info" Text="Finalizar" runat="server" OnClick="Finalizar_Click1" />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

